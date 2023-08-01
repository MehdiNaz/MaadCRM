namespace WebApi.Routes.Customers;

public static class CustomerRoute
{
    // public static RouteGroupBuilder MapCustomerRoute(this RouteGroupBuilder login) // return MapCustomerRoute;
    public static RouteGroupBuilder MapCustomerRoute(this RouteGroupBuilder customer)
    {
        customer.MapPost("/CustomerByFilterItems", ([FromBody] CustomerFilterRequest request, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new CustomerByFilterItemsQuery
                        {
                            CustomerId = request.CustomerId,
                            BirthDayDate = request.BirthDayDate,
                            Gender = request.Gender,
                            CityId = request.CityId,
                            CustomerState = request.CustomerState,
                            From = request.From,
                            UpTo = request.UpTo,
                            ProvinceId = request.ProvinceId,
                            MoshtaryMoAref = request.MoshtaryMoAref,
                            ProductCustomerFavorite = request.ProductCustomerFavorite,
                            IdUser = userId
                        });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Get All Customers By Filter Items.",
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

        customer.MapGet("/CustomerBySearchItem/{q}", (string q, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new CustomerBySearchItemQuery
                        {
                            Q = q.ToLower(),
                            UserId = userId
                        });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Get All Customers By Search Item.",
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

        customer.MapGet("/ById/{customerId}", (Ulid customerId, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new CustomerByIdQuery
                        {
                            CustomerId = customerId,
                            UserId = UserId
                        });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Get All Customers By Id.",
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

        customer.MapPost("/ChangeStatus", ([FromBody] ChangeStatusCustomerCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(request with
                            {
                                UserId = UserId
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Customer StatusType Changed.",
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

        customer.MapPost("/ChangeState", ([FromBody] ChangeStateCustomerCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(request with
                            {
                                UserId = UserId
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Customer State Changed.",
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

        customer.MapPost("/Insert", ([FromBody] CreateCustomerCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(request with
                            {
                                UserId = userId,
                                IdUserAdded = userId,
                                IdUserUpdated = userId
                            });
                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "New Customer Inserted.",
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

        customer.MapPut("/Update", ([FromBody] UpdateCustomerCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(request with
                            {
                                UserId = userId,
                                IdUserUpdated = userId
                            });
                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Customer Updated.",
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

        customer.MapDelete("/Delete/{customerId}", (Ulid customerId, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new DeleteCustomerCommand
                        {
                            CustomerId = customerId
                        });
                        return Results.Ok(new
                        {
                            Valid = true,
                            Message = "Customer Deleted.",
                            Data = result.Result
                        });
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
        
        return customer;
    }
}