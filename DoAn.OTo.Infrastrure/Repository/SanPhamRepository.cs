using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Dapper;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Entities;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DoAn.OTo.Infrastrure.Repository
{
    public class SanPhamRepository : BaseRepository<SanPham>, ISanPhamRepository
    {
        public IEnumerable<SanPham> GetByHang(Guid MaHang)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var sqlCommand = $"SELECT * FROM SanPham WHERE MaHang= @MaHang";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MaHang", MaHang);
                var product = SqlConnection.Query<SanPham>(sqlCommand, param: parameters);
                return product;
            }
        }

        public IEnumerable<SanPham> GetByMaCH(Guid MaCH)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var sqlCommand = $"SELECT * FROM SanPham WHERE MaCH= @MaCH";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MaCH", MaCH);
                var product = SqlConnection.Query<SanPham>(sqlCommand, param: parameters);
                return product;
            }
        }

        /* public override int Delete(Guid MaSP)
         {
             using (SqlConnection = new MySqlConnection(ConnectionString))
             {
                 var sqlCommand = $"DELETE FROM SanPham WHERE MaSP = @productID";
                 DynamicParameters parameters = new DynamicParameters();
                 parameters.Add("@productID", MaSP);
                 var res = SqlConnection.Execute(sqlCommand, param: parameters);
                 return res;
             }
         }*/

        public IEnumerable<SanPham> GetByName(string name)
        {
            using(SqlConnection= new MySqlConnection(ConnectionString))
            {
                var sqlCommand = $"SELECT * FROM SanPham WHERE TenSP= @nameProduct";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nameProduct", name);
                var product = SqlConnection.Query<SanPham>(sqlCommand, param: parameters);
                return product;
            }
            
        }

        public async Task<IEnumerable<SanPham>> GetPage(int page, int pageSize)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var offset = (page - 1) * pageSize;
                var query = $"SELECT * FROM SanPham LIMIT @PageSize OFFSET @Offset";
                return await SqlConnection.QueryAsync<SanPham>(query, new { PageSize = pageSize, Offset = offset });
            }
                
        }
    }
}
