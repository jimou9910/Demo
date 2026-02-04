using MediatR;
using webapi.Models.Dto;

namespace webapi.Commands
{
    public class AddMonthlyCommand : IRequest<MonthlySummaryDto>
    {
        public MonthlySummaryDto Dto
        {
            get; set;
        }

        public AddMonthlyCommand(MonthlySummaryDto dto)
        {
            Dto = dto;
        }
    }
}
