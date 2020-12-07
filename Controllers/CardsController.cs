using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDILearning.Data;
using AspNetCoreDILearning.Services.Interfaces;

namespace AspNetCoreDILearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IEnumerable<ICardApprovalRule> _rules;
        private readonly DummyDataProvider _dataProvider;

        public CardsController(IEnumerable<ICardApprovalRule> rules, DummyDataProvider dataProvider)
        {
            _rules = rules;
            _dataProvider = dataProvider;
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
                .Where(r => !r.Approve(customer))
                .Select(r => r.RuleName)
                .ToList();

            return ruleViolations.Count > 0
                ? Ok(new {Status = "Rejected", Violations = ruleViolations})
                : Ok(new {Status = "Accepted"});
        }

    }
}
