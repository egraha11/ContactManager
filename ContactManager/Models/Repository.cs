using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace ContactManager.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private ContactContext context { get; set; }
        private DbSet<T> dbset { get; set; }


        public Repository(ContactContext ctx)
        {
            context = ctx;
            dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> List(string cat)
        {
            return dbset.Include(cat).ToList();

        }

        public virtual T Get(int id) => dbset.Find(id);
        public virtual void Insert(T entity) => dbset.Add(entity);
        public virtual void Update(T entity) => dbset.Update(entity);
        public virtual void Delete(T entity) => dbset.Remove(entity);
        public virtual void Save() => context.SaveChanges();





    }
}
