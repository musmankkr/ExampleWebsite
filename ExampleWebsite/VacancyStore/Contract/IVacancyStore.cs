using ExampleWebsite.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace NatWestWebsite.VacancyStore.Contract
{
    public interface IVacancyStore
    {
        public void ReadNatWestVacancies();
    
    }
}
