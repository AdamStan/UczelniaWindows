using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class EntitiesTest
    {
        static void Main(string[] args)
        {
            var context = new UczelniaEntities();
            var faculty = new Faculty()
            {
                faculty_name = "Wydział Elektroniczny",
                description = "Powstał w roku 1945. Kształcą się na nim przyszli " +
                "automatycy, elektronicy, elektrotechnicy i informatycy."
            };
            context.Faculties.Add(faculty);
            context.SaveChanges();
        }
    }
}
