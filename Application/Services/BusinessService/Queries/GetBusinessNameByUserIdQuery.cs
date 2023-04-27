﻿namespace Application.Services.BusinessService.Queries;

public struct GetBusinessNameByUserIdQuery : IRequest<Result<Business>>
{
    public string UserId { get; set; }
}