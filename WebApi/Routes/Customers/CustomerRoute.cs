﻿namespace WebApi.Routes.Customers;

public static class CustomerRoute
{
    public static void MapCustomerRoute(this IEndpointRouteBuilder app)
    {
        #region Customer

        RouteGroupBuilder plan = app.MapGroup("v1/Customer").EnableOpenApiWithAuthentication().WithOpenApi();

        plan.MapGet("/AllCustomers", (IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new AllCustomersQuery
                            {
                                UserId = UserId
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Get All Customers.",
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

        plan.MapGet("/CustomerDashBourd", (IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new CustomerDashBourdQuery
                            {
                                UserId = UserId
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Get All Customers.",
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

        plan.MapPost("/CustomerByFilterItems", ([FromBody] CustomerByFilterItemsQuery request, IMediator mediator, HttpContext httpContext) =>
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
                        ProductCustomerFavorite = request.ProductCustomerFavorite
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

        plan.MapGet("/CustomerBySearchItem/{q}", (string q, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new CustomerBySearchItemQuery
                            {
                                Q = q.ToLower()
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

        plan.MapGet("/ById/{customerId}", (Ulid customerId, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new CustomerByIdQuery { CustomerId = customerId });

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
         
        plan.MapPost("/Insert", ([FromBody] CreateCustomerCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new CreateCustomerCommand
                            {
                                UserId = UserId,
                                FirstName = request.FirstName,
                                LastName = request.LastName,
                                BirthDayDate = request.BirthDayDate,
                                CustomerPic = request.CustomerPic,
                                CustomerCategoryId = request.CustomerCategoryId,
                                Gender = request.Gender,
                                CustomerMoarefId = request.CustomerMoarefId,
                                PhoneNumbers = request.PhoneNumbers,
                                EmailAddresses = request.EmailAddresses,
                                FavoritesLists = request.FavoritesLists,
                                CustomersAddresses = request.CustomersAddresses,
                                CustomerNotes = request.CustomerNotes,
                                CustomerPeyGiries = request.CustomerPeyGiries,
                                CityId = request.CityId,
                                IdUserAdded = UserId,
                                IdUserUpdated = UserId
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
 
        plan.MapPost("/ChangeStatus", ([FromBody] ChangeStatusCustomerCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new ChangeStatusCustomerCommand
                            {
                                CustomerStatus = request.CustomerStatus,
                                CustomerId = request.CustomerId
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Customer Status doen't Changed.",
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
        
        plan.MapPost("/ChangeState", ([FromBody] ChangeStateCustomerCommand request, IMediator mediator, HttpContext httpContext) =>
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
                    var result = mediator.Send(new ChangeStateCustomerCommand
                    {
                        CustomerStateType = request.CustomerStateType,
                        CustomerId = request.CustomerId
                    });

                    return result.Result.Match(
                        succes => Results.Ok(new
                        {
                            Valid = true,
                            Message = "Customer State doen't Changed.",
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
 
        plan.MapPut("/Update", ([FromBody] UpdateCustomerCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new UpdateCustomerCommand
                            {
                                UserId = UserId,
                                Id = request.Id,
                                FirstName = request.FirstName,
                                LastName = request.LastName,
                                BirthDayDate = request.BirthDayDate,
                                CustomerPic = request.CustomerPic,
                                CustomerCategoryId = request.CustomerCategoryId,
                                Gender = request.Gender,
                                CustomerMoarefId = request.CustomerMoarefId,
                                PhoneNumbers = request.PhoneNumbers,
                                EmailAddresses = request.EmailAddresses,
                                FavoritesLists = request.FavoritesLists,
                                CustomersAddresses = request.CustomersAddresses,
                                CustomerNotes = request.CustomerNotes,
                                CustomerPeyGiries = request.CustomerPeyGiries,
                                CityId = request.CityId,
                                IdUserUpdated = UserId
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

        plan.MapDelete("/Delete/{customerId}", (Ulid customerId, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new DeleteCustomerCommand
                            {
                                CustomerId = customerId,
                                UserId = UserId
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
        #endregion
    }
}