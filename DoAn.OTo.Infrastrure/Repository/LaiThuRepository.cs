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
    public class LaiThuRepository : BaseRepository<LaiThu>, ILaiThuRepository
    {
        public async Task<IEnumerable<LaiThu>> GetPage(int page, int pageSize)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var offset = (page - 1) * pageSize;
                var query = $"SELECT * FROM LaiThu LIMIT @PageSize OFFSET @Offset";
                return await SqlConnection.QueryAsync<LaiThu>(query, new { PageSize = pageSize, Offset = offset });
            }
        }
    }
}
