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
    }
}

