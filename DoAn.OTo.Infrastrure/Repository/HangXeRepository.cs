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
    public class HangXeRepository : BaseRepository<HangXe>, IHangXeRepository
    {
        public async Task<IEnumerable<HangXe>> GetPage(int page, int pageSize)
        {
            using (SqlConnection = new MySqlConnector.MySqlConnection(ConnectionString))
            {
                var offset = (page - 1) * pageSize;
                var query = $"SELECT * FROM HangXe LIMIT @PageSize OFFSET @Offset";
                return await SqlConnection.QueryAsync<HangXe>(query, new { PageSize = pageSize, Offset = offset });
            }
        }
    }
}
