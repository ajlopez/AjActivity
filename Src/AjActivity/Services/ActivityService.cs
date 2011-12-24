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
            Message message = new Message(id, userid, datetime, content);
            this.repository.AddMessage(message);

            User user = this.repository.GetUserById(userid);

            user.AddMessage(message);

            foreach (ulong followerid in user.FollowerIds)
            {
                User follower = this.repository.GetUserById(followerid);
                follower.AddMessage(message);
            }

            return id;
        }

        private ulong NextId()
        {
            return ++counter;
        }
    }
}
