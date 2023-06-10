using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication2.AppDbContext;
using WebApplication2.DTO;

namespace WebApplication2.Queries
{
    public class GetParcelJsonByParcelNumber
    {
        public class Query : IRequest<ParcelDto>
        {
            public string ParcelNumber { get; set; }
        }
        public sealed class Handler : IRequestHandler<Query, ParcelDto>
        {
            private readonly IAppDbContext _appDbContext;
            private readonly IMapper _mapper;

            public Handler(IAppDbContext appDbContext, IMapper mapper)
            {
                _appDbContext = appDbContext;
                _mapper = mapper;
            }

            public async Task<ParcelDto> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var result = _appDbContext.ParcelDto
                                .FromSqlInterpolated($"EXEC [dbo].[spGetParcelJson] @parcelNumber = {request.ParcelNumber}")
                                .AsEnumerable().FirstOrDefault();

                return result is null ? throw new Exception("Parcel not found") : result;
            }
        }
    }
}
