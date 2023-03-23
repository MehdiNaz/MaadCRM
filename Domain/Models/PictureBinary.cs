using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.General;

public class PictureBinary:BaseEntity
{
    public int PictureId { get; set; }
    public byte[] BinaryData { get; set; }
    [ForeignKey(nameof(PictureId))]
    public Picture Picture { get; set; }
}