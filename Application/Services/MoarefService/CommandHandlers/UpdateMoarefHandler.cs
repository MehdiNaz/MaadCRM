namespace Application.Services.MoarefService.CommandHandlers;

public class UpdateMoarefHandler : IRequestHandler<UpdateMoarefCommand, Moaref>
{
    private readonly IMoarefRepository _repository;

    public UpdateMoarefHandler(IMoarefRepository repository)
    {
        _repository = repository;
    }

    public async Task<Moaref> Handle(UpdateMoarefCommand request, CancellationToken cancellationToken)
    {
        Moaref item = new()
        {
            MoarefName = request.MoarefName,
            MoarefFamily = request.MoarefFamily,
            MoarefPhone = request.MoarefPhone
        };
        await _repository.UpdateMoarefAsync(item, request.MoarefId);
        return item;
    }
}