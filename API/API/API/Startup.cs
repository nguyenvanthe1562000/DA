using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using DAL.Helper;
using Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Data.Reponsitory.Interface;
using Data.Reponsitory;
using Model.Model;
using Service.Admin.Service.Interface;
using Service.Admin.Service;
namespace QLBanDoGiaDung_API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebApi API",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                        },
                        new string[] { }
                    }
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
            //services.AddScoped<IPhotoService, PhotoService>();


            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            //services.AddAuthentication(x =>
            //{
            //  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //  x.RequireHttpsMetadata = false;
            //  x.SaveToken = true;
            //  x.TokenValidationParameters = new TokenValidationParameters
            //  {
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = new SymmetricSecurityKey(key),
            //    ValidateIssuer = false,
            //    ValidateAudience = false
            //  };
            //});

         

            services.AddTransient<IDatabaseHelper, DatabaseHelper>();

            services.AddTransient<INhomSanPhamBussiness, NhomSanPhamBussiness>();
            services.AddTransient<INhomSanPhamRepository, NhomSanPhamRepository>();
            services.AddTransient<ILoaiSanPhamBussiness, LoaiSanPhamBussiness>();
            services.AddTransient<ILoaiSanPhamRepository, LoaiSanPhamRepository>();
            services.AddTransient<ISanPhamBussiness, SanPhamBussiness>();
            services.AddTransient<ISanPhamRepository, SanPhamRepository>();
            services.AddTransient<IHangSanPhamBussiness, HangSanPhamBussiness>();
            services.AddTransient<IHangSanPhamRepository, HangSanPhamRepository>();
            services.AddTransient<IDonHangBussiness, DonHangBussiness>();
            services.AddTransient<IDonHangRepository, DonHangRepository>();
            services.AddTransient<INguoiDungBussiness, NguoiDungBussiness>();
            services.AddTransient<INguoiDungRepository, NguoiDungRepository>();
            services.AddTransient<IDiaChiBussiness, DiaChiBussiness>();
            services.AddTransient<IDiaChiRepository, DiaChiRepository>();
  services.AddTransient<ITinTucRepository, TinTucRepository>();
  services.AddTransient<ITinTucService , TinTucService >();
   services.AddTransient<IThongKeBussiness  , ThongKeBussiness  >();
    services.AddTransient<IThongKeRepository  , ThongKeRepository  >();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }
            app.UseCors(x => x
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            app.UseAuthentication();
            app.UseHttpsRedirection();

       app.UseStaticFiles();

                app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
