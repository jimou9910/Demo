using AutoMapper;
using MediatR;
using webapi.Models.Dto;
using webapi.Models;
using webapi.Commands;

namespace webapi.Handlers
{
    public class AddMonthly : IRequestHandler<AddMonthlyCommand, MonthlySummaryDto>
    {
        private readonly DEMOContext _context;
        private readonly IMapper _mapper;

        public AddMonthly(DEMOContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MonthlySummaryDto> Handle(AddMonthlyCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MonthlySummary>(request.Dto);
            await _context.MonthlySummary.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<MonthlySummaryDto>(entity);
        }
    }
}
