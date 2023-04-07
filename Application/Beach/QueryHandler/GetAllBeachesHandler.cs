using Application.Beach.Query;
using MediatR;

namespace Application.Beach.QueryHandler;

public class GetAllBeachesHandler: IRequestHandler<GetAllBeachesQuery, GetAllBeachesResponse>
{
    public Task<GetAllBeachesResponse> Handle(GetAllBeachesQuery request, CancellationToken cancellationToken)
    {
        var newBeach = new GetAllBeachesResponse()
        {
            Id = "1",
            Name = "Test"
        };
        return Task.FromResult(newBeach);
    }
}