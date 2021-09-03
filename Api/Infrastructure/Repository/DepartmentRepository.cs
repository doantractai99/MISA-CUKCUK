using Microsoft.Extensions.Configuration;
using MISA.Web07.Core.Entities;
using MISA.Web07.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Web07.Infrastructure.Repository
{
    public class DepartmentRepository: BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
