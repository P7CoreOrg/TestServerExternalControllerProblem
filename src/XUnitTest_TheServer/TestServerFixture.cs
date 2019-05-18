using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;

namespace XUnitTest_TheServer
{
    public class TestServerFixture<TStartup> 
        where TStartup : class
    {
        private string _environmentUrl;
        public bool IsUsingInProcTestServer { get; set; }

        public HttpMessageHandler MessageHandler { get; }
        protected TestServer _testServer { get; }

        protected string RelativePathToHostProject => @"..\..\..\..\TestServerExternalControllerProblem";

        public TestServerFixture()
        {
            var contentRootPath = GetContentRootPath();
            var builder = new WebHostBuilder();

            builder.UseContentRoot(contentRootPath)
                .UseEnvironment("Development");
           

            builder.UseStartup<TStartup>(); // Uses Start up class from your API Host project to configure the test server

            _testServer = new TestServer(builder);

            MessageHandler = _testServer.CreateHandler();

        }






        public HttpClient Client => _testServer.CreateClient();

        private string GetContentRootPath()
        {
            var testProjectPath = PlatformServices.Default.Application.ApplicationBasePath;
            return Path.Combine(testProjectPath, RelativePathToHostProject);
        }

    }
}