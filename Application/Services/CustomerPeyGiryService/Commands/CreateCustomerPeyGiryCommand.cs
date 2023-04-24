﻿namespace Application.Services.CustomerPeyGiryService.Commands;

public struct CreateCustomerPeyGiryCommand : IRequest<Result<CustomerPeyGiry>>
{
    public string Description { get; set; }
    public Ulid CustomerId { get; set; }
    public string? IdUser { get; set; }
}