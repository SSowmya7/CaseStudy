using AutoMapper;
using CaseStudy.Application.VM;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.DTO;
using CaseStudy.Core.Models;
using CaseStudy.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    public class MenuSettingsControllerTests
    {
        private readonly Mock<IMenuSettingsServices> _mockMenuSettingsServices;
        private readonly Mock<IMapper> _mockMapper;
        private readonly MenuSettingsController _controller;

        public MenuSettingsControllerTests()
        {
            _mockMenuSettingsServices = new Mock<IMenuSettingsServices>();
            _mockMapper = new Mock<IMapper>();
            _controller = new MenuSettingsController(_mockMenuSettingsServices.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetMenuSettings_ShouldReturnOkResultWithMenuSettings()
        {
            // Arrange
            var menuSettings = new List<MenuSettings>
            {
                new MenuSettings { DealerId = 1, MenuType = "Type1" },
                new MenuSettings { DealerId = 2, MenuType = "Type2" }
            };
            _mockMenuSettingsServices.Setup(service => service.GetMenuSettings()).ReturnsAsync(menuSettings);

            // Act
            var result = await _controller.GetMenuSettings();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<MenuSettings>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
            _mockMenuSettingsServices.Verify(service => service.GetMenuSettings(), Times.Once);
        }

        [Fact]
        public async Task GetMenuSettings_ShouldReturnNoContentWhenNoMenuSettings()
        {
            // Arrange
            _mockMenuSettingsServices.Setup(service => service.GetMenuSettings()).ReturnsAsync((IEnumerable<MenuSettings>)null);

            // Act
            var result = await _controller.GetMenuSettings();

            // Assert
            Assert.IsType<NoContentResult>(result.Result);
            _mockMenuSettingsServices.Verify(service => service.GetMenuSettings(), Times.Once);
        }

        [Fact]
        public async Task GetMenuSettingsById_ShouldReturnOkResultWithMenuSettings()
        {
            // Arrange
            var menuSettings = new MenuSettings { DealerId = 1, MenuType = "Type1" };
            _mockMenuSettingsServices.Setup(service => service.GetMenuSettingsById(1)).ReturnsAsync(menuSettings);

            // Act
            var result = await _controller.GetMenuSettingsById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<MenuSettings>(okResult.Value);
            Assert.Equal(1, returnValue.DealerId);
            _mockMenuSettingsServices.Verify(service => service.GetMenuSettingsById(1), Times.Once);
        }

        [Fact]
        public async Task GetMenuSettingsById_ShouldReturnNotFoundWhenMenuSettingsNotFound()
        {
            // Arrange
            _mockMenuSettingsServices.Setup(service => service.GetMenuSettingsById(1)).ReturnsAsync((MenuSettings)null);

            // Act
            var result = await _controller.GetMenuSettingsById(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("Dealer Not Found", notFoundResult.Value);
            _mockMenuSettingsServices.Verify(service => service.GetMenuSettingsById(1), Times.Once);
        }

        [Fact]
        public async Task AddMenuSettings_ShouldReturnOkResultWhenMenuSettingsAdded()
        {
            // Arrange
            var menuSettings = new MenuSettings { DealerId = 1, MenuType = "Type1" };
            _mockMenuSettingsServices.Setup(service => service.AddMenuSettings(menuSettings)).ReturnsAsync(true);

            // Act
            var result = await _controller.AddMenuSettings(menuSettings);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<MenuSettings>(okResult.Value);
            Assert.Equal(1, returnValue.DealerId);
            _mockMenuSettingsServices.Verify(service => service.AddMenuSettings(menuSettings), Times.Once);
        }

        [Fact]
        public async Task AddMenuSettings_ShouldReturnNotFoundWhenDealerNotFound()
        {
            // Arrange
            var menuSettings = new MenuSettings { DealerId = 1, MenuType = "Type1" };
            _mockMenuSettingsServices.Setup(service => service.AddMenuSettings(menuSettings)).ReturnsAsync(false);

            // Act
            var result = await _controller.AddMenuSettings(menuSettings);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("Dealer Not Found", notFoundResult.Value);
            _mockMenuSettingsServices.Verify(service => service.AddMenuSettings(menuSettings), Times.Once);
        }

        [Fact]
        public async Task UpdateMenuSettings_ShouldReturnOkResultWhenMenuSettingsUpdated()
        {
            // Arrange
            var menuSettingsVM = new MenuSettingsVM { DealerId = 1, MenuType = "Type2", SrpFilterPosition = "Right" };
            var menuSettingsDTO = new MenuSettingsDTO { DealerId = 1, MenuType = "Type2", SrpFilterPosition = "Right" };
            _mockMapper.Setup(m => m.Map<MenuSettingsVM, MenuSettingsDTO>(menuSettingsVM)).Returns(menuSettingsDTO);
            _mockMenuSettingsServices.Setup(service => service.UpdateMenuSettings(menuSettingsDTO)).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateMenuSettings(1, menuSettingsVM);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<MenuSettingsVM>(okResult.Value);
            Assert.Equal("Type2", returnValue.MenuType);
            _mockMenuSettingsServices.Verify(service => service.UpdateMenuSettings(menuSettingsDTO), Times.Once);
        }

        [Fact]
        public async Task UpdateMenuSettings_ShouldReturnNotFoundWhenMenuSettingsNotFound()
        {
            // Arrange
            var menuSettingsVM = new MenuSettingsVM { DealerId = 1, MenuType = "Type2", SrpFilterPosition = "Right" };
            var menuSettingsDTO = new MenuSettingsDTO { DealerId = 1, MenuType = "Type2", SrpFilterPosition = "Right" };
            _mockMapper.Setup(m => m.Map<MenuSettingsVM, MenuSettingsDTO>(menuSettingsVM)).Returns(menuSettingsDTO);
            _mockMenuSettingsServices.Setup(service => service.UpdateMenuSettings(menuSettingsDTO)).ReturnsAsync(false);

            // Act
            var result = await _controller.UpdateMenuSettings(1, menuSettingsVM);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("Record Not Found", notFoundResult.Value);
            _mockMenuSettingsServices.Verify(service => service.UpdateMenuSettings(menuSettingsDTO), Times.Once);
        }

        [Fact]
        public async Task DeleteMenuSettings_ShouldReturnOkResultWhenMenuSettingsDeleted()
        {
            // Arrange
            _mockMenuSettingsServices.Setup(service => service.DeleteMenuSettings(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteMenuSettings(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<string>(okResult.Value);
            Assert.Equal("Record with DealerId:- 1 Successfully deleted", returnValue);
            _mockMenuSettingsServices.Verify(service => service.DeleteMenuSettings(1), Times.Once);
        }

        [Fact]
        public async Task DeleteMenuSettings_ShouldReturnNotFoundWhenMenuSettingsNotFound()
        {
            // Arrange
            _mockMenuSettingsServices.Setup(service => service.DeleteMenuSettings(1)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteMenuSettings(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Record Not Found", notFoundResult.Value);
            _mockMenuSettingsServices.Verify(service => service.DeleteMenuSettings(1), Times.Once);
        }
    }
}
