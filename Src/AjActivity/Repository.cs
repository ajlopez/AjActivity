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
        private User lastuser;
        private Message lastmessage;

        public Repository()
        {
            this.messages = new List<Message>();
            this.users = new List<User>();
        }

        internal void AddMessage(Message message)
        {
            this.messages.Add(message);
            this.lastmessage = message;
        }

        internal void AddUser(User user)
        {
            this.users.Add(user);
            this.lastuser = user;
        }

        internal User GetUserById(ulong id)
        {
            return this.users.Where(u => u.Id == id).SingleOrDefault();
        }
    }
}
