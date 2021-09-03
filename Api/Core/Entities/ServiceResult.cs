using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Web07.Core.Entities
{
    public class ServiceResult
    {
        #region Property
        /// <summary>
        /// Thành công trả về True, thất bại trả về false
        /// </summary>
        public bool isValid { get; set; } = true;

        /// <summary>
        /// Trả về dữ liệu
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Trả về thông báo
        /// </summary>
        public string Messenger { get; set; }

        #endregion
    }
}
