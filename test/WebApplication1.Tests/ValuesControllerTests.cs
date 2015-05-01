using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.TestHost;
using Microsoft.Framework.DependencyInjection;
using System.Net;
using Xunit;

namespace WebApplication1.Tests
{
    public class ValuesControllerTests
    {
        [Fact]
        public async void GetShouldReturnTwoValues()
        {
            var server = TestServer.Create(app =>
            {
                var env = app.ApplicationServices.GetRequiredService<IHostingEnvironment>();
                new Startup(env).Configure(app, env);
            }, services => services.AddMvc());

            var result = await server.CreateClient().GetAsync("api/values/");

            Assert.True(result.IsSuccessStatusCode);
        }
    }
}
