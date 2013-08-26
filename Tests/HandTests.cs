using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Spades;

namespace Tests
{
    [TestFixture] 
    public class HandTests
    {
        [Test]
        public void CreateHandTest()
        {
            var hand = new Hand();
            Assert.IsNotNull(hand);
        }

    }
}
