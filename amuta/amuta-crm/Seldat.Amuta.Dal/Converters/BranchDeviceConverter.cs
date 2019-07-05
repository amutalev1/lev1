using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using Seldat.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using Unity;
using static Seldat.Amuta.Dal.DbContent;
using static Seldat.Amuta.Entities.BranchDevice;

namespace Seldat.Amuta.Dal.Converters
{
    class BranchDeviceConverter
    {
        public static BranchDevice RowToBranchDevice(DataRow row)
        {
            return new BranchDevice()
            {
                Device =new Device() {Id=DataRowHelper.GetValue<int>(row, Tables.BranchDevices.DeviceId.Name)} ,
                Branch = new Branch() { Id = DataRowHelper.GetValue<int>(row, Tables.BranchDevices.BranchId.Name) },             
            };
        }
        public static List<BranchDevice> TableToBranchDevice(DataTable table)
        {
            if (table == null)
                return null;
            List<BranchDevice> branchDevices = new List<BranchDevice>();
            foreach (DataRow row in table.Rows)
            {
                branchDevices.Add(RowToBranchDevice(row));
            }
            return branchDevices;
        }
    }
}

