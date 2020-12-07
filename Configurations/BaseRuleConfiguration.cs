using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDILearning.Configurations
{
    public class BaseRuleConfiguration
    {
        public const string BaseRule = "BaseRule";
        public int MinimumCreditScore { get; set; }
        public bool IsOnlyForCityDweller { get; set; }
        public int NRecommendations { get; set; }
        public int MinimumIncomeRequired { get; set; }
    }
}
