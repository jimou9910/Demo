using MediatR;
using webapi.Models.Dto;
using webapi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using webapi.Queries;

namespace webapi.Handlers
{
    public class GetMonthlySummaryHandler : IRequestHandler<GetMonthlySummaryQuery, PagedResult<MonthlySummaryDto>>
    {
        private readonly DEMOContext _context;
        private readonly IMapper _mapper;

        public GetMonthlySummaryHandler(DEMOContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResult<MonthlySummaryDto>> Handle(GetMonthlySummaryQuery request, CancellationToken cancellationToken)
        {
            var query = _context.MonthlySummary.AsQueryable();

            if (!string.IsNullOrEmpty(request.CompanyCode))
            {
                query = query.Where(x => x.CompanyCode == request.CompanyCode);
            }

            if (!string.IsNullOrEmpty(request.DataYM))
            {
                query = query.Where(x => x.DataYM == request.DataYM);
            }

            var pageNumber = request.PageNumber < 1 ? 1 : request.PageNumber;
            var pageSize = request.PageSize < 1 ? 10 : request.PageSize;

            var totalRecords = await query.CountAsync(cancellationToken);
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var mappedItems = items.Select(x => _mapper.Map<MonthlySummaryDto>(x)).ToList();

            return new PagedResult<MonthlySummaryDto>
            {
                Items = mappedItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };
        }

        public async Task<MonthlySummaryDto> AddMonthlyRevenueAsync(MonthlySummaryDto dto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MonthlySummary>(dto);
            await _context.MonthlySummary.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<MonthlySummaryDto>(entity);
        }
    }
}
