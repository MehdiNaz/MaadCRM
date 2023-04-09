namespace Application.Services.BusinessPlansService.Commands;

public class DeleteBusinessPlansCommand : IRequest<BusinessPlans>
{
    public Ulid BusinessPlansId { get; set; }
}