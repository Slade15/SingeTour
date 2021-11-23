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
    public class SpectateurTest
    {
        private readonly Spectateur _spectateur;

        public SpectateurTest()
        {
            _spectateur = new Spectateur("spec");
        }

        [TestMethod]
        public void ApplauditAsync_WithTaskCanceledException_ReturnCompleted()
        {
            //Arange

            var stopTokenSource = new System.Threading.CancellationTokenSource();

            //Act
            var result = _spectateur.ApplauditAsync(stopTokenSource.Token);

            stopTokenSource.CancelAfter(500);

            result.Wait(5000);

            //Assert
            result.IsCompleted.Should().BeTrue();
        }
        [TestMethod]
        public void SiffleAsync_WithTaskCanceledException_ReturnCompleted()
        {
            //Arange

            var stopTokenSource = new System.Threading.CancellationTokenSource();

            //Act
            var result = _spectateur.SiffleAsync(stopTokenSource.Token);

            stopTokenSource.CancelAfter(500);

            result.Wait(5000);

            //Assert
            result.IsCompleted.Should().BeTrue();
        }
    }
}
