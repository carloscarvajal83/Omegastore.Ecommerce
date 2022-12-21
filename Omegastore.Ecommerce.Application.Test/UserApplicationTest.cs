using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Omegastore.Ecommerce.Application.Interfaces;
using Omegastore.Ecommerce.Services.WebApi;
using System.IO;

namespace Omegastore.Ecommerce.Application.Test
{
    [TestClass]
    public class UserApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _serviceScopeFactory;


        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();
            _configuration = builder.Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            _serviceScopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void Authenticate_WhenNoParametersSent_ReturnValidationErrorMessage()
        {
            // Arrange
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserApplication>();
            var userName = "";
            var password = "";
            var expected = "Validation Errors";
            
            // Act
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            //Assert: Check
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_WhenWrongParametersSent_ReturnValidationErrorMessage()
        {
            // Arrange
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserApplication>();
            var userName = "juan";
            var password = "password";
            var expected = "Wrong user or password";

            // Act
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            //Assert: Check
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_WhenRigthParametersSent_ReturnValidationErrorMessage()
        {
            // Arrange
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserApplication>();
            var userName = "jcarrillo";
            var password = "123456";
            var expected = "Successfully logged in";

            // Act
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            //Assert: Check
            Assert.AreEqual(expected, actual);
        }
    }
}
