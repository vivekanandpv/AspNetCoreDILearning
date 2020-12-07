using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDILearning.Configurations;
using AspNetCoreDILearning.Domain.Models;

namespace AspNetCoreDILearning.Services.Interfaces
{
    public interface ICardApprovalRule
    {
        bool Approve(Customer customer, BaseRuleConfiguration baseRule);
        string RuleName { get; }
    }
}
