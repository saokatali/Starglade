using System;
using System.Collections.Generic;
using System.Text;

namespace Starglade.Core.Interfaces
{
    public interface ICacheRepository<T>
    {
        void SetAsync(string key, T value);

        T GetAsync(string key);
    }
}
