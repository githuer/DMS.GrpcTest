using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.GrpcTest.Protocol;
using DMS.GrpcTest.ProtocolImpl;
using Grpc.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DMS.GrpcTest.Webapi
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
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            });
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            Start();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static Server _server;
        public static void Start()
        {
            _server = new Server
            {
                Services = { MsgService.BindService(new MsgServiceImpl()) },
                Ports = { new ServerPort("localhost", 40001, ServerCredentials.Insecure) }
            };
            _server.Start();
        }
    }
}
