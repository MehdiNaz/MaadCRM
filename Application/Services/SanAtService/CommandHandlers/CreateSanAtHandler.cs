﻿namespace Application.Services.SanAtService.CommandHandlers;

public class CreateSanAtHandler : IRequestHandler<CreateSanAtCommand, SanAt>
{
    private readonly ISanAtRepository _repository;

    public CreateSanAtHandler(ISanAtRepository repository)
    {
        _repository = repository;
    }

    public async Task<SanAt> Handle(CreateSanAtCommand request, CancellationToken cancellationToken)
    {
        SanAt item = new()
        {
            SanAtName = request.SanAtName,
            UserId = request.UserId,
        };
        await _repository.CreateSanAtsAsync(item);
        return item;
    }
}
