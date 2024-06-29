namespace TrafficAnimation;

/// <summary>
/// CS 121 Project 0: Traffic Animation
/// Animates a [put your description here]
/// @author BSU CS 121 Instructors
/// @author [put your name here]
/// </summary>
public class TrafficAnimation:Panel
{
   // This is where you declare constants and variables that need to keep their
	// values between calls	to paintComponent(). Any other variables should be
	// declared locally, in the method where they are used

    /**
	 * A constant to regulate the frequency of Timer events.
	 * Note: 100ms is 10 frames per second - you should not need
	 * a faster refresh rate than this
	 */
    private const int DELAY = 100;

    /**
	 * The anchor coordinate for drawing / animating. All of your vehicle's
	 * coordinates should be relative to this offset value.
	 */
     private int xOffset = 0;

     /**
	 * The number of pixels added to xOffset each time paintComponent() is called.
	 */
	private int stepSize = 10;

    private readonly Color BACKGROUND_COLOR = Color.Black;

    /// <summary>
    ///  Constructor for the display panel initializes necessary variables.
	///  Only called once, when the program first begins. This method also
	///  sets up a Timer that will call paint() with frequency specified by
	/// the DELAY constant.
    /// </summary>
    public TrafficAnimation(){
        // Do not initialize larger than 800x600. I won't be able to
		// grade your project if you do.
		int initWidth = 600;
		int initHeight = 400;
		this.Size = new Size(initWidth, initHeight);
		this.DoubleBuffered=true;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Interval = DELAY;
        timer.Tick += new EventHandler(OnTick);
        timer.Start();
    }

    /// <summary>
    /// This method draws on the panel's Graphics context.
	///  This is where the majority of your work will be.
    /// </summary>
    /// <param name="e"></param> 
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        // Get the current width and height of the window.
        int width = this.ClientSize.Width;
        int height = this.ClientSize.Height;
        this.Dock = DockStyle.Fill;

        // Fill the graphics page with the background color.
        using(Brush canvasBrush = new SolidBrush(BACKGROUND_COLOR))
        {
            g.FillRectangle(canvasBrush,0,0,width,height);
        }

        // Calculate the new xOffset position of the moving object.
		xOffset  = (xOffset + stepSize) % width;

        // This draws a green square. Replace it with your own object.
		int squareW = height/5;
		int squareH = squareW; 
		int squareX = xOffset;
		int squareY = height/2 - squareW/2;

        using(Brush squareBrush = new SolidBrush(Color.Green))
        {
            g.FillRectangle(squareBrush,squareX, squareY,squareW,squareH);
        }

        // TODO: Use width, height, and xOffset to draw your scalable objects
		// at their new positions on the screen

    }

    private void OnTick(object? sender,EventArgs e)
    {
        this.Invalidate();
    }
}