namespace AjActivity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjActivity.Model;
    using AjActivity.Collections;

    public class UserRepository
    {
        private SparseArray<User> users = new SparseArray<User>();

        public void SetUser(User user)
        {
            users[user.Id] = user;
        }

        public User GetUser(ulong id)
        {
            return users[id];
        }
    }
}
