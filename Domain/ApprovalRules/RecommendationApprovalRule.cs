using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDILearning.Configurations;
using AspNetCoreDILearning.Domain.Models;
using AspNetCoreDILearning.Services.Interfaces;

namespace AspNetCoreDILearning.Domain.ApprovalRules
{
    public class RecommendationApprovalRule: ICardApprovalRule
    {
        public bool Approve(Customer customer, BaseRuleConfiguration baseRule)
        {
            return customer.NRecommendations >= baseRule.NRecommendations;
        }

        public string RuleName => "Recommendation Rule";
    }
}
