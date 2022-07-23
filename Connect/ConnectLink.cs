using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace ApiProject.Connect

{
    public class ConnectLink
    {

        private IConfiguration iConfig;

        public ConnectLink(IConfiguration configuration)
        {
            iConfig = configuration;
        }
        public IDbConnection CreateConnection(string name = "default")
        {

            switch (name)
            {
                case "default":
                    {
                        var ConnectionString = iConfig["ConnectionStrings:DefaultConnection"];

                            return new SqlConnection(ConnectionString);
                    }
                default:
                    {
                        throw new Exception("name 不存在。");
                    }
            }

        }
    }
}
