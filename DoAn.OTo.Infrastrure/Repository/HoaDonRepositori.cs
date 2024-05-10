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
    public class HoaDonRepositori : BaseRepository<HoaDon>, IHoaDonRepository
    {
        public async Task<IEnumerable<HoaDon>> GetPage(int page, int pageSize)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var offset = (page - 1) * pageSize;
                var query = $"SELECT * FROM HoaDon LIMIT @PageSize OFFSET @Offset";
                return await SqlConnection.QueryAsync<HoaDon>(query, new { PageSize = pageSize, Offset = offset });
            }
        }
    }
}
