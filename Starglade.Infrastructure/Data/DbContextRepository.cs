using System;
using System.Collections.Generic;
using System.Text;
using Starglade.Core.Interfaces;

namespace Starglade.Infrastructure.Data
{
    public class DbContextRepository<T> : IDbRepository<T>
    {
        public IList<T> GetById()
        {
            throw new NotImplementedException();
        }
    }
}
