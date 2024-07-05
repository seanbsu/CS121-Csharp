
namespace TextBook;
public class TextBook : TextBookInterface
{
    public TextBook() 
    {

    }

    public bool AddComment(int postIndex, string author, string text)
    {
        throw new NotImplementedException();
    }

    public bool AddPost(string author, string text)
    {
        throw new NotImplementedException();
    }

    public int GetLastID()
    {
        throw new NotImplementedException();
    }

    public int GetPostCount()
    {
        throw new NotImplementedException();
    }

    public List<Post> GetPosts()
    {
        throw new NotImplementedException();
    }

    public string GetPostString(int index)
    {
        throw new NotImplementedException();
    }

    public Post RemovePost(int index)
    {
        throw new NotImplementedException();
    }
}