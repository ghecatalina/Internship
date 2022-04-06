using NUnit.Framework;
using System.Collections.Generic;
using TDD;

namespace Testing
{
    [TestFixture]
    public class Tests
    {
        private UserValidation _userValidation;

        [SetUp]
        public void Setup()
        {
            _userValidation = new();
        }

        [Test]
        public void Test1()
        {
        }

        [TestCase]
        public void User_Should_Be_Added_Successfully()
        {
            var user = new User { Name = "Ana", Age = 20, Password = "1234abcdefg" };
            _userValidation = new();

            bool result = _userValidation.Register(user);

            Assert.True(result);
            Assert.Contains(user, UserValidation.GetUsers());
        }

        [TestCase]
        public void User_Should_Be_Older_Than_16()
        {
            Dispose();
            var user = new User { Name = "Ana", Age = 15, Password = "1234abcdefg" };
            UserValidation userRegistrationService = new();

            bool result = _userValidation.Register(user);

            Assert.False(result);
        }

        [TestCase]
        public void Get_Users_Should_Return_All_Users_Saved()
        {
            Dispose();
            var user1 = new User { Age = 20, Name = "Ana", Password = "1234567890" };
            var user2 = new User { Age = 26, Name = "Vlad", Password = "1234567890" };
            _userValidation = new();

            _userValidation.Register(user1);
            _userValidation.Register(user2);

            var result = UserValidation.GetUsers();

            Assert.NotNull(result);
            Assert.IsAssignableFrom<List<User>>(result);
            Assert.AreEqual(2, result.Count);
        }

        public void Dispose()
        {
            UserValidation.UserDatabase = new List<User>();
            _userValidation = new();
        }
    }
}