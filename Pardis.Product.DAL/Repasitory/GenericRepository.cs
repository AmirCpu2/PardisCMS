using Pardis.Product.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pardis.Product.DAL.Repasitory
{
    interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        void Create(T entity);
        void Delete(T entity);
        void AddOrUpdate(T entity);
        void Save();
    }

    public class GenericRepository<T> : MainDAL, IGenericRepository<T> where T : class
    {
        public static GenericRepository<T> Instance { get; } = new GenericRepository<T>();
        public virtual IQueryable<T> GetAll()
        {
            return DB.Set<T>();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return DB.Set<T>().Where(filter);
        }

        public virtual T Find(int id)
        {
            return DB.Set<T>().Find(id);
        }
        public virtual void Create(T entity)
        {
            if (entity == null)
                return;
            DB.Set<T>().Add(entity);
        }
        public virtual void Delete(T entity)
        {
            if (entity == null)
                return;
            DB.Set<T>().Remove(entity);
        }
        public virtual void Update(T entity)
        {
            if (entity == null)
                return;
            DB.Entry(entity).State = EntityState.Modified;
        }
        public virtual void AddOrUpdate(T entity)
        {
            if (entity == null)
                return;
            DB.Set<T>().AddOrUpdate(entity);
        }
        public virtual void Save()
        {
            try
            {
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual List<string> SqlQuery(string query)
        {
            var b = DB.Database.SqlQuery<string>(query).ToList();
            return b;
        }
        public virtual List<Ttype> SqlQuery<Ttype>(string query)
        {
            var queryResult = DB.Database.SqlQuery<Ttype>(query);
            if (queryResult == null)
                return new List<Ttype>();
            var result = queryResult?.ToList();
            return result;
        }

        public virtual int ExecuteSqlCommand(string query)
        {
            var returned = DB.Database.ExecuteSqlCommand("");
            return returned;
        }
    }
}
