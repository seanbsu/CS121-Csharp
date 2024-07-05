namespace TextBook;

public class TextBookUnitTester
{
    private  const string ADA_POST_AUTHOR = "AdaLovelace";
	private  const string ADA_POST_TEXT = "I am much pleased to find how very well I stand work and how my powers of attention and continued effort increase.";
	private  const string ADA_POST_COMMENT1_AUTHOR = "GraceHopper";
	private  const string ADA_POST_COMMENT1_TEXT = "The only phrase I've ever disliked is, 'Why, we've always done it that way.' I always tell young people, 'Go ahead and do it. You can always apologize later.'";
	private  const string ADA_POST_COMMENT2_AUTHOR = "KatherineJones";
	private  const string ADA_POST_COMMENT2_TEXT = "I like to learn. That's an art and a science.";
	private  const string GRACE_POST_AUTHOR = "GraceHopper";
	private  const string GRACE_POST_TEXT = "One accurate measurement is worth a thousand expert opinions.";
	private  const string GRACE_POST_COMMENT1_AUTHOR = "AdaLovelace";
	private  const string GRACE_POST_COMMENT1_TEXT = "Thus not only the mental and the material but the theoretical and the practical in the mathematical world, are brought into more intimate and effective connection with each other.";
	private  const string KATHERINE_POST_AUTHOR = "KatherineJohnson";
	private  const string KATHERINE_POST_TEXT = "Girls are capable of doing everything men are capable of doing. Sometimes they have more imagination than men.";

    private const int TOTAL_TESTS = 9;
    private static int testsPassed = 0;

	private static int status = 0;
    

    public static int Run(){
        TestConstructor();
		TestAddPost();
		TestRemovePost();
		TestAddComment();
		TestLastID();
		TestGetPostCount();
		TestGetPostString();
		TestToString();
		TestGetPosts();

		Console.WriteLine("\nPassed " + testsPassed + " of " + TOTAL_TESTS + " tests (" + (double)testsPassed*100/TOTAL_TESTS + "%)\n");

		return status;
    }

    /**
	 * Confirm that calling the TextBook constructor for a new empty TextBook does
	 * not result in a thrown Exception (and TextBook implements TextBookInterface
	 * as required). Also attempts to recover a TextBook from file and superficially
	 * checks that all Posts were recovered.
	 */
     private static void TestConstructor()
     {
        string testName = "TestConstructor";
        bool testPassed = true;
        string testResults ="";
        string subtest = testName;
        try{
            subtest = testName + " - new TextBook(), no prior " + TextBookInterface.POST_LIST_FILENAME;
			string postFile = TextBookInterface.POST_LIST_FILENAME;
            if(File.Exists(postFile))
            {
                File.Delete(postFile);
            }

            TextBookInterface theTextBook = new TextBook();//expecting no exceptions
            testResults += SubTestPass(subtest);

            subtest = testName + " - recovering TextBook from file";
			theTextBook.AddPost(ADA_POST_AUTHOR, ADA_POST_TEXT);
			theTextBook.AddPost(KATHERINE_POST_AUTHOR, KATHERINE_POST_TEXT);
			theTextBook.AddPost(GRACE_POST_AUTHOR, GRACE_POST_TEXT);
			theTextBook.AddComment(0, ADA_POST_COMMENT1_AUTHOR, ADA_POST_COMMENT1_TEXT);
			theTextBook.AddComment(0, ADA_POST_COMMENT2_AUTHOR, ADA_POST_COMMENT2_TEXT);
			theTextBook.AddComment(2, GRACE_POST_COMMENT1_AUTHOR, GRACE_POST_COMMENT1_TEXT);		
			TextBookInterface recoveredTextBook = new TextBook();
			bool subtestPassed = true;
            if (recoveredTextBook.GetPostCount() != 3) {
				testResults += SubTestFailure(subtest, "Post count == 3", recoveredTextBook.GetPostCount().ToString());
				testPassed = false;
				subtestPassed = false;
			}
			if (recoveredTextBook.GetLastID() != 3) {
				testResults += SubTestFailure(subtest, "Last ID == 3", recoveredTextBook.GetLastID().ToString());
				testPassed = false;
				subtestPassed = false;
			} 
			if (!recoveredTextBook.GetPosts()[0].GetAuthor().Equals(ADA_POST_AUTHOR)) { //incomplete confirmation, but at least author is there
				testResults += SubTestFailure(subtest, "First Post recovered with author " + ADA_POST_AUTHOR, recoveredTextBook.GetPosts()[0].GetAuthor());
				testPassed = false;
				subtestPassed = false;
			}
			if (!recoveredTextBook.GetPosts()[1].GetAuthor().Equals(KATHERINE_POST_AUTHOR)) { //incomplete confirmation, but at least author is there
				testResults += SubTestFailure(subtest, "Second Post recovered with author " + KATHERINE_POST_AUTHOR, recoveredTextBook.GetPosts()[1].GetAuthor());
				testPassed = false;
				subtestPassed = false;
			}
			if (!recoveredTextBook.GetPosts()[2].GetAuthor().Equals(GRACE_POST_AUTHOR)) { //incomplete confirmation, but at least author is there
				testResults += SubTestFailure(subtest, "Third Post recovered with author " + GRACE_POST_AUTHOR, recoveredTextBook.GetPosts()[2].GetAuthor());
				testPassed = false;
				subtestPassed = false;
			} 
			if (!recoveredTextBook.GetPosts()[0].ToString().Contains(ADA_POST_COMMENT1_AUTHOR)
					|| !recoveredTextBook.GetPosts()[0].ToString().Contains(ADA_POST_COMMENT1_TEXT)) { //incomplete confirmation, but at least author and text are there
				testResults += SubTestFailure(subtest, "Missing first comment for first post", recoveredTextBook.GetPosts()[0].ToString());
				testPassed = false;					
				subtestPassed = false;
			} 
			if (!recoveredTextBook.GetPosts()[0].ToString().Contains(ADA_POST_COMMENT2_AUTHOR)
					|| !recoveredTextBook.GetPosts()[0].ToString().Contains(ADA_POST_COMMENT2_TEXT)) { //incomplete confirmation, but at least author and text are there
				testResults += SubTestFailure(subtest, "Missing second comment for first post", recoveredTextBook.GetPosts()[0].ToString());
				testPassed = false;					
				subtestPassed = false;
			}
			if (!recoveredTextBook.GetPosts()[2].ToString().Contains(GRACE_POST_COMMENT1_AUTHOR)
					|| !recoveredTextBook.GetPosts()[2].ToString().Contains(GRACE_POST_COMMENT1_TEXT)) { //incomplete confirmation, but at least author and text are there
				testResults += SubTestFailure(subtest, "Missing first comment for third post", recoveredTextBook.GetPosts()[2].ToString());
				testPassed = false;					
			}
			if (subtestPassed) {
				testResults += SubTestPass(subtest);
			}

        }catch(Exception e){
            testResults += SubTestFailure(subtest, "No exceptions.", "Exception thrown.");
			testResults += e.ToString();
			testPassed = false;
            Console.Error.WriteLine(e.StackTrace);
        }

     }

