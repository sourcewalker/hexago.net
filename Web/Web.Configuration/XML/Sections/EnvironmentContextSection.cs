using System.Configuration;
using Web.Configuration.Collections;

namespace Web.Configuration.Sections
{
    public sealed partial class EnvironmentContextSection :  ConfigurationSection
    {
        [ConfigurationProperty("Environments", IsDefaultCollection = true)]
        public EnvironmentCollection Environments
        {
            get
            {
                EnvironmentCollection hostCollection = (EnvironmentCollection)base["Environments"];
                return hostCollection;
            }
        }
    }
}
