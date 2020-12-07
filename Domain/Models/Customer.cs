using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDILearning.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CreditScore { get; set; }
        public int AnnualIncome { get; set; }
        public bool CityDweller { get; set; }
        public int NRecommendations { get; set; }

    }
}
