﻿namespace Application.Services.BusinessService.CommandHandler;

public readonly struct UpdateBusinessCommandHandler : IRequestHandler<UpdateBusinessCommand, Business>
{
    private readonly IBusinessRepository _repository;

    public UpdateBusinessCommandHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Business> Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
    {
        UpdateBusinessCommand item = new()
        {
            BusinessId = request.BusinessId,
            Url = request.Url,
            Hosts = request.Hosts,
            CompanyName = request.CompanyName,
            CompanyAddress = request.CompanyAddress,
            DisplayOrder = request.DisplayOrder,
            BusinessName = request.BusinessName
            //UserId = request.UserId!
        };
        return await _repository.UpdateBusinessAsync(item);
    }
}