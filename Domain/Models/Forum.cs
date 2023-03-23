namespace Domain.Models;

public class Forum
{
    public Forum()
    {
        InverseIdForoumParentNavigation = new HashSet<Forum>();
        Posts = new HashSet<Post>();
    }

    public int Id { get; set; }
    public int IdForoumParent { get; set; }
    public string Title { get; set; }
    public string SeoTitle { get; set; }
    public int OrderF { get; set; }
    public byte Status { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] Rowversion { get; set; }

    public virtual Forum IdForoumParentNavigation { get; set; }
    public virtual ICollection<Forum> InverseIdForoumParentNavigation { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
}