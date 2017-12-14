using System.Text;
using AspNetCoreApplication.Model;
using AspNetCoreApplication.Repository;
using AspNetCoreApplication.Repository.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AspNetCoreApplication {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<AspNetCoreApplicationDbContext> (options => {
                options.UseSqlServer (Configuration.GetConnectionString ("ApplicationConnection"));
            });
            services.AddIdentity<IdentityUser, IdentityRole> ().AddEntityFrameworkStores<AspNetCoreApplicationDbContext> ();
            services.AddMvc ()
                .AddJsonOptions (opt => {
                    opt.SerializerSettings.ReferenceLoopHandling =
                        ReferenceLoopHandling.Ignore;
                });
            var signingKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes ("this is the secret phrase"));
            services.AddAuthentication (options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer (cfg => {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters () {
                    IssuerSigningKey = signingKey,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
            services.AddCors (options => options.AddPolicy ("Cors", builder => {
                builder
                    .AllowAnyOrigin ()
                    .AllowAnyMethod ()
                    .AllowAnyHeader ();
            }));
            services.AddAutoMapper ();
            services.AddScoped<ICampaignRepository, CampaignRepository> ();
            services.AddScoped<ICategoryRepository, CategoryRepository> ();
            services.AddScoped<ITrainingRepository, TrainingRepository> ();
            services.AddScoped<IModalityRepository, ModalityRepository> ();
            services.AddScoped<IBusinessRepository, BusinessRepository> ();
            services.AddScoped<IOrganizationRepository, OrganizationRepository> ();
            services.AddScoped<IContactRepository, ContactRepository> ();
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory) {
            loggerFactory.AddConsole ();
            loggerFactory.AddDebug (LogLevel.Information);
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler (appBuilder => {
                    appBuilder.Run (async context => {
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature> ();
                        if (exceptionHandlerFeature != null) {
                            var logger = loggerFactory.CreateLogger ("Global exception logger");
                            logger.LogError (500,
                                exceptionHandlerFeature.Error,
                                exceptionHandlerFeature.Error.Message);
                        }
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync ("An unexpected fault happened. Try again later.");

                    });
                });
            }
            app.UseAuthentication ();
            app.UseCors ("Cors");
            app.UseHsts (opt => {
                opt.MaxAge (days: 180);
                opt.IncludeSubdomains ();
                opt.Preload ();
            });
            app.UseMvc ();
        }
    }
}