using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDILearning.Domain.Models;
using AspNetCoreDILearning.Services.Interfaces;

namespace AspNetCoreDILearning.Domain.ApprovalRules
{
    public class CityDwellerApprovalRule: ICardApprovalRule
    {
        public bool Approve(Customer customer)
        {
            return customer.CityDweller;
        }

        public string RuleName => "City Dweller Rule";
    }
}
