using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SingeTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //je part du principe qu'un tour a un nom, une type et une Action a executer qui prendra un certain temp 

            #region init            
            var toursSinge1 = new List<Tour>
            {
                new Tour("Marcher sur les mains pendant 1 secound", TourType.Acrobatie, async () =>
                {
                    await Task.Delay(1000);
                }),
                new Tour("Chante pendant 2 secondes ", TourType.Musique, async () =>
                {
                    await Task.Delay(2000);
                }),
                new Tour("Saute sur un pied pendant 1 seconde", TourType.Acrobatie, async () =>
                {
                    await Task.Delay(1000);
                }),
            };

            var toursSinge2 = new List<Tour>()
            {
                 toursSinge1[0],
                   new Tour("Chante pendant 1 seconde ", TourType.Musique, async () =>
                {
                    await Task.Delay(1000);
                }),
            };

            Spectateur spectateur = new Spectateur("Spectateur");

            Dresseur dresseur1 = new Dresseur(new Singe("Singe 1", toursSinge1));
            Dresseur dresseur2 = new Dresseur(new Singe("Singe 2", toursSinge2));

            #endregion


            //spetacle
            foreach (Dresseur dresseur in new[] { dresseur1, dresseur2 })
            {
                foreach (Tour tour in dresseur.Singe.TourListe)
                {
                    Task t = dresseur.Singe.ExecuterTourAsync(tour);

                    var cancellationTokenSource = new CancellationTokenSource();

                    Task spectateurAction = null;

                    switch (tour.Type)
                    {
                        case TourType.Acrobatie:
                            {
                                spectateurAction = spectateur.ApplauditAsync(cancellationTokenSource.Token);
                                Console.WriteLine($"{spectateur.Nom} applaudit pendant le tour de {tour.Type} \"{tour.Nom}\" du singe {dresseur.Singe.Nom}");
                                break;
                            }
                        case TourType.Musique:
                            {
                                spectateurAction = spectateur.SiffleAsync(cancellationTokenSource.Token);
                                Console.WriteLine($"{spectateur.Nom} siffle pendant le tour de {tour.Type} \"{tour.Nom}\" du singe {dresseur.Singe.Nom}");
                                break;
                            }
                    }
                    
                    t.ContinueWith(p => { cancellationTokenSource.Cancel(); });
                    spectateurAction?.Wait();



                }

            }



        }
    }
}
