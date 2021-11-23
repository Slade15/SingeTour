using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingeTour
{
    public class Dresseur
    {
        public Singe Singe { get; private set; }

        public Dresseur(Singe singe)
        {
            this.Singe = singe;
        }
       
    }
}
