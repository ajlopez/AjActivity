namespace AjActivity.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjActivity.Model;

    public class ActivityService
    {
        private Repository repository;
        private ulong counter;

        public ActivityService(Repository repository)
        {
            this.repository = repository;
        }

        public ulong NewMessage(ulong userid, string content)
        {
            DateTime datetime = DateTime.UtcNow;
            ulong id = this.NextId();
            this.repository.AddMessage(new Message(id, userid, datetime, content));
            return id;
        }

        private ulong NextId()
        {
            if (counter == 0)
                if (this.repository.Messages.Count() > 0)
                    counter = this.repository.Messages.Select(m => m.Id).Max();

            return ++counter;
        }
    }
}
