using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dbContext
    {
        public readonly string ConnectionString;

        public dbContext()
        {
            ConnectionString = "Data Source=LAPTOP-HU4NMC01;Initial Catalog=GameYamDB;Integrated Security=True";
        }
    }
}
