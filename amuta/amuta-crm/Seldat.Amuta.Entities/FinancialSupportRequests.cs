using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities
{
    public class FinancialSupportRequests : IEnumerable<FinancialSupportRequest>
    {
        private List<FinancialSupportRequest> financialSupportRequests;

        public FinancialSupportRequests()
        {
            financialSupportRequests = new List<FinancialSupportRequest>();
        }

        public void Add(FinancialSupportRequest financialSupportRequest)
        {
            financialSupportRequests.Add(financialSupportRequest);
        }

        public void AddRange(List<FinancialSupportRequest> financialSupportRequests)
        {
            foreach (FinancialSupportRequest financialSupportRequest in financialSupportRequests)
            {
                Add(financialSupportRequest);
            }
        }
        
        public IEnumerator<FinancialSupportRequest> GetEnumerator()
        {
            return financialSupportRequests.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return financialSupportRequests;
        }

        
    }
}
