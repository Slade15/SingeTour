using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SingeTour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingeTourTest
{
    [TestClass]
    public class SingeTest
    {
        public readonly Singe _singe;
        public readonly IEnumerable<Tour> _tourList;
        public SingeTest()
        {
            _tourList = new List<Tour>()
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
            _singe = new Singe("Sing test", _tourList);
        }


        [TestMethod]
        public void ExecuterTourAsync_ExistingTour_Completed()
        {
            //Arange

            Tour t = _tourList.First();

            //Act
            var result = _singe.ExecuterTourAsync(t);

            result.Wait();

            //Assert
            result.IsCompleted.Should().BeTrue();
        }
        [TestMethod]
        public void ExecuterTourAsync_NotExistingTour_Completed()
        {
            //Arange

            Tour t = new Tour("unknowntour", TourType.Musique, null);

            //Act
            var result = _singe.ExecuterTourAsync(t);       

            //Assert
            result.Exception.Should().NotBeNull();
            result.IsCompleted.Should().BeTrue();
        }
    }
}
