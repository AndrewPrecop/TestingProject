using RedPanda.DataAccess.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RedPanda.DataAccess.Repository {
    public interface ISaveRepository<T> where T : BaseEntity {

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);
        bool SaveChanges();
    }
}
