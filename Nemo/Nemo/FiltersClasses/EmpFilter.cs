using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemo.FiltersClasses
{
    public class EmpFilter
    {

        public EmpFilter()
        {
            salLess = "";
            salgreater = "";
            bDateLess = "";
            bDategreater = "";
            hiringDateLess = "";
            hiringDategreater = "";
            genderMaleFound = false ;
            genderFemaleFound = false;
            statusMarriedFound = false;
            statusNotMarriedFound = false;


            isAndAdded = false;
        }

        public string name { get; set; }
        public string salLess { get; set; }
        public string salgreater { get; set; }
        public string bDateLess { get; set; }
        public string bDategreater { get; set; }
        public string hiringDateLess { get; set; }
        public string hiringDategreater { get; set; }

        public bool male { get; set; }
        public bool female { get; set; }
        
        public bool married { get; set; }
        public bool single { get; set; }
        private bool genderMaleFound, genderFemaleFound;
        private bool statusMarriedFound, statusNotMarriedFound;
        static bool isAndAdded;

        public void setMarried(bool maried)
        {
            this.married = maried;
            statusMarriedFound = maried;
        }
        
        public void setSingle(bool notmaried)
        {
            this.single = notmaried;
            statusNotMarriedFound = notmaried;
        }
        
        public void setMale(bool male)
        {
            this.male = male;
            genderMaleFound = male;
        }
        
        public void setFemale(bool female)
        {
            this.female = female;
            genderFemaleFound = female;
        }


        private void append(StringBuilder query, string _appendable)
        {
            if (isAndAdded)
            {
                query.Append( "And ");
                isAndAdded = true;

            }
            query .Append( _appendable + " ");
            isAndAdded = true;
        }


        public string GetSqlQuery()
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ID,CONCAT(Fname,' ',Lname)AS 'Name',CASE  WHEN Jop_title = 'M'  THEN 'Manager' WHEN Jop_title = 'W' THEN 'Worker' WHEN Jop_title = 'S'  THEN 'Supervisor' END as 'Jop_description', Salary FROM Employee ");

                
            isAndAdded = false;
            if (IsThereACondition())
            {
                query.Append( "WHERE ");
                
                if (!string.IsNullOrEmpty(name))
                {
                    append(query, "(Fname LIKE '%" + name + "%' OR Lname LIKE '%" + name + "%')");
                }
                
                if (!string.IsNullOrEmpty(salgreater))
                {
                    append(query, "salary >" + salgreater + " ");
                }
                
                if (!string.IsNullOrEmpty(salLess))
                {
                    append(query, "salary <" + salLess + " ");
                }
                
                if (!string.IsNullOrEmpty(bDategreater))
                {
                    append(query, "Bdata >'" + bDategreater + "' ");
                }
                
                if (!string.IsNullOrEmpty(bDateLess))
                {
                    append(query, "Bdata <'" + bDateLess + "' ");
                }
                
                if (!string.IsNullOrEmpty(hiringDategreater))
                {
                    append(query, "HiringDate >'" + hiringDategreater + "' ");

                }
                
                if (!string.IsNullOrEmpty(hiringDateLess))
                {
                    append(query, "HiringDate <'" + hiringDateLess + "' ");

                }
                if (genderMaleFound && genderFemaleFound)
                {
                    append(query, "(Gender = 'M' OR Gender = 'F') ");

                }
                else if (genderMaleFound)
                {
                    append(query, "Gender = 'M' ");

                }
                
                else if (genderFemaleFound)
                {
                    append(query, "Gender = 'F' ");

                }
                
                if (statusMarriedFound && statusNotMarriedFound)
                {
                    append(query, "(Status = 'M' OR Status = 'S')");

                }
                else if (statusMarriedFound)
                {
                    append(query, "Status = 'M' ");

                }
                
                else if (statusNotMarriedFound)
                {
                    append(query, "Status = 'S' ");

                }
            }

                
            return query.ToString();
        }

        private bool IsThereACondition()
        {
            if (genderMaleFound || genderFemaleFound ||statusMarriedFound || statusNotMarriedFound ||
                !string.IsNullOrEmpty(name)||
                !string.IsNullOrEmpty(salgreater) || !string.IsNullOrEmpty(salLess) ||
               ! string.IsNullOrEmpty(bDategreater) || !string.IsNullOrEmpty(bDateLess) ||
                !string.IsNullOrEmpty(hiringDategreater) || !string.IsNullOrEmpty(hiringDateLess))
            {
                return true;
            }
            return false;

        }

    }
}
