namespace AjActivity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjActivity.Model;

    public class Repository
    {
        private IList<Message> messages;
        private IList<User> users;

        public Repository()
        {
            this.messages = new List<Message>();
            this.users = new List<User>();
        }

        public IEnumerable<Message> Messages { get { return this.messages; } }

        public IEnumerable<User> Users { get { return this.users; } }

        public void AddMessage(Message message)
        {
            this.messages.Add(message);
        }
    }
}
