using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using SQLConnectionApplication.Model;


namespace SQLConnectionApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            var context = new DatabaseContext();
        }

    }
}
