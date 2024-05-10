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
    public class HinhAnhRepository : BaseRepository<HinhAnh>, IHinhAnhRepository
    {
        public async Task<IEnumerable<HinhAnh>> GetPage(int page, int pageSize)
        {

            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var offset = (page - 1) * pageSize;
                var query = $"SELECT * FROM HinhAnh LIMIT @PageSize OFFSET @Offset";
                return await SqlConnection.QueryAsync<HinhAnh>(query, new { PageSize = pageSize, Offset = offset });
            }
        }
    }
}
