using MISA.CeGov.Web07.GD.NDQuang.Common.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CeGov.Web07.GD.NDQuang.API.Core
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi  
        /// </summary>
        /// <returns>Trả về tất cả bản ghi</returns>
        /// Created by: NDQuang (23/08/2022)
        public IEnumerable<dynamic> GetAllRecords();



        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>ID bản ghi được thêm mới</returns>
        /// Created by: NDQuang (24/08/2022)
        public Guid InsertOneRecord(T record);


        /// <summary>
        /// Sửa một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần sửa</param>
        /// <returns>ID bản ghi được sửa</returns>
        /// Created by: NDQuang (24/08/2022)
        public Guid UpdateOneRecord(Guid recordID, T record);

        /// <summary>
        /// Xóa 1 nhân viên
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: NDQuang (17/08/2022)
        public int DeleteEmployeeByID(Guid recordID);

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
        public PagingData<dynamic> FilterRecords(
            string? keyword,
            int pageSize,
            int pageNumber);

        /// <summary>
        /// Lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <param name="recordID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// Created by: NDQuang (17/08/2022)
        public IEnumerable<dynamic> GetRecordByID(Guid recordID);

        /// <summary>
        /// Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: NDQuang (17/08/2022)
        public string GetNewRecordCode();

        /// <summary>
        /// Kiểm tra trùng mã nhân viên 
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: NDQuang (17/08/2022)
        public string CheckDuplicateRecordCode(string recordCode);
    }
}
