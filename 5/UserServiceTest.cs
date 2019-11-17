using System;
using NUnit.Framework;

namespace UnitTestProjectForLab5
{
    [TestFixture]
    public class UserServiceTest
    {
        private User user;
        private UserService userService;
        private UserMapper userMapper;
        private Mapper mapper;

        [SetUp]
        public void SetUp()
        {
            user = new User
            {
                FirstName = "Test",
                LastName = "Test 1",
                MiddleName = "Test",
                BirthDate = new DateTime(),
                Login = "Login",
                Password = "Test",
                Email = "tt@mail.ru"
            };

            userService = new UserService(this.user);
            userService.CreateNewUser(this.user);
        }
        
        [Test]
        public void UserService_ValidUserModel_SuccessSaveToDB()
        {
            UserDTO userDTO = mapper.ToUserDTOModel(this.user);
            userDTO.FirstName = "AAAA";

            bool saveResult = this.userService.CreateNewUser(userDTO);

            Assert.IsTrue(saveResult);
            Assert.IsTrue(this.userService.IsUserContainsInDB(this.user));
        }

        [Test]
        public void UserService_ValidUserModel_SuccessEditProfile()
        {
            UserDTO userDTO = mapper.ToUserDTOModel(this.user);
            userDTO.FirstName = "New name";

            bool isUpdateModel = this.userService.UpdateUserInfo(userDTO);

            Assert.IsTrue(isUpdateModel);
            Assert.Equals(this.userService.GetUser(this.user.Id).FirstName, "New name");
        }

        [Test]
        public void UserService_ValidUserModel_SuccessRemoveProfile()
        {
            UserDTO userDTO = mapper.ToUserDTOModel(this.user);

            bool isSuccessRemove = this.userService.RemoveUser(userDTO);

            Assert.IsTrue(isSuccessRemove);
            Assert.IsFalse(this.userService.IsUserContainsInDB(this.user));
        }

        [Test]
        public void UserService_NotValidUserModel_InvalidMassage()
        {
            UserDTO userDTO = mapper.ToUserDTOModel(this.user);
            userDTO.FirstName = null;

            bool saveResult = this.userService.CreateNewUser(userDTO);

            Assert.IsFalse(saveResult);
            Assert.IsFalse(this.userService.IsUserContainsInDB(this.user));
        }

        [Test]
        public void UserService_EqualdUserModelFromExisting_NoUpdate()
        {
            UserDTO userDTO = mapper.ToUserDTOModel(this.user);

            bool isUpdateModel = this.userService.UpdateUserInfo(userDTO);

            Assert.IsFalse(isUpdateModel);
            Assert.Equals(this.userService.GetUser(this.user.Id).FirstName, "Test");
        }

        [Test]
        public void UserService_InvalidUserModel_ErrorRemoveProfile()
        {
            UserDTO userDTO = mapper.ToUserDTOModel(this.user);
            userDTO.Id = 85555;

            bool isSuccessRemove = this.userService.RemoveUser(userDTO);

            Assert.IsFalse(isSuccessRemove);
            Assert.IsTrue(this.userService.IsUserContainsInDB(this.user));
        }
    }
}
