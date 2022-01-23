using Xunit;
using WebAPI.Models;
using WebAPI.Logic;
using System;
using System.Collections.Generic;

namespace APITests
{
    public class UnitTest1
    {

        [Fact]
        public void workingTest()
        {
            int a = 1;

            Assert.Equal(1, a);
        }

    }
}