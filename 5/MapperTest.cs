using System;
using NUnit.Framework;

namespace UnitTestProjectForLab5
{
    [TestFixture]
    public class MapperTest
    {
        private User user;
        private UserDTO userDTO;
        private Mapper mapper;

        [SetUp]
        public void SetUp()
        {
            this.user = new User() { FirstName = "Test", LastName = "Test 1", MiddleName = "Test", BirthDate = new DateTime(), Login = "Login", Password = "Test", Email = "tt@mail.ru" };
            this.userDTO = new UserDTO() { FirstName = "Test", LastName = "Test 1", MiddleName = "Test", BirthDate = new DateTime(), Login = "Login", Password = "Test", Email = "tt@mail.ru" };
        }

        [Test]
        public void UserMapper_ValidUserModel_ValidConvertResult()
        {
            UserDTO mapModel = mapper.ToUserDTOModel(this.user);
            Assert.Equals(mapModel, userDTO);
        }

        [Test]
        public void UserMapper_ValidUserDTOModel_ValidConvertResult()
        {
            User mapUser = mapper.ToUserModel(this.userDTO);
            Assert.Equals(mapUser, this.userDTO);
        }
    }
}
