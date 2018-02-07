using Enterprise.AuthorizationServer.DataLayers;
using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Enterprise.Utility.Database.Interfaces;

namespace Enterprise.Utility.Database.Functions
{
    public class CleanUpDB:ICleanUpDB
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ConfigurationDBContext _configurationDBContext;
        private readonly ILogger<CleanUpDB> _logger;

        public CleanUpDB(ApplicationDbContext applicationDbContext,ConfigurationDBContext configurationDBContext,ILogger<CleanUpDB> logger)
        {
            _applicationDbContext = applicationDbContext;
            _configurationDBContext = configurationDBContext;
            _logger = logger;
        }
        public void CleanUpAllValues()
        {
            _logger.LogInformation("Starting CleanUp Whole Apps DB Values");

            // NOTES : Order is IMPORTANT...
            CleanUpConfigurationApps();
            CleanUpMenuPermittedRoles();
            CleanUpAppMenus();
            CleanUpAppMenuCategories();
            CleanUpAppMenuLayout();
            CleanUpIntegratedApps();
            CleanUpProjects();
            CleanUpAppRole();

            _logger.LogInformation("Starting CleanUp Whole Apps DB Values");
        }

        #region Authorization Server
        public void CleanUpAppRole()
        {
            try
            {
                // Delete All Record
                _applicationDbContext.Roles.RemoveRange(_applicationDbContext.Roles.ToList());
                _applicationDbContext.SaveChanges();
                _logger.LogInformation("Application Roles Cleared Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In Application Block.");
                throw;
            }
        }
        #endregion

        #region Configuration Server
        public void CleanUpAppMenuLayout()
        {
            try
            {
                // Delete All Record
                _configurationDBContext.AppMenuLayouts.RemoveRange(_configurationDBContext.AppMenuLayouts.ToList());
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("App Menu Layout Values Cleared Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In App Menu Layout CleanUp Block.");
                throw;
            }
        }
        public void CleanUpIntegratedApps()
        {
            try
            {
                // Delete All Record
                _configurationDBContext.IntegratedApps.RemoveRange(_configurationDBContext.IntegratedApps.ToList());
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("Integrated App Values Cleared Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In Integrated App CleanUp Block.");
                throw;
            }
        }
        public void CleanUpConfigurationApps()
        {
            try
            {
                _logger.LogInformation("Starting Re-CleanUp Configuration Apps");

                // Delete All Record
                _configurationDBContext.ApplicationConfigurations.RemoveRange(_configurationDBContext.ApplicationConfigurations.ToList());
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("Configuration Apps Values Cleared Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In Configuration App CleanUp Block.");
                throw;
            }
        }
        public void CleanUpAppMenus()
        {
            try
            {
                _logger.LogInformation("Starting Re-CleanUp Application Menu");

                // Delete All Record
                _configurationDBContext.AppMenus.RemoveRange(_configurationDBContext.AppMenus.ToList());
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("App Menus Values Cleared Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In App Menu CleanUp Block.");
                throw;
            }
        }
        public void CleanUpAppMenuCategories()
        {
            try
            {
                _logger.LogInformation("Starting Re-CleanUp Application Menu Categories");

                // Delete All Record
                _configurationDBContext.AppMenuCategories.RemoveRange(_configurationDBContext.AppMenuCategories.ToList());
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("App Menus Category Values Cleared Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In App Menu Categories CleanUp Block.");
                throw;
            }
        }
        public void CleanUpProjects()
        {
            try
            {
                _logger.LogInformation("Starting Re-CleanUp Projects Values");

                // Delete All Record
                _configurationDBContext.Projects.RemoveRange(_configurationDBContext.Projects.ToList());
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("Projects Values Cleared Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In Projects CleanUp Block.");
                throw;
            }
        }
        public void CleanUpMenuPermittedRoles()
        {
            try
            {
                _logger.LogInformation("Starting Re-CleanUp Menu Permitted Roles");

                // Delete All Record
                _configurationDBContext.MenuPermittedRoles.RemoveRange(_configurationDBContext.MenuPermittedRoles.ToList());
                _configurationDBContext.SaveChanges();
                _logger.LogInformation("Menu Permitted Roles Values Cleared Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured In Menu Permitted Roles CleanUp Block.");
                throw;
            }
        }
        #endregion
    }
}
