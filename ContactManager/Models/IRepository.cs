﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List(string cat);
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();





    }
}
