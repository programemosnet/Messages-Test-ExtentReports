using Messages.Services;
using System;
using Xunit;

namespace Messages.Tests.Unit.Services.Message
{
    public class GreetingTest
    {
        public MessageService messageService;
 
        public GreetingTest()
        {
            this.messageService = new MessageService();
        }

        [Fact]
        public void Greeting_WhenNameIsNullOrEmpty_ReturnMessageGreeting()
        {
            //Arrange
            string name = "Programemos.net";
            string greeting = $"Hello {name}!!!";

            //Act
            string message = messageService.Greeting(name);

            //Aseerts
            Assert.Equal(greeting,message);
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Greeting_WhenNameIsNullOrEmpty_ReturnArgumentNullException(string name)
        {
            //Act & asserts
            var ex = Assert.Throws<ArgumentNullException>(() => this.messageService.Greeting(name));
        }
    }
}
