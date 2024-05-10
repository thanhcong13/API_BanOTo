using Dapper;
using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using MySql.Data.MySqlClient;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DoAn.OTo.Infrastrure.Repository
{
    public class GroupsRepository : BaseRepository<Groups>, IGroupsReporitory
    {
        public int Delete(string GID)
        {
            using (SqlConnection = new MySqlConnector.MySqlConnection(ConnectionString))
            {
                var sqlCommand = $"DELETE FROM Groups WHERE GID = @GID";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@GID", GID);
                var res = SqlConnection.Execute(sqlCommand, param: parameters);
                return res;
            }
        }

        public async Task<IEnumerable<Groups>> GetPage(int page, int pageSize)
        {
            using (SqlConnection = new MySqlConnector.MySqlConnection(ConnectionString))
            {
                var offset = (page - 1) * pageSize;
                var query = $"SELECT * FROM Groups LIMIT @PageSize OFFSET @Offset";
                return await SqlConnection.QueryAsync<Groups>(query, new { PageSize = pageSize, Offset = offset });
            }
        }

        public int Update(Groups group, string GID)
        {
            using (SqlConnection = new MySqlConnector.MySqlConnection(ConnectionString))
            {
                // Mở kết nối đến cơ sở dữ liệu
                
                // Chuỗi truy vấn SQL
                var sqlCommand = "UPDATE Groups SET Name = @Name WHERE GID = @GID";

                // Tham số động
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", group.Name);
                parameters.Add("@GID", GID);

                // Thực thi truy vấn và trả về số lượng bản ghi đã được cập nhật
                var result = SqlConnection.Execute(sqlCommand, parameters);

                // Trả về kết quả cho client
                return result;
            }
        }
    }
}
