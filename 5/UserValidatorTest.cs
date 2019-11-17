using System;
using NUnit.Framework;

namespace UnitTestProjectForLab5
{
    [TestFixture]
    public class UserValidatorTest
    {
        private Validator<User> validator = new Validator<User>();
        private User user;

        [Test]
       public void Validator_NotEmptyObj_ValidResult()
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
            bool isValid = validator.Validate(this.user);
            Assert.IsTrue(isValid);
        }

        [TestCase(new User() { FirstName = null, LastName = "Test 1", MiddleName = "Test", BirthDate = new DateTime(), Login = "Login", Password = "Test", Email = "tt@mail.ru" })]
        [TestCase(new User() { FirstName = "Test", LastName = null, MiddleName = "Test", BirthDate = new DateTime(), Login = "Login", Password = "Test", Email = "tt@mail.ru" })]
        [TestCase(new User() { FirstName = "Test", LastName = "Test 1", MiddleName = null, BirthDate = new DateTime(), Login = "Login", Password = "Test", Email = "tt@mail.ru" })]
        [TestCase(new User() { FirstName = "Test", LastName = "Test 1", MiddleName = "Test", BirthDate = new DateTime(), Login = null, Password = "Test", Email = "tt@mail.ru" })]
        [TestCase(new User() { FirstName = "Test", LastName = "Test 1", MiddleName = "Test", BirthDate = new DateTime(), Login = "Login", Password = null, Email = "tt@mail.ru" })]
        [TestCase(new User() { FirstName = "Test", LastName = "Test 1", MiddleName = "Test", BirthDate = new DateTime(), Login = "Login", Password = "Test", Email = null })]
        public void Validator_EmptyParametr_InValidResult(User user)
             => Assert.Throws(typeof(NullReferenceException), () => validator.Validate(user));     
    }
}
