using ExampleWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using NatWestWebsite.Services.Contract;
using NatWestWebsite.VacancyStore.Contract;

namespace WebApplication5.Controllers
{
    public class DynamicController : Controller
    {
        private IVacancyService vacancyService;
        private IVacancyStore vacancyStore;
       
        public DynamicController(IVacancyService userService, IVacancyStore vacancyStore)
        {
            this.vacancyStore = vacancyStore;
            this.vacancyService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public Vacancy Test(int index)
        {
            vacancyStore.ReadNatWestVacancies(); //read vacancies from a file
            var maxIndex = vacancyService.MaxPaginationNumber();

            if (index < 0)
                index = 0;

            if (index > maxIndex)
                index = maxIndex;

            var model = new Vacancy
            {
                Index = index,
                Vacancies = vacancyService.GetVacancies(index),
                HasNext = index < maxIndex,
                HasPrevious = index > 0
            };

            return model;
        }
    }
}