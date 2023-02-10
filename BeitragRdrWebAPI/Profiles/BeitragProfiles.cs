using AutoMapper;
using BeitragRdr.DTOs;
using BeitragRdr.DTOs.CompanyDTOs;
using BeitragRdr.DTOs.ImageModelsDTOs;
using BeitragRdr.DTOs.SubModelsDTOs;
using BeitragRdr.Models;
using BeitragRdr.Models.Address;
using BeitragRdr.Models.CompanyModel;
using BeitragRdr.Models.ImageModels;
using BeitragRdr.Models.SubModels;
using BeitragRdr.Models.UserModel;
using Elfie.Serialization;

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
            CreateMap<Company, CompanyReadDTO>();
            CreateMap<CompanyReadDTO, Company>();
            CreateMap<CompanyCreateDTO, Company>();
            CreateMap<AddressModel, AddressReadDTO>();
            CreateMap<PhoneNumberModel, PhoneNumberReadDTO>();
            CreateMap<Company, CompanyCreateDTO>();
            CreateMap<Beitrag, CreateBeitragDTO>();
            CreateMap<CreateBeitragDTO, Beitrag>();

            //Create the Beitrag
            CreateMap<BeitragDTO, Beitrag>(); ;

            CreateMap<TagsDTO, Tags>();
            CreateMap<BeitragFaceDTO, BeitragFace>();
            CreateMap<BeitragInstaDTO, BeitragInsta>();
            CreateMap<BeitragPintrDTO, BeitragPintr>();
            CreateMap<ImageModelFacebookDTO, ImageModelFacebook>();
            CreateMap<ImageModelInstagramDTO, ImageModelInstagram>();
            CreateMap<ImageModelPintrDTO, ImageModelPintr>();

            //User profiles
            CreateMap<User, UserReadDTO>();
            CreateMap<User, UserCreateDTO>();
            CreateMap<UserCreateDTO, User>();

        }
    }
}
