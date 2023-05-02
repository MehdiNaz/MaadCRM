﻿namespace Application.Services.ContactService.CommandHandlers;

public readonly struct DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Result<ContactsResponse>>
{
    private readonly IContactRepository _repository;

    public DeleteContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ContactsResponse>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteContactAsync(request.ContactId)).Match(result => new Result<ContactsResponse>(result), exception => new Result<ContactsResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ContactsResponse>(new Exception(e.Message));
        }
    }
}