using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities
{
    public class Branches : IEnumerable<Branch>
    {
        private List<Branch> branchs;
        public Branches()
        {
            branchs = new List<Branch>();
        }
        public void Add(Branch branch)
        {
            branchs.Add(branch);
        }
        public IEnumerator<Branch> GetEnumerator()
        {
            return branchs.GetEnumerator();
        }
        public void AddRange(List<Branch> branches)
        {
            foreach (Branch branch in branches)
            {
                Add(branch);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return branchs;
        }
    }
}
