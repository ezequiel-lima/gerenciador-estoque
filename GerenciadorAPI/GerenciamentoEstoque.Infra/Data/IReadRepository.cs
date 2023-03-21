﻿using System.Linq.Expressions;

namespace GerenciamentoEstoque.Infra.Data
{
    public interface IReadRepository<T> where T : class 
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
    }
}