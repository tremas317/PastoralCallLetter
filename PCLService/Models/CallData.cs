using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCLService.Models
{    
    public class CallData
    {
        public string PastorName { get; set; }
        public string ChurchName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal Salary { get; set; }
        public decimal HousingAllowance { get; set; }
        public decimal Medical { get; set; }
        public decimal Pension { get; set; }
        public decimal Life { get; set; }
        public decimal Disability { get; set; }
        public decimal Vision { get; set; }
        public decimal SECA { get; set; }
        public decimal Vacation { get; set; }
        public decimal StudyLeave { get; set; }
        public decimal Sabbatical { get; set; }
        public string WorldlyCareClause { get; set; }
        public string OtherExpenses { get; set; }
        public string InsuranceMessage { get; set; }
        public string OutputFormat { get; set; }
        public string TimeStamp { get; set; }
        public string Key { get; set; }

    }
}