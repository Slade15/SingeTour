using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingeTour
{
    internal class Spectateur
    {
        public string Nom { get; private set; }

        public Spectateur(string nom)
        {
            this.Nom = nom;
        }
        public async Task ApplauditAsync()
        {
            System.Console.WriteLine($"Applaudit  start");
            await Task.Delay(500);
            System.Console.WriteLine($"Applaudit  end");
        }
        public async Task SiffleAsync()
        {
            System.Console.WriteLine($"Siffle start");
            await Task.Delay(500);
            System.Console.WriteLine($"Siffle end");
        }



        //internal void ReagitAuTour(Tour tour, Singe singe)
        //{
        //    switch(tour.Type)
        //    {
        //        case TourType.Acrobatie: { Applaudit(tour, singe);break; }
        //        case TourType.Musique: { Siffle(tour, singe); break; }
        //    }
        //}

        //private void Applaudit(Tour tour, Singe singe)
        //{
        //    Console.WriteLine($"Spectateur {nameof(Applaudit)} pendant le tour de {tour.Type} \"{tour.Nom}\" du singe {nameof(singe)}");
        //}
        //private void Siffle(Tour tour, Singe singe)
        //{            
        //    Console.WriteLine($"Spectateur {nameof(Siffle)} pendant le tour de {tour.Type} \"{tour.Nom}\" du singe {nameof(singe)}");
        //}


    }
}
