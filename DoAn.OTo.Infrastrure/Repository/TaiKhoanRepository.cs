using Dapper;
using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Infrastrure.Repository
{
    public class TaiKhoanRepository : BaseRepository<TaiKhoan>, ITaiKhoanRepository
    {
        public int Delete(string TenTaiKhoan)
        {
            using (SqlConnection = new MySqlConnector.MySqlConnection(ConnectionString))
            {
                var sqlCommand = $"DELETE FROM TaiKhoan WHERE TenTaiKhoan = @TenTaiKhoan";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenTaiKhoan", TenTaiKhoan);
                var res = SqlConnection.Execute(sqlCommand, param: parameters);
                return res;
            }
        }

        public async Task<IEnumerable<TaiKhoan>> GetPage(int page, int pageSize)
        {
            using (SqlConnection = new MySqlConnector.MySqlConnection(ConnectionString))
            {
                var offset = (page - 1) * pageSize;
                var query = $"SELECT * FROM TaiKhoan LIMIT @PageSize OFFSET @Offset";
                return await SqlConnection.QueryAsync<TaiKhoan>(query, new { PageSize = pageSize, Offset = offset });
            }
        }

        public int Update(TaiKhoan taikhoan, string TenTaiKhoan)
        {
            using (SqlConnection = new MySqlConnector.MySqlConnection(ConnectionString))
            {
                // Mở kết nối đến cơ sở dữ liệu

                // Chuỗi truy vấn SQL
                var sqlCommand = "UPDATE TaiKhoan SET TenTaiKhoan = @TenTaiKhoan , MatKhau = @MatKhau ,MaNV =@MaNV , GID =@GID  WHERE TenTaiKhoan = @TenTaiKhoan";

                // Tham số động
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenTaiKhoan", taikhoan.TenTaiKhoan);
                parameters.Add("@MatKhau", taikhoan.MatKhau);
                parameters.Add("@MaNV", taikhoan.MaNV);
                parameters.Add("@GID", taikhoan.GID);
                

                // Thực thi truy vấn và trả về số lượng bản ghi đã được cập nhật
                var result = SqlConnection.Execute(sqlCommand, parameters);

                // Trả về kết quả cho client
                return result;
            }
        }
    }
}
