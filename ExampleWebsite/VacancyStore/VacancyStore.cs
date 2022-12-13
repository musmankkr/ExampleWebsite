using ExampleWebsite.Models;
using Microsoft.Extensions.Configuration;
using NatWestWebsite.VacancyStore.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace NatWestWebsite.VacancyStore
{
    public class VacancyStore : IVacancyStore
    {
        private readonly IConfiguration? _configuration;
        private readonly string? ReadFileName;
        private readonly string? ReadFolderName;
        private readonly string? WorkingDirectory;

        public static List <VacancyModel> VacanyList;
        
        public VacancyStore(IConfiguration iconfig)
        {
            _configuration = iconfig;
            ReadFileName = _configuration?.GetValue<string>("MySettings:FileName");
            ReadFolderName = _configuration?.GetValue<string>("MySettings:FolderName");
            WorkingDirectory = Environment.CurrentDirectory;
        }

        /// <summary>
        /// Reads the Vacancies from the file stored in WokringDirectory/ReadFolderName
        /// </summary>
        public void ReadNatWestVacancies()
        {
            string filepath = WorkingDirectory + "\\" + ReadFolderName + "\\" + ReadFileName;
            string fs = File.ReadAllText(filepath);

            if (!string.IsNullOrEmpty(fs))
            {
                VacanyList = JsonConvert.DeserializeObject<List<VacancyModel>>(fs) ?? new List<VacancyModel> { };
            }
        }
    }
}
