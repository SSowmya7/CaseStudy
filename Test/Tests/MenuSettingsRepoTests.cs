using CaseStudy.Core.DTO;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using CaseStudy.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Tests
{
    public class MenuSettingsRepoTests
    {
        private readonly MenuSettingsRepo _repository;
        private readonly PrjContext _context;

        public MenuSettingsRepoTests()
        {
            var options = new DbContextOptionsBuilder<PrjContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase") // Ensure this line is correct
                .Options;
            _context = new PrjContext(options);
            _repository = new MenuSettingsRepo(_context);
        }

        [Fact]
        public async Task GetMenuSettings_ShouldReturnAllMenuSettings()
        {
            // Arrange
            _context.MenuSettings.RemoveRange(_context.MenuSettings); // Clear any existing data
            await _context.SaveChangesAsync();

            var menuSettings = new List<MenuSettings>
            {
                new MenuSettings { DealerId = 1, MenuType = "Type1" },
                new MenuSettings { DealerId = 2, MenuType = "Type2" }
            };
            _context.MenuSettings.AddRange(menuSettings);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetMenuSettings();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetMenuSettingsById_ShouldReturnMenuSettings()
        {
            // Arrange
            _context.MenuSettings.RemoveRange(_context.MenuSettings); // Clear any existing data
            await _context.SaveChangesAsync();

            var menuSettings = new MenuSettings { DealerId = 1, MenuType = "Type1" };
            _context.MenuSettings.Add(menuSettings);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetMenuSettingsById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Type1", result.MenuType);
        }

        [Fact]
        public async Task GetMenuSettingsById_ShouldReturnNullIfNotFound()
        {
            // Arrange
            _context.MenuSettings.RemoveRange(_context.MenuSettings); // Clear any existing data
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetMenuSettingsById(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddMenuSettings_ShouldAddMenuSettings()
        {
            // Arrange
            _context.MenuSettings.RemoveRange(_context.MenuSettings); // Clear any existing data
            await _context.SaveChangesAsync();

            var dealer = new Dealers { DealerId = 1, DealerName = "Dealer1" };
            var menuSettings = new MenuSettings { DealerId = 1, MenuType = "Type1" };
            _context.Dealers.Add(dealer);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.AddMenuSettings(menuSettings);

            // Assert
            Assert.True(result);
            Assert.Single(_context.MenuSettings);
        }

        [Fact]
        public async Task AddMenuSettings_ShouldReturnFalseIfDealerNotFound()
        {
            // Arrange
            _context.MenuSettings.RemoveRange(_context.MenuSettings); // Clear any existing data
            await _context.SaveChangesAsync();

            var menuSettings = new MenuSettings { DealerId = 15, MenuType = "Type1" };

            // Act
            var result = await _repository.AddMenuSettings(menuSettings);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task UpdateMenuSettings_ShouldUpdateMenuSettings()
        {
            // Arrange
            _context.MenuSettings.RemoveRange(_context.MenuSettings); // Clear any existing data
            await _context.SaveChangesAsync();

            var menuSettings = new MenuSettings { DealerId = 1, MenuType = "Type1", SrpFilterPosition = "Left" };
            _context.MenuSettings.Add(menuSettings);
            await _context.SaveChangesAsync();
            var menuSettingsDto = new MenuSettingsDTO { DealerId = 1, MenuType = "Type2", SrpFilterPosition = "Right" };

            // Act
            var result = await _repository.UpdateMenuSettings(menuSettingsDto);

            // Assert
            Assert.True(result);
            var updatedMenuSettings = await _context.MenuSettings.FindAsync(1);
            Assert.Equal("Type2", updatedMenuSettings.MenuType);
            Assert.Equal("Right", updatedMenuSettings.SrpFilterPosition);
        }

        [Fact]
        public async Task UpdateMenuSettings_ShouldReturnFalseIfNotFound()
        {
            // Arrange
            _context.MenuSettings.RemoveRange(_context.MenuSettings); // Clear any existing data
            await _context.SaveChangesAsync();

            var menuSettingsDto = new MenuSettingsDTO { DealerId = 1, MenuType = "Type2", SrpFilterPosition = "Right" };

            // Act
            var result = await _repository.UpdateMenuSettings(menuSettingsDto);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task DeleteMenuSettings_ShouldDeleteMenuSettings()
        {
            // Arrange
            _context.MenuSettings.RemoveRange(_context.MenuSettings); // Clear any existing data
            await _context.SaveChangesAsync();

            var menuSettings = new MenuSettings { DealerId = 1, MenuType = "Type1" };
            _context.MenuSettings.Add(menuSettings);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteMenuSettings(1);

            // Assert
            Assert.True(result);
            Assert.Empty(_context.MenuSettings);
        }

        [Fact]
        public async Task DeleteMenuSettings_ShouldReturnFalseIfNotFound()
        {
            // Arrange
            _context.MenuSettings.RemoveRange(_context.MenuSettings); // Clear any existing data
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteMenuSettings(1);

            // Assert
            Assert.False(result);
        }
    }
}
