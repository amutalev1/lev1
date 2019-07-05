using System.Collections;
using System.Collections.Generic;


namespace Seldat.Amuta.Entities
{
   public class Students : IEnumerable<Student>
    {
        public List<Student> students;

        public Students()
        {
            students = new List<Student>();
        }

        public void Add(Student student)
        {
            students.Add(student);
        }

        public void AddRange(List<Student> students)
        {
            foreach (Student student in students)
            {
                Add(student);
            }
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return students.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return students;
        }
    }
}
