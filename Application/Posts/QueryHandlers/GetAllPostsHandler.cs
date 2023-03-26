using Application.Interfaces;
using Application.Posts.Queries;
using MediatR;

namespace Application.Posts.QueryHandlers;

public class GetAllPostsHandler : IRequestHandler<GetAllPostsQuery,ICollection<Post?>>
{
    private readonly IPostRepository _postRepository;
    public GetAllPostsHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    public async Task<ICollection<Post?>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        return await _postRepository.GetAllPost();
    }
}