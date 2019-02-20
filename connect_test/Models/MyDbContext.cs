using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace connect_test.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Test> Test { get; set; }
               
    }

    public class DataSettingManager
    {
        private const string _dataSettingsFilePath = "App_Data/dataSetting.json";
        public virtual DataSettings LoadSettings()
        {
            var text = File.ReadAllText(_dataSettingsFilePath);
            if (string.IsNullOrEmpty(text))
                return new DataSettings();

            //get data settings from the JSON file
            DataSettings settings = JsonConvert.DeserializeObject<DataSettings>(text);
                return settings;
        }
    }

    public class DataSettings
    {
        public string DataConnectionString { get; set; }
    }
}
