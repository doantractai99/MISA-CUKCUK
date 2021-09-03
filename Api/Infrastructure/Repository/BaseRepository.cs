using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Web07.Core.Interfaces.Repository;
using MISA.Web07.Core.MISAAttribute;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Web07.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity>: IBaseRepository<MISAEntity>, IDisposable
    {
        IDbConnection _dbConnection;
        public readonly string _connectionString;
        string _className;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MISADatabase");
            _className = typeof(MISAEntity).Name;
        }

        /// <summary>
        /// Lấy tất cả dữ liệu từ data base
        /// Created by Bxloc 29/08/2021
        /// </summary>
        /// <returns>Tất cả dữ liệu từ database</returns>
        public List<MISAEntity> GetAll()
        {
            // 1.Khởi tạo đối tượng kết nối với database
            _dbConnection = new MySqlConnection(_connectionString);
            // 2.Lấy dữ liệu
            //var sqlCommand = $"SELECT * FROM {_className}";
            var storeName = $"Proc_Get{_className}s";
            var entities = _dbConnection.Query<MISAEntity>(storeName, commandType: CommandType.StoredProcedure);
            return entities.ToList();
        }

        /// <summary>
        /// Lấy dữ liệu từ database theo Id
        /// Created by Bxloc 29/08/2021
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>Dữ liệu từ database theo Id</returns>
        public MISAEntity GetById(Guid entityId)
        {
            // 1.Khởi tạo đối tượng kết nối với database
            _dbConnection = new MySqlConnection(_connectionString);
            // 2.Lấy dữ liệu
            //var sqlCommand = $"SELECT * FROM {_className} WHERE {_className}Id = @EntityIdParam";
            var storeName = $"Proc_Get{_className}sById";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@m_{_className}Id", entityId);
            //var entity = _dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameters);
            var entity = _dbConnection.QueryFirstOrDefault<MISAEntity>(storeName, param: parameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

        /// <summary>
        /// Thêm dữ liệu vào database
        /// Created by Bxloc 29/08/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số dòng thêm vào database</returns>
        public int Add(MISAEntity entity)
        {
            // 1.Khởi tạo đối tượng kết nối với database
            _dbConnection = new MySqlConnection(_connectionString);

            //khai báo dynamicParam:
            var dynamicParam = new DynamicParameters();

            // 2.Thêm dữ liệu vào database
            var columnsName = string.Empty;
            var columnsParam = string.Empty;

            //Đọc từng property của object:
            var properties = entity.GetType().GetProperties();

            //Duyệt từng property:
            foreach (var prop in properties)
            {
                // kiểm tra có thuộc tính nào là not map không
                var notMapProp = prop.GetCustomAttributes(typeof(MISANotMap), true);

                // các thuộc tính là not map sẽ ko dc thêm vào database
                if (notMapProp.Length == 0)
                {
                    //lấy tên của prop:
                    var propName = prop.Name;
                    // Nếu  tên của prop là EmployeeId,CustomerId...

                    //Lấy value của prop:
                    var propValue = prop.GetValue(entity);
                    if (propName == $"{_className}Id" && prop.PropertyType == typeof(Guid))
                    {
                        //sinh id mới
                        propValue = Guid.NewGuid();
                    }

                    //Lấy kiểu dữ liệu của prop:
                    var propType = prop.PropertyType;

                    //thêm param tương ứng với mỗi property của đối tượng
                    dynamicParam.Add($"@{propName}", propValue);

                    columnsName += $"{propName},";
                    columnsParam += $"@{propName},";
                }
            }

            columnsName = columnsName.Remove(columnsName.Length - 1, 1);
            columnsParam = columnsParam.Remove(columnsParam.Length - 1, 1);


            var sqlCommand = $"INSERT INTO {_className} ({columnsName}) VALUES({columnsParam}) ";
            var rowEffects = _dbConnection.Execute(sqlCommand, param: dynamicParam);
            return rowEffects;
        }

        /// <summary>
        /// Sửa dữ liệu trong database
        /// Created by Bxloc 02/09/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số dòng sửa trong database</returns>
        public int Update(MISAEntity entity, Guid entityId)
        {

            // 2.Khởi tạo đối tượng kết nối với database
            _dbConnection = new MySqlConnection(_connectionString);
            //khai báo dynamicParam:
            var dynamicParam = new DynamicParameters();

            // 3.Thêm dữ liệu vào database
            var columnsName = string.Empty;

            //Đọc từng property của object:
            var properties = entity.GetType().GetProperties();

            //Duyệt từng property:
            foreach (var prop in properties)
            {
                // kiểm tra có thuộc tính nào là not map không
                var notMapProp = prop.GetCustomAttributes(typeof(MISANotMap), true);

                // các thuộc tính là not map sẽ ko dc thêm vào database
                if (notMapProp.Length == 0)
                {
                    //lấy tên của prop:
                    var propName = prop.Name;

                    //Lấy value của prop:
                    var propValue = prop.GetValue(entity);

                    //Lấy kiểu dữ liệu của prop:
                    var propType = prop.PropertyType;

                    //thêm param tương ứng với mỗi property của đối tượng
                    dynamicParam.Add($"@{propName}", propValue);

                    columnsName += $"{propName} = @{propName},";
                }

            }
            columnsName = columnsName.Remove(columnsName.Length - 1, 1);

            var sqlCommand = $"UPDATE {_className} SET {columnsName} WHERE {_className}Id = @EntityIdParam ";

            dynamicParam.Add("@EntityIdParam", entityId);
            var rowEffects = _dbConnection.Execute(sqlCommand, param: dynamicParam);
            return rowEffects;
        }

        public int Delete(Guid entityId)
        {
            return 0;
        }

        public bool checkedCodeExist(string entityCode, Guid entityId)
        {
            // 1.Khởi tạo đối tượng kết nối với database
            _dbConnection = new MySqlConnection(_connectionString);

            var sqlCommand = $"SELECT * FROM {_className} WHERE {_className}Code = @EntityCodeParam";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EntityCodeParam", entityCode);
            var entityCheck = _dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameters);

            var propValue = "";
            if (entityCheck != null)
            {
                propValue = entityCheck.GetType().GetProperty($"{_className}Id").GetValue(entityCheck).ToString();
            }


            if (entityId == Guid.Empty)
            {
                if (entityCheck != null)
                {
                    return false;
                }
            }
            else
            {
                if (entityCheck != null && entityId.ToString() == propValue)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Sinh mã nhân viên mới
        /// Created by Bxloc 03/09/2021
        /// </summary>
        /// <returns></returns>
        public string NewEmployeeCode()
        {
            // 1.Khởi tạo đối tượng kết nối với database
            _dbConnection = new MySqlConnection(_connectionString);
            // 2.Lấy dữ liệu
            //var sqlCommand = $"SELECT * FROM {_className}";
            var storeName = $"Proc_NewEmployeeCode";
            var newCode = _dbConnection.QueryFirstOrDefault(storeName, commandType: CommandType.StoredProcedure);
            return newCode.EmployeeCode;
        }

        public void Dispose()
        {
            _dbConnection.Dispose();
        }
    }
}
