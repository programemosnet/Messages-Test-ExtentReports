using Messages.Services;
using System;
using Xunit;

namespace Messages.Tests.Unit.Services.Message
{
    public class GoodbyeTest
    {
        public MessageService messageService;
 
        public GoodbyeTest()
        {
            this.messageService = new MessageService();
        }

        [Fact]
        public void Greeting_WhenNameIsNullOrEmpty_ReturnMessageGoodbye()
        {
            //Arrange
            string name = "Programemos.net";
            string greeting = $"Goodbye {name}!!!";

            //Act
            string message = messageService.Goodbye(name);

            //Aseerts
            Assert.Equal(greeting, message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Goodbye_WhenNameIsNullOrEmpty_ReturnArgumentNullException(string name)
        {
            //Act & asserts
            var ex = Assert.Throws<ArgumentNullException>(() => this.messageService.Greeting(name));
        }
    }
}
