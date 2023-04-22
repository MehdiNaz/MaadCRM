﻿using Domain.Models.Businesses.Plans;

namespace Application.Services.PlanService.Commands;

public struct UpdatePlanCommand : IRequest<Plan>
{
    public Ulid Id { get; set; }
    public string PlanName { get; set; }
    public uint CountOfUsers { get; set; }
    public decimal PriceOfUsers { get; set; }
    public uint CountOfDay { get; set; }
    public decimal PriceOfDay { get; set; }
    public decimal FinalPrice { get; set; }
    public string UserId { get; set; }
}