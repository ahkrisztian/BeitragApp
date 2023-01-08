using AutoMapper;
using BeitragRdr.DTOs;
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
        private readonly IMapper mapper;

        public BeitragController(IBeitragRepo beitragRepo, ILogger<BeitragController> logger, IMapper mapper)
        {
            this.beitragRepo = beitragRepo;
            this.logger = logger;
            this.mapper = mapper;
        }

        // GET: api/<BeitragController>
        [HttpGet]
        public ActionResult<IEnumerable<BeitragDTO>> GetTheBeitrags()
        {
            logger.LogInformation("GetAllBeitrags get called");
            var output = beitragRepo.GetAllBeitragsAsync();

            if(output.Any())
            {
                logger.LogInformation("Ok200 returned");
                return Ok(mapper.Map<IEnumerable<BeitragDTO>>(output));               
            }

            logger.LogWarning("GetAllBeitrags got called, Bad Request was returned 400");
            return BadRequest();
            
        }

        // GET api/<BeitragController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeitragDTO>> GetTheBeitragsByid(int id)
        {
            logger.LogInformation("GetTheBeitragsByid/{id} get called", id);
            var output = await beitragRepo.GetBeitragById(id);

            if (output != null)
            {
                logger.LogInformation("Ok200 returned");
                return Ok(mapper.Map<BeitragDTO>(output));
            }

            logger.LogWarning("GetTheBeitragsByid/{id} got called, Bad Request was returned 400", id);
            return BadRequest();
            
        }

        // POST api/<BeitragController>
        [HttpPost]
        public ActionResult CreateBeitrag([FromBody] BeitragDTO beitrag)
        {
            try
            {               
                beitragRepo.CreateBeitrag(mapper.Map<Beitrag>(beitrag));
                logger.LogInformation("CreateBeitrag was called and returned Ok200");

                return Ok();
            }
            catch (Exception ex)
            {

                logger.LogWarning("The CreateBeitrag was called but error {message}", ex.Message);
                return BadRequest();
            }
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
        public async Task<ActionResult> DeleteBeitrag(int id)
        {
            var result = await beitragRepo.GetBeitragById(id);

            if(result == null)
            {
                logger.LogWarning("DeleteBeitrag/id was called and Returned NotFound404.", id);
                return NotFound();
            }

            beitragRepo.DeleteBeitrag(id);

            logger.LogInformation("DeleteBeitrag/{id} was called and Returned NoContent204", id);

            return NoContent();

        }
    }
}
