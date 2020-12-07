using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDILearning.Services.Interfaces;

namespace AspNetCoreDILearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IGuidProvider _guidProvider;
        private readonly IIntIdProvider _intIdProvider;

        public TestController(IGuidProvider guidProvider, IIntIdProvider intIdProvider)
        {
            _guidProvider = guidProvider;
            _intIdProvider = intIdProvider;
        }

        public IActionResult Get()
        {
            return Ok($"Guid: {_guidProvider.GetGuid()}; Id: {_intIdProvider.GetId()}");
        }
    }
}
