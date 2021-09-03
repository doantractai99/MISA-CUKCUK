using MISA.Web07.Core.Entities;
using MISA.Web07.Core.Interfaces.Repository;
using MISA.Web07.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Web07.Ptit.Core.Services;

namespace MISA.Web07.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        ServiceResult _serviceResult;

        public EmployeeService(IEmployeeRepository employeeRepository, IBaseRepository<Employee> baseRepository) : base(baseRepository)
        {
            _serviceResult = new ServiceResult();
            _employeeRepository = employeeRepository;
        }

        public override ServiceResult GetAll()
        {
            return base.GetAll();
        }
    }
}
