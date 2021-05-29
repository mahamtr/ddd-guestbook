using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Services;
using Moq;
using System;
using Xunit;

namespace CleanArchitecture.UTest
{
    public class UnitTest1
    {
        [Fact]
        public void CompareHashShouldReturnTrueIfHashesMatches()
        {
            //arrange
            var mockRepo = new Mock<IRepository>();
            var authService = new AuthService(mockRepo.Object);

            //act
            var response = authService.CompareHash("10524D1D64BD72AB99C627F5D4CC0FA151B28348552A68F5FBB1B11EE4198146", "10524D1D64BD72AB99C627F5D4CC0FA151B28348552A68F5FBB1B11EE4198146");

            //assert
            Assert.True(response);

        }


        [Fact]
        public void CompareHashShouldReturnFalseIfHashesDoNotMatches()
        {
            //arrange
            var mockRepo = new Mock<IRepository>();
            var authService = new AuthService(mockRepo.Object);

            //act
            var response = authService.CompareHash("10524D1D64BD76AB99C627F5D4CC0FA151B28348552A68F5FBB1B11EE4198146", "10524D1D64BD72AB99C627F5D4CC0FA151B28348f52A68F5FBB1B11EE4198146");

            //assert
            Assert.False(response);

        }
    }
}
