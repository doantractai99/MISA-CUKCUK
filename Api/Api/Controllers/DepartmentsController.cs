using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web07.Core.Entities;
using MISA.Web07.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Web07.Bxloc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseEntityController<Department>
    {
        IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService) : base(departmentService)
        {
        }
    }
}
