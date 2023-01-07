using BeitragRdr.Models;
using BeitragRdr.Models.SubModels;
using BeitragRdrDataAccessLibrary.Data;
using BeitragRdrDataAccessLibrary.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeitragRdrWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeitragController : ControllerBase
    {
        private readonly IBeitragRepo beitragRepo;
        private readonly ILogger<BeitragController> logger;

        public BeitragController(IBeitragRepo beitragRepo, ILogger<BeitragController> logger)
        {
            this.beitragRepo = beitragRepo;
            this.logger = logger;
        }

        // GET: api/<BeitragController>
        [HttpGet]
        public ActionResult<IEnumerable<Beitrag>> Get()
        {
            logger.LogInformation("GetAllBeitrags get called");
            var output = beitragRepo.GetAllBeitragsAsync();

            if(output != null)
            {
                return Ok(output);
            }

            return BadRequest();
        }

        // GET api/<BeitragController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var output = beitragRepo.GetBeitragById(id);

            if (output != null)
            {
                return Ok(output);
            }

            return BadRequest();
        }

        // POST api/<BeitragController>
        [HttpPost]
        public ActionResult Post([FromBody] Beitrag beitrag)
        {
            beitragRepo.CreateBeitrag(beitrag);

            return Ok();
        }

        // PUT api/<BeitragController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Beitrag beitrag)
        {
            beitragRepo.UpdateBeitrag(id);

            return Ok();

        }

        // DELETE api/<BeitragController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            beitragRepo.DeleteBeitrag(id);

            return Ok();
        }
    }
}
