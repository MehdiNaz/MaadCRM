namespace Application.Interfaces.Customers.Notes;

public interface INoteHashTagRepository
{
    ValueTask<ICollection<CustomerNoteHashTag?>> GetAllNoteHashTagsAsync();
    ValueTask<CustomerNoteHashTag?> GetNoteHashTagByIdAsync(Ulid noteHashTagId);
    ValueTask<CustomerNoteHashTag?> ChangeStatusNoteHashTagByIdAsync(ChangeStatusNoteHashTagCommand request);
    ValueTask<CustomerNoteHashTag?> CreateNoteHashTagAsync(CreateNoteHashTagCommand request);
    ValueTask<CustomerNoteHashTag?> UpdateNoteHashTagAsync(UpdateNoteHashTagCommand request);
    ValueTask<CustomerNoteHashTag?> DeleteNoteHashTagAsync(DeleteNoteHashTagCommand request);
}