using AutoMapper;
using BeitragRdr.DTOs;
using BeitragRdr.DTOs.ImageModelsDTOs;
using BeitragRdr.DTOs.SubModelsDTOs;
using BeitragRdr.Models;
using BeitragRdr.Models.ImageModels;
using BeitragRdr.Models.SubModels;

namespace BeitragRdrWebAPI.Profiles
{
    public class BeitragProfiles : Profile
    {
        public BeitragProfiles()
        {

            //Read the Beitrags

            CreateMap<Beitrag, BeitragDTO>();
            CreateMap<Tags, TagsDTO>();
            CreateMap<BeitragFace, BeitragFaceDTO>();
            CreateMap<BeitragInsta, BeitragInstaDTO>();
            CreateMap<BeitragPintr, BeitragPintrDTO>();
            CreateMap<ImageModelFacebook, ImageModelFacebookDTO>();
            CreateMap<ImageModelInstagram, ImageModelInstagramDTO>();
            CreateMap<ImageModelPintr, ImageModelPintrDTO>();

            //Create the Beitrag
            CreateMap<BeitragDTO, Beitrag>();
            CreateMap<TagsDTO, Tags>();
            CreateMap<BeitragFaceDTO, BeitragFace>();
            CreateMap<BeitragInstaDTO, BeitragInsta>();
            CreateMap<BeitragPintrDTO, BeitragPintr>();
            CreateMap<ImageModelFacebookDTO, ImageModelFacebook>();
            CreateMap<ImageModelInstagramDTO, ImageModelInstagram>();
            CreateMap<ImageModelPintrDTO, ImageModelPintr>();
        }
    }
}
