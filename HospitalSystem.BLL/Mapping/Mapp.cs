using AutoMapper;
using HospitalSystem.BLL.ModelVM.Account;
using HospitalSystem.BLL.ModelVM.MedicalReport;
using HospitalSystem.BLL.ModelVM.Patient;
using HospitalSystem.DAL.Entity;
using SH.BLL.ModelVm;


namespace HospitalSystem.BLL.Mapping
{
    public class Mapp : Profile
    {
        public Mapp()
        {
            CreateMap<Patient, EditePatientVM>().ReverseMap();
            CreateMap<Patient, ChangePasswordVM>().ReverseMap();
            CreateMap<Patient, PatientProfileVM>().ReverseMap();
            CreateMap<Patient, PatientVM>().ReverseMap();
            CreateMap<Patient, LoginVM>().ReverseMap();
            CreateMap<RegistrationVM, Patient>()
            .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => src.BirthDate));
            CreateMap<ConfirmEmailLoginVM, Patient>()
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailAddress));
            CreateMap<Doctor, GetAllDoctorsVM>();
            CreateMap<Doctor, GetByIdDocVM>();
            CreateMap<CreateDocVM, Doctor>();
            CreateMap<DeleteDocVM, Doctor>();
            CreateMap<EditDocVM, Doctor>();
            CreateMap<MedicalReport, EditReportVM>().ReverseMap();
        }
    }
}
