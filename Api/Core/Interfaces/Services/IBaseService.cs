using MISA.Web07.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Web07.Core.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        #region Methods
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// Create by Bxloc 29/8/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ServiceResult: Trả về kết quả</returns>
        ServiceResult GetAll();

        /// <summary>
        /// Tìm kiếm theo Id
        /// Create by Bxloc 29/8/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ServiceResult: Trả về kết quả</returns>
        ServiceResult GetById(Guid entityId);

        /// <summary>
        /// Thêm mới
        /// Create by Bxloc 29/8/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ServiceResult: Trả về kết quả</returns>
        ServiceResult Add(MISAEntity entity);

        /// <summary>
        /// Sửa
        /// Create by Bxloc 29/8/2021
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ServiceResult: Trả về kết quả</returns>
        ServiceResult Edit(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Sinh mã nhân viên mới
        /// Create by Bxloc 03/09/2021
        /// </summary>
        /// <param name="string"></param>
        /// <returns>ServiceResult: Trả về kết quả</returns>
        ServiceResult NewEmployeeCode();
        #endregion

    }
}
