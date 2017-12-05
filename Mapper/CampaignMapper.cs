using AspNetCoreApplication.Model;
using AspNetCoreApplication.ModelDto;
using AutoMapper;

namespace AspNetCoreApplication.Mapper {
    public class CampaignMapper : Profile {
        public CampaignMapper () {
            CreateMap<Campaign, CampaignVm> ().ReverseMap ();
            CreateMap<CampaignForCreationDto, Campaign> ().ReverseMap ();
            CreateMap<Training, TrainingVm> ()
                .ForMember (x => x.BusinessUnitName, opt => opt.MapFrom (x => x.BusinessUnit.Name))
                .ForMember (x => x.ModalityName, opt => opt.MapFrom (x => x.Modality.Name))
                .ForMember (x => x.OrganizationName, opt => opt.MapFrom (x => x.Organization.Name))
                .ReverseMap ();

            CreateMap<CreateTraining, Training> ().ReverseMap ();

            CreateMap<Organization, OrganizationVm> ()
                .ForMember (c => c.Value, opt => opt.MapFrom (x => x.OrganizationId))
                .ForMember (c => c.Label, opt => opt.MapFrom (x => x.Name)).ReverseMap ();

            CreateMap<Modality, ModalityVm> ()
                .ForMember (c => c.Value, opt => opt.MapFrom (x => x.ModalityId))
                .ForMember (c => c.Label, opt => opt.MapFrom (x => x.Name)).ReverseMap ();

            CreateMap<BusinessUnit, BusinessUnitVm> ()
                .ForMember (c => c.Value, opt => opt.MapFrom (x => x.BusinessUnitId))
                .ForMember (c => c.Label, opt => opt.MapFrom (x => x.Name)).ReverseMap ();

            CreateMap<Category, CategoriesVm> ().ReverseMap ();
        }
    }
}