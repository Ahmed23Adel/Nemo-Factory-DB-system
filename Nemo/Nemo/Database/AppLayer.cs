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

        public DataTable GetBasicDataForUserNamePass(string userName, string pass)
        {
            DataTable dt = controller.isUserNamePassExist(userName, pass);
            if (dt == null)
                return new DataTable();
            return dt;
        }

        public DataTable SelectAllEmps()
        {
            return controller.selectAllEmps();
        }
        public DataTable SelectEmpAtId(string id)
        {
            return controller.selectEmpAtId(id);
        }

        public int UpdateEmpAtId(string id, string Fname, string Lname, string Balance, string Bdata, string Jop_title, string userName, string password)
        {
            if (string.IsNullOrEmpty(Fname))
                Fname = "NULL";
            if (string.IsNullOrEmpty(Lname))
                Lname = "NULL";
            if (string.IsNullOrEmpty(Balance))
                Balance = "NULL";
            if (string.IsNullOrEmpty(Bdata))
                Bdata = null;
            if (string.IsNullOrEmpty(Jop_title))
                Jop_title = "NULL";
            if (string.IsNullOrEmpty(userName))
                userName = "NULL";
            if (string.IsNullOrEmpty(password))
                password = "NULL";

            return controller.updateEmpAtId(id, Fname, Lname, Balance, Bdata, Jop_title, userName, password);

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

        public int InsertEmp(string Fname, string Lname, string Balance, string Bdata, string Jop_title, string userName, string password, string nationalID)
        {
            if (string.IsNullOrEmpty(Fname))
                Fname = "NULL";
            if (string.IsNullOrEmpty(Lname))
                Lname = "NULL";
            if (string.IsNullOrEmpty(Balance))
                Balance = "NULL";
            if (string.IsNullOrEmpty(Bdata))
                Bdata = null;
            if (string.IsNullOrEmpty(Jop_title))
                Jop_title = "NULL";
            if (string.IsNullOrEmpty(userName))
                userName = "NULL";
            if (string.IsNullOrEmpty(password))
                password = "NULL";
            if (string.IsNullOrEmpty(nationalID))
                nationalID = "NULL";
            return controller.InsertEmp(Fname, Lname, Balance, Bdata, Jop_title, userName, password, nationalID);
        }

        //hossam

        public DataTable loadAssignedMachines(string username)
        {
            return controller.viewAssignedMachines(username);
        }

        public DataTable loadWorkerData(string userName)
        {
            return controller.loadWorkerData(userName);
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

        public int RemoveMachineAtId(string id)
        {
            return controller.RemoveMachineAtId(id);
        }

        public int UpdateMachineAtId(string id, string name, string date)
        {
            if (string.IsNullOrEmpty(name))
                name = "NULL";
            if (string.IsNullOrEmpty(date))
                date = "NULL";
            return controller.UpdateMachineAtId(id, name, date);
        }

        public DataTable GetMachineAtId(string id)
        {
            return controller.GetMachineAtId(id);
        }

        public int UpdateaEmpAtUserNamePass(string Fname, string Lname, string Balance, string Bdata, string Jop_title, string userName, string password, string nationalID, string Gender, string Address, string Religion, string Status, string oldUserName, string oldPass)
        {
            if (string.IsNullOrEmpty(Fname))
                Fname = "NULL";
            if (string.IsNullOrEmpty(Lname))
                Lname = "NULL";
            if (string.IsNullOrEmpty(Balance))
                Balance = "NULL";
            if (string.IsNullOrEmpty(Bdata))
                Bdata = null;
            if (string.IsNullOrEmpty(Jop_title))
                Jop_title = "NULL";
            if (string.IsNullOrEmpty(userName))
                userName = "NULL";
            if (string.IsNullOrEmpty(password))
                password = "NULL";
            if (string.IsNullOrEmpty(Gender))
                Gender = "NULL";
            if (string.IsNullOrEmpty(Address))
                Address = "NULL";
            if (string.IsNullOrEmpty(nationalID))
                nationalID = "NULL";
            if (string.IsNullOrEmpty(Religion))
                Religion = "NULL";
            if (string.IsNullOrEmpty(Status))
                Status = "NULL";
            return controller.UpdateaEmpAtUserNamePass(Fname, Lname, Balance, Bdata, Jop_title, userName, password, nationalID, Gender, Address, Religion, Status, oldUserName, oldPass);


        }

        public DataTable selectEmpAtUserNamePass(string userName, string password)
        {
            return controller.selectEmpAtUserNamePass(userName, password);
        }
        public int InsertMachine(string name, string startDate)
        {
            if (string.IsNullOrEmpty(name))
                name = "NULL";
            if (string.IsNullOrEmpty(startDate))
                startDate = "NULL";

            return controller.InsertMachine(name, startDate);
        }
        public DataTable GetAllMachines()
        {
            return controller.GetAllMachines();
        }
        //hossam end
    }
}
