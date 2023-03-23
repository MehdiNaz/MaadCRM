namespace Application.Interfaces;

public interface IPostRepository
{
    ValueTask<ICollection<Post?>> GetAllPost();
    ValueTask<Post?> GetPostById(int postId);
    ValueTask<Post> CreatePost(Post toCreate);
    ValueTask<Post?> UpdatePost(string updateContent, int postId);
    ValueTask DeletePost(int postId);
}