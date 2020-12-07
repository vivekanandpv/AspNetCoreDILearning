using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDILearning.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace AspNetCoreDILearning.Services.Implementations
{
    public class GuidAndIdProvider: IGuidProvider, IIntIdProvider
    {
        private static readonly Guid Guid = Guid.NewGuid();
        private static readonly int Id = 1001;

        public GuidAndIdProvider(ILoggerFactory loggerFactory)
        {
            loggerFactory.CreateLogger("GuidAndIdProvider")
                .LogInformation("GuidAndIdProvider Created");
        }

        public Guid GetGuid()
        {
            return Guid;
        }

        public int GetId()
        {
            return Id;
        }
    }
}
