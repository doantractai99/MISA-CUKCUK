using MISA.Web07.Core.MISAAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MISA.Web07.Core.Entities
{
    public class Employee : BaseEntity
    {
        #region Property

        /// <summary>
        /// Khóa chính 
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [MISARequired]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        [MISARequired]
        //[MISAIsNumber]
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [MISARequired]
        [MISAEmail]
        public string Email { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
        [MISARequired]
        [MISAPhoneNumber]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// số điện thoại cố định
        /// </summary>
        public string LandlinNumber { get; set; }

        /// <summary>
        /// số chứng minh nhân dân
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime IdentityDate { get; set; }

        /// <summary>
        /// Chức vụ
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        public string BankNumber { get; set; }

        /// <summary>
        /// Tên tài khoản ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Chi nhánh
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// Khóa chính Phòng ban, đơn vị
        /// </summary>
        [MISARequired]
        public Guid DepartmentId { get; set; }

        [MISANotMap]
        public string DepartmentName { get; set; }

        #endregion  
    }
}
