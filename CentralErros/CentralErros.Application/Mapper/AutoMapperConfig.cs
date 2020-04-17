using AutoMapper;
using CentralErros.Application.ViewModel;
using CentralErros.Domain.Modelo;

namespace CentralErros.Application.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x => x.AllowNullCollections = true);
        }

        public AutoMapperConfig()
        {
            CreateMap<Aplicacao, AplicacaoViewModel>().ReverseMap();
            CreateMap<Aviso, AvisoViewModel>().ReverseMap();
            CreateMap<Log, LogViewModel>().ReverseMap();
            CreateMap<TipoLog, TipoLogViewModel>().ReverseMap();
            CreateMap<UsuarioAplicacao, UsuarioAplicacaoViewModel>().ReverseMap();
            CreateMap<UsuarioAviso, UsuarioAvisoViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
