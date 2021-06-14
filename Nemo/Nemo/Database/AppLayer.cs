using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Nemo.Database
{
    class AppLayer
    {
        private static AppLayer instance;
        private Controller controller;
        private AppLayer()
        {
            controller = Controller.getInstance();
        }

        public static AppLayer GetInstance()
        {
            if (instance == null)
                instance = new AppLayer();
            return instance;
        }

        public DEFs.JOP_TITLES IsUserNamePassExist(string userName, string pass) 
        {
            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pass) ||userName.Length>50 ||pass.Length>50)
                return DEFs.JOP_TITLES.NONE;

            DataTable dt = controller.isUserNamePassExist(userName, pass);
            if (dt == null)
                return DEFs.JOP_TITLES.NONE;
            if (dt.Rows.Count > 0)
            {
                if(dt.Rows[0]["Jop_title"]==DBNull.Value)
                        throw new Exceptions.JopTitleNotFound("Jop title not found");
                if (((string)dt.Rows[0]["Jop_title"])== "M")
                    return DEFs.JOP_TITLES.MNGR;
                if (((string)dt.Rows[0]["Jop_title"])== "S")
                    return DEFs.JOP_TITLES.SPRVSR;
                if (((string)dt.Rows[0]["Jop_title"])== "W")
                    return DEFs.JOP_TITLES.WRKR;
                else
                    return DEFs.JOP_TITLES.NONE;
            }
           return DEFs.JOP_TITLES.NONE;

        }

        public DataTable GetProductionLineAtId(string lineId)
        {
            return controller.GetProductionLineAtId(lineId);
        }
        public DataTable GetAllSupervisors()
        {
            return controller.GetAllSupervisors();
        }

        public DataTable GetBasicDataForUserNamePass(string userName, string pass)
        {
            DataTable dt = controller.isUserNamePassExist(userName, pass);
            if (dt == null)
                return new DataTable();
            return dt;
        }
        public int DeleteProductionLineAtId(string lineId)
        {
            return controller.DeleteProductionLineAtId(lineId);
        }
        public int UpdateProductionLineAtId(string lineId, string name, string Location, string Supervisor_id)
        {
            if (string.IsNullOrEmpty(name))
                name = "NULL";
            else
                name = "'" + name + "'";
            
            if (string.IsNullOrEmpty(Location))
                Location = "NULL";
            else
                Location = "'" + Location + "'";
            
            if (string.IsNullOrEmpty(Supervisor_id))
                Supervisor_id = "NULL";
            else
                Supervisor_id = "'" + Supervisor_id + "'";

            return controller.UpdateProductionLineAtId(lineId, name, Location, Supervisor_id);


        }
        public DataTable SelectAllEmps()
        {
            return controller.selectAllEmps();
        }
        
        public DataTable selectAllEmpsForSending()
        {
            return controller.selectAllEmpsForSending();
        }
        public DataTable SelectEmpAtId(string id)
        {
            return controller.selectEmpAtId(id);
        }

        public int UpdateEmpAtId(string id, string Fname, string Lname, string salary, string Bdata, string Jop_title, string userName, string password, string nationalID, string Gender, string Address, string Religion, string Status)
        {
            if (string.IsNullOrEmpty(Fname))
                Fname = "NULL";
            else
                Fname = "'" + Fname + "'";
            if (string.IsNullOrEmpty(Lname))
                Lname = "NULL";
            else
                Lname = "'" + Lname + "'";
            if (string.IsNullOrEmpty(salary))
                salary = "NULL";
            else
                salary = "" + salary + "";
            if (string.IsNullOrEmpty(Bdata))
                Bdata = "NULL";
            else
                Bdata = "'" + Bdata + "'";
            if (string.IsNullOrEmpty(Jop_title))
                Jop_title = "NULL";
            else
                Jop_title = "'" + Jop_title + "'";
            if (string.IsNullOrEmpty(userName))
                userName = "NULL";
            else
                userName = "'" + userName + "'";
            if (string.IsNullOrEmpty(password))
                password = "NULL";
            else
                password = "'" + password + "'";
            if (string.IsNullOrEmpty(nationalID))
                nationalID = "NULL";
            else
                nationalID = "'" + nationalID + "'";
            if (string.IsNullOrEmpty(Gender))
                Gender = "NULL";
            else
                Gender = "'" + Gender + "'";
            if (string.IsNullOrEmpty(Address))
                Address = "NULL";
            else
                Address = "'" + Address + "'";
            if (string.IsNullOrEmpty(Religion))
                Religion = "NULL";
            else
                Religion = "'" + Religion + "'";
            if (string.IsNullOrEmpty(Status))
                Status = "NULL";
            else
                Status = "'" + Status + "'";

            return controller.updateEmpAtId( id, Fname, Lname, salary, Bdata, Jop_title, userName, password, nationalID, Gender, Address, Religion, Status);

        }
        public int DeleteAtId(string id)
        {
            return controller.deleteAtId(id);
        }

        public int MakeEmpManager(string id)
        {
            return controller.UpdateJopDesc(id, "M");
        }
        
        public int MakeEmpWorker(string id)
        {
            return controller.UpdateJopDesc(id, "W");
        }
        public int MakeEmpSupervisor(string id)
        {
            return controller.UpdateJopDesc(id, "S");
        }

        public int InsertEmp(string Fname, string Lname, string Balance, string Bdata, string Jop_title, string userName, string password, string nationalID, string Gender, string Address, string Religion, string Status)
        {
            if (string.IsNullOrEmpty(Fname))
                Fname = "NULL";
            else
                Fname = "'"+ Fname + "'";
            if (string.IsNullOrEmpty(Lname))
                Lname = "NULL";
            else
                Lname = "'" + Lname + "'";
            if (string.IsNullOrEmpty(Balance))
                Balance = "NULL";
            else
                Balance = "" + Balance + "";
            if (string.IsNullOrEmpty(Bdata))
                Bdata = "NULL";
            else
                Bdata = "'" + Bdata + "'";
            if (string.IsNullOrEmpty(Jop_title))
                Jop_title = "NULL";
            else
                Jop_title = "'" + Jop_title + "'";
            if (string.IsNullOrEmpty(userName))
                userName = "NULL";
            else
                userName = "'" + userName + "'";
            if (string.IsNullOrEmpty(password))
                password = "NULL";
            else
                password = "'" + password + "'";
            if (string.IsNullOrEmpty(nationalID))
                nationalID = "NULL";
            else
                nationalID = "'" + nationalID + "'";
            if (string.IsNullOrEmpty(Gender))
                Gender = "NULL";
            else
                Gender = "'" + Gender + "'";
            if (string.IsNullOrEmpty(Address))
                Address = "NULL";
            else
                Address = "'" + Address + "'";
            if (string.IsNullOrEmpty(Religion))
                Religion = "NULL";
            else
                Religion = "'" + Religion + "'";
            if (string.IsNullOrEmpty(Status))
                Status = "NULL";
            else
                Status = "'" + Status + "'";
            return controller.InsertEmp( Fname, Lname, Balance, Bdata, Jop_title, userName, password, nationalID, Gender, Address, Religion, Status);
        }

        //hossam

        //hossam

        public DataTable loadAssignedMachines(string username)
        {
            return controller.viewAssignedMachines(username);
        }

        public DataTable loadWorkerTranscript(string userName)
        {
            return controller.loadWorkerTranscript(userName);
        }
        public DataTable getAssignedLines(string userName)
        {
            return controller.getAssignedLines(userName);
        }
        public DataTable getWorkersAndMachines(string userName)
        {
            return controller.getWorkersAndMachines(userName);
        }

        public DataTable getAllLines()
        {
            return controller.getAllLines();
        }
        public DataTable getAllSupervisors()
        {
            return controller.getAllSupervisors();
        }
        public int insertLine(string name, string location, int supervisor)
        {
            return controller.insertLine(name,location,supervisor);
        }
        public int deleteLine(string lineID)
        {
            return controller.deleteLine(int.Parse(lineID));
        }
        public int deleteMachine(string machineID)
        {
            return controller.deleteMachine(int.Parse(machineID));
        }
        public DataTable getMessages(string username)
        {
            return controller.getMessages(username);

        }
        public DataTable getProduction(string username)
        {
            return controller.getProduction(username);
        }
        public bool doesLineProduces(int lineID, int productID)
        {
            return controller.doesLineProduces(lineID,productID);
        }
        public int insertProduction(int lineID, int productID, int amount)
        {
            return controller.insertProduction(lineID, productID, amount);
        }
        public int updateProdcution(int lineID, int productID, int amount)
        {
            return controller.updateProdcution(lineID, productID, amount);
        }
        public DataTable getLineNameAndID(string username)
        {
            return controller.getLineNameAndID(username);
        }
        public DataTable getAllProducts()
        {
            return controller.getAllProducts();
        }
        //hossam end

        public int RemoveMachineAtId(string id)
        {
            return controller.RemoveMachineAtId(id);
        }

        public int UpdateMachineAtId(string id, string name, string date, string oldLineId,string newLindId)
        {
            if (string.IsNullOrEmpty(name))
                name = "NULL";
            if (string.IsNullOrEmpty(date))
                date = "NULL";
            if (controller.UpdateLinkMachineToProductionLine(newLindId, id, oldLineId) == 0)
            {
                controller.LinkMachineToProductionLine(newLindId, id);
            }
            return controller.UpdateMachineAtId(id, name, date);
        }

        public DataTable GetMachineAtId(string id)
        {
            return controller.GetMachineAtId(id);
        }

        public int UpdateaEmpAtUserNamePass(string Fname, string Lname, string salary, string Bdata, string Jop_title, string userName, string password, string nationalID, string Gender, string Address, string Religion, string Status, string oldUserName, string oldPass)
        {
            if (string.IsNullOrEmpty(Fname))
                Fname = "NULL";
            else
                Fname = "'" + Fname + "'";
            if (string.IsNullOrEmpty(Lname))
                Lname = "NULL";
            else
                Lname = "'" + Lname + "'";
            if (string.IsNullOrEmpty(salary))
                salary = "NULL";
            else
                salary = "" + salary + "";
            if (string.IsNullOrEmpty(Bdata))
                Bdata = "NULL";
            else
                Bdata = "'" + Bdata + "'";
            if (string.IsNullOrEmpty(Jop_title))
                Jop_title = "NULL";
            else
                Jop_title = "'" + Jop_title + "'";
            if (string.IsNullOrEmpty(userName))
                userName = "NULL";
            else
                userName = "'" + userName + "'";
            if (string.IsNullOrEmpty(password))
                password = "NULL";
            else
                password = "'" + password + "'";
            if (string.IsNullOrEmpty(nationalID))
                nationalID = "NULL";
            else
                nationalID = "'" + nationalID + "'";
            if (string.IsNullOrEmpty(Gender))
                Gender = "NULL";
            else
                Gender = "'" + Gender + "'";
            if (string.IsNullOrEmpty(Address))
                Address = "NULL";
            else
                Address = "'" + Address + "'";
            if (string.IsNullOrEmpty(Religion))
                Religion = "NULL";
            else
                Religion = "'" + Religion + "'";
            if (string.IsNullOrEmpty(Status))
                Status = "NULL";
            else
                Status = "'" + Status + "'";
            return controller.UpdateaEmpAtUserNamePass(Fname, Lname, salary, Bdata, Jop_title, userName, password, nationalID, Gender, Address, Religion, Status, oldUserName, oldPass);


        }

        public DataTable selectEmpAtUserNamePass(string userName, string password)
        {
            return controller.selectEmpAtUserNamePass(userName, password);
        }
        public int InsertMachine(string name, string startDate)
        {
            if (string.IsNullOrEmpty(name))
                name = "NULL";
            else
                name = "'" + name + "'";
            if (string.IsNullOrEmpty(startDate))
                startDate = "NULL";
            else
                startDate = "'" + startDate + "'";

            return controller.InsertMachine(name, startDate);
        }
        public DataTable GetAllMachines()
        {
            return controller.GetAllMachines();
        }

        public string GetLastMachine()
        {
            DataTable dt = controller.GetLastMachine();
            return dt.Rows[0]["ID"].ToString();

        }
        
        
        public string GetLastProduct()
        {
            DataTable dt = controller.GetLastProduct();
            return dt.Rows[0]["ID"].ToString();

        }


        //Stats
        public DataTable GetMaleFemale()
        {
            return controller.GetMaleFemale();
        }
        public DataTable GetAvgSalaries()
        {
            return controller.GetAvgSalaries();
        }
        public DataTable GetReligions()
        {
            return controller.GetReligions();
        }
        public DataTable GetTopProductionLines()
        {
            return controller.GetTopProductionLines();
        }
        public DataTable GetOldestMachines()
        {
            return controller.GetOldestMachines();
        }
        public DataTable SelectHighestPeopleReside()
        {
            return controller.SelectHighestPeopleReside();
        }
        public DataTable GetNumEmps()
        {
            return controller.GetNumEmps();
        }
        public DataTable GetNumReligions()
        {
            return controller.GetNumReligions();
        }
        public int InsertMsgToEmps(string userName,string password, string subject, string msg, DataTable toEmps)
        {
            if (string.IsNullOrEmpty(subject))
                subject = "NULL";
            else
                subject = "'" + subject + "'";
            if (string.IsNullOrEmpty(msg))
                msg = "NULL";
            else
                msg = "'" + msg + "'";

            DataTable dt = selectEmpAtUserNamePass(userName, password);
            string senderId =dt.Rows[0]["ID"].ToString();
            return controller.InsertMsgToEmps(senderId, subject, msg, toEmps);
        }
        public DataTable SelectAllRecievedMsgs(string userName, string password)
        {
            return controller.SelectAllRecievedMsgs(userName, password);
        }

        public int sendAssignedWorkerId(string id, string machine)
        {
            return controller.AssignedWorkerId(id, machine);
        }
        public int updateProduction(int lineID, int productID, int amount)
        {
            return controller.updateProdcution(lineID, productID, amount);
        }

        public DataTable GetTargetVsProduced()
        {
            return controller.GetTargetVsProduced();
        }
        public double GetTotalCost()
        {
            return controller.GetTotalCost();
        }
        public double GetTotalSal()
        {
            int currentMonth = DateTime.Now.Month;
            return controller.GetTotalSal(currentMonth);
        }
        public DataTable GetTotalEmpsOverYears()
        {

            DataTable dt = controller.GetTotalEmpsOverYears();
            if(dt.Rows.Count>0)
            {
                dt.Columns["EmpsCount"].ReadOnly = false;
                int sum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sum = sum + int.Parse(dt.Rows[i]["EmpsCount"].ToString());
                    dt.Rows[i]["EmpsCount"] = sum.ToString();

                }
                return dt;
            }
            return new DataTable();
            
        }

        public DataTable GetProductionoOverYears()
        {
            return controller.GetProductionoOverYears();
        }

        public DataTable GetProductAmtOverAllYearsAccu(string prodLineId, string productId)
        {
            DataTable dt= controller.GetProductAmtOverAllYearsAccu(prodLineId, productId); 
            if(dt.Rows.Count>0)
            {
                dt.Columns["sumInYear"].ReadOnly = false;
                int sum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sum = sum + int.Parse(dt.Rows[i]["sumInYear"].ToString());
                    dt.Rows[i]["sumInYear"] = sum.ToString();

                }
                return dt;
            }
            return new DataTable();
            
        }
        
        public DataTable GetProductAmtOverAllYears(string prodLineId, string productId)
        {
            return controller.GetProductAmtOverAllYearsAccu(prodLineId, productId); 
        }

        public DataTable GetAllProductionLine()
        {
            return controller.GetAllProductionLine();
        }
        public DataTable GetAllProductsAtProductionLine(string productionLine)
        {
            return controller.GetAllProductsAtProductionLine(productionLine);
        }
        public DataTable GetProductionOverThisYearAcu(string prodLineId, string product_id, string year)
        {
            string currentYear = DateTime.Now.Year.ToString();
            DataTable dt= controller.GetProductionOverThisYear(prodLineId, product_id, year);
            if (dt.Rows.Count > 0)
            {
                dt.Columns["monAmount"].ReadOnly = false;
                int sum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sum = sum + int.Parse(dt.Rows[i]["monAmount"].ToString());
                    dt.Rows[i]["monAmount"] = sum.ToString();

                }
                return dt;
            }
            return new DataTable();
            

        }
        
        public DataTable GetProductionOverThisYear(string prodLineId, string product_id, string year)
        {
            string currentYear = DateTime.Now.Year.ToString();
            return controller.GetProductionOverThisYear(prodLineId, product_id, year);

        }
        public DataTable GetTargedVsActual()
        {
            return controller.GetTargedVsActual();
        }
        public DataTable GetMachinesOverYearsAcu()
        {
            string currentYear = DateTime.Now.Year.ToString();
            DataTable dt = controller.GetMachinesOverYears(currentYear);
            if(dt.Rows.Count>0)
            {
                dt.Columns["sumMachines"].ReadOnly = false;
                int sum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sum = sum + int.Parse(dt.Rows[i]["sumMachines"].ToString());
                    dt.Rows[i]["sumMachines"] = sum.ToString();

                }
                return dt;
            }
            return new DataTable();
            
        }
        public DataTable GetAllProducts()
        {
            return controller.GetAllProducts();
        }
        public int InsertNewProduct(string name, string cost)
        {
            if (string.IsNullOrEmpty(name))
                name = "NULL";
            else
                name = "'" + name + "'";
            
            if (string.IsNullOrEmpty(cost))
                cost = "NULL";
            else
                cost = "" + cost + "";
            return controller.InsertNewProduct(name, cost);
        }

        public DataTable GetProductAtId(string id)
        {
            return controller.GetProductAtId(id);
        }
        public DataTable UpdateProductAtId(string id, string name, string cost)
        {
            if (string.IsNullOrEmpty(name))
                name = "NULL";
            else
                name = "'" + name + "'";

            if (string.IsNullOrEmpty(cost))
                cost = "NULL";
            else
                cost = "" + cost + "";
            return controller.UpdateProductAtId(id, name, cost);
        }
        public int DeleteProductAtId(string id)
        {
            return controller.DeleteProductAtId(id);
        }
        public DataTable SelectEmpsLikeName(string name)
        {
            
            return controller.SelectEmpsLikeName(name);
        }
        public DataTable searchAndFilter(FiltersClasses.EmpFilter empFilter)
        {
            return controller.searchAndFilterEmployees(empFilter.GetSqlQuery());
        }
        public DataTable searchAndFilterMachines(FiltersClasses.MachineFilter machiesFilter)
        {
            return controller.searchAndFilterMachines(machiesFilter.GetSqlQuery());
        }
        public int LinkMachineToProductionLine(string Line_id, string Machine_id)
        {
            return controller.LinkMachineToProductionLine(Line_id, Machine_id);
        }
        
        public int LinkProductToProductoinLine(string Line_id, string product_id)
        {
            return controller.LinkProductToProductoinLine(Line_id, product_id);
        }

        public void UpdateLinkProductToProductionLine(string product_id, string oldLine_id, string newLine_id)
        {
            if (controller.UpdateLinkProductToProductionLine(product_id, oldLine_id, newLine_id) == 0)
            {
                controller.LinkProductToProductoinLine(newLine_id, product_id);
            }
        }




    }

}
