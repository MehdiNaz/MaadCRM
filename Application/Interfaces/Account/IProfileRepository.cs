using Application.Services.Profile.Command;
using Domain.Models.IdentityModels;

namespace Application.Interfaces.Account;

public interface IProfileRepository
{
    ValueTask<User?> SetProfile(SetProfileCommand request);
}