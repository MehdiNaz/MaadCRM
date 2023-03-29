namespace Application.Services.SanAtService.CommandHandlers;

public class UpdateSanAtHandler : IRequestHandler<UpdateSanAtCommand, SanAt>
{
    private readonly ISanAtRepository _repository;

    public UpdateSanAtHandler(ISanAtRepository repository)
    {
        _repository = repository;
    }

    public async Task<SanAt> Handle(UpdateSanAtCommand request, CancellationToken cancellationToken)
    {
        SanAt item = new()
        {
            SanAtName = request.SanAtName,
            IdUser = request.IdUser,
        };
        await _repository.UpdateSanAtsAsync(item, request.SanAtId);
        return item;
    }
}
