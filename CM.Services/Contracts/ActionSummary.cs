using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services.Contracts
{
    public class ActionSummary
    {
        public ActionSummary(bool isCreated)
        {
            this.IsCreated = isCreated;
        }
        
        public ActionSummary(bool isCreated, string message)
            : this(isCreated)
        {
            this.Message = message;
        }

        public string Message { get; }

        public bool IsCreated { get; }
    }
}
