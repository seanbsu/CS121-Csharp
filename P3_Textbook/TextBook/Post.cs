
namespace TextBook;
public class Post : PostInterface
{
  

    public string ToString(){
        return "";
    }
    public string GetAuthor(){
        return "";
    }

    public void AddComment(string author, string text)
    {
        throw new NotImplementedException();
    }

    public bool IsValid()
    {
        throw new NotImplementedException();
    }

    public string ToStringPostOnly()
    {
        throw new NotImplementedException();
    }

    public string GetFilename()
    {
        throw new NotImplementedException();
    }

    public int GetPostID()
    {
        throw new NotImplementedException();
    }

    public string Text()
    {
        throw new NotImplementedException();
    }

    public DateTime GetTimestamp()
    {
        throw new NotImplementedException();
    }
}