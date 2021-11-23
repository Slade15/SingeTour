using System.Threading.Tasks;

namespace SingeTour
{
    internal class Tour
    {
        public string Nom { get; private set; }
        public TourType Type { get; private set; }

        public Tour(string nom, TourType type)
        {
            this.Nom = nom;      
            this.Type = type;
        }
        public async Task ExcuterTourAsync()
        {
            System.Console.WriteLine($"Tour {Nom} start");
            await Task.Delay(1000);
            System.Console.WriteLine($"Tour {Nom} end ");
        }
    }
    enum TourType
    {
        Acrobatie,
        Musique
    }
}