using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal
{
    class CourseManager
    {
        public void Add()
        {
            // (5) Burada "Course"ye ihtiyacımızın olduğunu düşünüyoruz.
            // (6) O zaman, herhangi bir şeye ihtiyacımı olmadan, Course'yi direk olarak burada kullanabiliriz.

            Course course = new Course();
            Student student = new Student(); //bu şekilde de kullanabiliriz çünkü defaultu Internal !!!


        }

    }
}
