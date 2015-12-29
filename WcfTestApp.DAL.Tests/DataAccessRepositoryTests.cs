using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfTestApp.DAL.DataAccess;
using WcfTestApp.Domain.Models;

namespace WcfTestApp.DAL.Tests
{
    /// <summary>
    /// Вид наименования:
    /// TestMethod_ExpectedData_WhatMustReturn
    /// Где:
    /// TestMethod     - Тестируемый метод.
    /// ExpectedData   - Ожидаемые данные.
    /// WhatMustReturn - Что должен вернуть.
    /// В каждом тесте по 3 блока, где:
    /// Arrange - инициализация начальных данных.
    /// Act     - действия.
    /// Assert  - проверки ожидаемых результатов.
    /// </summary>
    [TestClass]
    public class DataAccessRepositoryTests
    {
        /// <summary>
        /// Инициализировать репозиторий значениями.
        /// </summary>
        public void InitUserRepository(EntityWithNameRepository<User> repository)
        {
            var user1 = new User { Name = "User1", Email = "f@f.ru"};
            var user2 = new User { Name = "User2", Email = "y@f.ru" };
            repository.Add(user1);
            repository.Add(user2);
        }

        [TestMethod]
        public void Add_UserData_SaveChanges()
        {
            // Arrange
            var userName = "Иннокентий Иванов";
            var email = "fff@f.ru";
            var user = new User { Name = userName, Email = email };
            var context = new ServiceContext();
            var unitOfWork = new UnitOfWork(context);
            var userRepository = new EntityWithNameRepository<User>(context);

            // Act
            userRepository.Add(user);
            unitOfWork.SaveChanges();

            // Assert
            var newUser = userRepository.GetByName(userName);
            Assert.IsTrue(newUser != null);
            Assert.IsTrue(newUser.Name == user.Name);
            Assert.IsTrue(newUser.Email == user.Email);
        }

        [TestMethod]
        public void Delete_UserData_SaveChanges()
        {
            // Arrange
            var context = new ServiceContext();
            var unitOfWork = new UnitOfWork(context);
            var userRepository = new EntityWithNameRepository<User>(context);
            InitUserRepository(userRepository);
            unitOfWork.SaveChanges();

            // Act
            var deleteUser = userRepository.GetAll().First();
            userRepository.Delete(deleteUser);
            unitOfWork.SaveChanges();

            // Assert
            var newUser = userRepository.Get(x => x.Id == deleteUser.Id);
            Assert.IsTrue(newUser == null);
        }

        [TestMethod]
        public void Edit_UserData_SaveChanges()
        {
            // Arrange
            var someName = "OtherName";
            var email = "fff@f.ru";
            var context = new ServiceContext();
            var unitOfWork = new UnitOfWork(context);
            var userRepository = new EntityWithNameRepository<User>(context);
            InitUserRepository(userRepository);
            unitOfWork.SaveChanges();

            // Act
            var editUser = userRepository.GetAll().First();
            editUser.Name = someName;
            editUser.Email = email;
            unitOfWork.SaveChanges();

            // Assert
            var newUser = userRepository.Get(x => x.Id == editUser.Id);
            Assert.IsTrue(newUser != null);
            Assert.IsTrue(editUser.Name == someName);
            Assert.IsTrue(editUser.Email == email);
        }
    }
}
