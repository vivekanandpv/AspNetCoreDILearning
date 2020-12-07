using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDILearning.Services.Interfaces
{
    public interface IGuidProvider
    {
        public Guid GetGuid();
    }

    public interface IIntIdProvider
    {
        public int GetId();
    }
}
