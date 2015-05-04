using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Delete(int id);
}

/// <summary>
/// The EF-dependent, generic repository for data access
/// </summary>
/// <typeparam name="T">Type of entity for this Repository.</typeparam>
