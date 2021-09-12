using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Messages.Services;
using System;
using Xunit;

namespace Messages.Tests.Unit.Services.Message
{
    
    public class GreetingFixture : IDisposable
    {
        public ExtentReports extent;
        public ExtentTest extentTest;

        public GreetingFixture()
        {
            var report = new ExtentHtmlReporter("index.html");
            extent = new ExtentReports();
            extent.AttachReporter(report);
            extentTest = extent.CreateTest("Greeting");
            extentTest.AssignAuthor("Programemos.net");
        }

        public void Dispose()
        {
            extent.Flush();
        }
    }

    public class GreetingTest : IClassFixture<GreetingFixture>
    {
        public ExtentReports extent;
        public MessageService messageService;
        public ExtentTest extentTest;

        public GreetingTest(GreetingFixture fixture)
        {
            extent = fixture.extent;
            extentTest = fixture.extentTest;
            this.messageService = new MessageService();

        }

        [Fact]
        public void Greeting_WhenNameIsValid_ReturnMessageGreeting()
        {
            var node = extentTest.CreateNode("Show Greeting", "Show message greeting");
            node.Log(Status.Info, $"Go to UR");

            //Arrange
            string name = "Programemos.net";
            string greeting = $"Hello {name}!!!";

            //Act
            string message = messageService.Greeting(name);

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
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Greeting_WhenNameIsNullOrEmpty_ReturnArgumentNullException(string name)
        {
            var node = extentTest.CreateNode("Name empty or null", "When name is null or empty return ArgumentNullException");
            node.Log(Status.Info, $"Go to UR");
            //Act & asserts
            var ex = Assert.Throws<ArgumentNullException>(() => this.messageService.Greeting(name));
        }
    }
}
