﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace PCLService.Data
{
    public static class CallDataTableFactory
    {
        public static DataTable GetDataSource (Models.CallData data)
        {
            var dt = new DataTable("CallData");
            var colPastorName = new DataColumn("PastorName", typeof(string));
            var colChurchName = new DataColumn("ChurchName", typeof(string));
            var colCity = new DataColumn("City", typeof(string));
            var colState = new DataColumn("State", typeof(string));
            var colSalary = new DataColumn("Salary", typeof(decimal));
            var colHousingAllowance = new DataColumn("HousingAllowance", typeof(decimal));
            var colMedical = new DataColumn("Medical", typeof(decimal));
            var colPension = new DataColumn("Pension", typeof(decimal));
            var colLife = new DataColumn("Life", typeof(decimal));
            var colDisability = new DataColumn("Disability", typeof(decimal));
            var colSECA = new DataColumn("SECA", typeof(decimal));
            var colVacation = new DataColumn("Vacation", typeof(decimal));
            var colStudyLeave = new DataColumn("StudyLeave", typeof(decimal));
            var colSabbatical = new DataColumn("Sabbatical", typeof(decimal));
            var colWorldlyCareClause = new DataColumn("WorldlyCareClause", typeof(string));
            var colOtherExpenses = new DataColumn("OtherExpenses", typeof(string));
            var colInsuranceMessage = new DataColumn("InsuranceMessage", typeof(string));

            dt.Columns.AddRange(new DataColumn[] { colPastorName, colChurchName, colCity, colState, colSalary, colHousingAllowance, colMedical, colPension, colLife, 
                colDisability, colSECA, colVacation, colStudyLeave, colSabbatical, colOtherExpenses, colWorldlyCareClause, colInsuranceMessage });

            var row = dt.NewRow();

            row[colPastorName] = data.PastorName;
            row[colChurchName] = data.ChurchName;
            row[colCity] = data.City;
            row[colState] = data.State;
            row[colSalary] = data.Salary;
            row[colHousingAllowance] = data.HousingAllowance;
            row[colMedical] = data.Medical;
            row[colPension] = data.Pension;
            row[colLife] = data.Life;
            row[colDisability] = data.Disability;
            row[colSECA] = data.SECA;
            row[colVacation] = data.Vacation;
            row[colStudyLeave] = data.StudyLeave;
            row[colSabbatical] = data.Sabbatical;
            row[colOtherExpenses] = data.OtherExpenses;
            row[colWorldlyCareClause] = data.WorldlyCareClause;
            row[colInsuranceMessage] = data.InsuranceMessage;

            dt.Rows.Add(row);

            return dt;

        }
    }
}