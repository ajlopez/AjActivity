namespace AjActivity.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjActivity.Model;

    public class ActivityService
    {
        private ulong counter;

        public ulong NewMessage(ulong userid, string content)
        {
            DateTime datetime = DateTime.UtcNow;
            ulong id = ++counter;
            new Message(id, userid, datetime, content);
            return id;
        }
    }
}
