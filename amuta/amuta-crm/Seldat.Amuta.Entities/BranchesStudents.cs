using System.Collections;
using System.Collections.Generic;


namespace Seldat.Amuta.Entities
{
    public class BranchesStudents : IEnumerable<BranchStudent>
    {

        List<BranchStudent> branchesStudents;

        public BranchesStudents()
        {
            branchesStudents = new List<BranchStudent>();
        }

        public void Add(BranchStudent branchStudent)
        {
            branchesStudents.Add(branchStudent);
        }

        public void AddRange(List<BranchStudent> institutionsStudents)
        {
            foreach (var institutionStudent in institutionsStudents)
            {
                Add(institutionStudent);
            }
        }

        public int Count()
        {
            return branchesStudents.Count;
        }
        public IEnumerator<BranchStudent> GetEnumerator()
        {
            return branchesStudents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return branchesStudents;
        }
    }
}
