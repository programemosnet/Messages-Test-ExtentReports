using System;

namespace Messages.Services
{
    public class GreetingService
    {
        public string Greeting(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return $"Hello {name}!!!";
        }
    }
}