using Dapper;
using MISA.CeGov.Web07.GD.NDQuang.API;
using MISA.CeGov.Web07.GD.NDQuang.API.Core;
using MISA.CeGov.Web07.GD.NDQuang.Common.Entity.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CeGov.Web07.GD.NDQuang.Infrastructure
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        public string CheckDuplicateRecordCode(string recordCode)
        {
            throw new NotImplementedException();
        }

        public int DeleteEmployeeByID(Guid recordID)
        {
            throw new NotImplementedException();
        }

        public PagingData<dynamic> FilterRecords(string? keyword, int pageSize, int pageNumber)
        {
            var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);
            string v_Where = "1=1";
            string v_Sort = "EmulationTitleCode DESC";
            int v_Limit = -1;
            int v_Offset = 0;
            // Chuẩn bị câu filter Query
            string className = typeof(T).Name.ToLower();
            string classNameH = typeof(T).Name;
            var orConditions = new List<string>();
            var andConditions = new List<string>();
            string whereClause = "";

            if (keyword != null)
            {
                orConditions.Add($"EmployeeCode LIKE '%{keyword}%'");
                orConditions.Add($"EmployeeName LIKE '%{keyword}%'");
                orConditions.Add($"TelNumber LIKE '%{keyword}%'");
            }
            if (orConditions.Count > 0)
            {
                whereClause = $"({string.Join(" OR ", orConditions)})";
            }
            if (andConditions.Count > 0)
            {
                whereClause += $" AND {string.Join(" AND ", andConditions)}";
            }
            
            if(whereClause.Length > 0)
            {
                v_Where = whereClause;

            }


            if (pageSize > 0)
            {
                v_Limit = pageSize;
            }
            if(pageNumber > 0)
            {
                v_Offset = (pageNumber - 1) * pageSize;
            }
            string filterQuery = $"SELECT * FROM {className} WHERE {v_Where} ORDER BY {v_Sort} LIMIT {v_Offset} , {v_Limit}";

            var multipleResults = mySqlConnection.QueryMultiple(filterQuery);

            var records = multipleResults.Read<dynamic>().ToList();

            string filterQuery2 = $"SELECT count({classNameH}ID) FROM {className} WHERE {v_Where}";
            var multipleResults2 = mySqlConnection.QueryMultiple(filterQuery2);
            var totalCount = multipleResults2.Read<long>().Single();
            return new PagingData<dynamic>()
            {
                Data = records,
                TotalCount = totalCount
            };
        }

        /// <summary>
        /// Lấy tất cả bản ghi  
        /// </summary>
        /// <returns>Trả về tất cả bản ghi</returns>
        /// Created by: NDQuang (23/08/2022)
        public virtual IEnumerable<dynamic> GetAllRecords()
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {

                // Chuẩn bị storedProcedureName 
                string className = typeof(T).Name.ToLower();
                string employeeCommand = $"SELECT * FROM {className};";


                // Thực hiện gọi vào DB để chạy stored procedure 
                var multipleResults = mySqlConnection.Query(employeeCommand);


                return (IEnumerable<dynamic>)multipleResults;
            }
        }

        public IEnumerable<dynamic> GetRecordByID(Guid recordID)
        {
            throw new NotImplementedException();
        }

        public string GetNewRecordCode()
        {
            throw new NotImplementedException();
        }

        public Guid InsertOneRecord(T record)
        {
            throw new NotImplementedException();
        }

        public Guid UpdateOneRecord(Guid recordID, T record)
        {
            throw new NotImplementedException();
        }
    }
}
