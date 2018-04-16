using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AutomatedUIFramework.Configuration.Environments
{
    public sealed class EnvironmentsSection : ConfigurationSection
    {
        private static EnvironmentsSection settings = ConfigurationManager.GetSection("EnvironmentSection") as EnvironmentsSection;

        public static EnvironmentsSection Settings
        {
            get { return settings; }
        }

        [ConfigurationProperty("Environments", IsRequired = true)]
        [ConfigurationCollection(typeof(Environments), AddItemName = "Environment")]
        public Environments Environments
        {
            get { return (Environments)this["Environments"]; }
        }
    }
}