     /**
	 * Confirms no exceptions are thrown when adding new posts.
	 */
	private static void TestAddPost() 
    {

    }

    /**
	 * Confirm that removePost() returns null for invalid indexes and the Post
	 * with expected values for valid indexes.
	 */
	private static void TestRemovePost()
    {

    }

     /**
	 * Confirm that addComment() returns false for invalid Post indexes and true
	 * for valid indexes.
	 */
     private static void TestAddComment() 
     {

     }

     /**
	 * Confirm that removePost() returns null for invalid indexes and the Post
	 * with expected values for valid indexes.
	 */
     private static void TestLastID() 
     {

     }

     /**
	 * Confirm that getPostCount() returns the expected count.
	 */
	private static void TestGetPostCount() 
    {

    }

    /**
	 * Confirm that getPostString() returns null for invalid indexes and a
	 * String including the Post and all comments for valid indexes.
	 */
	private static void TestGetPostString()
    {

    }

    /**
	 * Confirm GetPosts() returns a list of all expected Posts and that TextBook
	 * encapsulation is preserved.
	 */
	private static void TestGetPosts()
    {

    }

    /**
	 * Confirm expected markers of required output content and formatting from
	 * toString().
	 */
	private static void TestToString()
    {

    }

    /**
	 * Format test output for a failed subtest.
	 * @param testName name of failed subtest
	 * @param expected description of expected result
	 * @param actual description of actual result
	 * @return formatted String with test output
	 */
	private static string SubTestFailure(string testName, string expected, string actual)
    {
        string output= "    (error): " + testName + "\n";
		output += "        --> expected: " + expected + "\n";
		output += "        -->   actual: " + actual + "\n";;
        return output;
    }

    /**
	 * Format test output for a passed subtest.
	 * @param testName name of passed subtest
	 * @return formatted String with test output
	 */
	private static string SubTestPass(string testName) {
		return "    " + testName + "\n";
	}

    /**
	 * Format test output for a failed test.
	 * @param testName name of failed test
	 * @param message description of the cause of test failure
	 */
	private static void fail(string testName, string message) {
		Console.Error.WriteLine("FAILED: " + testName);
		Console.Error.WriteLine("    " + message.Trim());
		status = 1;
	}

    /**
	 * Format test output for a passed test.
	 * @param testName name of passed test
	 * @param message description to elaborate on test result
	 */
	private static void pass(String testName, String message) {
		Console.WriteLine("PASSED: " + testName);
		Console.WriteLine("    " + message.Trim());
		testsPassed++;
	}



}
