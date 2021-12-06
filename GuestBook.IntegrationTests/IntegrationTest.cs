using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using GuestBook.Contracts.v1.Request;
using GuestBook.Contracts.v1.Response;
using GuestBook.Migrations;
using GuestBook.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Xunit;

namespace GuestBook.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;
        
        public IntegrationTest()
        {
            var appfactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(GuestBookDbContext));
                        services.AddDbContext<GuestBookDbContext>(options =>
                        {
                            options.UseSqlServer("Data Source=178.54.86.113,14330;Initial Catalog=guestbookdb_unit;User ID=SA;Password=19Andrei19");
                        });
                    });

                    /*builder.Configure(app =>
                    {
                        app.UseDeveloperExceptionPage();
                    });*/
                });
            TestClient = appfactory.CreateClient();
        }

        protected async Task<HttpResponseMessage> GetAllNotesAsync()
        {
            return await TestClient.GetAsync(ApiRoutes.Notes.GetAll);
        }
        protected async Task<HttpResponseMessage> CreateNoteAsync(CreateNoteRequest request)
        {
            return await TestClient.PostAsJsonAsync(ApiRoutes.Notes.Create, request);
        }
       
    }
}