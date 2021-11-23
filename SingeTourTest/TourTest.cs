using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SingeTour;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingeTourTest
{
    [TestClass]
    public class TourTest
    {
        private readonly IEnumerable<Tour> _listedeTours;

        public TourTest()
        {
            _listedeTours = new List<Tour>()
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
                 new Tour("Error Tour", TourType.Acrobatie, null),
            };
        }

        [TestMethod]
        public void ExcuterTourAsync_ExistingCallback_ReturnOK()
        {
            //Arange

            Tour t = _listedeTours.First();

            //Act
            var result = t.ExcuterTourAsync();

            result.Wait();

            //Assert
            result.IsCompleted.Should().BeTrue();             
        }
        [TestMethod]
        public void ExcuterTourAsync_NULLCallback_ReturnNullReferenceException()
        {
            //Arange

            Tour t = _listedeTours.Last();

            //Act
            var result = t.ExcuterTourAsync();

            result.Exception.Should().NotBeNull();            

            //Assert
            result.IsCompleted.Should().BeTrue();
        }
    }
}