using ExampleWebsite.Models;
using System.Collections.Generic;

namespace NatWestWebsite.Services.Contract
{
    public interface IVacancyService
    {
        List<VacancyModel> GetVacancies(int paginationNumber);

        List<VacancyModel> GetVacancies();

        int MaxPaginationNumber();
        
    }
}
