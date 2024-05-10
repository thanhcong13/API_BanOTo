using Dapper;
using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Infrastrure.Repository
{
    public class NhanVienRepository : BaseRepository<NhanVien>, INhanVienRepository
    {
        public int Delete(string MaNV)
        {
            using (SqlConnection = new MySqlConnector.MySqlConnection(ConnectionString))
            {
                var sqlCommand = $"DELETE FROM NhanVien WHERE MaNV = @MaNV";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MaNV", MaNV);
                var res = SqlConnection.Execute(sqlCommand, param: parameters);
                return res;
            }
        }

        public IEnumerable<NhanVien> GetByCH(Guid MaCH)
        {
            using (SqlConnection = new MySqlConnector.MySqlConnection(ConnectionString))
            {
                var sqlCommand = $"SELECT * FROM NhanVien WHERE MaCH = @MaCH";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MaCH", MaCH);
                var res = SqlConnection.Query<NhanVien>(sqlCommand, param: parameters);
                return res;
            }
        }

        public async Task<IEnumerable<NhanVien>> GetPage(int page, int pageSize)
        {
            using (SqlConnection = new MySqlConnector.MySqlConnection(ConnectionString))
            {
                var offset = (page - 1) * pageSize;
                var query = $"SELECT * FROM NhanVien LIMIT @PageSize OFFSET @Offset";
                return await SqlConnection.QueryAsync<NhanVien>(query, new { PageSize = pageSize, Offset = offset });
            }
        }

        public int Update(NhanVien nhanVien, string MaNV)
        {
            using (SqlConnection = new MySqlConnector.MySqlConnection(ConnectionString))
            {
                // Mở kết nối đến cơ sở dữ liệu

                // Chuỗi truy vấn SQL
                var sqlCommand = "UPDATE NhanVien SET TenNV=@TenNV,NgaySinh= @NgaySinh,GioiTinh=@GioiTinh,DiaChi=@DiaChi,SoDT=@SoDT,ChucVu=@ChucVu,MaCH=@MaCH   WHERE MaNV = @MaNV";

                // Tham số động
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MaNV", nhanVien.MaNV);
                parameters.Add("@TenNV", nhanVien.TenNV);
                parameters.Add("@NgaySinh", nhanVien.NgaySinh);
                parameters.Add("@GioiTinh", nhanVien.GioiTinh);
                parameters.Add("@DiaChi", nhanVien.DiaChi);
                parameters.Add("@SoDT", nhanVien.SoDT);
                parameters.Add("@ChucVu", nhanVien.ChucVu);
                parameters.Add("@MaCH", nhanVien.MaCH);
                


                // Thực thi truy vấn và trả về số lượng bản ghi đã được cập nhật
                var result = SqlConnection.Execute(sqlCommand, parameters);

                // Trả về kết quả cho client
                return result;
            }
        }
    }
}
