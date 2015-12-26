using System;
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
        public void InitUserRepository(GenericRepository<User> repository)
        {
            var user1 = new User { Name = "User1" };
            var user2 = new User { Name = "User2" };
            repository.Add(user1);
            repository.Add(user2);
        }

        [TestMethod]
        public void Add_UserData_SaveChanges()
        {
            // Arrange
            var userName = "Иннокентий Иванов";
            var user = new User { Name = userName };
            var context = new ServiceContext();
            var unitOfWork = new UnitOfWork(context);
            var userRepository = new GenericRepository<User>(context);

            // Act
            userRepository.Add(user);
            unitOfWork.SaveChanges();

            // Assert
            var newUser = userRepository.Get(x => x.Name == userName);
            Assert.IsTrue(newUser != null);
            Assert.IsTrue(newUser.Name == user.Name);
        }

        [TestMethod]
        public void Delete_UserData_SaveChanges()
        {
            // Arrange
            var context = new ServiceContext();
            var unitOfWork = new UnitOfWork(context);
            var userRepository = new GenericRepository<User>(context);
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
            var context = new ServiceContext();
            var unitOfWork = new UnitOfWork(context);
            var userRepository = new GenericRepository<User>(context);
            InitUserRepository(userRepository);
            unitOfWork.SaveChanges();

            // Act
            var editUser = userRepository.GetAll().First();
            editUser.Name = someName;
            unitOfWork.SaveChanges();

            // Assert
            var newUser = userRepository.Get(x => x.Id == editUser.Id);
            Assert.IsTrue(newUser != null);
            Assert.IsTrue(editUser.Name == someName);
        }
    }
}
