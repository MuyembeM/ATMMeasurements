using MeasurementsModels.Dtos;
using MeasurementsWebAPI.BusinessLogic.Interfaces;
using MeasurementsWebAPI.BusinessLogic.Models;
using MeasurementsWebAPI.ServiceAPI.Controllers;
using MeasurementsWebAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementsTests.Controllers
{
    public class AtmControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOkResult_WithAtmDtos()
        {
            // Arrange
            var atmList = new List<Atm>
            {
                new Atm(){Id=1,Description="NCR1",Length=100,Width=100,Height=100},
                new Atm(){Id=2,Description="NCR2",Length=200,Width=200,Height=200},
                new Atm(){Id=3,Description="NCR3",Length=300,Width=300,Height=300}
            };
            var mockBusinessManager = new Mock<IAtmBusinessManager>();
            mockBusinessManager.Setup(manager => manager.GetAll()).ReturnsAsync(atmList);
            var controller = new AtmController(mockBusinessManager.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var atmDtos = Assert.IsType<List<AtmDto>>(okResult.Value);
            Assert.NotEmpty(atmDtos); 
        }

        [Fact]
        public async Task Get_ExistingId_ReturnsOkResult_WithAtmDto()
        {
            // Arrange
            int atmId = 1;
            var returnedAtm = new Atm { Id = 1, Description = "NCR", Length = 200, Width = 200, Height = 200 };
            var mockBusinessManager = new Mock<IAtmBusinessManager>();
            mockBusinessManager.Setup(manager => manager.Get(atmId)).ReturnsAsync(returnedAtm);
            var controller = new AtmController(mockBusinessManager.Object);

            // Act
            var result = await controller.Get(atmId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var atmDto = Assert.IsType<AtmDto>(okResult.Value);
            Assert.Equal(atmId, atmDto.Id);
        }

        [Fact]
        public async Task Post_ValidAtmDto_ReturnsOkResult_WithNewAtmDto()
        {
            // Arrange
            var mockBusinessManager = new Mock<IAtmBusinessManager>();
            var newAtmId = 2; // ID of the newly inserted ATM
            var validAtmDto = new AtmDto { Description="NCR",Length=200,Width=200,Height=200 };
            var insertedAtm = new Atm { Id = newAtmId, Description = "NCR", Length = 200, Width = 200, Height = 200 };

            mockBusinessManager.Setup(manager => manager.Insert(It.IsAny<Atm>()))
                               .ReturnsAsync(insertedAtm);

            var controller = new AtmController(mockBusinessManager.Object);

            // Act
            var result = await controller.Post(validAtmDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var newAtmDto = Assert.IsType<AtmDto>(okResult.Value);

            Assert.Equal(newAtmId, newAtmDto.Id); // Validate the returned ATM ID
            
        }

        [Fact]
        public async Task Patch_ValidAtmDto_ReturnsOkResult_WithUpdatedAtmDto()
        {
            // Arrange
            var mockBusinessManager = new Mock<IAtmBusinessManager>();
            var updatedAtmId = 1; 
            var validAtmDto = new AtmDto { Id = 1, Description = "NCR", Length = 200, Width = 200, Height = 200 };
            var updatedAtm = new Atm { Id = updatedAtmId, Description = "NCR", Length = 200, Width = 200, Height = 200 };

            mockBusinessManager.Setup(manager => manager.Update(It.IsAny<Atm>()))
                               .ReturnsAsync(updatedAtm);

            var controller = new AtmController(mockBusinessManager.Object);

            // Act
            var result = await controller.Patch(updatedAtmId, validAtmDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var updatedAtmDto = Assert.IsType<AtmDto>(okResult.Value);

            Assert.Equal(updatedAtmId, updatedAtmDto.Id); 
            // Add more assertions based on your requirements
        }

        [Fact]
        public async Task Delete_ExistingId_ReturnsOkResult_WithDeletedAtmDto()
        {
            // Arrange
            int atmId = 1;
            var mockBusinessManager = new Mock<IAtmBusinessManager>();
            mockBusinessManager.Setup(manager => manager.Delete(atmId)).ReturnsAsync(new Atm() { Id = 1});
            var controller = new AtmController(mockBusinessManager.Object);

            // Act
            var result = await controller.Delete(atmId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var atmDto = Assert.IsType<AtmDto>(okResult.Value);
            Assert.Equal(atmId, atmDto.Id); 
        }
    }
}
