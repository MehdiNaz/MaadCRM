namespace WebApi.Routes.Customers.PeyGiry;

public static class CustomerPeyGiryRoute
{
    public static void MapCustomerPeyGiryRoute(this IEndpointRouteBuilder app)
    {
        #region Customer PeyGiry

        var plan = app.MapGroup("v1/CustomerPeyGiry")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapPost("/AllCustomerPeyGiries/{customerId}", async (Ulid customerId, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllCustomerPeyGiriesQuery
                {
                    CustomerId = customerId
                });

                return result.Match(
                    u => Results.Ok(new
                    {
                        Valid = true,
                        Message = "Show All Customer PeyGiries.",
                        Data = u
                    }),
                    exception => Results.BadRequest(new
                    {
                        Valid = false,
                        Message = exception,
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

        plan.MapPost("/ById", async ([FromBody] CustomerPeyGiryByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CustomerPeyGiryByIdQuery
                {
                    CustomerPeyGiryId = request.CustomerPeyGiryId
                });
                return result.Match(
                    u => Results.Ok(new
                    {
                        Valid = true,
                        Message = "Show Customer PeyGiry By Id.",
                        Data = u
                    }),
                    exception => Results.BadRequest(new
                    {
                        Valid = false,
                        Message = exception,
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

        plan.MapPost("/Insert", async ([FromBody] CreateCustomerPeyGiryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateCustomerPeyGiryCommand
                {
                    Description = request.Description,
                    CustomerId = request.CustomerId,
                    IdUserAdded = request.IdUserAdded,
                    IdUserUpdated = request.IdUserUpdated,
                });

                return result.Match(
                    u => Results.Ok(new
                    {
                        Valid = true,
                        Message = "New Customer PeyGiry Inserted.",
                        Data = u
                    }),
                    exception => Results.BadRequest(new
                    {
                        Valid = false,
                        Message = exception,
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

        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusCustomerPeyGiryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusCustomerPeyGiryCommand
                {
                    CustomerPeyGiryId = request.CustomerPeyGiryId,
                    CustomerPeyGiryStatus = request.CustomerPeyGiryStatus
                });

                return result.Match(
                    u => Results.Ok(new
                    {
                        Valid = true,
                        Message = "Status Customer PeyGiry Changed.",
                        Data = u
                    }),
                    exception => Results.BadRequest(new
                    {
                        Valid = false,
                        Message = exception,
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

        plan.MapPut("/Update", async ([FromBody] UpdateCustomerPeyGiryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateCustomerPeyGiryCommand
                {
                    Id = request.Id,
                    Description = request.Description,
                    CustomerId = request.CustomerId,
                    IdUserAdded = request.IdUserAdded,
                    IdUserUpdated = request.IdUserUpdated,
                });
                return result.Match(
                    u => Results.Ok(new
                    {
                        Valid = true,
                        Message = "Customer PeyGiry Updated.",
                        Data = u
                    }),
                    exception => Results.BadRequest(new
                    {
                        Valid = false,
                        Message = exception,
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

        plan.MapDelete("/Delete", async ([FromBody] DeleteCustomerPeyGiryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteCustomerPeyGiryCommand
                {
                    Id = request.Id
                });

                return result.Match(
                    u => Results.Ok(new
                    {
                        Valid = true,
                        Message = "Business Deleted.",
                        Data = u
                    }),
                    exception => Results.BadRequest(new
                    {
                        Valid = false,
                        Message = exception,
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

        #endregion
    }
}