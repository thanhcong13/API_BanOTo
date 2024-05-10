using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using DoAn.OTo.Core.Services;
using DoAn.OTo.Infrastrure.Repository;

namespace DoAn.OTo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Xử lí  DI : 
            builder.Services.AddScoped<ISanPhamRepository , SanPhamRepository>();
            builder.Services.AddScoped<ISanPhamService , SanPhamService>();

            builder.Services.AddScoped<ICuaHangRepository, CuaHangRepository>();
            builder.Services.AddScoped<ICuaHangService, CuaHangService>();

            builder.Services.AddScoped<IGroupsReporitory, GroupsRepository>();
            builder.Services.AddScoped<IGroupsService, GroupsService>();

            builder.Services.AddScoped<ITaiKhoanRepository, TaiKhoanRepository>();
            builder.Services.AddScoped<ITaiKhoanService, TaiKhoanService>();

            builder.Services.AddScoped<INhanVienRepository, NhanVienRepository>();
            builder.Services.AddScoped<INhanVienService, NhanVienService>();

            builder.Services.AddScoped<IBaoDuongRepository, BaoDuongRepository>();
            builder.Services.AddScoped<IBaoDuongService, BaoDuongService>();

            builder.Services.AddScoped<IHangXeRepository, HangXeRepository>();
            builder.Services.AddScoped<IHangXeService, HangXeService>();

            builder.Services.AddScoped<IHinhAnhRepository, HinhAnhRepository>();
            builder.Services.AddScoped<IHinhAnhService, HinhAnhService>();

            builder.Services.AddScoped<ILaiThuRepository, LaiThuRepository>();
            builder.Services.AddScoped<ILaiThuService, LaiThuService>();

            builder.Services.AddScoped<ILienHeRepository, LienHeRepository>();
            builder.Services.AddScoped<ILienHeService, LienHeService>();

            builder.Services.AddScoped<ICTLienHeRepository, CTLienHeRepository>();
            builder.Services.AddScoped<ICTLienHeService, CTLienHeService>();

            builder.Services.AddScoped<IHoaDonRepository, HoaDonRepositori>();
            builder.Services.AddScoped<IHoaDonService, HoaDonService>();

            builder.Services.AddScoped<ICTHoaDonRepository, CTHoaDonRepository>();
            builder.Services.AddScoped<ICTHoaDonService, CTHoaDonService>();

            builder.Services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
            builder.Services.AddScoped(typeof(IBaseService<>),typeof(BaseService<>));

           
            


            var app = builder.Build();
            app.UseCors(builder =>
             builder
            .WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader());


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}