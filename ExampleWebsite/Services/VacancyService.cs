using ExampleWebsite.Models;
using Microsoft.Extensions.Configuration;
using NatWestWebsite.Services.Contract;
using NatWestWebsite.VacancyStore;
using NatWestWebsite.VacancyStore.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ExampleWebsite.Services
{
    public class VacancyService : IVacancyService
    {
        private IVacancyStore _vacancyStore;
        private int amountPerPage = 5;


        public VacancyService(IVacancyStore vacancyStore)
        {
            _vacancyStore = vacancyStore;
        }

        public List<VacancyModel> GetVacancies(int paginationNumber)
        {
            var index = amountPerPage * paginationNumber;
            var vacancies = VacancyStore.VacanyList;

            if (index >= vacancies.Count)
                return new List<VacancyModel>();

            return vacancies.GetRange(index, Math.Min(vacancies.Count - index, amountPerPage));
        }

        public List<VacancyModel> GetVacancies()
        {
            return VacancyStore.VacanyList;
        }

        public int MaxPaginationNumber()
        {
            return GetVacancies().Count / amountPerPage;
        }

    }
}
