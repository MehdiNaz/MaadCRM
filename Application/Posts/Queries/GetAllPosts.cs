using MediatR;

namespace Application.Posts.Queries;

public class GetAllPostsQuery : IRequest<ICollection<Post?>>
{
    
}