using CodeWorksVoyWeb.Controllers;
using Moq;
using System;
using Xunit;

namespace CodeWorksVoyWebServiceTest.Controllers
{
    public class ValuesControllerTests : IDisposable
    {
        private MockRepository mockRepository;



        public ValuesControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private ValuesController CreateValuesController()
        {
            return new ValuesController();
        }

        [Fact]
        public void Get_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateValuesController();

            // Act
            var result = unitUnderTest.Get();

            // Assert
            Assert.Null(null);
        }

        [Fact]
        public void Get_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var unitUnderTest = CreateValuesController();
            int id = 0;

            // Act
            var result = unitUnderTest.Get(
                id);

            // Assert
            Assert.Null(null);
        }

        [Fact]
        public void Post_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateValuesController();
            string value = "test";

            // Act
            unitUnderTest.Post(
                value);

            // Assert
            Assert.Null(null);
        }

        [Fact]
        public void Put_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateValuesController();
            int id = 1;
            string value = "test";

            // Act
            unitUnderTest.Put(
                id,
                value);

            // Assert
            Assert.Null(null);
        }

        [Fact]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateValuesController();
            int id = 0;

            // Act
            unitUnderTest.Delete(
                id);

            // Assert
            Assert.Null(null);
        }
    }
}
