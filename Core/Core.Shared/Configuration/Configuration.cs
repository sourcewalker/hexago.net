using System.Collections.Generic;
using System.Dynamic;

namespace Core.Shared.Configuration
{
    public class Configuration
    {
        public Environments Environment { get; set; }

        public dynamic Settings { get; set; }

        public List<string> Exceptions = new List<string>();

        public Configuration()
        {
            Settings = new ExpandoObject();
        }

        public void AddSetting(string key, object value)
        {
            var p = Settings as IDictionary<string, object>;
            p[key] = value;
        }

        public T GetSetting<T>(string key)
        {
            var p = Settings as IDictionary<string, object>;

            return p.ContainsKey(key) ? (T)p[key] : default;
        }

        public void AddException(string value)
        {
            Exceptions.Add(value);
        }
    }
}
