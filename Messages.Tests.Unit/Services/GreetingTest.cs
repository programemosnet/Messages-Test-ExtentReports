using AventStack.ExtentReports;
using Messages.Services;
using System;
using Xunit;

namespace Messages.Tests.Unit.Services
{
    public class GreetingTest : IClassFixture<GreetingFixtureTest>
    {
        public ExtentReports extent;
        public GreetingService messageService;
        public ExtentTest extentTest;

        public GreetingTest(GreetingFixtureTest fixture)
        {
            extent = fixture.extent;
            extentTest = fixture.extentTest;
            this.messageService = new GreetingService();

        }

        [Fact]
        public void Greeting_WhenNameIsValid_ReturnMessageGreeting()
        {
            var node = extentTest.CreateNode("Show Greeting", "Show message greeting");
            node.Log(Status.Info, "The test starts");

            //Arrange
            string name = "Programemos.net";
            string greeting = $"Hello {name}!!!";
            node.Log(Status.Info, $"The test parameter is name={name}");

            //Act
            string message = messageService.Greeting(name);
            node.Log(Status.Info, "The call to the Message service was successful");

            //Aseerts
            try
            {
                Assert.Equal(greeting, message);
                node.Log(Status.Pass, "Test Pass");
            }
            catch(Exception ex)
            {
                node.Fail(ex.Message);
                throw ex;
            }

            node.Log(Status.Info, "The test was finished");         
        }


        [Fact]

        public void Greeting_WhenNameIsNullOrEmpty_ReturnArgumentNullException()
        {
            //Arrange
            string name = "";

            var node = extentTest.CreateNode("Name empty or null", "When name is null or empty return ArgumentNullException");
            node.Log(Status.Info, "The test starts");

            //Act & asserts
            var ex = Assert.Throws<ArgumentNullException>(() => this.messageService.Greeting(name));
            node.Log(Status.Info, "The test was finished");
        }
    }
}
