﻿using MISA.Web07.Core.Entities;
using MISA.Web07.Core.Interfaces.Repository;
using MISA.Web07.Core.Interfaces.Services;
using MISA.Web07.Core.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Web07.Ptit.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        #region DECLARE
        IBaseRepository<MISAEntity> _baseRepository;
        ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _serviceResult = new ServiceResult();
            _baseRepository = baseRepository;
        }
        #endregion

        public virtual ServiceResult GetAll()
        {
            _serviceResult.Data = _baseRepository.GetAll();
            return _serviceResult;
        }

        public ServiceResult GetById(Guid entityId)
        {
            _serviceResult.Data = _baseRepository.GetById(entityId);
            return _serviceResult;
        }

        public ServiceResult Add(MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            var entityCode = entity.GetType().GetProperty($"{className}Code").GetValue(entity).ToString();
            //validate dữ liệu và xử lí nghiệp vụ
            var isValid = true;
            //validate các trường bắt buộc
            isValid = validateRequired(entity);
            if (isValid)
            {
                //validate Email
                isValid = validateEmail(entity);
            }

            if (isValid)
            {
                //validate các trường chỉ chứa số
                isValid = validateIsNumber(entity);
            }

            if (isValid)
            {
                //validate số điện thoại
                isValid = validatePhoneNumber(entity);
            }

            if (isValid)
            {
                //check trùng mã
                isValid = checkedCodeExist(entityCode, Guid.Empty);
            }

            if (isValid)
            {
                //Thực hiện thêm mới
                _serviceResult.Data = _baseRepository.Add(entity);
            }
            return _serviceResult;

        }

        public ServiceResult Edit(MISAEntity entity, Guid entityId)
        {
            //validate dữ liệu và xử lí nghiệp vụ
            var className = typeof(MISAEntity).Name;
            var entityCode = entity.GetType().GetProperty($"{className}Code").GetValue(entity).ToString();
            //validate dữ liệu và xử lí nghiệp vụ
            var isValid = true;

            //validate các trường bắt buộc
            isValid = validateRequired(entity);
            if (isValid)
            {
                //validate Email
                isValid = validateEmail(entity);
            }

            if (isValid)
            {
                //validate các trường chỉ chứa số
                isValid = validateIsNumber(entity);
            }

            if (isValid)
            {
                //validate số điện thoại
                isValid = validatePhoneNumber(entity);
            }

            if (isValid)
            {
                //Thực hiện sửa
                _serviceResult.Data = _baseRepository.Update(entity, entityId);
            }

            return _serviceResult;
        }

        public ServiceResult NewEmployeeCode()
        {   
            var code  = _baseRepository.NewEmployeeCode();
            var s = code.Substring(0, 2);
            int number = int.Parse(code.Substring(2, 6)) +1;

            _serviceResult.Data = s + number;
            return _serviceResult;
        }

        #region Validate

        /// <summary>
        /// Hàm kiểm tra nhập các trường bắt buộc
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy : Bxloc 30/08/2021
        public bool validateRequired(MISAEntity entity)
        {
            var isValid = true;
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var prop in properties)
            {
                var requiredProp = prop.GetCustomAttributes(typeof(MISARequired), true);

                if (requiredProp.Length > 0)
                {
                    var propName = (requiredProp[0] as MISARequired).Name;
                    var propValue = prop.GetValue(entity).ToString();
                    if (string.IsNullOrEmpty(propValue))
                    {
                        isValid = false;
                        _serviceResult.Messenger = "Thông tin này không được phép để trống";
                        //_serviceResult.Messenger = string.Format(Properties.ResourceVN.Empty_Field, propName);
                        _serviceResult.isValid = false;
                    }
                }
            }
            return isValid;
        }

        /// <summary>
        /// Hàm kiểm tra định dạng Email
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy : Bxloc 30/08/2021
        public bool validateEmail(MISAEntity entity)
        {
            var isValid = true;
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var prop in properties)
            {
                var emailProp = prop.GetCustomAttributes(typeof(MISAEmail), true);
                if (emailProp.Length > 0)
                {
                    var propValue = prop.GetValue(entity).ToString();
                    var emailFormat = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                    var isMatch = Regex.IsMatch(propValue, emailFormat, RegexOptions.IgnoreCase);
                    if (!isMatch)
                    {
                        isValid = false;
                        _serviceResult.Messenger = "Lỗi Email";
                        //_serviceResult.Messenger = Properties.ResourceVN.Error_Email;
                        _serviceResult.isValid = false;
                    }
                }
            }
            return isValid;
        }

        /// <summary>
        /// Hàm kiểm tra các trường chỉ chứa chữ số
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy : Bxloc 30/08/2021
        public bool validateIsNumber(MISAEntity entity)
        {
            var isValid = true;
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var prop in properties)
            {
                var NumProp = prop.GetCustomAttributes(typeof(MISAIsNumber), true);
                if (NumProp.Length > 0)
                {
                    var propName = (NumProp[0] as MISAIsNumber).Name.ToString();
                    var propValue = prop.GetValue(entity);
                    var NumFormat = @"^([0-9]\d*)$";
                    var isMatch = Regex.IsMatch(propValue.ToString(), NumFormat, RegexOptions.IgnoreCase);
                    if (!isMatch)
                    {
                        isValid = false;
                        _serviceResult.Messenger = "Trường thong tin có số";
                        //_serviceResult.Messenger = string.Format(Properties.ResourceVN.Contain_Numbers_Only, propName);
                        _serviceResult.isValid = false;
                    }
                }
            }
            return isValid;
        }

        /// <summary>
        /// Hàm kiểm tra định dạng số điện thoại
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy : Bxloc 30/08/2021
        public bool validatePhoneNumber(MISAEntity entity)
        {
            var isValid = true;
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var prop in properties)
            {
                var phoneNumProp = prop.GetCustomAttributes(typeof(MISAPhoneNumber), true);
                if (phoneNumProp.Length > 0)
                {
                    var propValue = prop.GetValue(entity).ToString();
                    var phoneNumFormat = @"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$";
                    var isMatch = Regex.IsMatch(propValue, phoneNumFormat, RegexOptions.IgnoreCase);
                    if (!isMatch)
                    {
                        isValid = false;
                        _serviceResult.Messenger = "Lỗi số điện thoại";
                        //_serviceResult.Messenger = Properties.ResourceVN.Error_PhoneNumber;
                        _serviceResult.isValid = false;
                    }
                }
            }
            return isValid;
        }

        /// <summary>
        /// Hàm kiểm tra trùng mã 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy : Bxloc 30/08/2021
        public virtual bool checkedCodeExist(string entityCode, Guid entityId)
        {
            var isValid = _baseRepository.checkedCodeExist(entityCode, entityId);
            if (!isValid)
            {
                _serviceResult.Messenger = "Trùng mã";
                //_serviceResult.Messenger = Properties.ResourceVN.Duplicate_Code;
                _serviceResult.isValid = false;
            }
            return isValid;
        }

        #endregion
    }
}
