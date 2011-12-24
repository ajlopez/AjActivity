namespace AjActivity.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Message
    {
        private ulong id;
        private ulong userid;
        private DateTime datetime;
        private string content;

        public Message(ulong id, ulong userid, DateTime datetime, string content)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException("id");
            if (userid == 0)
                throw new ArgumentOutOfRangeException("userid");
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException("content");

            this.id = id;
            this.userid = userid;
            this.datetime = datetime;
            this.content = content;
        }

        public ulong Id { get { return this.id; } }

        public ulong UserId { get { return this.userid; } }

        public DateTime DateTime { get { return this.datetime; } }

        public string Content { get { return this.content; } }
    }
}

