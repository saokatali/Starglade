using System;
using System.Collections.Generic;
using System.Text;

namespace Starglade.Core.Interfaces
{
    public interface IDbRepository<T>
    {
        IList<T> GetById();
    }
}
