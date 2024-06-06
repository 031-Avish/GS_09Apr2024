using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDataAccessLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        readonly Dictionary<int, Employee> _employees;

        int GenerateId()
        {
            if (_employees.Count == 0)
                return 1;
            int id = _employees.Keys.Max();
            return ++id;
        }
        public Employee Add(Employee item)
        {
            if(_employees.ContainsKey(item.Id))
            {
                return null;
            }
            item.Id = GenerateId();
            _employees.Add(item.Id, item); 
            return item; 
        }

        public Employee Delete(int key)
        {
            if(_employees.ContainsKey(key))
            {
                var employee = _employees[key];
                _employees.Remove(key);
                return employee;
            }
            return null;
        }

        public Employee Get(int key)
        {
            return _employees.ContainsKey(key) ? _employees[key] : null;
        }

        public List<Employee> GetAll()
        {
            if (_employees.Count == 0)
                return null;
            return _employees.Values.ToList();
        }

        public Employee Update(Employee item)
        {
            if(_employees.ContainsKey((int)item.Id))
            {
                _employees[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
