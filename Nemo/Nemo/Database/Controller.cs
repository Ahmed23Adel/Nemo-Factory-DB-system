using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

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
            string query = " SELECT ID,CONCAT(Fname,' ',Lname)AS 'Name',CASE  WHEN Jop_title = 'M'  THEN 'Manager' WHEN Jop_title = 'W' THEN 'Worker' WHEN Jop_title = 'S'  THEN 'Supervisor' END as 'Jop_description', Salary FROM Employee;";
            return dbMan.ExcuteReader(query);

        }

        public DataTable selectAllEmpsForSending()
        {
            string query = " SELECT ID, CONCAT(Fname,' ',Lname)AS 'Name',userName FROM Employee;";
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
        public int UpdateaEmpAtUserNamePass(string Fname, string Lname, string salary, string Bdata, string Jop_title, string userName, string password, string nationalID, string Gender, string Address, string Religion, string Status, string oldUsername, string oldPass)
        {
            string query = "UPDATE Employee " +
               "SET " +
               "Fname = " + Fname + ", " +
               "Lname = " + Lname + ", " +
               "Salary = " + salary + ", " +
               "Bdata = " + Bdata + ", " +
               "Jop_title = " + Jop_title + ", " +
               "userName = " + userName + ", " +
               "password = " + password + ", " +
               "nationalID = " + nationalID + ", " +
               "Gender = " + Gender + ", " +
               "Address = " + Address + ", " +
               "Religion = " + Religion + ", " +
               "Status = " + Status + " " +
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

        public int updateEmpAtId(string id,string Fname, string Lname, string salary, string Bdata, string Jop_title, string userName, string password, string nationalID, string Gender, string Address, string Religion, string Status)
        {
            string query = "UPDATE Employee " +
                "SET " +
                "Fname = " + Fname + ", " +
                "Lname = " + Lname + ", " +
                "Salary = " + salary + ", " +
                "Bdata = " + Bdata + ", " +
                "Jop_title = " + Jop_title + ", " +
                "userName = " + userName + ", " +
                "password = " + password + ", " +
                "nationalID = " + nationalID + ", " +
                "Gender = " + Gender + ", " +
                "Address = " + Address + ", " +
                "Religion = " + Religion + ", " +
                "Status = " + Status + " " +
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
        public int InsertEmp(string Fname, string Lname, string salary, string Bdata, string Jop_title, string userName, string password, string nationalID, string Gender, string Address, string Religion, string Status)
        {
            string query = "INSERT INTO Employee" +
                "(Fname,Lname,Salary,Bdata,Jop_title,userName,password,Gender,Address,Religion,Status,nationalID)" +
                " VALUES(" + Fname + "" +
                ", " + Lname + "" +
                ", " + salary + "" +
                ", " + Bdata + "" +
                ", " + Jop_title + "" +
                ", " + userName + "" +
                ", " + password + "" +
                ", " + Gender + "" +
                ", " + Address + "" +
                ", " + Religion + "" +
                ", " + Status + "" +
                ", " + nationalID + ");";
            return dbMan.ExecuteNonQuery(query);
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
            string query = "INSERT INTO Machine (Name,  Start_date) VALUES(" + name + ", " + startDate + "); ";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable GetAllMachines()
        {
            string query = "SELECT * FROM Machine";
            return dbMan.ExcuteReader(query);
        }

        //////////////////////////Stats//////////////////////////
        public DataTable GetMaleFemale()
        {
            string query = "select "+
                            "count(case when Gender = 'M' then 1 end) as maleCount, " +
                            "count(case when gender = 'F' then 1 end) as FemaleCount "+
                            "FROM Employee; ";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetAvgSalaries()
        {
            string query = "SELECT p.Name as 'Production_line',AVG(Salary) as 'Average' " +
                            "FROM(((Employee as e JOIN Works_on AS w ON e.ID = w.Emp_id)JOIN Line_has_machine AS l ON w.Machine_id = l.machine_id) JOIN Production_line  as p ON p.ID = l.Line_id ) " +
                            "GROUP BY p.Name,l.Line_id";

            return dbMan.ExcuteReader(query);
        }

        public DataTable GetReligions()
        {
            string query = "SELECT Religion, COUNT(Religion) AS 'Countr' " +
                            "FROM Employee " +
                            "GROUP BY Religion " +
                            " HAVING Count(Religion) >0 AND Religion is not NULL AND Religion !='NULL' " +
                            "ORDER BY COUNT(Religion) DESC; ";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetTopProductionLines()
        {
            string query = "SELECT  p.Name as 'prodLine', Product.Name as 'Product',pr.Daily_amount,CONCAT(Employee.Fname,' ',Employee.Lname)AS 'supervisor' " +
                            "From ((((Production_line as p JOIN Produces as pr ON p.ID=pr.Line_id ) JOIN Product ON Product.ID=pr.product_id )) JOIN Employee on Employee.ID=p.Supervisor_id) " +
                            "GROUP BY Employee.Lname,Employee.Fname,Product.Name,pr.Daily_amount,p.Name " +
                            "ORDER BY pr.Daily_amount DESC "+
                            "OFFSET  0 ROWS " +
                            "FETCH NEXT 5 ROWS ONLY ;";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetOldestMachines()
        {
            string query = "SELECT Name, Start_date " +
                            "FROM Machine " +
                            "WHERE Start_date IS NOT NULL"+
                            " ORDER BY Start_date ASC ";
            return dbMan.ExcuteReader(query);
        }

////////hossam

        public DataTable viewAssignedMachines(string username)
        {
            string query = "EXEC h_viewAssignedMachines @username='" + username + "'  ";
            return dbMan.ExcuteReader(query);
        }

        public DataTable getAllLines()
        {
            string query = "EXEC h_getAlllines ";
            return dbMan.ExcuteReader(query);
        }

        public DataTable loadWorkerTranscript(string userName)
        {
            string query = "EXEC h_loadWorkerTranscript @username='" + userName + "'  ";

            return dbMan.ExcuteReader(query);
        }

        public DataTable getAssignedLines(string userName)
        {
            string query = "EXEC h_getAssignedLines @username='" + userName + "'  ";
            return dbMan.ExcuteReader(query);
        }
        public DataTable getWorkersAndMachines(string userName)
        {
            string query = "EXEC h_getWorkersAndMachines @username='"+userName+"'  ";

            return dbMan.ExcuteReader(query);
        }
        public DataTable getAllSupervisors()
        {
            string query = "EXEC h_getAllSupervisors";
            return dbMan.ExcuteReader(query);
        }
        public int insertLine(string name, string location, int supervisor)
        {
            string query="EXEC h_insertLine @name='"+name+"',@location='"+location+"',@supervisor="+supervisor+" ";
            return dbMan.ExecuteNonQuery(query);
        }

        public int deleteLine(int lineID)
        {
            string query = "EXEC h_deleteLine @lineID=" + lineID + "";

            return dbMan.ExecuteNonQuery(query);
        }
        public int deleteMachine(int machineID)
        {
            string query = "EXEC h_deleteMachine @machineID="+machineID+"";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getMessages(string username)
        {
            string query = "EXEC h_getMessages @username='" + username + "' ";
            return dbMan.ExcuteReader(query);
        }

        public DataTable getProduction(string username)
        {
            string query = "EXEC h_getProduction @username='"+username+"' ";




            return dbMan.ExcuteReader(query);
        }
        public bool doesLineProduces(int lineID,int productID)
        {
            string query = "exec h_doeslineproduces @lineId=" + lineID + ",@productID=" + productID + " ";

            int flag = int.Parse(dbMan.ExcuteReader(query).Rows[0]["Count"].ToString());

            if (flag == 0) return false;
            else return true;
        }
        public int insertProduction(int lineID,int productID,int amount)
        {
            string query = "exec h_insertProduction @lineId=" + lineID + ",@productID=" + productID + ", @amount=" + amount + " ";
            return dbMan.ExecuteNonQuery(query);
        }
        
        public int updateProdcution(int lineID, int productID, int amount)
        {
            string query = "Exec h_updateProdcution @lineId=" + lineID + ",@productID=" + productID + ", @amount=" + amount + "   ";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable getLineNameAndID(string username)
        {
            string query = "Exec h_getLineNameAndID @username='" + username + "' ";
            return dbMan.ExcuteReader(query);
        }
        public DataTable getAllProducts()
        {
            string query = "Exec h_getAllProducts";
            return dbMan.ExcuteReader(query);
        }
        ////////hossam

        public int AssignedWorkerId(string id, string machine)
        {

            string query1 = "insert into Works_on  values ( '" + int.Parse(machine) + "' , ' " + id + "')";
            string checkQuery = "select Works_on.Emp_id where Works_on.Machine_id =  ' " + int.Parse(machine) + " '";
            if (dbMan.ExecuteNonQuery(checkQuery) == 1)
            {
                //  query1 = "update Works_on set Machine_id = '" + int.Parse(machine) + "' where Emp_id = ' " + id +" '";
                query1 = "UPDATE  Works_on " +
                "SET " +
                "Machine_id = '" + int.Parse(machine) + "' " +
                "WHERE Emp_id = '" + id + "'";
                return dbMan.ExecuteNonQuery(query1);
            }
            return dbMan.ExecuteNonQuery(query1);
        }
        public DataTable SelectHighestPeopleReside()
        {
            string query = "SELECT e.Address, COUNT(Address) AS'Count' " +
                " FROM Employee AS e " +
                "GROUP BY e.Address " +
                "ORDER BY COUNT(Address) DESC";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetNumEmps()
        {
            string query = "select count(case when Jop_title = 'M' then 1 end) as mangerCount, count(case when Jop_title = 'S' then 1 end) as superVisorsCount, count(case when Jop_title = 'W' then 1 end) as workersCount From Employee; ";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetNumReligions()
        {
            string query = "SELECT e.Religion, COUNT(e.Religion)  AS'count' FROM Employee AS e Group by e.Religion HAVING COUNT(e.Religion) > 0 ORDER BY COUNT(e.Religion) DESC;";
            return dbMan.ExcuteReader(query);
        }
        public int SendAnnounc(string subject, string msg)
        {
            string query = "INSERT INTO Msg (SenderId,Msg,Subject) VALUES " +
                " '" + subject + "'," +
                " '" + msg + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertMsgToEmps(string  senderId,string subject, string msg, DataTable toEmps)
        {


            string queryInsert = "INSERT INTO Msg(SenderId,Subject,Msg)" +
                " VALUES (" + senderId + "," + subject + "," + msg + ");";
            dbMan.ExecuteNonQuery(queryInsert);

            string queryId = "SELECT MsgID FROM Msg ORDER BY MsgID DESC";
            DataTable dt = dbMan.ExcuteReader(queryId);
            string id = dt.Rows[0]["MsgID"].ToString();

            for (int i = 0; i < toEmps.Rows.Count; i++)
            {
                if (((bool)toEmps.Rows[i]["Checked"]) == true)
                {
                    string toId = toEmps.Rows[i]["ID"].ToString();
                    string quryInsertTo = "INSERT INTO MsgTo (MsgID,ReceiverId) VALUES ('"+id+"','"+toId+"');";
                    dbMan.ExecuteNonQuery(quryInsertTo);
                }

            }
            return 0;
        }


        public DataTable SelectAllRecievedMsgs(string userName, string password)
        {
            string query = "SELECT CONCAT(e.Fname,' ',e.Lname)AS 'Name',m.Subject,m.Msg "+
                            "FROM((MsgTo as mt JOIN Employee as e ON mt.ReceiverId = e.ID) JOIN Msg as m ON m.MsgID = mt.MsgID) "+
                            "WHERE e.userName = '"+userName+"' AND e.password = '"+password+"' ";
            return dbMan.ExcuteReader(query);
        }
    }
}
