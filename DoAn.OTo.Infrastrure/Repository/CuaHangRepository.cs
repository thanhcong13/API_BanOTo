using Dapper;
using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Infrastrure.Repository
{
    public class CuaHangRepository : BaseRepository<CuaHang>, ICuaHangRepository
    {
        public async Task<IEnumerable<CuaHang>> GetPage(int page, int pageSize)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var offset = (page - 1) * pageSize;
                var query = $"SELECT * FROM CuaHang LIMIT @PageSize OFFSET @Offset";
                return await SqlConnection.QueryAsync<CuaHang>(query, new { PageSize = pageSize, Offset = offset });
            }
        }
    }
}
