using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingeTour
{
    public class Spectateur
    {
        public string Nom { get; private set; }

        public Spectateur(string nom)
        {
            this.Nom = nom;
        }
        public async Task ApplauditAsync(System.Threading.CancellationToken stopToken)
        {
            // Applaudit jusque a ce qu'on demmande d'arretter
            try
            {
                while (true)
                {
                    await Task.Delay(1000, stopToken);
                }
            }
            catch (TaskCanceledException ex)
            {

            }

        }
        public async Task SiffleAsync(System.Threading.CancellationToken stopToken)
        {
            //Siffle jusque a ce qu'on demmande d'arretter
            try
            {
               while(true)
                {
                    await Task.Delay(1000, stopToken);
                }                             
            }catch (TaskCanceledException ex)
            {

            }
        }


    }
}
