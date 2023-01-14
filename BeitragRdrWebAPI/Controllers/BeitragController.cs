using AutoMapper;
using Azure;
using BeitragRdr.DTOs;
using BeitragRdr.Models;
using BeitragRdrDataAccessLibrary.Repo;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace BeitragRdrWebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
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
        /// <summary>
        /// Get a list of all Beitrags in the system.
        /// </summary>
        /// <remarks>
        /// Sample Request: GET /Beitrag
        /// [
        /// {
            ///    "name": "Winter",
            ///    "description": "Winter",
            ///    "beitragInsta": {
            ///      "name": "Sommer",
            ///      "description": "Winter",
            ///      "createdByUserId": null,
            ///      "createdDate": null,
            ///      "lastModifiedUserId": null,
            ///      "lastModifiedDate": null,
            ///     "image": {
            ///      "name": "string",
            ///      "imageUrl": "string",
            ///      "base64data": "string"
            ///    }
            ///    },
            ///    "beitragFace": {
            ///      "name": "Winter",
            ///      "description": "Winter",
            ///      "createdByUserId": null,
            ///      "createdDate": null,
            ///      "lastModifiedUserId": null,
            ///      "lastModifiedDate": null
            ///    },
            ///    "beitragPintr": {
            ///      "name": "Winter",
            ///      "description": "Winter",
            ///      "createdByUserId": "1",
            ///      "createdDate": "2020-01-01T00:00:00",
            ///      "lastModifiedUserId": "1",
            ///      "lastModifiedDate": "2020-01-01T00:00:00"
            ///    },
            ///    "tags": [
            ///      {
            ///        "tags": {
            ///          "tag": "Christmas"
            ///        }
            ///}
            ///    ]
            ///}
        /// ]
        /// </remarks>
        /// <returns></returns>
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
        /// <summary>
        /// Get a Beitrag from the database.
        /// </summary>
        /// <remarks>
        /// Sample Request: GET /Beitrag{id}
        /// [
        /// {
        ///    "name": "Winter",
        ///    "description": "Winter",
        ///    "beitragInsta": {
        ///      "name": "Sommer",
        ///      "description": "Winter",
        ///      "createdByUserId": null,
        ///      "createdDate": null,
        ///      "lastModifiedUserId": null,
        ///      "lastModifiedDate": null,
        ///     "image": {
        ///      "name": "string",
        ///      "imageUrl": "string",
        ///      "base64data": "string"
        ///    }
        ///    },
        ///    "beitragFace": {
        ///      "name": "Winter",
        ///      "description": "Winter",
        ///      "createdByUserId": null,
        ///      "createdDate": null,
        ///      "lastModifiedUserId": null,
        ///      "lastModifiedDate": null
        ///    },
        ///    "beitragPintr": {
        ///      "name": "Winter",
        ///      "description": "Winter",
        ///      "createdByUserId": "1",
        ///      "createdDate": "2020-01-01T00:00:00",
        ///      "lastModifiedUserId": "1",
        ///      "lastModifiedDate": "2020-01-01T00:00:00"
        ///    },
        ///    "tags": [
        ///      {
        ///        "tags": {
        ///          "tag": "Christmas"
        ///        }
        ///}
        ///    ]
        ///}
        /// ]
        /// </remarks>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTheBeitragsByid")]
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

        // POST api/BeitragController
        /// <summary>
        /// Create a Beitrag.
        /// </summary>
        /// <remarks>
        /// Sample Request: POST /Beitrag
        /// [
        /// {
        ///    "name": "Winter",
        ///    "description": "Winter",
        ///    "beitragInsta": {
        ///      "name": "Sommer",
        ///      "description": "Winter",
        ///     "image": {
        ///      "name": "string",
        ///      "imageUrl": "string",
        ///      "base64data": "string"
        ///    }
        ///    },
        ///    "beitragFace": {
        ///      "name": "Winter",
        ///      "description": "Winter",
        ///      "createdByUserId": null,
        ///      "createdDate": null,
        ///      "lastModifiedUserId": null,
        ///      "lastModifiedDate": null
        ///    },
        ///    "beitragPintr": {
        ///      "name": "Winter",
        ///      "description": "Winter",
        ///      "createdByUserId": "1",
        ///    },
        ///    "tags": [
        ///      {
        ///        "tags": {
        ///          "tag": "Christmas"
        ///        }
        ///}
        ///    ]
        ///}
        /// ]
        /// </remarks>
        /// <returns>
        /// [
        /// {
        ///    "name": "Winter",
        ///    "description": "Winter",
        ///    "beitragInsta": {
        ///      "name": "Sommer",
        ///      "description": "Winter",
        ///      "createdByUserId": null,
        ///      "createdDate": null,
        ///      "lastModifiedUserId": null,
        ///      "lastModifiedDate": null,
        ///     "image": {
        ///      "name": "string",
        ///      "imageUrl": "string",
        ///      "base64data": "string"
        ///    }
        ///    },
        ///    "beitragFace": {
        ///      "name": "Winter",
        ///      "description": "Winter",
        ///      "createdByUserId": null,
        ///      "createdDate": null,
        ///      "lastModifiedUserId": null,
        ///      "lastModifiedDate": null
        ///    },
        ///    "beitragPintr": {
        ///      "name": "Winter",
        ///      "description": "Winter",
        ///      "createdByUserId": "1",
        ///      "createdDate": "2020-01-01T00:00:00",
        ///      "lastModifiedUserId": "1",
        ///      "lastModifiedDate": "2020-01-01T00:00:00"
        ///    },
        ///    "tags": [
        ///      {
        ///        "tags": {
        ///          "tag": "Christmas"
        ///        }
        ///}
        ///    ]
        ///}
        /// ]
        /// </returns>
        [HttpPost]
        public ActionResult<BeitragDTO> CreateBeitrag([FromBody] BeitragDTO beitrag)
        {
            if(beitrag == null)
            {
                logger.LogWarning("The CreateBeitrag was called but error.");
                return BadRequest();
            }

            var beitragmodel = mapper.Map<Beitrag>(beitrag);

            beitragRepo.CreateBeitrag(beitragmodel);

            var readbeitragmodel = mapper.Map<BeitragDTO>(beitragmodel);

            var output = CreatedAtRoute(nameof(GetTheBeitragsByid), new { Id = beitragmodel.Id }, readbeitragmodel);

            logger.LogInformation("CreateBeitrag was called and returned Ok201");
            return output;
        }

        // PUT api/BeitragController/5
        /// <summary>
        /// Update a Beitrag.
        /// </summary>
        /// <remarks>
        /// PUT /Beitrag
        /// </remarks>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBeitrag(int id, BeitragDTO beitrag)
        {
            var beitragmodel = await beitragRepo.GetBeitragById(id);

            if(beitragmodel == null)
            {
                logger.LogInformation("UpdateBeitrag was called and returned NotFound404");
                return NotFound();
            }

            mapper.Map(beitrag, beitragmodel);

            beitragRepo.UpdateBeitrag(beitragmodel);

            logger.LogInformation("UpdateBeitrag was called and returned NoContent204");
            return NoContent();

        }

        //PATCH api/api/BeitragController/5
        /// <summary>
        /// Partial update a Beitrag.
        /// </summary>
        /// <remarks>
        /// PATCH /Beitrag/id
        /// </remarks>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialBeitragUpdate(int id, JsonPatchDocument<BeitragDTO> patchDocument)
        {
            var beitrag = await beitragRepo.GetBeitragById(id);

            if(beitrag == null)
            {
                return NotFound();
            }

            var beitragToPatch = mapper.Map<BeitragDTO>(beitrag);


            patchDocument.ApplyTo(beitragToPatch, ModelState);

            if (!TryValidateModel(patchDocument))
            {
                return ValidationProblem(ModelState);
            }

            mapper.Map(beitragToPatch, beitrag);

            beitragRepo.UpdateBeitrag(beitrag);

            return NoContent();
        }

        // DELETE api/<BeitragController>/5
        /// <summary>
        /// Delete a Beitrag.
        /// </summary>
        /// <remarks>
        /// DELETE /Beitrag
        /// </remarks>
        /// <returns></returns>
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
