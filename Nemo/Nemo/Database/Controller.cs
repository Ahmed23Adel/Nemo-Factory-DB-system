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
            dbMan = DBManager.getInstance();
        }

        ////////////////////////////////Login////////////////////////////////
        public DataTable isUserNamePassExist(string userName, string pass)
        {
            string query = "EXEC isUserNamePassExist @username='" + userName + "' , @pass='" + pass + "' ";
            ; return dbMan.ExcuteReader(query);
        }


        ////////////////////////////////Employees////////////////////////////////
        public DataTable selectAllEmps()
        {
            string query = "exec selectAllEmps";
            return dbMan.ExcuteReader(query);

        }

        public DataTable selectAllEmpsForSending()
        {
            string query = "exec selectAllEmpsForSending ";
            return dbMan.ExcuteReader(query);

        }
        public DataTable SelectEmpsLikeName(string name)
        {
            string query = "exec SelectEmpsLikeName @name='" + name + "' ";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetProductionLineAtId(string lineId)
        {
            string query = "exec GetProductionLineAtId @lineId='" + lineId + "' ";
            return dbMan.ExcuteReader(query);
        }


        public int UpdateProductionLineAtId(string lineId, string name, string Location, string Supervisor_id)
        {
            string query = "UPDATE Production_line " +
                 "SET " +
                "Name = " + name + ", " +
                "Location = " + Location + ", " +
                "Supervisor_id = " + Supervisor_id + "" +
                "WHERE " +
                " ID = " + lineId;
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable GetAllSupervisors()
        {
            string query = "exec GetAllSupervisors ";
            return dbMan.ExcuteReader(query);
        }

        public int DeleteProductionLineAtId(string lineId)
        {
            string query = "exec DeleteProductionLineAtId @lineId='" + lineId + "' ";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable searchAndFilterEmployees(string query)
        {
            return dbMan.ExcuteReader(query);
        }

        ////////////////////////////////update Employees////////////////////////////////
        public DataTable selectEmpAtId(string id)
        {
            string query = "exec selectEmpAtID @id='" + id + "' ";
            return dbMan.ExcuteReader(query);

        }
        public DataTable selectEmpAtUserNamePass(string userName, string password)
        {
            string query = "exec selectEmpAtUserNamePass @username='" + userName + "', @password='" + password + "'  ";
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
            string query = "exec UpdateMachineAtId @id='" + id + "', @name='" + name + "', @date='" + date + "'";

            return dbMan.ExecuteNonQuery(query);
        }

        public int updateEmpAtId(string id, string Fname, string Lname, string salary, string Bdata, string Jop_title, string userName, string password, string nationalID, string Gender, string Address, string Religion, string Status)
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
                "WHERE ID = '" + id + "';";

            return dbMan.ExecuteNonQuery(query);

        }

        public int deleteAtId(string id)
        {
            string query = "exec deleteAtId @id='" + id + "'";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateJopDesc(string id, string Jop_title)
        {
            string query = "exec UpdateJopDesc  @id='" + id + "', @Jop_title='" + Jop_title + "' ";

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
            string query = "SELECT Machine.ID,Machine.Name,Machine.Start_date, Production_line.ID AS  'prodLine',Production_line.Name " +
                            "FROM Machine LEFT JOIN Line_has_machine ON Machine.ID = Line_has_machine.Machine_id LEFT join Production_line ON Production_line.ID = Line_has_machine.Line_id " +
                            "WHERE Machine.ID = " + id + "; ";
            return dbMan.ExcuteReader(query);
        }
        public int RemoveMachineAtId(string id)
        {
            string query = "exec RemoveMachineAtId @id='" + id + "' ";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertMachine(string name, string startDate)
        {
            string query = "INSERT INTO Machine (Name,  Start_date) VALUES(" + name + ", " + startDate + "); ";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable GetAllMachines()
        {
            string query = "exec GetAllMachines";
            return dbMan.ExcuteReader(query);
        }

        public DataTable searchAndFilterMachines(string query)
        {
            return dbMan.ExcuteReader(query);
        }

        //////////////////////////Stats//////////////////////////
        public DataTable GetMaleFemale()
        {
            string query = "exec GetMaleFemale";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetAvgSalaries()
        {
            string query = "exec GetAvgSalaries";

            return dbMan.ExcuteReader(query);
        }

        public DataTable GetReligions()
        {
            string query = "exec GetReligions";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetTopProductionLines()
        {
            string query = "exec GetTopProductionLines";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetOldestMachines()
        {
            string query = "exec GetOldestMachines";
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
            string query = "EXEC h_getWorkersAndMachines @username='" + userName + "'  ";

            return dbMan.ExcuteReader(query);
        }
        public DataTable getAllSupervisors()
        {
            string query = "EXEC h_getAllSupervisors";
            return dbMan.ExcuteReader(query);
        }
        public int insertLine(string name, string location, int supervisor)
        {
            string query = "EXEC h_insertLine @name='" + name + "',@location='" + location + "',@supervisor=" + supervisor + " ";
            return dbMan.ExecuteNonQuery(query);
        }

        public int deleteLine(int lineID)
        {
            string query = "EXEC h_deleteLine @lineID=" + lineID + "";

            return dbMan.ExecuteNonQuery(query);
        }
        public int deleteMachine(int machineID)
        {
            string query = "EXEC h_deleteMachine @machineID=" + machineID + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getMessages(string userName)
        {
            string query = "SELECT CONCAT(e.Fname,' ',e.Lname)AS 'Name',m.Subject,m.Msg " +
                            "FROM((MsgTo as mt JOIN Employee as e ON mt.ReceiverId = e.ID) JOIN Msg as m ON m.MsgID = mt.MsgID) " +
                            "WHERE e.userName = '" + userName + "'";
            
            return dbMan.ExcuteReader(query);
        }

        public DataTable getProduction(string username)
        {
            string query = "EXEC h_getProduction @username='" + username + "' ";




            return dbMan.ExcuteReader(query);
        }
        public bool doesLineProduces(int lineID, int productID)
        {
            string query = "exec h_doeslineproduces @lineId=" + lineID + ",@productID=" + productID + " ";

            int flag = int.Parse(dbMan.ExcuteReader(query).Rows[0]["Count"].ToString());

            if (flag == 0) return false;
            else return true;
        }
        public int insertProduction(int lineID, int productID, int amount)
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
            string query = "exec SelectHighestPeopleReside";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetNumEmps()
        {
            string query = "exec GetNumEmps";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetNumReligions()
        {
            string query = "exec GetNumReligions";
            return dbMan.ExcuteReader(query);
        }
        public int SendAnnounc(string subject, string msg) //seems
        {
            string query = "INSERT INTO Msg (SenderId,Msg,Subject) VALUES " +
                " '" + subject + "'," +
                " '" + msg + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertMsgToEmps(string senderId, string subject, string msg, DataTable toEmps)
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
                    string quryInsertTo = "INSERT INTO MsgTo (MsgID,ReceiverId) VALUES ('" + id + "','" + toId + "');";
                    dbMan.ExecuteNonQuery(quryInsertTo);
                }

            }
            return 0;
        }







        public DataTable SelectAllRecievedMsgs(string userName, string password)
        {
            string query = "exec SelectAllRecievedMsgs @userName='" + userName + "', @password='" + password + "'";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetTargetVsProduced()
        {
            string query = "exec GetTargetVsProduced ";
            return dbMan.ExcuteReader(query);
        }
        //There is a problem here the year is fixed
        public double GetTotalCost()
        {
            string query = "exec GetTotalCost";
            return (double)dbMan.ExcuteScalar(query);
        }

        public double GetTotalSal(int numMonths)
        {
            string query = "exec GetTotalSal @numMonths=" + numMonths + "";
            return (double)dbMan.ExcuteScalar(query);
        }

        public DataTable GetTotalEmpsOverYears()
        {
            string query = "exec GetTotalEmpsOverYears ";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetProductionoOverYears()
        {
            string query = "exec GetProductionoOverYears ";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetProductAmtOverAllYearsAccu(string prodLineId, string productId)
        {
            string query = "exec GetProductAmtOverAllYearsAccu @prodLineId='" + prodLineId + "', @productId='" + productId + "' ";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetAllProductionLine()
        {
            string query = "exec GetAllProductionLine";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetAllProductsAtProductionLine(string productionLine)
        {
            string query = "exec GetAllProductsAtProductionLine @productionLine='" + productionLine + "' ";
            return dbMan.ExcuteReader(query);
        }
        public DataTable GetProductionOverThisYear(string prodLineId,string product_id, string year )
        {
            string query = "SELECT SUBSTRING('JAN FEB MAR APR MAY JUN JUL AUG SEP OCT NOV DEC ', (month(ma.date) * 4) - 3, 3) AS month , monAmount  " +
                            "from MonthlyAmount as ma " +
                            "where ma.ProductId = "+ product_id + " AND ma.ProdLineId = "+ prodLineId + " AND year(ma.date) = " + year + " " +
                            "order by date;";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetTargedVsActual()
        {
            string year = DateTime.Now.Year.ToString();
            string query = "SELECT SUBSTRING('JAN FEB MAR APR MAY JUN JUL AUG SEP OCT NOV DEC ', (month(ProdTarget.date) * 4) - 3, 3) AS month,sum(ProdTarget.MonTarget) AS target, sum(MonthlyAmount.MonAmount) AS actual " +
                            "FROM ProdTarget, MonthlyAmount " +
                            "where year(ProdTarget.date)= "+year+" " +
                            "GROUP BY month(ProdTarget.date) ;";
            return dbMan.ExcuteReader(query);
        }


        public DataTable GetMachinesOverYears(string year)
        {
            string query = "SELECT YEAR(Start_date) AS years, COUNT(Start_date) AS sumMachines " +
                            "FROM Machine " +
                            "Group BY year(Start_date) ";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetAllProducts() //
        {
            string query = "exec GetAllProducts";
            return dbMan.ExcuteReader(query);
        }

        public int InsertNewProduct(string name, string cost)
        {
            string query = "INSERT INTO Product (Name, cost) VALUES(" + name + "," + cost + ")";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable GetProductAtId(string id)
        {
            string query = "SELECT Product.ID,Product.Name,Product.cost, Production_line.ID as'prodLine',Production_line.Name " +
                            "FROM Product LEFT JOIN Produces ON Product.ID = Produces.product_id LEFT join Production_line on Production_line.ID = Produces.Line_id " +
                            "WHERE Product.ID = " + id + "; ";
            return dbMan.ExcuteReader(query);

        }

        public DataTable UpdateProductAtId(string id, string name, string cost)
        {
            string query = "UPDATE Product " +
                 "SET " +
                 "name = " + name + ", " +
                 "cost = " + cost + " " +
                 "WHERE ID = '" + id + "';";
            return dbMan.ExcuteReader(query);

        }
        public int DeleteProductAtId(string id)
        {
            string query = "exec DeleteProductAtId @id='" + id + "'";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable GetLastMachine()
        {
            string query = "SELECT ID " +
                            "FROM Machine " +
                            "ORDER BY ID DESC;";
            return dbMan.ExcuteReader(query);
        }

        public DataTable GetLastProduct()
        {
            string query = "SELECT ID " +
                            "FROM Product " +
                            "ORDER BY ID DESC;";
            return dbMan.ExcuteReader(query);
        }

        public int LinkProductToProductoinLine(string Line_id, string product_id)
        {
            string query = "INSERT INTO Produces (Line_id,product_id) VALUES('" + Line_id + "','" + product_id + "')";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateLinkProductToProductionLine(string product_id, string newLine_id, string oldLine_id)
        {
            string query = "UPDATE Produces " +
                "SET " +
                "product_id = " + product_id + "," +
                "Line_id = " + newLine_id + " " +
                "WHERE product_id = " + product_id + " AND Line_id  =" + oldLine_id;
           return  dbMan.ExecuteNonQuery(query);
        }

        public int LinkMachineToProductionLine(string Line_id, string Machine_id)
        {
            string query = "INSERT INTO Line_has_machine (Line_id,Machine_id) VALUES('" + Line_id + "','" + Machine_id + "')";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateLinkMachineToProductionLine(string Line_id, string Machine_id, string oldLineId)
        {
            string query = "UPDATE Line_has_machine " +
                "SET " +
                "Line_id = " + Line_id + "," +
                "Machine_id = " + Machine_id + " " +
                "WHERE " +
                "Line_id = " + oldLineId + " AND Machine_id = " + Machine_id;




            return dbMan.ExecuteNonQuery(query);
        }
    }
}
