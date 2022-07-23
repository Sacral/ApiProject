using System;
using System.Collections.Generic;
using ApiProject.DatabaseAccess;
using ApiProject.Model;
using ApiProject.UtiFunction;


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

        public async Task<ResFormat> dep_select_Logic(DepData value)
        {
            string name = value.name;
            string gname = value.groupName;
            ResFormat resJson;

            if(!string.IsNullOrEmpty(name) && !UtiFunctions.checkString(name))
            {
                return resJson = UtiFunctions.ResponseString(-1, "包含了非中英文的字元");
            }

            DepData newdata = new DepData
            {
                name = name,
                groupName = gname
            };
            return resJson = await depManager.DepartmentSelect(newdata);

            //if(!string.IsNullOrEmpty(name))
            //{

            //    if (!UtiFunctions.checkString(name))
            //    {
            //        return resJson = UtiFunctions.ResponseString(-1, "包含了非中英文的字元");
            //    }
            //    else
            //    {
            //        DepData newdata = new DepData
            //        {
            //            name = name,
            //            groupName = gname
            //        };
            //        return resJson = await depManager.DepartmentSelect(newdata);
            //    }

            //}
            //else
            //{
            //    DepData newdata = new DepData
            //    {
            //        name = name,
            //        groupName = gname
            //    };
            //    return resJson = await depManager.DepartmentSelect(newdata);
            //}

        }

        // POST 

        public async Task<ResFormat> dep_insert_Logic(DepData value)
        {
            string name = value.name;
            string gname = value.groupName;
            ResFormat resJson;
            //正規化
            if (UtiFunctions.checkString(name))
            {
                DepData newdata = new DepData
                {
                    name = name,
                    groupName = gname,
                    modifiedDate = DateTime.Now
                };
                return resJson = await depManager.DepartmentInsert(newdata);
            }
            else
            {
                return resJson = UtiFunctions.ResponseString(-1,"包含了非中英文的字元");
            }

        }

        // PUT

        public async Task<ResFormat> dep_update_Logic(DepData value)
        {
            string name = value.name;
            int depId = value.departmentID;
            string gname = value.groupName;
            ResFormat resJson;

            if (depId <= 0)
            {
                return resJson = UtiFunctions.ResponseString(-1, "id 不得為0或小於0");
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

                return resJson = await depManager.DepartmentUpdate(newdata);
            }
            else
            {
                return resJson = UtiFunctions.ResponseString(-1, "包含了非中英文的字元");
            }

        }

        // DELETE 

        public async Task<ResFormat> dep_delete_Logic(DepData value)
        {
            int depId = value.departmentID;
            ResFormat resJson;

            if (depId <= 0)
            {
                return resJson = UtiFunctions.ResponseString(-1, "id 不得為0或小於0");
            }
            else
            {
                DepData newdata = new DepData
                {
                    departmentID = depId
                };

                return resJson = await depManager.DepartmentDelete(newdata);

            }

        }
    }
}
