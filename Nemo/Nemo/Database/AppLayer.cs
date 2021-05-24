﻿using System;
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

        public static AppLayer getInstance()
        {
            if (instance == null)
                instance = new AppLayer();
            return instance;
        }

        public DEFs.JOP_TITLES isUserNamePassExist(string userName, string pass)
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

        public DataTable getBasicDataForUserNamePass(string userName, string pass)
        {
            DataTable dt = controller.isUserNamePassExist(userName, pass);
            if (dt == null)
                return new DataTable();
            return dt;
        }

        public DataTable selectAllEmps()
        {
            return controller.selectAllEmps();
        }
        public DataTable selectEmpAtId(string id)
        {
            return controller.selectEmpAtId(id);
        }

        public int updateEmpAtId(string id, string Fname, string Lname, string Balance, string Bdata, string Jop_title, string userName, string password)
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
        public int deleteAtId(string id)
        {
            return controller.deleteAtId(id);
        }
    }
}
