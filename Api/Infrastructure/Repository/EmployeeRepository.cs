using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Web07.Core.Entities;
using MISA.Web07.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Web07.Infrastructure.Repository
{
    public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
    {
        IDbConnection _dbConnection;
        public readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
