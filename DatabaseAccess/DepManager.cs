using System;
using System.Collections.Generic;
using ApiProject.Connect;
using ApiProject.Model;
using Dapper;
using ApiProject.UtiFunction;


namespace ApiProject.DatabaseAccess
{
    public class DepManager
    {

        private IConfiguration config;
        private ConnectLink conLink;

        public DepManager(IConfiguration configuration)
        {
            config = configuration;
            conLink = new ConnectLink(config);
        }


        public async Task<List<DepData>> DepartmentSelect(DepData newdata)
        {
            List<string> list1 = new List<string>();
            List<DepData> dataList = new List<DepData>();

            var cn = conLink.CreateConnection();
            var sql = "SELECT * FROM [AdventureWorks2019].[HumanResources].[Department] ";


            if (!string.IsNullOrEmpty(newdata.name))
            {
                list1.Add(" Name = @name ") ;
            }

            if (!string.IsNullOrEmpty(newdata.groupName))
            {
                list1.Add (" GroupName = @groupName ") ;
            }

            if (list1.Count == 0)
            {

                dataList = cn.Query<DepData>(sql).ToList();

            }
            else
            {
                string paRessult = string.Join(" AND ", list1); 

                sql += "WHERE "+paRessult;

                dataList = cn.Query<DepData>(sql, newdata ).ToList();

            }

            return dataList;

        }


        public async Task<int> DepartmentInsert(DepData newdata)
        {
            var cn = conLink.CreateConnection();

            var sql = "INSERT INTO [AdventureWorks2019].[HumanResources].[Department] ( Name, GroupName,ModifiedDate) VALUES (@name, @groupName, @modifiedDate)";

            int recordset =  cn.Execute(sql, newdata);

            //ResFormat resJson = UtiFunctions.ResponseString(recordset,"");

            return recordset;
        }

        public async Task<int> DepartmentUpdate(DepData newdata)
        {
            var cn = conLink.CreateConnection();

            var sql = "UPDATE [AdventureWorks2019].[HumanResources].[Department] SET  Name = @name, GroupName = @groupName,ModifiedDate = @modifiedDate WHERE DepartmentID = @departmentID   ";
  
            int recordset = cn.Execute(sql, newdata);

            //var reader = cn.ExecuteReader();

            //ResFormat resJson = UtiFunctions.ResponseString(recordset,"");

            return recordset;
        }

        public async Task<int> DepartmentDelete(DepData newdata)
        {
            var cn = conLink.CreateConnection();

            var sql = "DELETE FROM [AdventureWorks2019].[HumanResources].[Department] WHERE DepartmentID = @departmentID   ";

            int recordset  = cn.Execute(sql, newdata);

            //ResFormat resJson = UtiFunctions.ResponseString(recordset, "");

            return recordset;
        }
    }
}
