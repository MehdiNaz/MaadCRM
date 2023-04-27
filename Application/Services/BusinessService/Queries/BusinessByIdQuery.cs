﻿namespace Application.Services.BusinessService.Queries;

public struct BusinessByIdQuery : IRequest<Result<Business>>
{
    public string UserId { get; set; }
}