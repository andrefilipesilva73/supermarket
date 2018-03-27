using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using Supermarket.Backoffice.Entities;

namespace Supermarket.Backoffice.Managers
{
    public class CatalogManager
    {
        /// <summary>
        /// Current Catalog Name Configuration Key Name
        /// </summary>
        private const string CurrentCatalogNameConfigurationKey = "CurrentCatalogName";

        /// <summary>
        /// Loads the current catalog
        /// (Simulates the creation of a DataAccess)
        /// </summary>
        /// <returns></returns>
        public static Catalog GetCurrentCatalog()
        {
            //Get Catalog Name
            string currentCatalogName = ConfigurationManager.AppSettings[CurrentCatalogNameConfigurationKey];

            //Define Catalog File Path
            string catalogFilePath = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "Catalogs"), currentCatalogName);

            //Read File
            string catalogText = File.ReadAllText(catalogFilePath);

            //Parse Text to Object
            Catalog currentCatalog = JsonConvert.DeserializeObject<Catalog>(catalogText);

            //Return catalog currentCatalogin is current state
            return currentCatalog;
        }
    }
}