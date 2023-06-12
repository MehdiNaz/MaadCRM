namespace WebApi.Routes.Products;

public static class ProductRoute
{
    public static void MapProductRoute(this IEndpointRouteBuilder app)
    {
        var plan = app.MapGroup("v1/Product")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllProducts", (IMediator mediator, HttpContext httpContext) =>
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
                        var business = mediator.Send(new GetBusinessNameByUserIdQuery
                        {
                            UserId = UserId
                        });

                        return business.Result.Match(bId =>
                            {
                                var result = mediator.Send(new AllProductsQuery
                                {
                                    BusinessId = bId.Id
                                });


                                return result.Result.Match(
                                    succes => Results.Ok(new
                                    {
                                        Valid = true,
                                        Message = "Show All Products.",
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
        
        plan.MapGet("/AllProductsActive", (IMediator mediator, HttpContext httpContext) =>
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
                        var business = mediator.Send(new GetBusinessNameByUserIdQuery
                        {
                            UserId = UserId
                        });

                        return business.Result.Match(bId =>
                            {
                                var result = mediator.Send(new AllProductsActiveQuery
                                {
                                    BusinessId = bId.Id
                                });


                                return result.Result.Match(
                                    succes => Results.Ok(new
                                    {
                                        Valid = true,
                                        Message = "Show All Products Active.",
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

        plan.MapGet("/ById/{Id}", (Ulid Id, IMediator mediator, HttpContext httpContext) =>
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
                        var business = mediator.Send(new GetBusinessNameByUserIdQuery
                        {
                            UserId = UserId
                        });

                        return business.Result.Match(bId =>
                        {
                            var result = mediator.Send(new ProductByIdQuery
                            {
                                ProductId = Id
                            });


                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Show All Products.",
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

        plan.MapGet("/ByProductCategoryId/{productCategoryId}", (Ulid productCategoryId, IMediator mediator, HttpContext httpContext) =>
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
                        var business = mediator.Send(new GetBusinessNameByUserIdQuery
                        {
                            UserId = UserId
                        });

                        return business.Result.Match(bId =>
                        {
                            var result = mediator.Send(new ProductByIdCategoryQuery
                            {
                                ProductCategoryId = productCategoryId
                            });


                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Show All Products By Product Category Id.",
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

        plan.MapPost("/ChangeStatus", ([FromBody] ChangeStatusProductByIdCommand request, IMediator mediator, HttpContext httpContext) =>
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
                        var business = mediator.Send(new ChangeStatusProductByIdCommand
                        {
                            ProductId = request.ProductId,
                            ProductStatusType = request.ProductStatusType
                        });

                        return business.Result.Match(bId =>
                        {
                            var result = mediator.Send(new ProductByIdQuery
                            {
                                ProductId = bId.IdProduct
                            });


                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Show All Products.",
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

        plan.MapGet("/ProductBySearchItem/{q}", (string q, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new ProductBySearchItemQuery { Q = q.ToLower() });
                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Show Product By Id",
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

        plan.MapPost("/ChangeState", ([FromBody] ChangeStateProductCommand request, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new ChangeStateProductCommand
                        {
                            Id = request.Id,
                            Status = request.Status
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

        plan.MapPost("/Insert", ([FromBody] CreateProductCommand request, IMediator mediator, HttpContext httpContext) =>
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
                        var business = mediator.Send(new GetBusinessNameByUserIdQuery
                        {
                            UserId = UserId
                        });

                        return business.Result.Match(bId =>
                        {
                            var result = mediator.Send(new CreateProductCommand
                            {
                                ProductName = request.ProductName,
                                ProductCategoryId = request.ProductCategoryId,
                                Title = request.Title,
                                Summery = request.Summery,
                                Price = request.Price,
                                SecondaryPrice = request.SecondaryPrice,
                                Discount = request.Discount,
                                DiscountPercent = request.DiscountPercent,
                                Picture = request.Picture,
                                IdUserAdded = UserId,
                                IdUserUpdated = UserId,
                                Status = request.Status
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Inserted new Product.",
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

        plan.MapPut("/Update", ([FromBody] UpdateProductCommand request, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new UpdateProductCommand
                        {
                            Id = request.Id,
                            ProductName = request.ProductName,
                            Title = request.Title,
                            Summery = request.Summery,
                            Price = request.Price,
                            SecondaryPrice = request.SecondaryPrice,
                            Discount = request.Discount,
                            DiscountPercent = request.DiscountPercent,
                            FavoritesListId = request.FavoritesListId,
                            Picture = request.Picture,
                            IdUserUpdated = UserId
                        });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Customer PeyGiry Updated.",
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

        plan.MapDelete("/Delete/{productId}", (Ulid productId, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new DeleteProductCommand { Id = productId });
                        return result.Result.Match(
                                    succes => Results.Ok(new
                                    {
                                        Valid = true,
                                        Message = "Customer PeyGiry Updated.",
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
