namespace Application.Services.Posts.CommandHandlers;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Post>
{
    private readonly IPostRepository _postRepository;
    public CreatePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post
        {
            Content = request.PostContent
        };
        await _postRepository.CreatePost(post);
        return post;
    }
}