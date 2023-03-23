using MediatR;

namespace Application.Posts.Commands;

public class UpdatePostCommand : IRequest<Post>
{
    public int PostId { get; set; }
    public string? UpdatedPostContent { get; set; }
}