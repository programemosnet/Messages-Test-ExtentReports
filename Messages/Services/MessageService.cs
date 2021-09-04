using System;

namespace Messages.Services
{
    public class MessageService
    {
        public string Greeting(string name)
        {
            EnsureName(name);
            return $"Hello {name}!!!";
        }

        public string Goodbye(string name)
        {
            EnsureName(name);
            return $"Goodbye {name}!!!";
        }

        private void EnsureName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
        }
    }
}
