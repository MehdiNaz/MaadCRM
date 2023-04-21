﻿namespace Application.Services.CustomerService.Query;

public struct CustomerBySearchItemQuery : IRequest<ICollection<CustomerResponse>?>
{
    public string Q { get; set; }
}