using AutoMapper;
using BeitragRdr.DTOs;
using BeitragRdr.Models;
using BeitragRdr.Models.ImageModels;
using BeitragRdr.Models.SubModels;
using BeitragRdrDataAccessLibrary.Repo;
using BeitragRdrWebAPI.Controllers;
using BeitragRdrWebAPI.Profiles;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdrUnitTest
{
    public class BeitragControllerTest
    {
        Mock<IBeitragRepo> repo;
        BeitragProfiles profiles;
        MapperConfiguration mapperConfiguration;
        IMapper mapper;
        Mock<NullLogger<BeitragController>> mocklogger;

        public BeitragControllerTest()
        {
            repo= new Mock<IBeitragRepo>();
            profiles= new BeitragProfiles();
            mapperConfiguration = new MapperConfiguration(cfg => 
            cfg.AddProfile(profiles));
            mapper = new Mapper(mapperConfiguration);
            mocklogger = new Mock<NullLogger<BeitragController>>();
        }

        public void Dispose()
        {
            repo = null;
            profiles = null;
            mapperConfiguration = null;
            mapper = null;
        }

        [Fact]
        public void GetAllBeitragsTest_ReturnOk()
        {
            //Arrange
            repo.Setup(x => x.GetAllBeitragsAsync()).Returns(GetBeitrags(1));

            var beitragController = new BeitragController(repo.Object, mocklogger.Object, mapper);

            //Act

            var result = beitragController.GetTheBeitrags();

            //Assert

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllBeitragsDbEmpty_ReturnsBadrequest400()
        {
            //Arrange
            repo.Setup(x => x.GetAllBeitragsAsync()).Returns(GetBeitrags(0));

            var beitragController = new BeitragController(repo.Object, mocklogger.Object, mapper);

            //Act

            var result = beitragController.GetTheBeitrags();

            //Assert

            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public void GetBeitragById_ReturnsOk200()
        {
            //Arrange
            repo.Setup(x => x.GetBeitragById(1).Result).Returns(GetBeitrags(1)[0]);

            var beitragController = new BeitragController(repo.Object, mocklogger.Object, mapper);

            //Act
            var result = beitragController.GetTheBeitragsByid(1);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result.Result);
        }

        [Fact]
        public void GetBeitragById_ReturnsBadRequest400()
        {
            //Arrange
            repo.Setup(x => x.GetBeitragById(2).Result).Returns(() => null);

            var beitragController = new BeitragController(repo.Object, mocklogger.Object, mapper);

            //Act
            var result = beitragController.GetTheBeitragsByid(2);

            //Assert
            Assert.IsType<BadRequestResult>(result.Result.Result);
        }

        [Fact]
        public void CreateBeitrag_WhenValid()
        {
            //Arrange
            repo.Setup(x => x.GetBeitragById(1).Result).Returns(GetBeitrags(1)[0]);

            var beitragController = new BeitragController(repo.Object, mocklogger.Object, mapper);

            //Act
            var result = beitragController.CreateBeitrag(new BeitragDTO { });

            //Assert
            Assert.IsType<ActionResult<BeitragDTO>>(result);
        }

        [Fact]
        public void CreateBeitrag_Returns201Created()
        {
            //Arrange
            repo.Setup(x => x.GetBeitragById(1).Result).Returns(GetBeitrags(1)[0]);

            var beitragController = new BeitragController(repo.Object, mocklogger.Object, mapper);

            //Act
            var result = beitragController.CreateBeitrag(new BeitragDTO { });

            //Assert
            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }

        [Fact]
        public void UpdateBeitrag_Returns204NoContent()
        {
            //Arrange
            repo.Setup(x => x.GetBeitragById(1).Result).Returns(GetBeitrags(1)[0]);

            var beitragController = new BeitragController(repo.Object, mocklogger.Object, mapper);

            //Act

            var result = beitragController.UpdateBeitrag(1, new BeitragDTO { });

            //Assert

            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public void UpdateBeitrag_Returns404NotFound()
        {
            //Arrange
            repo.Setup(x => x.GetBeitragById(1).Result).Returns(() => null);

            var beitragController = new BeitragController(repo.Object, mocklogger.Object, mapper);

            //Act
            var result = beitragController.UpdateBeitrag(0, new BeitragDTO { });

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void DeleteBeitrag_ReturnsNoContent204()
        {
            //Arrange
            repo.Setup(x => x.GetBeitragById(1).Result).Returns(GetBeitrags(1)[0]);

            var beitragController = new BeitragController(repo.Object, mocklogger.Object, mapper);

            //Act

            var result = beitragController.DeleteBeitrag(1);

            //Assert

            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public void DeleteBeitrag_ReturnsNotFoundt404()
        {
            //Arrange
            repo.Setup(x => x.GetBeitragById(0).Result).Returns(() => null);

            var beitragController = new BeitragController(repo.Object, mocklogger.Object, mapper);

            //Act

            var result = beitragController.DeleteBeitrag(0);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        private List<Beitrag> GetBeitrags(int num)
        {
            var models = new List<Beitrag>();

            if (num > 0)
            {
                models.Add(new Beitrag()
                {
                    Id = 1,
                    Name = "test",
                    Description = "test",
                    beitragFace = new BeitragFace()
                    {
                        Id = 1,
                        Name = "test",
                        Description = "test",
                    },
                    beitragInsta = new BeitragInsta()
                    {
                        Id = 1,
                        Name = "test",
                        Description = "test",
                        Image = new ImageModelInstagram
                        {
                            Id = 1,
                            Name = "test",
                            ImageUrl = "test.com"
                        }

                    },
                    beitragPintr = new BeitragPintr()
                    {
                        Id = 1,
                        Name = "test",
                        Description = "test"
                    },
                    tags = new List<Tags>()
                {
                    new Tags()
                    {
                        Id = 1,
                        Tag = "hello"
                    }
                }
                });
            }

            

            

            return models;
        }
    }
}
