﻿using Microsoft.EntityFrameworkCore;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class EmployeeRequestRepository : EmployeeRepository
    {
        public EmployeeRequestRepository(RequestTrackerContext context) : base(context)
        {
        }
        public async override Task<IList<Employee>> GetAll()
        {
            return await _context.Employees.Include(e => e.RequestsRaised).ToListAsync();
        }
        public async override Task<Employee> GetByKey(int key)
        {
            var employee = _context.Employees.Include(e => e.RequestsRaised).SingleOrDefault(e => e.Id == key);
            return employee;
        }
    }
}