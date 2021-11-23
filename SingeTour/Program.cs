using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SingeTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region init
            Spectateur spectateur = new Spectateur("Spectateur");

            List<Tour> toursSinge1 = new List<Tour>()
            {
                new Tour("Tour1", TourType.Acrobatie),
                new Tour("Tour2", TourType.Musique),
                new Tour("Tour3", TourType.Acrobatie)
            };

            List<Tour> toursSinge2 = new List<Tour>()
            {
                new Tour("Marcher sur les mains", TourType.Acrobatie),
                new Tour("Dance", TourType.Musique)
            };

            Dresseur dresseur1 = new Dresseur(new Singe("Singe 1", toursSinge1));
            Dresseur dresseur2 = new Dresseur(new Singe("Singe 2", toursSinge2));

            List<Dresseur> listDresseur = new List<Dresseur>() { dresseur1, dresseur2 };

            #endregion



            foreach (Dresseur dresseur in listDresseur)
            {
                foreach (Tour tour in dresseur.Singe.TourListe)
                {
                    Task t = dresseur.Singe.ExecuterTourAsync(tour);
                    //spectateur.ReagitAuTour(tour, dresseur.Singe);                   
                    Task spectateurAction = null;
                    do
                    {
                        switch (tour.Type)
                        {
                            case TourType.Acrobatie:
                                {
                                    spectateurAction = spectateur.ApplauditAsync();
                                    Console.WriteLine($"{spectateur.Nom} applaudit pendant le tour de {tour.Type} \"{tour.Nom}\" du singe {dresseur.Singe.Nom}");
                                    break;
                                }
                            case TourType.Musique:
                                {
                                    spectateurAction = spectateur.SiffleAsync();
                                    Console.WriteLine($"{spectateur.Nom} siffle pendant le tour de {tour.Type} \"{tour.Nom}\" du singe {dresseur.Singe.Nom}");
                                    break;
                                }
                        }
                        spectateurAction?.Wait();
                    } while (!t.IsCompleted);

                 

                }

            }


        }
    }
}
