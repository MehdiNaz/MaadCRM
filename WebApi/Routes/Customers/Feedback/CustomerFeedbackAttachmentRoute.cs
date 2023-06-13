namespace WebApi.Routes.Customers.Feedback;

public static class CustomerFeedbackAttachmentRoute
{
    public static RouteGroupBuilder MapCustomerFeedbackAttachmentRoute(this RouteGroupBuilder customerFeedbackAttachment)
    {
        customerFeedbackAttachment.MapGet("/AllCustomerFeedbackAttachment/{customerFeedbackId}", (Ulid customerFeedbackId, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new AllCustomerFeedbackAttachmentsQuery
                            {
                                CustomerFeedbackId = customerFeedbackId
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Show All Customer Feedback Attachments.",
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

        customerFeedbackAttachment.MapGet("/ById/{Id}", (Ulid Id, IMediator mediator, HttpContext httpContext) =>
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
                    var result = mediator.Send(new CustomerFeedbackAttachmentByIdQuery
                    {
                        Id = Id
                    });
                    return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Show Customer Feedback Attachment  By Id",
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

        customerFeedbackAttachment.MapPost("/Insert", ([FromBody] CreateCustomerFeedbackAttachmentCommand request, IMediator mediator, HttpContext httpContext) =>
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
                    var result = mediator.Send(new CreateCustomerFeedbackAttachmentCommand()
                    {
                        Name = request.Name,
                        FileName = request.FileName,
                        Extenstion = request.Extenstion,
                        IdCustomerFeedback = request.IdCustomerFeedback
                    });
                    return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Customer Feedback Attachment Inserted.",
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

        customerFeedbackAttachment.MapPut("/Update", ([FromBody] UpdateCustomerFeedbackAttachmentCommand request, IMediator mediator, HttpContext httpContext) =>
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
                    var result = mediator.Send(new UpdateCustomerFeedbackAttachmentCommand()
                    {
                        Id = request.Id,
                        Name = request.Name,
                        FileName = request.FileName,
                        Extenstion = request.Extenstion,
                        IdCustomerFeedback = request.IdCustomerFeedback
                    });
                    return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Customer Feedback Attachment Updated.",
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

        customerFeedbackAttachment.MapDelete("/Delete/{Id}", (Ulid Id, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new DeleteCustomerFeedbackAttachmentCommand
                        {
                            Id = Id
                        });
                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Customer Feedback Attachment Deleted.",
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
        
        return customerFeedbackAttachment;
    }
}