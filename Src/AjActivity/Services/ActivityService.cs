namespace AjActivity.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjActivity.Model;

    public class ActivityService
    {
        private MessageRepository repository;
        private UserRepository urepository;
        private ulong counter;

        public ActivityService(MessageRepository repository, UserRepository urepository)
        {
            this.repository = repository;
            this.urepository = urepository;
        }

        public Message NewMessage(ulong userid, string content)
        {
            DateTime datetime = DateTime.UtcNow;
            ulong id = this.NextId();
            Message message = new Message(id, userid, datetime, content);
            this.repository.AddMessage(message);

            User user = this.urepository.GetUser(userid);

            user.AddMessage(message);

            foreach (ulong followerid in user.FollowerIds)
            {
                User follower = this.urepository.GetUser(followerid);
                follower.AddMessage(message);
            }

            return message;
        }

        private ulong NextId()
        {
            return ++counter;
        }
    }
}
