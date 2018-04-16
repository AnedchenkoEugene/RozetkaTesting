using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SeleniumFramework.Configuration.Environments
{
    [ConfigurationCollection(typeof(Environment), CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public sealed class Environments : ConfigurationElementCollection<Environment>
    {
    }
}
