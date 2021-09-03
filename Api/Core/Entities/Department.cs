using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Web07.Core.Entities
{
    public class Department: BaseEntity
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã phòng ban, đơn vị
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Tên phòng ban, đơn vị
        /// </summary>
        public string DepartmentName { get; set; }
        #endregion
    }
}
