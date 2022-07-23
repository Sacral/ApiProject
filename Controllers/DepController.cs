using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProject.BusinessLogic;
using ApiProject.Model;
using ApiProject.UtiFunction;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DepController
    {

        private DepLogic depLogic;


        public DepController(IConfiguration configuration)
        {
            depLogic = new DepLogic(configuration);
        }

        // GET 
        [HttpGet]
        public async Task<ResFormat<DepData>> Get([FromQuery]DepData value)
        {
            string msg = "";
            int reCode = 1;
            List<DepData> resSelect = await depLogic.dep_select_Logic(value);

            if (!string.IsNullOrEmpty(value.name) && !UtiFunctions.checkString(value.name))
            {
                msg = "包含了非中英文的字元";
                reCode = 0;
            }

            return UtiFunctions.ResponseString<DepData>(reCode, msg, resSelect);
        }


        // POST 
        [HttpPost]
        public async Task<ResFormat<DepData>> Post([FromForm] DepData value)
        {

            int resInsert = await depLogic.dep_insert_Logic(value);
            string msg = "";

            if (resInsert < 0)
            {
                msg = "包含了非中英文的字元" ;
            }

            return UtiFunctions.ResponseString<DepData>(resInsert , msg);
        }

        // PUT
        [HttpPut]
        public async Task<ResFormat<DepData>> Put([FromForm] DepData value)
        {

            int  resUpdate = await depLogic.dep_update_Logic(value);
            string msg = "";

            if (resUpdate==-2)
            {
                msg = "id 不得為0或小於0";

            }else if (resUpdate == -1)
            {
                msg = "包含了非中英文的字元";
            }

            return UtiFunctions.ResponseString<DepData>(resUpdate, msg); 
        }

        // DELETE 
        [HttpDelete]
        public async Task<ResFormat<DepData>> Delete([FromForm] DepData value)
        {
            int resDelete = await depLogic.dep_delete_Logic(value);
            string msg = "";

            if (resDelete == -2)
            {
                msg = "id 不得為0或小於0";

            }

            return UtiFunctions.ResponseString<DepData>(resDelete, msg);
        }
    }
}
