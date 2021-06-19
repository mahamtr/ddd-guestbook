using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        public readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(Guid id) where T : BaseEntity
        {


            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public T GetById<T>(Guid id, string include) where T : BaseEntity
        {
            return _dbContext.Set<T>()
                .Include(include)
                .SingleOrDefault(e => e.Id == id);
        }

        public List<T> List<T>(params Expression<Func<T, object>>[] properties) where T : BaseEntity
        {
            var query = _dbContext.Set<T>().AsQueryable();
            foreach (var include in properties)
            {
                query = query.Include(include);
            }
            return query.ToList();
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public IEnumerable<T> BulkInsert<T>(IEnumerable<T> entity) where T : BaseEntity
        {
            _dbContext.Set<T>().AddRange(entity);
            _dbContext.SaveChanges();

            return entity;
        }


        public void Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
