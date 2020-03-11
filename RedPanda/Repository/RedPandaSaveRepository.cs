using RedPanda.DataAccess.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace RedPanda.DataAccess.Repository
{
    public class RedPandaSaveRepository<T> : ISaveRepository<T> where T : BaseEntity {

        private DbContext _context;
        private DbSet<T> _dbSet;

        public RedPandaSaveRepository(DbContext context) {

            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity) {
            entity.CreateDate = DateTime.UtcNow;

            _dbSet.Add(entity);

            SaveChanges();
        }

        public void Delete(T entity) {
            _dbSet.Remove(entity);

            SaveChanges();
        }

        public void DeleteById(int id) {
            var entity = _dbSet.FirstOrDefault(f => f.Id == id);

            Delete(entity);
        }

        public bool SaveChanges() {

            return _context.SaveChanges() > 0;
        }

        public void Update(T entity) {
            entity.UpdateDate = DateTime.UtcNow;
            SaveChanges();
        }
    }
}
