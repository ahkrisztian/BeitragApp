using AutoMapper;
using BeitragRdr.DTOs;
using BeitragRdr.Models;
using BeitragRdr.Models.UserModel;
using BeitragRdrDataAccessLibrary.Repo;
using Microsoft.AspNetCore.Mvc;

namespace BeitragRdrWebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo userRepo;
        private readonly ILogger<UserController> logger;
        private readonly IMapper mapper;

        // GET: UserController

        public UserController(IUserRepo userRepo, ILogger<UserController> logger, IMapper mapper)
        {
            this.userRepo = userRepo;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet("{objectId}")]
        [ActionName("GetUserByObjectId")]
        public async Task<ActionResult> GetUserByObjectId(string objectId)
        {
            logger.LogInformation("GetUser/{id} get called", objectId);
            var output = await userRepo.GetUser(objectId);

            if(output == null)
            {
                logger.LogWarning("GetUser/{id} got called, Not Found was returned", objectId);
                return NotFound();
            }

            logger.LogInformation("GetUser/{id} got called, Ok200 returned", objectId);
            return Ok(mapper.Map<UserReadDTO>(output));
        }

        [HttpPost]

        public ActionResult<UserReadDTO> CreateUser(UserCreateDTO user)
        {
            if (user == null)
            {
                logger.LogWarning("The CreateUser was called but error.");
                return BadRequest();
            }

            var usermodel = mapper.Map<User>(user);

            userRepo.CreateUser(usermodel);

            var readusermodel = mapper.Map<UserReadDTO>(usermodel);

            var output = CreatedAtRoute(nameof(GetUserByObjectId), new { Id = readusermodel.Id }, readusermodel);

            logger.LogInformation("CreateUser was called and returned Ok200");

            return Ok(output.Value);
        }

    }
}
