using MeasurementsWebAPI.BusinessLogic.Models;
using MeasurementsWebAPI.BusinessManager;
using MeasurementsWebAPI.DataAccess.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementsTests.BusinessLogic
{
    public class AtmBusinessManagerTests
    {
        [Fact]
        public async Task Delete_ValidId_ReturnsDeletedAtm()
        {
            // Arrange
            int atmId = 1;
            var repositoryMock = new Mock<IRepository<Atm>>();
            repositoryMock.Setup(repo => repo.Delete(atmId)).ReturnsAsync(new Atm { Id = atmId });

            var atmBusinessManager = new AtmBusinessManager(repositoryMock.Object);

            // Act
            var result = await atmBusinessManager.Delete(atmId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(atmId, result.Id);
        }

        [Fact]
        public async Task Get_ValidId_ReturnsAtm()
        {
            // Arrange
            int atmId = 1;
            var repositoryMock = new Mock<IRepository<Atm>>();
            repositoryMock.Setup(repo => repo.Get(atmId)).ReturnsAsync(new Atm { Id = atmId });

            var atmBusinessManager = new AtmBusinessManager(repositoryMock.Object);

            // Act
            var result = await atmBusinessManager.Get(atmId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(atmId, result.Id);
        }

        [Fact]
        public async Task GetAll_ReturnsListOfAtms()
        {
            // Arrange
            var atms = new List<Atm>
            {
                new Atm { Id = 1 },
                new Atm { Id = 2 }
            };
            var repositoryMock = new Mock<IRepository<Atm>>();
            repositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(atms);

            var atmBusinessManager = new AtmBusinessManager(repositoryMock.Object);

            // Act
            var result = await atmBusinessManager.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(atms.Count, result.Count());
        }

        [Fact]
        public async Task Insert_ValidAtm_ReturnsInsertedAtm()
        {
            // Arrange
            var newAtm = new Atm { Id = 1 };
            var repositoryMock = new Mock<IRepository<Atm>>();
            repositoryMock.Setup(repo => repo.Insert(newAtm,x=>x.Id)).ReturnsAsync(newAtm);

            var atmBusinessManager = new AtmBusinessManager(repositoryMock.Object);

            // Act
            var result = await atmBusinessManager.Insert(newAtm);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newAtm.Id, result.Id);
        }

        [Fact]
        public async Task Update_ValidAtm_ReturnsUpdatedAtm()
        {
            // Arrange
            var updatedAtm = new Atm { Id = 1 };
            var repositoryMock = new Mock<IRepository<Atm>>();
            repositoryMock.Setup(repo => repo.Update(updatedAtm)).ReturnsAsync(updatedAtm);

            var atmBusinessManager = new AtmBusinessManager(repositoryMock.Object);

            // Act
            var result = await atmBusinessManager.Update(updatedAtm);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedAtm.Id, result.Id);
        }
    }
}
