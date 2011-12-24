namespace AjActivity.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class User
    {
        private ulong id;
        private string name;
        private IList<ulong> followerids = new List<ulong>();
        private IList<ulong> followingids = new List<ulong>();
        private IList<Message> messages = new List<Message>();

        public User(ulong id, string name)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException("id");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            this.id = id;
            this.name = name;
        }

        public ulong Id { get { return this.id; } }

        public string Name { get { return this.name; } }

        public IEnumerable<ulong> FollowerIds { get { return this.followerids; } }

        public IEnumerable<ulong> FollowingIds { get { return this.followingids; } }

        public IEnumerable<Message> Messages { get { return this.messages; } }

        public void AddMessage(Message message)
        {
            this.messages.Add(message);
        }

        public void AddFollower(ulong followerid)
        {
            if (!this.followerids.Contains(followerid))
                this.followerids.Add(followerid);
        }

        public void Following(ulong userid)
        {
            if (!this.followingids.Contains(userid))
                this.followingids.Add(userid);
        }
    }
}

