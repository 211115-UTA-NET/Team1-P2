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

        [Fact]
        public void TestDto_Expenses()
        {
            Expenses_Dto? X = new();

            X.Id = 1;
            X.UserPassId = 2;

            Assert.Equal(1, X.Id);
            Assert.Equal(2, X.UserPassId);
        }
    }
}