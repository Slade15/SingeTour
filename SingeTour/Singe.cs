using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingeTour
{
    internal class Singe
    {
        public string Nom { get; private set; }
        public List<Tour> TourListe { get; private set; }

        public Singe(string nom ,List<Tour> tours)
        {
            this.Nom = nom;
            this.TourListe = tours;
        }

        public async Task ExecuterTourAsync(Tour tour)
        {

            var t = TourListe.SingleOrDefault(p => p.Equals(tour));
            await t?.ExcuterTourAsync();

            //if (TourListe.Contains(tour))
            //{
            //  //  tour.Execute();
            //}
            //else
            //{
            //    throw new Exception("Ce singe ne connait pas ce tour");
            //}
        }
    }
}
