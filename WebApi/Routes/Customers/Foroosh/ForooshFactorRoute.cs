namespace WebApi.Routes.Customers.Foroosh;

public static class ForooshFactorRoute
{
    public static void MapForooshFactorRoute(this IEndpointRouteBuilder app)
    {
        var plan = app.MapGroup("v1/ForooshFactor").EnableOpenApiWithAuthentication().WithOpenApi();

        plan.MapGet("/AllForooshFactors", (IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                    userId =>
                    {
                        var result = mediator.Send(new AllForooshFactorsQuery());

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Get All Foroosh Factor.",
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

        plan.MapGet("/ById/{forooshFactorId}", (Ulid forooshFactorId, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new ForooshFactorByIdQuery { ForooshFactorId = forooshFactorId });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Get All Foroosh Factors By Search Item.",
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

        plan.MapGet("/AllFactorInformationByFactorId/{forooshFactorId}", (Ulid forooshFactorId, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new AllFactorInformationByForooshFactorIdQuery { ForooshFactorId = forooshFactorId });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Get All Factor Information By Foroosh Factor Id Query.",
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

        plan.MapPost("/ChangeStatus", ([FromBody] ChangeStatusForooshFactorCommand request, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new ChangeStatusForooshFactorCommand
                        {
                            ForooshFactorStatus = request.ForooshFactorStatus,
                            Id = request.Id
                        });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Foroosh Factor Status Changed.",
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
            catch (ArgumentException e)
            {
                return Results.BadRequest(new ErrorResponse
                {
                    Valid = false,
                    Exceptions = e
                });
            }
        });

        plan.MapPost("/Insert", ([FromBody] CreateForooshFactorCommand request, IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                    userId =>
                    {
                        var result = mediator.Send(new CreateForooshFactorCommand
                        {
                            Amount = request.Amount,
                            AmountTax = request.AmountTax,
                            AmountTotal = request.AmountTotal,
                            PaymentMethod = request.PaymentMethod,
                            ShippingMethodType = request.ShippingMethodType,
                            TedadeAghsat = request.TedadeAghsat,
                            BazeyeZamany = request.BazeyeZamany,
                            DarSadeSoud = request.DarSadeSoud,
                            PishPardakht = request.PishPardakht,
                            MablagheKoleSoud = request.MablagheKoleSoud,
                            ShoroAghsat = request.ShoroAghsat,
                            PaymentAmount = request.PaymentAmount,
                            DatePay = request.DatePay,
                            CustomerId = request.CustomerId,
                            CustomersAddressId = request.CustomersAddressId,
                            UserIdAdded = userId,
                            UserIdUpdated = userId
                        });
                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "New Foroosh Factor Inserted.",
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
            catch (ArgumentException e)
            {
                return Results.BadRequest(new ErrorResponse
                {
                    Valid = false,
                    Exceptions = e
                });
            }
        });

        plan.MapPut("/Update", ([FromBody] UpdateForooshFactorCommand request, IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                    userId =>
                    {
                        var result = mediator.Send(new UpdateForooshFactorCommand
                        {
                            Id = request.Id,
                            Amount = request.Amount,
                            AmountTax = request.AmountTax,
                            AmountTotal = request.AmountTotal,
                            PaymentMethod = request.PaymentMethod,
                            ShippingMethodType = request.ShippingMethodType,
                            TedadeAghsat = request.TedadeAghsat,
                            BazeyeZamany = request.BazeyeZamany,
                            DarSadeSoud = request.DarSadeSoud,
                            PishPardakht = request.PishPardakht,
                            MablagheKoleSoud = request.MablagheKoleSoud,
                            ShoroAghsat = request.ShoroAghsat,
                            PaymentAmount = request.PaymentAmount,
                            DatePay = request.DatePay,
                        });
                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Customer Note Updated.",
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
            catch (ArgumentException e)
            {
                return Results.BadRequest(new ErrorResponse
                {
                    Valid = false,
                    Exceptions = e
                });
            }
        });

        plan.MapDelete("/Delete/{forooshFactorId}", (Ulid forooshFactorId, IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                    userId =>
                    {
                        var result = mediator.Send(new DeleteForooshFactorCommand
                        {
                            Id = forooshFactorId
                        });
                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Customer Note Updated.",
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
            catch (ArgumentException e)
            {
                return Results.BadRequest(new ErrorResponse
                {
                    Valid = false,
                    Exceptions = e
                });
            }
        });
    }
}