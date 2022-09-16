using AutoMapper;
using RestaurentProject.Models;
using RestaurentProject.ViewModel;

namespace RestaurentProject.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ExportDatum , CsvModelView>().ReverseMap();
        }
    }
}
