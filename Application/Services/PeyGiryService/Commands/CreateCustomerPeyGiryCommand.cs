﻿namespace Application.Services.PeyGiryService.Commands;

public struct CreateCustomerPeyGiryCommand : IRequest<CustomerPeyGiry>
{
    public string Description { get; set; }
    public Ulid CustomerId { get; set; }
}