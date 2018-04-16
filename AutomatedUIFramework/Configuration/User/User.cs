using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SeleniumFramework.Configuration.User
{
    public sealed class User : ConfigurationSection
    {
        private static User settings = ConfigurationManager.GetSection("User") as User;

        public static User Settings
        {
            get { return settings; }
        }

        [ConfigurationProperty("login", IsRequired = false)]
        public string Login
        {
            get
            {
                return (string)this["login"];
            }
            set
            {
                this["login"] = value;
            }
        }

        [ConfigurationProperty("password", IsRequired = false)]
        public string Password
        {
            get
            {
                return (string)this["password"];
            }
            set
            {
                this["password"] = value;
            }
        }
    }
}
