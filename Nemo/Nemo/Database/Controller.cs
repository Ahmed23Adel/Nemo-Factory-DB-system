using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemo.Database
{
    class Controller
    {
        DBManager dbMan;

        static Controller instance;
        public static Controller getInstance()
        {
            if (instance == null)
                instance = new Controller();
            return instance;
        }
        private Controller()
        {
            dbMan =DBManager.getInstance();
        }

        public int insertNewEmployee(string ssn, string name, string birthDate, string sex, string salary, string superSsn, string Dno)
        {
            string query = "insert into Employee (SSN,name,Bdate,Sex,Salary,Super_SSN,Dno) " +
                "values ( " + ssn + ",'" + name + "','" + birthDate + "','" + sex + "'," + salary + "," + superSsn + "," + Dno
                + ");";

            return dbMan.ExecuteNonQuery(query);

        }
    }
}
