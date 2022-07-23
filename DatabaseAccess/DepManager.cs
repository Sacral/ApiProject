using System;
using System.Collections.Generic;
using ApiProject.Connect;
using ApiProject.Model;
using Dapper;
using ApiProject.UtiFunction;
using System.Text.Json;



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


        public async Task<ResFormat> DepartmentSelect(DepData newdata)
        {
            List<string> list1 = new List<string>();

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

                var dataList = cn.Query<DepData>(sql).ToList();

                string resString = JsonSerializer.Serialize(dataList);
                ResFormat resJson = UtiFunctions.ResponseString(0, resString);

                return resJson;
            }
            else
            {
                string paRessult = string.Join(" AND ", list1);
                sql += "WHERE "+paRessult;

                var dataList = cn.Query<DepData>(sql, newdata ).ToList();
                string resString = JsonSerializer.Serialize(dataList);
                ResFormat resJson = UtiFunctions.ResponseString(0, resString);

                return resJson;
            }

        }


        public async Task<ResFormat> DepartmentInsert(DepData newdata)
        {
            var cn = conLink.CreateConnection();

            var sql = "INSERT INTO [AdventureWorks2019].[HumanResources].[Department] ( Name, GroupName,ModifiedDate) VALUES (@name, @groupName, @modifiedDate)";

            int recordset =  cn.Execute(sql, newdata);

            ResFormat resJson = UtiFunctions.ResponseString(recordset,"");

            return resJson;
        }

        public async Task<ResFormat> DepartmentUpdate(DepData newdata)
        {
            var cn = conLink.CreateConnection();

            var sql = "UPDATE [AdventureWorks2019].[HumanResources].[Department] SET  Name = @name, GroupName = @groupName,ModifiedDate = @modifiedDate WHERE DepartmentID = @departmentID   ";
  
            int recordset = cn.Execute(sql, newdata);

            //var reader = cn.ExecuteReader();

            ResFormat resJson = UtiFunctions.ResponseString(recordset,"");

            return resJson;
        }

        public async Task<ResFormat> DepartmentDelete(DepData newdata)
        {
            var cn = conLink.CreateConnection();

            var sql = "DELETE FROM [AdventureWorks2019].[HumanResources].[Department] WHERE departmentID = @departmentID   ";

            int recordset  = cn.Execute(sql, newdata);

            ResFormat resJson = UtiFunctions.ResponseString(recordset, "");

            return resJson;
        }
    }
}
