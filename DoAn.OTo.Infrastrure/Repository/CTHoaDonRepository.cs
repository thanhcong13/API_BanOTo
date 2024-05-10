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
    public class CTHoaDonRepository : BaseRepository<CTHoaDon>, ICTHoaDonRepository
    {
        public async Task<IEnumerable<CTHoaDon>> GetPage(int page, int pageSize)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var offset = (page - 1) * pageSize;
                var query = $"SELECT * FROM CTHoaDon LIMIT @PageSize OFFSET @Offset";
                return await SqlConnection.QueryAsync<CTHoaDon>(query, new { PageSize = pageSize, Offset = offset });
            }
        }
    }
}
