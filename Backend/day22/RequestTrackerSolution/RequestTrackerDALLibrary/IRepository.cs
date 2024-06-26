﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public interface IRepository<K,T> where T :class
    {
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<T> DeleteByKey(K key);
        public Task<T> GetByKey(K key);
        public Task<IList<T>> GetAll();
    }
}
