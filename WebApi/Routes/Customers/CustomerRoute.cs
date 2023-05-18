namespace WebApi.Routes.Customers;

public static class CustomerRoute
{
    public static void MapCustomerRoute(this IEndpointRouteBuilder app)
    {
        var plan = app.MapGroup("v1/Customer").EnableOpenApiWithAuthentication().WithOpenApi();

        plan.MapPost("/CustomerByFilterItems", ([FromBody] CustomerFilterRequest request, IMediator mediator, HttpContext httpContext) =>
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
                            UserId = userId
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
                                CustomerStatusType = request.CustomerStatusType,
                                CustomerId = request.CustomerId,
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
                                CustomerId = request.CustomerId,
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
                        userId =>
                        {
                            var result = mediator.Send(new CreateCustomerCommand
                            {
                                UserId = userId,
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
                        userId =>
                        {
                            var result = mediator.Send(new UpdateCustomerCommand
                            {
                                UserId = userId,
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
    }
}