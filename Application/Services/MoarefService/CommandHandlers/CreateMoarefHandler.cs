namespace Application.Services.MoarefService.CommandHandlers;

public class CreateMoarefHandler : IRequestHandler<CreateMoarefCommand, Moaref>
{
    private readonly IMoarefRepository _repository;

    public CreateMoarefHandler(IMoarefRepository repository)
    {
        _repository = repository;
    }

    public async Task<Moaref> Handle(CreateMoarefCommand request, CancellationToken cancellationToken)
    {
        Moaref item = new()
        {
            MoarefName = request.MoarefName,
            MoarefFamily = request.MoarefFamily,
            MoarefPhone = request.MoarefPhone
        };
        await _repository.CreateMoarefAsync(item);
        return item;
    }
}

