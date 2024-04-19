using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDataAccessLibrary
{
    public interface IRepository<K,T>
    {
        // Here T is a Class
        // K is a datatype may be int 
        /// <summary>
        /// function to get all the items
        /// </summary>
        /// <returns> list of items</returns>
        List<T> GetAll();
        T Get(K key);
        T Add(T item);
        T Update(T item);
        T Delete(K key);
    }
}
