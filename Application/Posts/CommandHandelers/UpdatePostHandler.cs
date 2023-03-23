using Application.Interfaces;
using Application.Posts.Commands;
using MediatR;

namespace Application.Posts.CommandHandelers;

public class UpdatePostHandler:IRequestHandler<UpdatePostCommand, Post>
{
    private readonly IPostRepository _postRepository;
    public UpdatePostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    public async Task<Post> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.UpdatePost(request.UpdatedPostContent, request.PostId);
        return post;
    }
}