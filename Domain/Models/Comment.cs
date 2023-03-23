namespace Domain.Models;

public partial class Comment
{
    public Comment()
    {
        InverseIdCommentParrentNavigation = new HashSet<Comment>();
    }

    public int Id { get; set; }
    public int? IdCommentParrent { get; set; }
    public string IdUser { get; set; }
    public int Idkoupon { get; set; }
    public string Txt { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] Rowversion { get; set; }
    public byte? Publish { get; set; }

    public virtual Comment IdCommentParrentNavigation { get; set; }
    public virtual Koupon IdkouponNavigation { get; set; }
    public virtual ICollection<Comment> InverseIdCommentParrentNavigation { get; set; }
}