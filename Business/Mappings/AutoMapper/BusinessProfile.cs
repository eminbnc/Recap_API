using AutoMapper;
using Core.Entities.ClaimInformation;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTO.Request.CompanyRequest;
using Entities.DTO.Request.JobApplicationRequest;
using Entities.DTO.Request.JobPostingRequest;
using Entities.DTO.Request.UserRequest;

namespace Business.Mappings.AutoMapper
{
    public class BusinessProfile:Profile
    {
        public BusinessProfile()
        {
            CreateMap<CompanyForRegisterRequest, Company>().ReverseMap();
            CreateMap<UserForRegisterRequest, User>().ReverseMap();
            CreateMap<InformationToAddedClaim, User>().ReverseMap();
            CreateMap<InformationToAddedClaim, Company>().ReverseMap();
            CreateMap<GetUsersResponse, User>().ReverseMap();
            CreateMap<JobPostingAddRequest, JobPosting>().ReverseMap();
            CreateMap<UserJobApplicationRequest,JobApplication>().ReverseMap();
            CreateMap<JobApplication, UserJobApplicationRequest>().ReverseMap();
        }
    }
}
