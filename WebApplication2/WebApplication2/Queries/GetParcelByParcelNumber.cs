using AutoMapper;
using MediatR;
using WebApplication2.AppDbContext;

namespace WebApplication2.Queries
{
    public class GetParcelByParcelNumber
    {
        public class Query : IRequest<List<Dictionary<string, object>>>
        {
            public string ParcelNumber { get; set; }
        }
        public sealed class Handler : IRequestHandler<Query, List<Dictionary<string, object>>>
        {
            private readonly IAppDbContext _appDbContext;
            private readonly IMapper _mapper;

            public Handler(IAppDbContext appDbContext, IMapper mapper)
            {
                _appDbContext = appDbContext;
                _mapper = mapper;
            }

            public async Task<List<Dictionary<string, object>>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                //var result = _appDbContext.ParcelDto
                //                .FromSqlInterpolated($"EXEC [dbo].[spGetParcelJson] @parcelNumber = {request.ParcelNumber}")
                //                .AsEnumerable().FirstOrDefault();

                var result = _appDbContext.ExecuteSqlScript($"EXEC [dbo].[spGetParcelJson] @parcelNumber = {request.ParcelNumber}");


                return result is null ? throw new Exception("Parcel not found") : result;
            }
        }
    }
}
