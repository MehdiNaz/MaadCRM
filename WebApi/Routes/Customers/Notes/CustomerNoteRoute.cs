namespace WebApi.Routes.Customers.Notes;

public static class CustomerNoteRoute
{
    public static RouteGroupBuilder MapCustomerNoteRoute(this RouteGroupBuilder mapCustomerNoteRoute)
    {
        mapCustomerNoteRoute.MapPost("/AllCustomersNote", ([FromBody] AllCustomerNotesQuery request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new AllCustomerNotesQuery
                            {
                                CustomerId = request.CustomerId
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Get All Customers Notes",
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

        mapCustomerNoteRoute.MapGet("/ById/{customerNoteId}", (Ulid customerNoteId, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new CustomerNoteByIdQuery { CustomerNoteId = customerNoteId });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Get Customers Note By Id",
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

        mapCustomerNoteRoute.MapPost("/Insert", ([FromBody] CreateCustomerNoteCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new CreateCustomerNoteCommand
                            {
                                Description = request.Description,
                                CustomerId = request.CustomerId,
                                ProductId = request.ProductId,
                                HashTagIds = request.HashTagIds,
                                IdUser = userId
                            });
                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "New Customer Note Inserted.",
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

        mapCustomerNoteRoute.MapPost("/ChangeStatus", ([FromBody] ChangeStatusCustomerNoteCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new ChangeStatusCustomerNoteCommand
                            {
                                CustomerNoteStatusType = request.CustomerNoteStatusType,
                                CustomerNoteId = request.CustomerNoteId
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Customers Note StatusType Changed.",
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

        mapCustomerNoteRoute.MapPut("/Update", ([FromBody] UpdateCustomerNoteCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new UpdateCustomerNoteCommand
                            {
                                Id = request.Id,
                                Description = request.Description,
                                ProductId = request.ProductId,
                                HashTagIds = request.HashTagIds
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

        mapCustomerNoteRoute.MapDelete("/Delete/{idNote}", (Ulid idNote, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new DeleteCustomerNoteCommand
                            {
                                Id = idNote,
                                UserId = userId
                            });
                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Customer Note Deleted.",
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
        return mapCustomerNoteRoute;
    }
}