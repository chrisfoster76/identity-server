using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SFA.DAS.Provider.Idams.Stub.Custom;

namespace SFA.DAS.Provider.Idams.Stub
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();
            //JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap = new Dictionary<string, string>();

            //JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "sub");

            //JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();
            //JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Add("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "sub");


            var jwtHandler = new JwtSecurityTokenHandler();
            jwtHandler.InboundClaimTypeMap.Clear();

            services.AddIdentityServer()
                .AddInMemoryClients(Clients.Get())
                .AddInMemoryIdentityResources(Resources.GetIdentityResources())
                .AddTestUsers(Users.Get().AsTestUsers())
                .AddDeveloperSigningCredential();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
