using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTest_Mock.Models;


namespace UnitTest_Mock.Services
{
    public class EmployeeService : IEmployeeService
    {
        #region Property

        private readonly ApiDbContext _apiDbContext;

        #endregion

        #region Constructor

        public EmployeeService(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        #endregion

        public async Task<string> GetEmployeebyId(int empID)
        {
            var name = await _apiDbContext.Employees.Where(
                c => c.id == empID).Select(
                d => d.name).FirstOrDefaultAsync();

            return name;
        }

        public async Task<Employee> GetEmployeeDetails(int empID)
        {
            var emp = await _apiDbContext.Employees.FirstOrDefaultAsync(
                c => c.id == empID);

            return emp;
        }
    }
}
