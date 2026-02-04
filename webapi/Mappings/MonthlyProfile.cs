using AutoMapper;
using webapi.Models.Dto;
using webapi.Models;

namespace webapi.Mappings
{
    public class MonthlyProfile : Profile
    {
        public MonthlyProfile()
        {
            CreateMap<MonthlySummary, MonthlySummaryDto>().ReverseMap();
        }
    }
}
