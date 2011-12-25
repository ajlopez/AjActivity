namespace AjActivity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjActivity.Model;

    public class Repository
    {
        private MessageRepository messages;
        private UserRepository users;

        public Repository()
        {
            this.messages = new MessageRepository();
            this.users = new UserRepository();
        }

        internal void AddMessage(Message message)
        {
            this.messages.AddMessage(message);
        }

        internal void AddUser(User user)
        {
            this.users.SetUser(user);
        }

        internal User GetUserById(ulong id)
        {
            return this.users.GetUser(id);
        }
    }
}
