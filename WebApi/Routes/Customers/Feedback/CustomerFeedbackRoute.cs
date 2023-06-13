namespace WebApi.Routes.Customers.Feedback;

public static class CustomerFeedbackRoute
{
    // public static RouteGroupBuilder MapCustomerFeedbackRoute(this RouteGroupBuilder customerFeedback) // return customerFeedback;
    public static RouteGroupBuilder MapCustomerFeedbackRoute(this RouteGroupBuilder customerFeedback)
    {
        customerFeedback.MapGet("/AllCustomerFeedbacks/{idCustomer}", (Ulid idCustomer,IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new AllCustomerFeedbacksQuery
                            {
                                Id = idCustomer
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Show All Customer Feedbacks.",
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

        customerFeedback.MapGet("/ById/{customerFeedbackId}", (Ulid customerFeedbackId, IMediator mediator, HttpContext httpContext) =>
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
                    var result = mediator.Send(new CustomerFeedbackByIdQuery
                    {
                        Id = customerFeedbackId
                    });
                    return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Show Customer Feedback By Id",
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

        customerFeedback.MapGet("/CustomerFeedbackBySearchItem/{q}", (string q, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new CustomerFeedbackBySearchItemQuery
                        {
                            Q = q.ToLower(),
                            UserId = UserId
                        });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Get All Customer Feedbacks By Search Item.",
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

        customerFeedback.MapPost("/Insert", ([FromBody] CreateCustomerFeedbackCommand request, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new CreateCustomerFeedbackCommand
                        {
                            Description = request.Description,
                            IdCategory = request.IdCategory,
                            IdCustomer = request.IdCustomer,
                            IdProduct = request.IdProduct,
                            IdUserAdded = userId,
                            IdUserUpdated = userId,
                            IdUser = request.IdUser
                        });
                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Insert Customer Feedbacks Done.",
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

        customerFeedback.MapPost("/ChangeStatus", ([FromBody] ChangeStateCustomerFeedbackCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new ChangeStateCustomerFeedbackCommand
                            {
                                Id = request.Id,
                                CustomerFeedbackStatusType = request.CustomerFeedbackStatusType
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Insert Customer Feedbacks Done.",
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

        customerFeedback.MapPut("/Update", ([FromBody] UpdateCustomerFeedbackCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new UpdateCustomerFeedbackCommand
                            {
                                Id = request.Id,
                                Description = request.Description,
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Insert Customer Feedbacks Done.",
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

        customerFeedback.MapPut("/Delete/{Id}", (Ulid Id, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new DeleteCustomerFeedbackCommand
                        {
                            Id = Id
                        });
                        return Results.Ok(new
                        {
                            Valid = true,
                            Message = "Customer Feedback Deleted.",
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
        
        return customerFeedback;
    }
}