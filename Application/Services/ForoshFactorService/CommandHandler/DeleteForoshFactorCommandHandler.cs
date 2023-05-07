﻿namespace Application.Services.ForoshFactorService.CommandHandler;

public readonly struct DeleteForoshFactorCommandHandler : IRequestHandler<DeleteForoshFactorCommand, Result<ForooshFactor>>
{
    private readonly IForoshFactorRepository _repository;

    public DeleteForoshFactorCommandHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshFactor>> Handle(DeleteForoshFactorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return ((await _repository.DeleteForoshFactorAsync(request.Id)))
                .Match(result => new Result<ForooshFactor>(result),
                    exception => new Result<ForooshFactor>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new Exception(e.Message));
        }
    }
}