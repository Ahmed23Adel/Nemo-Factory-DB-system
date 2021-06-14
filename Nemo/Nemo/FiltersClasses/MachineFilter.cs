using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemo.FiltersClasses
{
    public class MachineFilter
    {
        public string startDateLess { get; set; }
        public string startDateGreater { get; set; }
        public string name { get; set; }
        bool isAndAdded;

        public MachineFilter()
        {
            startDateLess = "";   
            startDateGreater = "";
            name = "";
            isAndAdded = false;

        }


        private void append(StringBuilder query, string _appendable)
        {
            if (isAndAdded)
            {
                query.Append("And ");
                isAndAdded = true;

            }
            query.Append(_appendable + " ");
            isAndAdded = true;
        }


        public string GetSqlQuery()
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT * FROM Machine ");

            isAndAdded = false;
            if (IsThereACondition())
            {
                query.Append("WHERE ");

                if (!string.IsNullOrEmpty(name))
                {
                    append(query, "Name LIKE '%" + name + "%' ");
                }

                if (!string.IsNullOrEmpty(startDateGreater))
                {
                    append(query, "Start_date >'" + startDateGreater + "' ");
                }

                if (!string.IsNullOrEmpty(startDateLess))
                {
                    append(query, "Start_date <'" + startDateLess + "' ");
                }


            }


            return query.ToString();
        }
        private bool IsThereACondition()
        {
            if (!string.IsNullOrEmpty(startDateLess) || !string.IsNullOrEmpty(startDateGreater) ||!string.IsNullOrEmpty(name))
            {
                return true;
            }
            return false;

        }
    }
}
