namespace Application.Services.Posts.Commands;

public class CreatePostCommand : IRequest<Post>
{
    public string? PostContent { get; set; }
}
