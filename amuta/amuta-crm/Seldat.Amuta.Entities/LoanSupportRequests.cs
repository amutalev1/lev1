using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities
{
    public class LoanSupportRequests : IEnumerable<LoanSupportRequest>
    {
        private List<LoanSupportRequest> loans;

        public LoanSupportRequests()
        {
            loans = new List<LoanSupportRequest>();
        }

        public void Add(LoanSupportRequest loan)
        {
            loans.Add(loan);
        }

        public void AddRange(List<LoanSupportRequest> loans)
        {
            foreach (LoanSupportRequest loan in loans)
            {
                Add(loan);
            }
        }

        public IEnumerator<LoanSupportRequest> GetEnumerator()
        {
            return loans.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return loans;
        }

       
    }
}
