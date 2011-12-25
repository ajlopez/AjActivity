namespace AjActivity.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjActivity.Model;

    public class UserService
    {
        private UserRepository repository;
        private ulong counter;

        public UserService(UserRepository repository)
        {
            this.repository = repository;
        }

        public User NewUser(string name)
        {
            ulong id = this.NextId();
            User user = new User(id, name);
            this.repository.SetUser(user);
            return user;
        }

        private ulong NextId()
        {
            return ++counter;
        }

        public void AddFollower(ulong userid, ulong followerid)
        {
            User user = this.repository.GetUser(userid);
            User follower = this.repository.GetUser(followerid);

            user.AddFollower(followerid);
            follower.Following(userid);
        }
    }
}
