using MISA.Web07.Core.Entities;
using MISA.Web07.Core.Interfaces.Repository;
using MISA.Web07.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Web07.Ptit.Core.Services;

namespace MISA.Web07.Core.Services
{
    public class DepartmentService: BaseService<Department>, IDepartmentService
    {
        IDepartmentRepository _departmentRepository;
        ServiceResult _serviceResult;

        public DepartmentService(IDepartmentRepository departmentRepository, IBaseRepository<Department> baseRepository) : base(baseRepository)
        {
            _serviceResult = new ServiceResult();
            _departmentRepository = departmentRepository;
        }
    }
}
