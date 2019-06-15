using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using humataapp.api.Data;
using humataapp.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumataApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DataContext _dbContext;

        public ValuesController(DataContext dbcontext)
        {
            _dbContext=dbcontext;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values= await _dbContext.Values.ToListAsync();
            if(!values.Any()){
                return NotFound();
            }
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value= await _dbContext.Values.FirstOrDefaultAsync(v=>v.Id==id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
