using Microsoft.AspNetCore.Cors;
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
    //[Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController<MISAEntity> : ControllerBase
    {
        #region DECLARE
        IBaseService<MISAEntity> _baseService;
        ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region method GET
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreateBy: Bxloc 29/8/2021
        [HttpGet]
        public virtual IActionResult GetAll()
        {
            try
            {
                var serviceResult = _baseService.GetAll();
                return StatusCode(200, serviceResult.Data);
            }
            catch (Exception ex)
            {
                var newObj = new
                {
                    devMsg = ex.Message,
                    //userMsg = Properties.Resource.Error_Message_UserVN,
                    errorCode = "misa-001",
                    moreInfo = @"https:/openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""
                };
                return BadRequest(newObj);
            }
        }
        #endregion

        #region method GET
        /// <summary>
        /// Tìm kiếm theo id
        /// </summary>
        /// <returns>Dữ liệu theo id</returns>
        /// CreateBy: Bxloc 29/8/2021
        [HttpGet("{entityId}")]
        public virtual IActionResult GetById(Guid entityId)
        {
            try
            {
                var entity = _baseService.GetById(entityId);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                var newObj = new
                {
                    devMsg = ex.Message,
                    //userMsg = Properties.Resource.Error_Message_UserVN,
                    errorCode = "misa-001",
                    moreInfo = @"https:/openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""
                };
                return BadRequest(newObj);
            }
        }
        #endregion

        #region method POST
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreateBy: Bxloc 29/8/2021
        [HttpPost]
        public virtual IActionResult InsertEntity(MISAEntity entity)
        {
            try
            {
                var serviceResult = _baseService.Add(entity);

                // Trả về cho client
                if (serviceResult.isValid == true)
                {
                    return StatusCode(201, serviceResult.Data);
                }
                else
                {
                    var errorObj = new
                    {
                        userMsg = serviceResult.Messenger,
                        errorCode = "misa-001",
                        moreInfo = @"https:/openapi.misa.com.vn/errorcode/misa-001",
                        traceId = ""
                    };
                    return StatusCode(400, errorObj);
                }
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    //userMsg = MISA.Core.Properties.ResourceVN.Error_Message_UserVN,
                    errorCode = "misa-001",
                    moreInfo = @"https:/openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""
                };
                return StatusCode(500, errorObj);
            }

        }
        #endregion

        #region method PUT
        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreateBy: Bxloc 02/09/2021
        [HttpPut("{entityId}")]
        public virtual IActionResult UpdateEntity(Guid entityId, MISAEntity entity)
        {
            try
            {
                var serviceResult = _baseService.Edit(entity, entityId);

                // Trả về cho client
                if (serviceResult.isValid == true)
                {
                    return StatusCode(201, serviceResult.Data);
                }
                else
                {
                    return BadRequest(serviceResult.Messenger);
                }
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    //userMsg = Properties.Resource.Error_Message_UserVN,
                    errorCode = "misa-001",
                    moreInfo = @"https:/openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""
                };
                return StatusCode(500, errorObj);
            }
        }
        #endregion

        #region method GET
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreateBy: Bxloc 29/8/2021
        [Route("[action]")]
        [HttpGet]
        [ActionName("NewEmployeeCode")]
        public IActionResult NewEmployeeCode()
        {
            try
            {
                var serviceResult = _baseService.NewEmployeeCode();
                return StatusCode(200, serviceResult.Data);
            }
            catch (Exception ex)
            {
                var newObj = new
                {
                    devMsg = ex.Message,
                    //userMsg = Properties.Resource.Error_Message_UserVN,
                    errorCode = "misa-001",
                    moreInfo = @"https:/openapi.misa.com.vn/errorcode/misa-001",
                    traceId = ""
                };
                return BadRequest(newObj);
            }
        }
        #endregion

        //#region method DELETE
        ///// <summary>
        ///// Hàm xóa khách hàng
        ///// </summary>
        ///// <param name="customerId"></param>
        ///// <returns></returns>
        ///// CreateBy: Dvanh 12/8/2021
        //[HttpDelete("{entityId}")]
        //public IActionResult DeleteEntity(Guid entityId)
        //{
        //    try
        //    {
        //        var rowEffects = _baseService.Delete(entityId);
        //        return Ok(rowEffects);

        //    }
        //    catch (Exception ex)
        //    {
        //        var errorObj = new
        //        {
        //            devMsg = ex.Message,
        //            userMsg = Properties.Resource.Error_Message_UserVN,
        //        };
        //        return StatusCode(500, errorObj);
        //    }

        //}
        //#endregion
    }
}
