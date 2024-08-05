
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.DTO;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.UnitOfWork;
using Moq;
using Xunit;

namespace Tests
{
    public class MenuSettingsServicesTests
    {
        private readonly Mock<IMenuSettingsRepo> _mockRepo;
        private readonly MenuSettingsServices _service;

        public MenuSettingsServicesTests()
        {
            _mockRepo = new Mock<IMenuSettingsRepo>();
            _service = new MenuSettingsServices(_mockRepo.Object);
        }

        [Fact]
        public async Task GetMenuSettings_ShouldReturnAllMenuSettings()
        {
            // Arrange
            var menuSettings = new List<MenuSettings>
            {
                new MenuSettings { DealerId = 1, MenuType = "Type1" },
                new MenuSettings { DealerId = 2, MenuType = "Type2" }
            };
            _mockRepo.Setup(repo => repo.GetMenuSettings()).ReturnsAsync(menuSettings);

            // Act
            var result = await _service.GetMenuSettings();

            // Assert
            Assert.Equal(2, result.Count());
            _mockRepo.Verify(repo => repo.GetMenuSettings(), Times.Once);
        }

        [Fact]
        public async Task GetMenuSettingsById_ShouldReturnMenuSettings()
        {
            // Arrange
            var menuSettings = new MenuSettings { DealerId = 1, MenuType = "Type1" };
            _mockRepo.Setup(repo => repo.GetMenuSettingsById(1)).ReturnsAsync(menuSettings);

            // Act
            var result = await _service.GetMenuSettingsById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Type1", result.MenuType);
            _mockRepo.Verify(repo => repo.GetMenuSettingsById(1), Times.Once);
        }

        [Fact]
        public async Task GetMenuSettingsById_ShouldReturnNullIfNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetMenuSettingsById(1)).ReturnsAsync((MenuSettings)null);

            // Act
            var result = await _service.GetMenuSettingsById(1);

            // Assert
            Assert.Null(result);
            _mockRepo.Verify(repo => repo.GetMenuSettingsById(1), Times.Once);
        }

        [Fact]
        public async Task AddMenuSettings_ShouldAddMenuSettings()
        {
            // Arrange
            var menuSettings = new MenuSettings { DealerId = 1, MenuType = "Type1" };
            _mockRepo.Setup(repo => repo.AddMenuSettings(menuSettings)).ReturnsAsync(true);

            // Act
            var result = await _service.AddMenuSettings(menuSettings);

            // Assert
            Assert.True(result);
            _mockRepo.Verify(repo => repo.AddMenuSettings(menuSettings), Times.Once);
        }

        [Fact]
        public async Task AddMenuSettings_ShouldReturnFalseIfNotAdded()
        {
            // Arrange
            var menuSettings = new MenuSettings { DealerId = 1, MenuType = "Type1" };
            _mockRepo.Setup(repo => repo.AddMenuSettings(menuSettings)).ReturnsAsync(false);

            // Act
            var result = await _service.AddMenuSettings(menuSettings);

            // Assert
            Assert.False(result);
            _mockRepo.Verify(repo => repo.AddMenuSettings(menuSettings), Times.Once);
        }

        [Fact]
        public async Task UpdateMenuSettings_ShouldUpdateMenuSettings()
        {
            // Arrange
            var menuSettingsDto = new MenuSettingsDTO { DealerId = 1, MenuType = "Type2", SrpFilterPosition = "Right" };
            _mockRepo.Setup(repo => repo.UpdateMenuSettings(menuSettingsDto)).ReturnsAsync(true);

            // Act
            var result = await _service.UpdateMenuSettings(menuSettingsDto);

            // Assert
            Assert.True(result);
            _mockRepo.Verify(repo => repo.UpdateMenuSettings(menuSettingsDto), Times.Once);
        }

        [Fact]
        public async Task UpdateMenuSettings_ShouldReturnFalseIfNotUpdated()
        {
            // Arrange
            var menuSettingsDto = new MenuSettingsDTO { DealerId = 1, MenuType = "Type2", SrpFilterPosition = "Right" };
            _mockRepo.Setup(repo => repo.UpdateMenuSettings(menuSettingsDto)).ReturnsAsync(false);

            // Act
            var result = await _service.UpdateMenuSettings(menuSettingsDto);

            // Assert
            Assert.False(result);
            _mockRepo.Verify(repo => repo.UpdateMenuSettings(menuSettingsDto), Times.Once);
        }

        [Fact]
        public async Task DeleteMenuSettings_ShouldDeleteMenuSettings()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.DeleteMenuSettings(1)).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteMenuSettings(1);

            // Assert
            Assert.True(result);
            _mockRepo.Verify(repo => repo.DeleteMenuSettings(1), Times.Once);
        }

        [Fact]
        public async Task DeleteMenuSettings_ShouldReturnFalseIfNotDeleted()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.DeleteMenuSettings(1)).ReturnsAsync(false);

            // Act
            var result = await _service.DeleteMenuSettings(1);

            // Assert
            Assert.False(result);
            _mockRepo.Verify(repo => repo.DeleteMenuSettings(1), Times.Once);
        }
    }
}
