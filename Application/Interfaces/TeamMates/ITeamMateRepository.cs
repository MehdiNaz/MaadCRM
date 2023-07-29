using Application.Services.TeamMates.Query;

namespace Application.Interfaces.TeamMates;

public interface ITeamMateRepository
{
    ValueTask<Result<bool>> AddTeamMateAsync(AddTeamMateCommand request);
    ValueTask<Result<TeamMateResponse>> EditTeamMateAsync(EditTeamMateCommand request);
    ValueTask<Result<TeamMateResponse>> ChangePermissionAsync(ChangePermissionCommand request);

    ValueTask<Result<TeamMateResponse>> DeleteTeamMateAsync(DeleteTeamMateCommand request);
    ValueTask<Result<ICollection<TeamMateResponse>>> GetAllTeamMatesAsync(AllUsersQuery request);
    ValueTask<Result<TeamMateResponse>> GetTeamMateByIdAsync(GetTeamMateByIdQuery request);


}