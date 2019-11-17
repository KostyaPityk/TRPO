using System;
using Mock;
using NUnit.Framework;

namespace UnitTestProjectForLab5
{
    [TestFixture]
    public class UserSecurityTest
    {
        private User user;
        private Mock<UserDataService> dataService;
        private Mock<CridentialsManager> cridentialsManager;

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
        }

        [Test]
        public void CridentialsManager_PassAllPointWheUserExist_ValidResult()
        {
            CridentialsManager credentials = new CridentialsManager("test login", "password");
            this.dataService.getUser(credentials).Return(this.user);
            this.cridentialsManager.SetDataService(this.dataService.objct);

            bool isValidCredentials = this.cridentialsManager.CheckUserCredentials(credentials);

            Assert.IsTrue(isValidCredentials);
        }

        [Test]
        public void CridentialsManager_FailSamePointWheUserExist_EmptyResult()
        {
            CridentialsManager credentials = new CridentialsManager("test login", "password");
            this.dataService.getUser(credentials).Return(null);
            this.cridentialsManager.SetDataService(this.dataService.objct);

            bool isValidCredentials = this.cridentialsManager.CheckUserCredentials(credentials);

            Assert.IsFalse(isValidCredentials);
        }
    }
}
