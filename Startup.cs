using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Institute.CustomAuthorization;
using Institute.Data;
using Institute.Model;
using Institute.Repository.FileManager;
using Institute.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Institute
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //SqlServer Database Connection
            services.AddDbContext<InstituteContext>(opt =>
           opt.UseSqlServer(Configuration.
           GetConnectionString("InstituteConnection")));

            //Conecting User to the Data Context
            services.AddIdentity<ApplicationUser, IdentityRole<string>>
                (options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<InstituteContext>();

            //Configuring JwtBearerTokenSetting Depency injection to the se
            services.Configure<JwtBearerTokenSetting>
                (Configuration.GetSection("JwtBearerTokenSetting"));
            services.Configure<NativeUser>
                (Configuration.GetSection("NativeUserData"));
            
            //adding authentication schemes to the services
            services.AddAuthentication(options => 
            { options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
            })
                .AddJwtBearer(opts =>
            {
                opts.RequireHttpsMetadata = false;
                opts.SaveToken = true;
                var jwtSection = Configuration
                    .GetSection("JwtBearerTokenSetting");
                var jwtBearerTokenSettings = jwtSection
                    .Get<JwtBearerTokenSetting>();
                opts.TokenValidationParameters = 
                    new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtBearerTokenSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtBearerTokenSettings.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = jwtBearerTokenSettings.SecurityKey,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            //Adding Custom Authorization
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("TutorCourseCheck", policy =>
                {
                    policy.Requirements.Add(new TutorCourseRequriements());
                });
                opts.AddPolicy("TestAuthorCheck", policy =>
                 {
                     policy.Requirements.Add(new TestAuthorRequirements());
                 });
                opts.AddPolicy("QuestionAuthorCheck", policy =>
                 {
                     policy.Requirements.Add();
                 });
            });

            //Adding Cntrollers
            services.AddControllers().AddNewtonsoftJson(s => 
            { s.SerializerSettings.ContractResolver 
                = new CamelCasePropertyNamesContractResolver(); });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Dependency Injection for IInstituteRepo
            services.AddScoped<IInstituteDataRepoCRUD, DbContextData>();
            services.AddScoped<IFileManager, DefaultFileManager>();
            services.AddScoped
                <IAuthorizationHandler, TutorCourseAuthorizationHandler>();
            services.AddScoped
                <IAuthorizationHandler, CoursePreTestAuthorizationHandler>();
            services.AddScoped
                <IAuthorizationHandler, CoursePostTestAuthorizationHandler>();
            services.AddScoped
                <IAuthorizationHandler, ChapterPreTestAuthorizationHandler>();
            services.AddScoped
                <IAuthorizationHandler, ChapterPostTestAuthorizationHandler>();
            services.AddScoped
                <IAuthorizationHandler, LessonPreTestAuthorizationHandler>();
            services.AddScoped
                <IAuthorizationHandler, LessonPostTestAuthorizationHandler>();

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

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
