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
            bool a = true;

            Assert.Equal(true, a);
        }

        [Fact]
        public void TestMethod1()
        {
            List<WeeklySpendings_Dtos> Test = new();
            List<WeeklySpendings_Dtos> Tester = new();
            var Testing = new Calculations();

            try
            {
                //Will fail until user input is added to Information collector fields
                Tester.Add(new(1.00m, 2.00m, 3.00m, 4.00m));


                Test = Testing.InformationCollector();
                Assert.Equal(Test, Tester);
            }
            catch
            {
                Assert.Throws<InvalidOperationException>(() => Testing.InformationCollector());
            }
        }
    }
}