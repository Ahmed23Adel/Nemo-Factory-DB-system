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

        //hossam end
    }
}
