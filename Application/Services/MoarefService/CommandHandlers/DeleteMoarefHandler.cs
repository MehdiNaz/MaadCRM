namespace Application.Services.MoarefService.CommandHandlers;

public class DeleteMoarefHandler : IRequestHandler<DeleteMoarefCommand, Moaref>
{
    private readonly IMoarefRepository _repository;

    public DeleteMoarefHandler(IMoarefRepository repository)
    {
        _repository = repository;
    }

    public async Task<Moaref> Handle(DeleteMoarefCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteMoarefAsync(request.MoarefId))!;
}