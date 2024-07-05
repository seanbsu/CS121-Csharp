namespace TextBook;
public interface PostInterface
{
   /// <summary>
    /// Adds a comment with the given values and the current timestamp to this Post.
    /// Appends comment timestamp, author, and text to Post's associated file.
    /// </summary>
    /// <param name="author">One-word username of the author, e.g. "AdaLovelace"</param>
    /// <param name="text">Complete post text</param>
    void AddComment(string author, string text);

    /// <summary>
    /// Returns true if no instance variables are null and a readable file with 
    /// name matching GetFilename() exists, else false.
    /// </summary>
    /// <returns>True if no instance variables are null and a readable file with name matching GetFilename() exists, else false</returns>
    bool IsValid();

    /// <summary>
    /// Returns a well-formatted string including the original post and all comments, 
    /// each on their own lines. Intended for use when a specific post and all of its 
    /// associated comments should be printed to console. Note that post ID should
    /// be formatted to 5-digits as shown in the example. The timestamp conforms to
    /// ISO-8601 standard as returned by an Instant's toString().
    /// Example:
    ///   Post:
    ///   00010 2021-11-30T23:38:23.085Z Mason Did stuff.
    ///   Comments:
    ///   2021-12-01T08:18:21.055Z Luke It's late...
    ///   2021-12-01T09:22:03.142Z Kathryn And it wasn't the right stuff. 
    /// </summary>
    /// <returns>A well-formatted string including post and all comments</returns>
    string ToString();

    /// <summary>
    /// Returns a well-formatted string including post ID, date, author, and text of 
    /// the original post, exactly as shown in the first line of ToString() output.
    /// Intended for use when a list of posts is printed to console.
    /// Example:
    ///   00010 2021-11-30T23:38:23.085Z Mason Did stuff
    /// </summary>
    /// <returns>A well-formatted string including id, date, author, and post text only</returns>
    string ToStringPostOnly();

    /// <summary>
    /// Return associated filename with format: Post-<postID>.txt
    /// where postID is formatted to 5 digits as shown in the example.
    /// Example:
    /// 	Post-00010.txt
    /// </summary>
    /// <returns>Filename associated with post ID</returns>
    string GetFilename();

    /// <summary>
    /// Return post ID.
    /// </summary>
    /// <returns>Post ID</returns>
    int GetPostID ();

    /// <summary>
    /// Return text of original post.
    /// </summary>
    /// <returns>Text of original post</returns>
    string Text();

    /// <summary>
    /// Return timestamp of original Post as Instant.
    /// </summary>
    /// <returns>Instant of original post</returns>
    DateTime GetTimestamp();

    /// <summary>
    /// Return author of original Post.
    /// </summary>
    /// <returns>Author of original post</returns>
    string GetAuthor(); 
}