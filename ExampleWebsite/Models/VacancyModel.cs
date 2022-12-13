using NatWestWebsite.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ExampleWebsite.Models
{
    public class Vacancy {
        public int Index { get; set; }
        public List<VacancyModel> Vacancies { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }


    public class VacancyModel
    {
        [JsonRequired]
        public int? Id { get; set; }
        public int? Salary { get; set; }
        public string? Location { get; set; }
        [JsonPropertyAttribute("Type of Employment")]
        public string? TypeofEmployment { get; set; }
        [System.Text.Json.Serialization.JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateTime PostingDate { get; set; }
        [JsonPropertyAttribute("Candidate requirements")]
        public string? Candidaterequirements { get; set; }
        [JsonPropertyAttribute("Role description")]
        public string? Roledescription { get; set; }
        [JsonPropertyAttribute("Vacancy Description")]
        public string? VacancyDescription { get; set; }
        [JsonPropertyAttribute("Learning outcomes")]
        public string? Learningoutcomes { get; set; }
    }
}
