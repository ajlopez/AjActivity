namespace AjActivity.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjActivity.Model;

    public class UserService
    {
        private Repository repository;
        private ulong counter;

        public UserService(Repository repository)
        {
            this.repository = repository;
        }

        public ulong NewUser(string name)
        {
            ulong id = this.NextId();
            this.repository.AddUser(new User(id, name));
            return id;
        }

        private ulong NextId()
        {
            if (counter == 0)
                if (this.repository.Users.Count() > 0)
                    counter = this.repository.Users.Select(u => u.Id).Max();

            return ++counter;
        }

        public void AddFollower(ulong userid, ulong followerid)
        {
            User user = this.repository.Users.Where(u => u.Id == userid).Single();
            User follower = this.repository.Users.Where(u => u.Id == followerid).Single();

            user.AddFollower(followerid);
            follower.Following(userid);
        }
    }
}
