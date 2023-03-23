namespace DataAccess.Repositories;

public class PostRepository : IPostRepository
{
    private readonly MaadContext _context;

    public PostRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Post> CreatePost(Post toCreate)
    {
        toCreate.DateCreated = DateTime.Now;
        toCreate.LastModfied = DateTime.Now;
        await _context.Posts.AddAsync(toCreate);
        await _context.SaveChangesAsync();
        return toCreate;
    }

    public async ValueTask DeletePost(int postId)
    {
        var post = await GetPostById(postId);
        if(post == null) return;
        
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
    }

    public async ValueTask<ICollection<Post?>> GetAllPost()
    {
        return await _context.Posts.ToListAsync();
    }

    public async ValueTask<Post?> GetPostById(int postId)
    {
        return await _context.Posts.FindAsync(postId);
    }

    public async ValueTask<Post?> UpdatePost(string updateContent, int postId)
    {
        var post = await GetPostById(postId);
        post.Content = updateContent;
        post.LastModfied = DateTime.Now;
        await _context.SaveChangesAsync();
        return post;
    }
}
