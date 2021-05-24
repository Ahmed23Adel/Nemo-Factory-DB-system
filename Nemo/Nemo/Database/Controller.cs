using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

        ////////////////////////////////Login////////////////////////////////
        public DataTable isUserNamePassExist(string userName, string pass)
        {
            string query = "SELECT * FROM Employee WHERE userName = '" + userName + "' AND password = '" + pass + "';";
;            return dbMan.ExcuteReader(query);
        }


        ////////////////////////////////Employees////////////////////////////////
        public DataTable selectAllEmps() 
        {
            string query = " SELECT ID,CONCAT(Fname,' ',Lname)AS 'Name',CASE  WHEN Jop_title = 'M'  THEN 'Manager' WHEN Jop_title = 'E' THEN 'Employee' WHEN Jop_title = 'S'  THEN 'Supervisor' END as 'Jop_description', Balance FROM Employee;";
            return dbMan.ExcuteReader(query);

        }

        ////////////////////////////////update Employees////////////////////////////////
        public DataTable selectEmpAtId(string id)
        {
            string query = "SELECT * FROM Employee WHERE ID = "+id+";";
            return dbMan.ExcuteReader(query);

        }
        
        public int updateEmpAtId(string id, string Fname,string Lname, string Balance, string Bdata, string Jop_title,string userName,string password)
        {
            string query = "UPDATE Employee " +
                "SET " +
                "Fname = '" + Fname + "', " +
                "Lname = '" + Lname + "', " +
                "Balance = " + Balance + ", " +
                "Bdata = '" + Bdata + "', " +
                "Jop_title = '" + Jop_title + "', " +
                "userName = '" + userName + "', " +
                "password = '" + password + "' " +
                "WHERE ID = '"+id+"';";
                
            return dbMan.ExecuteNonQuery(query);

        }

        public int deleteAtId(string id)
        {
            string query = "DELETE FROM Employee WHERE id='"+id+"'; ";
            return dbMan.ExecuteNonQuery(query);
        }

    }
}
