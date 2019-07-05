using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities
{
    public class StudentPayments: IEnumerable<StudentPayment>
    {
        public List<StudentPayment> payments;

        public StudentPayments()
        {
            payments = new List<StudentPayment>();
        }

        public void Add(StudentPayment payment)
        {
            payments.Add(payment);
        }

        public void AddRange(List<StudentPayment> payments)
        {
            foreach (StudentPayment payment in payments)
            {
                Add(payment);
            }
        }

        public IEnumerator<StudentPayment> GetEnumerator()
        {
            return payments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return payments;
        }

      
    }
}
