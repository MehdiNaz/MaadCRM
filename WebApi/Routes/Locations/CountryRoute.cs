namespace WebApi.Routes.Locations;

public static class CountryRoute
{
    public static RouteGroupBuilder MapCountryRoute(this RouteGroupBuilder country)
    {
        country.MapGet("/AllCountries", (IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                        UserId =>
                        {
                            var result = mediator.Send(new GetAllCountriesQuery());

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Get All Countries",
                                    Data = succes
                                }),
                                error => Results.BadRequest(new ErrorResponse
                                {
                                    Valid = false,
                                    Exceptions = error
                                }));
                        },
                        exception => Results.BadRequest(new ErrorResponse
                        {
                            Valid = false,
                            Exceptions = exception
                        }));
            }
            catch (Exception e)
            {
                return Results.BadRequest(new
                {
                    Valid = false,
                    e.Message,
                    e.StackTrace
                });
            }
        });

        country.MapGet("/ById/{countryId}", (Ulid countryId, IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                        _ =>
                        {
                            var result = mediator.Send(new GetCountryByIdQuery { CountryId = countryId });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Get Country By Id",
                                    Data = succes
                                }),
                                error => Results.BadRequest(new ErrorResponse
                                {
                                    Valid = false,
                                    Exceptions = error
                                }));
                        },
                        exception => Results.BadRequest(new ErrorResponse
                        {
                            Valid = false,
                            Exceptions = exception
                        }));
            }
            catch (Exception e)
            {
                return Results.BadRequest(new
                {
                    Valid = false,
                    e.Message,
                    e.StackTrace
                });
            }
        });
        
        return country;
    }
}