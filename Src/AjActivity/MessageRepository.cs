namespace AjActivity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
using AjActivity.Model;
    using AjActivity.Collections;

    public class MessageRepository
    {
        private TreeList<Message> messages = new TreeList<Message>();

        public IEnumerable<Message> Messages { get { return this.messages; } }

        public void AddMessage(Message message)
        {
            this.messages.Add(message);
        }
    }
}
