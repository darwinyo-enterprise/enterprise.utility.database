using Enterprise.AuthorizationServer.DataLayers;
using Enterprise.AuthorizationServer.MockData;
using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Enterprise.ConfigurationServer.MockData;
using Enterprise.Utility.Database.Interfaces;
using Microsoft.Extensions.Logging;

namespace Enterprise.Utility.Database.Functions
{
    public class SeedDB : ISeedDB
    {
        private readonly ConfigurationDBContext _configurationDBContext;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<SeedDB> _logger;

        public SeedDB(ConfigurationDBContext configurationDBContext, ApplicationDbContext applicationDbContext,ILogger<SeedDB> logger)
        {
            _configurationDBContext = configurationDBContext;
            _applicationDbContext = applicationDbContext;
            _logger = logger;

            logger.LogDebug("Starting application");
        }

        /// <summary>
        /// Make Sure All Seed Method Listed Correctly, This will throw exception If not so.
        /// </summary>
        /// <param name="configurationDBContext"></param>
        /// <param name="applicationDbContext"></param>
        public void SeedAllValues()
        {
            try
            {
                _logger.LogInformation("Starting Re-Seed Whole Apps DB Values");

                #region Authorization Server
                SeedAppRole();
                #endregion

                #region Configuration Server
                SeedProjects();
                SeedIntegratedApps();
                SeedConfigurationApps();
                SeedAppMenuLayout();
                SeedAppMenuCategories();
                SeedAppMenus();
                SeedMenuPermittedRoles();
                #endregion

                _logger.LogInformation("All Jobs Done...");
            }
            catch
            {
                throw;
            }
        }

        #region Authorization Server
        public void SeedAppRole()
        {
            try
            {
                _logger.LogInformation("Starting Re-Seed Application Roles");
                
                // re seed all record
                var mocks = new ApplicationRoleMock();
                foreach (var item in mocks.GetApplicationRoles())
                {
                    _applicationDbContext.Roles.Add(item);
                }
                _applicationDbContext.SaveChanges();
                _logger.LogInformation("Application Roles Successfully Populated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Exception Occured In Application Block.");
                throw;
            }
        }
        #endregion

        #region Configuration Server
        public void SeedAppMenuLayout()
        {
            try
            {
                _logger.LogInformation("Starting Re-Seed App Menu Layout Values");

                // re seed all record
                var mocks = new AppMenuLayoutMock();
                foreach (var item in mocks.GetAppMenuLayout())
                {
                    _configurationDBContext.AppMenuLayouts.Add(item);
                }
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("App Menu Layout Values Successfully Populated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In App Menu Layout Seed Block.");
                throw;
            }
        }

        public void SeedIntegratedApps()
        {
            try
            {
                _logger.LogInformation("Starting Re-Seed Integrated App Values");
                
                // re seed all record
                var mocks = new IntegratedAppsMock();
                foreach (var item in mocks.GetIntegratedApp())
                {
                    _configurationDBContext.IntegratedApps.Add(item);
                }
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("Integrated App Values Successfully Populated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In Integrated App Seed Block.");
                throw;
            }
        }
        public void SeedConfigurationApps()
        {
            try
            {
                _logger.LogInformation("Starting Re-Seed Configuration Apps");
                
                // re seed all record
                var mocks = new ApplicationConfigurationMock();
                foreach (var item in mocks.GetApplicationConfiguration())
                {
                    _configurationDBContext.ApplicationConfigurations.Add(item);
                }
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("Configuration Apps Values Successfully Populated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In Configuration App Seed Block.");
                throw;
            }
        }
        public void SeedAppMenus()
        {
            try
            {
                _logger.LogInformation("Starting Re-Seed Application Menu");
                
                // re seed all record
                var mocks = new AppMenuMock();
                foreach (var item in mocks.GetAppMenu())
                {
                    _configurationDBContext.AppMenus.Add(item);
                }
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("App Menus Values Successfully Populated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In App Menu Seed Block.");
                throw;
            }
        }
        public void SeedAppMenuCategories()
        {
            try
            {
                _logger.LogInformation("Starting Re-Seed Application Menu Categories");
                
                // re seed all record
                var mocks = new AppMenuCategoryMock();
                foreach (var item in mocks.GetAppMenuCategory())
                {
                    _configurationDBContext.AppMenuCategories.Add(item);
                }
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("Application Menu Categories Values Successfully Populated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In App Menu Categories Seed Block.");
                throw;
            }
        }
        public void SeedProjects()
        {
            try
            {
                _logger.LogInformation("Starting Re-Seed Projects Values");
                
                // re seed all record
                var mocks = new ProjectMock();
                foreach (var item in mocks.GetProject())
                {
                    _configurationDBContext.Projects.Add(item);
                }
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("Projects Values Successfully Populated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In Projects Seed Block.");
                throw;
            }
        }
        public void SeedMenuPermittedRoles()
        {
            try
            {
                _logger.LogInformation("Starting Re-Seed Menu Permitted Roles");
                
                // re seed all record
                var mocks = new MenuPermittedRoleMock();
                foreach (var item in mocks.GetMenuPermittedRole())
                {
                    _configurationDBContext.MenuPermittedRoles.Add(item);
                }
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("Menu Permitted Roles Values Successfully Populated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In Menu Permitted Roles Seed Block.");
                throw;
            }
        }
        #endregion
    }
}
