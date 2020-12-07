using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDILearning.Domain.Models;

namespace AspNetCoreDILearning.Data
{
    public class DummyDataProvider
    {
        private readonly IEnumerable<Customer> _customers;

        public DummyDataProvider()
        {
            this._customers = new List<Customer>
            {
                new Customer{Id=1, AnnualIncome = 1250000, CityDweller = true, CreditScore = 769, FirstName = "Sridhar", LastName = "S", NRecommendations = 3},
                new Customer{Id=2, AnnualIncome = 650000, CityDweller = true, CreditScore = 800, FirstName = "Madhur", LastName = "K", NRecommendations = 5},
                new Customer{Id=3, AnnualIncome = 500000, CityDweller = true, CreditScore = 700, FirstName = "Vani", LastName = "S", NRecommendations = 2},
                new Customer{Id=4, AnnualIncome = 435000, CityDweller = false, CreditScore = 770, FirstName = "Nitesh", LastName = "V", NRecommendations = 1},
                new Customer{Id=5, AnnualIncome = 100000, CityDweller = false, CreditScore = 580, FirstName = "Kiran", LastName = "J", NRecommendations = 3},
            };
        }
        
        public Customer Get(int id)
        {
            return this._customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
