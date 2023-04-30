﻿namespace Application.Services.CustomerService.Commands;

public struct ChangeStateCustomerCommand : IRequest<Result<CustomerResponse>>
{
    public Ulid CustomerId { get; set; }
    public CustomerStateTypes CustomerStateType { get; set; }
}