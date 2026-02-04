using MediatR;
using webapi.Models.Dto;

namespace webapi.Queries
{
    public class GetMonthlySummaryQuery : IRequest<PagedResult<MonthlySummaryDto>>
    {
        public string? CompanyCode
        {
            get; set;
        }
        public string? DataYM
        {
            get; set;
        }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
