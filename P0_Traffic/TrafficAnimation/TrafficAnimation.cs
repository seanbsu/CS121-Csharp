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
    private readonly Color SKY_COLOR = Color.FromArgb(51,255,255);
    private readonly Color GRASS_COLOR = Color.Green;

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

        //unit for drawing
        double unit = Math.Min(width,height)/20;

        // Fill the graphics page with the background color.
        using(Brush canvasBrush = new SolidBrush(BACKGROUND_COLOR))
        {
            g.FillRectangle(canvasBrush,0,0,width,height);
        }

        // This sets and draws the sky
         using(Brush canvasBrush = new SolidBrush(SKY_COLOR))
        {
            g.FillRectangle(canvasBrush,0,0,width,height/4);
        }

        //=====================================================
		//Grass
		//=====================================================
		//This set grass and draws the grass under the road
		int grassBelowX = 0;
		int grassBelowY = height * 3/4;
		int grassBelowH = height / 4;

        using(Brush canvasBrush = new SolidBrush(GRASS_COLOR))
        {
            g.FillRectangle(canvasBrush,grassBelowX,grassBelowY, width, grassBelowH);
        }

        //Grass above road
		int grassAboveX = 0;
		int grassAboveY = height / 4;
		int grassAboveH = height / 8;

        using(Brush canvasBrush = new SolidBrush(GRASS_COLOR))
        {
            g.FillRectangle(canvasBrush,grassAboveX,grassAboveY, width, grassAboveH);
        }
        //=====================================================
		//Road
		//=====================================================
		//This sets the and colors the road
        int roadX = 0;
		int roadY = height/4 + (int)unit * 2;
        using(Brush canvasBrush = new SolidBrush(BACKGROUND_COLOR))
        {
            g.FillRectangle(canvasBrush,roadX, roadY, width, (int)unit*8);
        }

        // Calculate the new xOffset position of the moving object.
		xOffset  = (xOffset + stepSize) % width;

        //=====================================================
		//Truck
		//=====================================================
		
		// Draw Truck body
		int truckW = (int)unit * 10;
		int truckH = (int)unit * 4; 
		int truckX = xOffset;
		int truckY = height/2;
        using(Brush squareBrush = new SolidBrush(Color.Red))
        {
            g.FillRectangle(squareBrush,truckX, truckY, truckW , truckH);
        }

        // draws and positions front of truck
		int frontX = truckX + (int) unit * 10;
		int frontY = truckY + (int)unit * 1;
		int frontW = truckW/3;
		int frontH = truckH - (int)unit*1;

        using(Brush squareBrush = new SolidBrush(Color.Blue))
        {
            g.FillRectangle(squareBrush,frontX, frontY, frontW, frontH);
        }
        
        
        //draw wheel 1 and fill in color
		int wheel1X = xOffset + (int)unit * 2;
		int wheel1Y = height * 6/10 + (int)unit;
        using(Brush wheelBrush = new SolidBrush(Color.Gray))
        {
            g.FillEllipse(wheelBrush,wheel1X, wheel1Y, (int)unit * 3/2, (int)unit * 3/2);
        }

        int wheel2X = xOffset + (int)(unit) * 7;
		int wheel2Y = height * 6/10  +(int)(unit) ;
        using(Brush wheelBrush = new SolidBrush(Color.Gray))
        {
            g.FillEllipse(wheelBrush,wheel2X, wheel2Y, (int)unit * 3/2, (int)unit * 3/2);
        }

    }

    private void OnTick(object? sender,EventArgs e)
    {
        this.Invalidate();
    }
}