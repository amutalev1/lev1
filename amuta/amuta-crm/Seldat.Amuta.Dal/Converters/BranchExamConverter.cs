using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using Seldat.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using Unity;
using static Seldat.Amuta.Dal.DbContent;


namespace Seldat.Amuta.Dal.Converters
{
   public class BranchExamConverter
    {
        public static BranchExam RowToBranchExam(DataRow row)
        {
            return new BranchExam()
            {
                SumbitExamScholarshipAddition = DataRowHelper.GetValue<int>(row, Tables.BranchExams.SubmitExamScholarshipAddition.Name),
                FailingSumbitExamScholarshipReducing = DataRowHelper.GetValue<int>(row, Tables.BranchExams.FailingSubmitExamScholarshipReducing.Name),
                Id = DataRowHelper.GetValue<int>(row, Tables.BranchExams.Id.Name),
                Branch = new Branch() { Id = DataRowHelper.GetValue<int>(row, Tables.BranchExams.BranchId.Name)},
                PassedExamScholarshipAddition = DataRowHelper.GetValue<int>(row, Tables.BranchExams.PassedExamScholarshipAddition.Name),
                NotPassedExamScholarshipReducing = DataRowHelper.GetValue<int>(row, Tables.BranchExams.NotPassedExamScholarshipReducing.Name),
                PassGrade = DataRowHelper.GetValue<decimal>(row, Tables.BranchExams.PassGrade.Name),
                Subject = DataRowHelper.GetValue<string>(row, Tables.BranchExams.Subject.Name)
            };
        }
        public static List<BranchExam> TableToBranchExam(DataTable table)
        {
            if (table == null)
                return null;
            List<BranchExam> branchExams = new List<BranchExam>();
            foreach (DataRow row in table.Rows)
            {
                branchExams.Add(RowToBranchExam(row));
            }
            return branchExams;
        }
    }
}
