using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Web07.Core.Interfaces.Repository
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <returns>Trả về tất cả dữ liệu</returns>
        /// Create by: Bxloc 29/8/2021
        List<MISAEntity> GetAll();

        /// <summary>
        /// Lấy tất cả dữ liệu theo id
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <returns>Trả về dữ liệu theo id</returns>
        /// Create by: Bxloc 29/8/2021
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm mơi dữ liệu
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Trả về số dòng được thêm</returns>
        /// Create by: Bxloc 29/8/2021
        int Add(MISAEntity entity);

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Trả về số dòng được sửa</returns>
        /// Create by: Bxloc 29/8/2021
        int Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <returns>Trả về số dòng được xóa</returns>
        /// Create by: Bxloc 29/8/2021
        int Delete(Guid entityId);

        /// <summary>
        /// Hàm kiểm tra trùng mã
        /// </summary>
        /// <returns>Trả về đúng hoặc sai</returns>
        /// Create by: Bxloc 29/8/2021
        bool checkedCodeExist(string entityCode, Guid entityId);

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Trả về số dòng được sửa</returns>
        /// Create by: Bxloc 03/9/2021
        string NewEmployeeCode();
    }
}
