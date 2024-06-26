﻿using Application.Responses.Location;

namespace Application.Services.Locations.CityService.QueryHandler;

public readonly struct GetAllCityHandler : IRequestHandler<GetAllCitiesQuery, Result<ICollection<CityResponse>>>
{
    private readonly ICityRepository _repository;

    public GetAllCityHandler(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CityResponse>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCitiesAsync())
                .Match(result => new Result<ICollection<CityResponse>>(result),
                exception => new Result<ICollection<CityResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CityResponse>>(new Exception(e.Message));
        }
    }
}