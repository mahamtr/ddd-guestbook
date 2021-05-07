using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(Guid id) where T : BaseEntity;
        T GetById<T>(Guid id, string include) where T : BaseEntity;
        List<T> List<T>(params Expression<Func<T, object>>[] properties) where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
        

    }
}
