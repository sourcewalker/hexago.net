using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Interfaces.Caching
{
    public interface ICacheProvider
    {

        void Add<T>(string key, T data, double expiry = 6) where T : class;

        T Get<T>(string key) where T : class;

        bool ContainsKey(string key);

        IEnumerable<string> GetAllCacheKeys();

        void Purge();

        void Remove(string key);

        void RemoveByPrefix(string prefix);
    }
}
