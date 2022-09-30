using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CeGov.Web07.GD.NDQuang.Common.Entity.DTO;
using MISA.CeGov.Web07.GD.NDQuang.Common.Resources;
using MISA.CeGov.Web07.GD.NDQuang.Core;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.CeGov.Web07.GD.NDQuang.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        #region Field

        private IBaseService<T> _baseService;

        #endregion

        #region Constructor

        public BasesController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        #endregion

        #region Method

        /// <summary>
        /// API Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        /// Created by: NDQuang (09/06/2022)
        [HttpGet]
        public virtual IActionResult GetAllRecords()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _baseService.GetAllRecords());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, Resource.error_expception);
            }
        }

        /// <summary>
        /// API Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>ID của bản ghi vừa thêm mới</returns>
        /// Created by: NDQuang (24/08/2022)
        [HttpPost]
        public virtual IActionResult InsertOneRecord([FromBody] T record)
        {
            try
            {
                //var validateResult = HandleError.ValidateEntity(ModelState, HttpContext);
                //if (validateResult != null)
                //{
                //    return StatusCode(StatusCodes.Status400BadRequest, validateResult);
                //}

                var recordID = _baseService.InsertOneRecord(record);

                if (recordID != Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status201Created, recordID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, Resource.failedOperation);
                }
            }
            //catch (ValidateException ex)
            //{
            //    var res = new
            //    {
            //        devMsg = ex.Message,
            //        userMsg = ex.Data
            //    };
            //    return StatusCode(StatusCodes.Status400BadRequest, res);
            //}
            //catch (MySqlException mySqlException)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateDuplicateCodeErrorResult(mySqlException, HttpContext));
            //}
            //catch (Exception exception)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateExceptionResult(exception, HttpContext));
            //}
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, Resource.error_expception);
            }
        }

        /// <summary>
        /// API Sửa một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần sửa</param>
        /// <param name="recordID">ID Đối tượng bản ghi cần sửa</param>
        /// <returns>ID bản ghi được sửa</returns>
        /// Created by: NDQuang (24/08/2022)
        [HttpPut("{recordID}")]
        public virtual IActionResult UpdateOneRecord([FromRoute] Guid recordID, [FromBody] T record)
        {
            try
            {
                //var validateResult = HandleError.ValidateEntity(ModelState, HttpContext);
                //if (validateResult != null)
                //{
                //    return StatusCode(StatusCodes.Status400BadRequest, validateResult);
                //}

                var ID = _baseService.UpdateOneRecord(recordID, record);

                if (ID != Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status200OK, recordID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, Resource.failedOperation);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, Resource.error_expception);
            }
        }


        /// <summary>
        /// API Lấy danh sách nhân viên cho phép lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="groupID">ID tổ bộ môn</param>
        /// <param name="storageRoomID">ID kho phòng</param>
        /// <param name="subjectID">ID môn</param>
        /// <param name="pageSize">Số trang muốn lấy</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// Created by: NDQuang (17/08/2022)
        //[SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData<T>))]
        //[SwaggerResponse(StatusCodes.Status400BadRequest)]
        //[SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet("filter")]
        public IActionResult FilterRecords(
            [FromQuery] string? keyword,
            [FromQuery] int pageSize = 100,
            [FromQuery] int pageNumber = 1)
        {
            try
            {
                var multipleResults = _baseService.FilterRecords(keyword, pageSize, pageNumber);

                // Xử lý kết quả trả về từ DB
                if (multipleResults != null)
                {
                    return StatusCode(StatusCodes.Status200OK, multipleResults);

                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, Resource.error_expception);
            }
        }

        #endregion
    }
}
