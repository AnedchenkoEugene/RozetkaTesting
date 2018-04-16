using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SeleniumFramework.Configuration.Environments
{
    public class Environment : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("url", IsRequired = false)]
        public string Url
        {
            get
            {
                return (string)this["url"];
            }
            set
            {
                this["url"] = value;
            }
        }

        [ConfigurationProperty("pageTitle", IsRequired = true)]
        public string PageTitle
        {
            get
            {
                return (string)this["pageTitle"];
            }
            set
            {
                this["pageTitle"] = value;
            }
        }
    }
}
