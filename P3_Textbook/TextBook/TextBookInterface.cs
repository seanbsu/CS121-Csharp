namespace TextBook;
using System.Collections.Generic;
/**
 * DO NOT MODIFY THIS INTERFACE - It is the responsibility of your TextBook class
 * to provide methods that look and behave exactly as described in this interface.
 * 
 * A TextBook manages the posts of the TextBook social media site. When instantiated,
 * a TextBook attempts to restore the previous session from files. If it is unable
 * to do so, it initiates a new empty list of posts and resets the last post ID to 
 * zero.
 * 
 * @author mvail
 * @author jerryfails
 */
public interface TextBookInterface
{
    /// <summary>
    /// This constant defines the expected name of the file that contains a
    /// list of all Post IDs in the TextBook, one ID per line.
    /// </summary>
    const string POST_LIST_FILENAME = "posts.txt";

    /// <summary>
    /// Return the last post ID assigned to a Post in TextBook. If TextBook has
    /// just been loaded, this number corresponds to the last ID read from the 
    /// posts file named POST_LIST_FILENAME or 0 if the file contained no IDs or
    /// is not found.
    /// </summary>
    /// <returns>Current value of lastID</returns>
    int GetLastID();

    /// <summary>
    /// Return the number of Posts currently in TextBook's collection.
    /// </summary>
    /// <returns>Current number of Posts</returns>
    int GetPostCount();

    /// <summary>
    /// Returns the string from the indexed Post's ToString(), which includes the Post
    /// itself and its comments. Returns null if the index is invalid.
    /// </summary>
    /// <param name="index">Index of Post</param>
    /// <returns>ToString() from Post at given index or null if invalid index</returns>
    string GetPostString(int index);

    /// <summary>
    /// Adds a new Post with the given author and text to the collection of Posts.
    /// Updates the file with name POST_LIST_FILENAME to include the new Post ID.
    /// Updates the value of last ID.
    /// </summary>
    /// <param name="author">Name of the new Post's author</param>
    /// <param name="text">Text of the new Post</param>
    /// <returns>True if successful, else false</returns>
    bool AddPost(string author, string text);

    /// <summary>
    /// Remove and return Post at given index or return null if invalid index.
    /// Updates file with name POST_LIST_FILENAME if index was valid to no longer
    /// include removed Post ID.
    /// </summary>
    /// <param name="index">The index of a Post in TextBook's collection</param>
    /// <returns>Removed Post or null if index was invalid</returns>
    Post RemovePost(int index);

    /// <summary>
    /// Adds a new comment with the given author and text to the Post at the given
    /// index if valid. If the given index is invalid, return false.
    /// </summary>
    /// <param name="postIndex">Index of post targeted by this comment</param>
    /// <param name="author">Name of comment's author</param>
    /// <param name="text">Text of the comment</param>
    /// <returns>True if index is valid, else false</returns>
    bool AddComment(int postIndex, string author, string text);

    /// <summary>
    /// Returns a well-formatted string with number of Posts and a list of Posts 
    /// where each Post's ToString() is preceded by its index in the collection 
    /// and each post is on its own line as shown in the example.
    /// Example:
    ///   "TextBook contains 2 posts:
    ///    0 - 00010 2021-11-02T12:20:59.122Z Mason Did stuff.
    ///    1 - 00011 2021-11-02T12:45:52.023Z Luke Heckled Mason."
    /// </summary>
    /// <returns>Well-formatted string with post count and indexed posts</returns>
    string ToString();

    /// <summary>
    /// Returns a COPY of the posts list for testing. Make sure you are not violating
    /// encapsulation by returning your posts variable or an alias.
    /// </summary>
    /// <returns>Copy of posts list</returns>
    List<Post> GetPosts();
}

