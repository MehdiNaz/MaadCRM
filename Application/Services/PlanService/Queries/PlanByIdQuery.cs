﻿namespace Application.Services.PlanService.Queries;

public struct PlanByIdQuery : IRequest<Plan?>
{
    public Ulid PlanId { get; set; }
}