using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProject.BusinessLogic;
using ApiProject.Model;

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
        //public async Task<ActionResult<IEnumerable<DepData>>> GetAsync()
        //{
        //    var select = await depLogic.dep_select_Logic();

        //    //return Ok(select);
        //    return "temp";
        //}
        public async Task<string> Get()
        {
            return "test ok";
        }

        // POST 
        [HttpPost]
        public async Task<ResFormat> Post([FromForm] DepData value)
        {

            ResFormat insert = await depLogic.dep_insert_Logic(value);

            return insert;
        }

        // PUT
        [HttpPut]
        public async Task<ResFormat> Put([FromForm] DepData value)
        {

            ResFormat update = await depLogic.dep_update_Logic(value);

            return update;
        }

        // DELETE 
        [HttpDelete]
        public async Task<ResFormat> Delete([FromForm] DepData value)
        {
            ResFormat delete = await depLogic.dep_delete_Logic(value);

            return delete;
        }
    }
}
