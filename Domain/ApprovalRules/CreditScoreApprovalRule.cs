using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDILearning.Domain.Models;
using AspNetCoreDILearning.Services.Interfaces;

namespace AspNetCoreDILearning.Domain.ApprovalRules
{
    public class CreditScoreApprovalRule: ICardApprovalRule
    {
        public bool Approve(Customer customer)
        {
            return customer.CreditScore >= 750;
        }

        public string RuleName => "Credit Score Rule";
    }
}
