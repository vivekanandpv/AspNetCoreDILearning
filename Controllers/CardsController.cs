using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDILearning.Configurations;
using AspNetCoreDILearning.Data;
using AspNetCoreDILearning.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace AspNetCoreDILearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IEnumerable<ICardApprovalRule> _rules;
        private readonly DummyDataProvider _dataProvider;
        private readonly BaseRuleConfiguration _baseRule;

        public CardsController(IEnumerable<ICardApprovalRule> rules, DummyDataProvider dataProvider, IOptions<BaseRuleConfiguration> options)
        {
            _rules = rules;
            _dataProvider = dataProvider;
            _baseRule = options.Value;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStatus(int id)
        {
            var customer = _dataProvider.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            var ruleViolations = _rules
                .Where(r => !r.Approve(customer, _baseRule))
                .Select(r => r.RuleName)
                .ToList();

            return ruleViolations.Count > 0
                ? Ok(new {Status = "Rejected", Violations = ruleViolations})
                : Ok(new {Status = "Accepted"});
        }

    }
}
