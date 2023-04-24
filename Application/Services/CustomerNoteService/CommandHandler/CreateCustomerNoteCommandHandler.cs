using LanguageExt.Common;

namespace Application.Services.CustomerNoteService.CommandHandler;

public readonly struct CreateCustomerNoteCommandHandler : IRequestHandler<CreateCustomerNoteCommand, Result<CustomerNote>>
{
    private readonly ICustomerNoteRepository _repository;

    public CreateCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNote>> Handle(CreateCustomerNoteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateCustomerNoteCommand item = new()
            {
                Description = request.Description,
                CustomerId = request.CustomerId,
                ProductId = request.ProductId,
                HashTagIds = request.HashTagIds,
                IdUser = request.IdUser
            };

            var result = await _repository.CreateCustomerNoteAsync(item);
            return result.Match(
                resultCode => new Result<CustomerNote>(resultCode),
                exception => new Result<CustomerNote>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNote>(new Exception(e.Message));
        }
    }
}