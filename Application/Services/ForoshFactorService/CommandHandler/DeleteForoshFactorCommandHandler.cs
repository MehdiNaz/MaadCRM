﻿namespace Application.Services.ForoshFactorService.CommandHandler;

public class DeleteForoshFactorCommandHandler : IRequestHandler<DeleteForoshFactorCommand, ForoshFactor>
{
    private readonly IForoshFactorRepository _repository;

    public DeleteForoshFactorCommandHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForoshFactor> Handle(DeleteForoshFactorCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteForoshFactorAsync(request.ForoshFactorId))!;
}