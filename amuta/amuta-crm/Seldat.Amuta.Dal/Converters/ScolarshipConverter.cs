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
   public class ScolarshipConverter
    {
        public static Scolarship RowToScolarship(DataRow row)
        {
            return new Scolarship()
            {
                Id = DataRowHelper.GetValue<int>(row, Tables.Scolarships.Id.Name),
                Amount = DataRowHelper.GetValue<decimal>(row, Tables.Scolarships.Amount.Name)                         
            };
        }
    }
}
