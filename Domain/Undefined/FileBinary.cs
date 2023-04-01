namespace Domain.UnDifined;

public class FileBinary : BaseEntity
{
    public int FileManagementId { get; set; }
    public byte[] BinaryData { get; set; }
    [ForeignKey(nameof(FileManagementId))]
    public FileManagement FileManagement { get; set; }
}