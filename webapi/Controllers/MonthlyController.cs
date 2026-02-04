using MediatR;
using Microsoft.AspNetCore.Mvc;
using webapi.Commands;
using webapi.Models.Dto;
using webapi.Queries;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonthlyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MonthlyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("query")]
        public async Task<ActionResult<PagedResult<MonthlySummaryDto>>> Get([FromBody] GetMonthlySummaryQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<MonthlySummaryDto>> Add([FromBody] MonthlySummaryDto dto, CancellationToken cancellationToken)
        {
            var command = new AddMonthlyCommand(dto);
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(Get), new{companyCode = dto.CompanyCode, dto.DataYM}, result);
        }
    }
}
