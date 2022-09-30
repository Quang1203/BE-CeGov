using MISA.CeGov.Web07.GD.NDQuang.API;
using MISA.CeGov.Web07.GD.NDQuang.API.Core;
using MISA.CeGov.Web07.GD.NDQuang.Common.Entity.DTO;
using MISA.CeGov.Web07.GD.NDQuang.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CeGov.Web07.GD.NDQuang.Infrastructure
{
    public class BaseService<T> : IBaseService<T>
    {
        #region Field
        private IBaseRepository<T> _baseRepository;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        #endregion

        public string CheckDuplicateRecordCode(string recordCode)
        {
            return _baseRepository.CheckDuplicateRecordCode(recordCode);
        }

        public int DeleteEmployeeByID(Guid recordID)
        {
            return _baseRepository.DeleteEmployeeByID(recordID);
        }

        public PagingData<dynamic> FilterRecords(string? keyword, int pageSize, int pageNumber)
        {
            return _baseRepository.FilterRecords(keyword, pageSize, pageNumber);
        }

        public IEnumerable<dynamic> GetAllRecords()
        {
            return _baseRepository.GetAllRecords();
        }

        public IEnumerable<dynamic> GetRecordByID(Guid recordID)
        {
            return _baseRepository.GetRecordByID(recordID);
        }

        public string GetNewRecordCode()
        {
            return _baseRepository.GetNewRecordCode();
        }

        public Guid InsertOneRecord(T record)
        {
            return _baseRepository.InsertOneRecord(record);
        }

        public Guid UpdateOneRecord(Guid recordID, T record)
        {
            return _baseRepository.UpdateOneRecord(recordID, record);
        }
    }
}