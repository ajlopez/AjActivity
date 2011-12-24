namespace AjActivity.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Message
    {
        private long id;
        private long userid;
        private DateTime datetime;
        private string content;

        public Message(long id, long userid, DateTime datetime, string content)
        {
            this.id = id;
            this.userid = userid;
            this.datetime = datetime;
            this.content = content;
        }

        public long Id { get { return this.id; } }

        public long UserId { get { return this.userid; } }

        public DateTime DateTime { get { return this.datetime; } }

        public string Content { get { return this.content; } }
    }
}

