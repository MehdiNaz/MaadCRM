namespace Application.Services.SanAtService.CommandHandlers;

public class DeleteSanAtHandler : IRequestHandler<DeleteSanAtCommand, SanAt>
{
    private readonly ISanAtRepository _repository;

    public DeleteSanAtHandler(ISanAtRepository repository)
    {
        _repository = repository;
    }

    public async Task<SanAt> Handle(DeleteSanAtCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteSanAtsAsync(request.SanAtId))!;
}