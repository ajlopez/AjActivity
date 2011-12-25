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

        public User NewUser(string name)
        {
            ulong id = this.NextId();
            User user = new User(id, name);
            this.repository.AddUser(user);
            return user;
        }

        private ulong NextId()
        {
            return ++counter;
        }

        public void AddFollower(ulong userid, ulong followerid)
        {
            User user = this.repository.GetUserById(userid);
            User follower = this.repository.GetUserById(followerid);

            user.AddFollower(followerid);
            follower.Following(userid);
        }
    }
}
