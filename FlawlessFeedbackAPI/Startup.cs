using FlawlessFeedbackAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.Text;

namespace FlawlessFeedbackAPI
{
    public class Startup
    {
        private string connStringToUse = "";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // If we are running in Debug mode, get the name of the PC and change Conn string to match
            // The database hosted on that machine
#if DEBUG
            services.AddDbContext<FFDBContext>(opts =>
            opts.UseSqlServer(Configuration.GetConnectionString(GetPCName())));
#else
             services.AddDbContext<FFDBContext>(opts =>
            opts.UseSqlServer(Configuration.GetConnectionString("FlawlessFeedbackLocal")));
#endif

            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson(opts => opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen();

            /*
           * Sets up the Token comparison and validation.
           * Also sets up the requirement for authentication
           */
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                // Only accepts data over a HTTPS connection - Extra security
                options.RequireHttpsMetadata = false;
                // Saves the token in memory for a short time - prevents the need to reauthenticate all the time
                options.SaveToken = true;

                // Token parameters
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    // Get the Audience and issuer from the Appsettings file
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    // Gets the Key from the App settings file
                    // Converts the key into a byte array
                    // Then generate a key from the byte array
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flawless Feedback API V1");
            });

            app.UseRouting();

            // Enable authentication
            // Must be set up before Authorization
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Gets the name of the current PC and returns the connection string for that matching PC
        /// </summary>
        /// <returns>String - Connection String</returns>
        private string GetPCName()
        {
            string currentPCName = Environment.MachineName; // Gets the current machine name
            const string laptopName = "ELLIOT-HPENVY-T"; // Constant string value for the Laptop
            const string desktopName = "ELLIOT-PC"; // Constant string value for the PC

            switch (currentPCName)
            {
                case laptopName:
                    connStringToUse = "FlawlessFeedbackLocal";
                    break;

                case desktopName:
                    connStringToUse = "FlawlessFeedbackPC";
                    break;

                default:
                    connStringToUse = "FlawlessFeedbackAzure";
                    break;
            }

            return connStringToUse;
        }
    }
}