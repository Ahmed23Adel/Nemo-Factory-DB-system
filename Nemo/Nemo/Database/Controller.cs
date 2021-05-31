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
            string query = " SELECT ID,CONCAT(Fname,' ',Lname)AS 'Name',CASE  WHEN Jop_title = 'M'  THEN 'Manager' WHEN Jop_title = 'W' THEN 'Worker' WHEN Jop_title = 'S'  THEN 'Supervisor' END as 'Jop_description', Balance FROM Employee;";
            return dbMan.ExcuteReader(query);

        }

        ////////////////////////////////update Employees////////////////////////////////
        public DataTable selectEmpAtId(string id)
        {
            string query = "SELECT * FROM Employee WHERE ID = "+id+";";
            return dbMan.ExcuteReader(query);

        }
        public DataTable selectEmpAtUserNamePass(string userName, string password)
        {
            string query = "SELECT * FROM Employee WHERE userName = '" + userName + "' AND password = '" + password + "'; ";
            return dbMan.ExcuteReader(query);

        }

        /// <summary>
        /// New version of insertEmp that insret all data
        /// </summary>
        /// <param name="Fname"></param>
        /// <param name="Lname"></param>
        /// <param name="Balance"></param>
        /// <param name="Bdata"></param>
        /// <param name="Jop_title"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="nationalID"></param>
        /// <returns></returns>
        public int UpdateaEmpAtUserNamePass(string Fname, string Lname, string Balance, string Bdata, string Jop_title, string userName, string password, string nationalID, string Gender, string Address, string Religion, string Status, string oldUsername, string oldPass)
        {
            string query = "UPDATE Employee " +
               "SET " +
               "Fname = '" + Fname + "', " +
               "Lname = '" + Lname + "', " +
               "Balance = " + Balance + ", " +
               "Bdata = '" + Bdata + "', " +
               "Jop_title = '" + Jop_title + "', " +
               "userName = '" + userName + "', " +
               "password = '" + password + "', " +
               "nationalID = '" + nationalID + "', " +
               "Gender = '" + Gender + "', " +
               "Address = '" + Address + "', " +
               "Religion = '" + Religion + "', " +
               "Status = '" + Status + "' " +
               "WHERE userName = '" + oldUsername + "' AND " +
               "password = '" + oldPass + "'; ";

            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateMachineAtId(string id, string name, string date)
        {
            string query = "UPDATE Machine " +
                "SET " +
                "Start_date = '" + date + "', " +
                "Name = '" + name + "' " +
                "WHERE ID = '" + id + "';";

            return dbMan.ExecuteNonQuery(query);
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

        public int UpdateJopDesc(string id, string Jop_title)
        {
            string query = "UPDATE Employee " +
                "SET " +
                "Jop_title = '" + Jop_title + "' " +
                "WHERE ID = '" + id + "';";

            return dbMan.ExecuteNonQuery(query);
        }

        ////////////////////////////////insert Employees////////////////////////////////
        public int InsertEmp(string Fname, string Lname, string Balance, string Bdata, string Jop_title, string userName, string password, string nationalID)
        {
            string query = "INSERT INTO Employee" +
                "(Fname,Lname,Balance,Bdata,Jop_title,userName,password,nationalID)" +
                " VALUES('" + Fname + "'" +
                ", '" + Lname + "'" +
                ", '" + Balance + "'" +
                ", '" + Bdata + "'" +
                ", '" + Jop_title + "'" +
                ", '" + userName + "'" +
                ", '" + password + "'" +
                ", '" + nationalID + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable viewAssignedMachines(string username)
        {
            string query = "SELECT ID, Start_date" +
                "from machine,Line_has_machine, manage " +
                "where machine.ID= machine_id and Line_id=prodLine_id and Supervisor_id=employee.ID and employee.username= '"+username+"' ";
            return dbMan.ExcuteReader(query);

        }
        public DataTable getAllLines()
        {
            string query = "";
            return dbMan.ExcuteReader(query);
        }

        public DataTable loadWorkerData(string userName)
        {
            string query = "";
            return dbMan.ExcuteReader(query);
        }
        public DataTable getAssignedLines(string userName)
        {
            string query = "";
            return dbMan.ExcuteReader(query);
        }
        public DataTable getWorkersAndMachines(string userName)
        {
            string query = "";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetMachineAtId(string id)
        {
            string query = "SELECT * FROM Machine WHERE ID = '" + id + "';";
            return dbMan.ExcuteReader(query);
        }
        public int RemoveMachineAtId(string id)
        {
            string query = "DELETE FROM Machine WHERE id='" + id + "'; ";
            return dbMan.ExecuteNonQuery(query);
        }
        public int InsertMachine(string name, string startDate)
        {
            string query = "INSERT INTO Machine (Name,  Start_date) VALUES('" + name + "', '" + startDate + "'); ";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable GetAllMachines()
        {
            string query = "SELECT * FROM Machine";
            return dbMan.ExcuteReader(query);
        }

    }
}
