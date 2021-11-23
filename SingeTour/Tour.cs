using System;
using System.Threading.Tasks;

namespace SingeTour
{
    public class Tour
    {
        public string Nom { get; private set; }
        public TourType Type { get; private set; }

        public delegate Task ExcuteCallBack();

        private ExcuteCallBack executeAction;
        public Tour(string nom, TourType type, ExcuteCallBack callBack)
        {
            this.Nom = nom;      
            this.Type = type;
            this.executeAction = callBack;
        }
        public async Task ExcuterTourAsync()
        {
            if (executeAction is null)
                throw new NullReferenceException(nameof(ExcuteCallBack));

            await executeAction?.Invoke();
        }


    }
    public enum TourType
    {
        Acrobatie,
        Musique
    }
}