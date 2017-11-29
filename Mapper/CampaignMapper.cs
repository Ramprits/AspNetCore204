using AspNetCoreApplication.Model;
using AspNetCoreApplication.ModelDto;
using AutoMapper;

namespace AspNetCoreApplication.Mapper {
    public class CampaignMapper : Profile {
        public CampaignMapper () {
            CreateMap<Campaign, CampaignVm> ().ReverseMap ();
            CreateMap<CampaignForCreationDto, Campaign> ().ReverseMap ();
        }
    }
}