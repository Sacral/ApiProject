using System;
using System.Collections.Generic;
using ApiProject.DatabaseAccess;
using ApiProject.Model;
using ApiProject.UtiFunction;
using System.Text.Json;


namespace ApiProject.BusinessLogic
{
    public class DepLogic
    {
        private DepManager depManager;

        public DepLogic(IConfiguration configuration)
        {
            depManager = new DepManager(configuration);
        }

        // GET 

        public async Task<List<DepData>> dep_select_Logic(DepData value)
        {
            string name = value.name;
            string gname = value.groupName;

             //dataList = new List<DepData>();

            DepData newdata = new DepData
            {
                name = name,
                groupName = gname
            };

            List<DepData> dataList = await depManager.DepartmentSelect(newdata);

            return dataList ;
                               
        }

        // POST 

        public async Task<int> dep_insert_Logic(DepData value)
        {
            string name = value.name;
            string gname = value.groupName;

            //正規化
            if (UtiFunctions.checkString(name))
            {
                DepData newdata = new DepData
                {
                    name = name,
                    groupName = gname,
                    modifiedDate = DateTime.Now
                };
                int dmRes = await depManager.DepartmentInsert(newdata);

                return dmRes; 

            }
            else
            {
                //return resJson = UtiFunctions.ResponseString(-1,"包含了非中英文的字元");
                return -1;
            }

        }

        // PUT

        public async Task<int> dep_update_Logic(DepData value)
        {
            string name = value.name;
            int depId = value.departmentID;
            string gname = value.groupName;

            if (depId <= 0)
            {
                return -2;
            }

            if (UtiFunctions.checkString(name))
            {
                DepData newdata = new DepData
                {
                    departmentID = depId,
                    name = name,
                    groupName = gname,
                    modifiedDate = DateTime.Now
                };

                int resUp = await depManager.DepartmentUpdate(newdata);
                return resUp; 
            }
            else
            {
                return -1;
            }

        }

        // DELETE 

        public async Task<int> dep_delete_Logic(DepData value)
        {
            int depId = value.departmentID;

            if (depId <= 0)
            {
                return -2; 
            }
            else
            {
                DepData newdata = new DepData
                {
                    departmentID = depId
                };

                return await depManager.DepartmentDelete(newdata);

            }

        }
    }
}
