using Application.Services.Profile.Command;

namespace WebApi.Routes.Account;
public static class ProfileRoute
{
    public static void MapProfileRoute(this IEndpointRouteBuilder app)
    {

        var profile = app.MapGroup("v1/profile")
            .WithOpenApi()
            .AllowAnonymous();

        profile.MapPost("/SetProfile", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] SetProfileCommand request,IMediator mediator) =>
        {
            try
            {
                var resultVerifyCode = mediator.Send(new SetProfileCommand
                {
                    Id = request.Id,
                    Email = request.Email,
                    Gender = request.Gender,
                    Name = request.Name,
                    Family = request.Family,
                    Address = request.Address,
                    BirthDatre = request.BirthDatre,
                    CodeMelli = request.CodeMelli,
                    CityId = request.CityId
                });

                Console.WriteLine(resultVerifyCode.Result);
                if (resultVerifyCode.Result == null)
                    return Results.NoContent();

                return Results.Ok(new
                {
                    Valid = true,
                    Message = "Done",
                    User = resultVerifyCode.Result
                });
                
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(new
                {
                    Valid = false,
                    e.Message,
                    e.StackTrace
                });
            }
        });
    }
}

    
