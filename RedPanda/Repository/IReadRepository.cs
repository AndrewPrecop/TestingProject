using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RedPanda.DataAccess.Repository {
    public interface IReadRepository<T> where T : class {
        IList<T> Get(Expression<Func<T, bool>>  querry, int takeCount, int skipCount);
        IList<T> Get(Expression<Func<T, bool>>  querry, int takeCount);
        IList<T> Get(Expression<Func<T, bool>>  querry);
    }
}
