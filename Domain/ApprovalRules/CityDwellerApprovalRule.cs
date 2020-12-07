using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDILearning.Configurations;
using AspNetCoreDILearning.Domain.Models;
using AspNetCoreDILearning.Services.Interfaces;

namespace AspNetCoreDILearning.Domain.ApprovalRules
{
    public class CityDwellerApprovalRule: ICardApprovalRule
    {
        public bool Approve(Customer customer, BaseRuleConfiguration baseRule)
        {
            return !baseRule.IsOnlyForCityDweller || customer.CityDweller;
        }

        public string RuleName => "City Dweller Rule";
    }
}
