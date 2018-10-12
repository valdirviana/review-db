using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ReviewDB.BackgroundTasks.Jobs;

namespace ReviewDB.BackgroundTasks
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(x => x.UseSqlServerStorage("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=ReviewDB;"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=ReviewDB;");

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //BackgroundJob.Enqueue(() => new MovieJob().MovieJobInserted());
            BackgroundJob.Schedule(() => new MovieJob().MovieJobInserted(), TimeSpan.FromSeconds(5));
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Minutely Job"), Cron.Minutely);
            var id = BackgroundJob.Enqueue(() => Console.WriteLine("Hello, "));
            BackgroundJob.ContinueWith(id, () => Console.WriteLine("world!"));

            var jobFireForget = BackgroundJob.Enqueue(() => Console.WriteLine($"Fire and forget: {DateTime.Now}"));
            var jobDelayed = BackgroundJob.Schedule(() => Console.WriteLine($"Delayed: {DateTime.Now}"), TimeSpan.FromSeconds(30));
            BackgroundJob.ContinueWith(jobDelayed, () => Console.WriteLine($"Continuation: {DateTime.Now}"));
            RecurringJob.AddOrUpdate(() => Console.WriteLine($"Recurring: {DateTime.Now}"), Cron.Minutely);
        }
    }
}
