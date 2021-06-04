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
            string query =
                    "select m.Name,m.ID,m.Start_date as Date,p.name as Line"+
                    " from Machine as m join Line_has_machine as lm on m.ID = lm.machine_id"+
                    " join Production_line as p on p.ID = lm.Line_id"+
                    " join Employee as sup on sup.ID = p.Supervisor_id"+
                    " where userName = '"+username+"'";
            return dbMan.ExcuteReader(query);
        }

        public DataTable getAllLines()
        {
            string query = "select Name,p.ID as ID,Location,CONCAT(Fname,' ',Lname) as Supervisor from" +
                " production_line as p join employee as e on Supervisor_id=e.ID ";
            return dbMan.ExcuteReader(query);
        }

        public DataTable loadWorkerTranscript(string userName)
        {
            string query = "select CONCAT(e.Fname,' ',e.Lname) as Name, e.ID as ID, e.salary, e.balance," +
                            "m.Name as Machine, CONCAT(sup.Fname, ' ', sup.Lname) as Supervisor" +
                            " from employee as e" +
                            " join Works_on as w on e.ID = w.Emp_id" +
                            " join Machine as m on m.ID = w.Machine_id" +
                            " join Line_has_machine as l on l.machine_id = w.Machine_id" +
                            " join Production_line as p on l.Line_id = p.ID" +
                            " join Employee as sup on sup.ID = p.Supervisor_id" +
                            " where e.userName = '"+userName+"'";

            return dbMan.ExcuteReader(query);
        }

        public DataTable getAssignedLines(string userName)
        {
            string query = "select Name,p.ID,Location"+
                           " from Production_line as p , Employee as sup"+
                           " where p.Supervisor_id = sup.ID and sup.userName ='"+userName+"'";
            return dbMan.ExcuteReader(query);
        }
        public DataTable getWorkersAndMachines(string userName)
        {
            string query =
" select CONCAT(e.Fname, ' ', e.Lname)AS Name, e.ID as ID, m.Name as Machine" +
" from Employee as e" +
" join Works_on as w on e.ID = w.Emp_id" +
" join Machine as m on m.ID = w.Machine_id" +
" join Line_has_machine as lm on m.ID = lm.Machine_id" +
" join Production_line as p on p.ID = lm.Line_id" +
" join Employee as sup on sup.ID=p.Supervisor_id"+
" where sup.username='"+userName+"'" +
" union" +
" select CONCAT(e.Fname, ' ', e.Lname)AS Name, e.ID as ID, m.Name" +
" from Employee as e  left join(Works_on as w join Machine as m on m.ID = w.Machine_id) on e.id = w.emp_id" +
" where jop_title='W' and e.ID not  in (select Emp_id from Works_on where Emp_id = e.id)" +
" order by m.Name desc";

            return dbMan.ExcuteReader(query);
        }
        public DataTable getAllSupervisors()
        {
            string query = "select concat(fname,' ',lname) as name,ID from employee where jop_title='S'";
            return dbMan.ExcuteReader(query);
        }
        public int insertLine(string name, string location, int supervisor)
        {
            string query="insert into production_line  values ('"+name+"','" + location + "'," + supervisor+")";
            return dbMan.ExecuteNonQuery(query);
        }


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

        public int deleteLine(int lineID)
        {
            string query ="delete from production_line where ID="+lineID+"";

            return dbMan.ExecuteNonQuery(query);
        }
        public int deleteMachine(int machineID)
        {
            string query = "delete from machine where ID=" + machineID + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getMessages(string username)
        {
            string query=
" select CONCAT(e.Fname, ' ', e.Lname) as Name,Subject,Msg"+
" from MsgTo join msg on msgto.MsgID = Msg.MsgID join Employee as e on e.ID = Msg.SenderId , Employee as r"+
" where r.userName = '"+username+"'";
            return dbMan.ExcuteReader(query);
        }

        public DataTable getProduction(string username)
        {
            string query=
" select l.Name, l.ID, prdct.Name as Prodcut, prds.Daily_amount as Amount"+
" from Production_line as l"+
" left join(Produces as prds join Product prdct on prdct.ID = prds.product_id) on l.ID = prds.Line_id"+
" where Supervisor_id in ( select e.ID from Employee as e where e.userName='"+username+"' )";
            return dbMan.ExcuteReader(query);
        }
        public bool doesLineProduces(int lineID)
        {
            string query = "select count(*) as count from Produces where Line_id="+lineID+" ";
            int flag = int.Parse(dbMan.ExcuteReader(query).Rows[0]["Count"].ToString());

            if (flag == 0) return false;
            else return true;
        }
        public int insertProduction(int lineID,int productID,int amount)
        {
            string query = "insert into Produces values ("+lineID+","+productID+","+amount+") ";
            return dbMan.ExecuteNonQuery(query);
        }
        
        public int updateProduction(int lineID,int productID,int amount)
        {
            string query = "update Produces " +
                "SET " +
                "Line_id = " + lineID +
                "product_id = " + productID +
                "Daily_amount = " + amount + ";";
            return dbMan.ExecuteNonQuery(query);
        }
        public int updateProdcution(int lineID, int productID, int amount)
        {
            string query = "update produces set Daily_amount="+amount+" "+
 " where Line_id = "+lineID+" and product_id = "+productID+"";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable getLineNameAndID(string username)
        {
            string query = "select p.Name, p.ID from Production_line as p join Employee as e on p.Supervisor_id = e.ID where e.userName = '"+username+"'";
            return dbMan.ExcuteReader(query);
        }
        public DataTable getAllProducts()
        {
            string query = "select p.Name, p.ID from Product as p";
            return dbMan.ExcuteReader(query);
        }
////////hossam


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
