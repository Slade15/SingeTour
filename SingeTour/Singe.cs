using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingeTour
{
    public class Singe
    {
        public string Nom { get; private set; }
        public IEnumerable<Tour> TourListe { get; private set; }

        public Singe(string nom ,IEnumerable<Tour> tours)
        {
            this.Nom = nom;
            this.TourListe = tours;
        }

        public async Task ExecuterTourAsync(Tour tour)
        {

            var t = TourListe.SingleOrDefault(p => p.Equals(tour));
            if (t is null)
            {
                throw new Exception("Ce singe ne connait pas ce tour");
            }
            await t?.ExcuterTourAsync();
           
        }
    }
}
