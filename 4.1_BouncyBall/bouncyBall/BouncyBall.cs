namespace bouncyBall;
public class BouncyBall : Panel
{
    private const int INIT_WIDTH = 600;
	private const int INIT_HEIGHT = 400;
	private const int DELAY = 60;       // milliseconds between Timer events

	private Random random;              // random number generator
	private Color color;                // initial ball color

	private int x, y;                   // ball anchor point coordinates
	private int xDelta, yDelta;         // change in x and y from one step to the next

	private int radius = 10;            // ball radius

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;
            // Clear canvas
            using(Brush canvasBrush = new SolidBrush(this.BackColor))
            {
                g.FillRectangle(canvasBrush,0,0,width,height);
            }
            // Calculate new x anchor point value
            x += xDelta;
            // TODO: Add conditional statements to keep ball in bounds
            //       in the x axis (e.g. left and right edges)


            // Calculate new y anchor point value
            y += yDelta;
            // TODO: Add conditional statements to keep ball in bounds
            //       in the y axis (e.g. top and bottom edges)


            
            // Paint the ball at the calculated anchor point
            using(Brush ballBrush = new SolidBrush(color))
            {
                g.FillEllipse(ballBrush,x - radius, y - radius, 2 * radius, 2 * radius);
            }
        }

        public BouncyBall()
        {
            this.BackColor =Color.White;
            this.Size = new Size(INIT_WIDTH,INIT_HEIGHT);
            this.DoubleBuffered = true;
            
            // Instantiate instance variable for reuse in OnPaint()
            random = new Random();

            // Initialize ball color
		    // TODO: replace with random starting color.
            color = Color.Red;

            // Initialize ball anchor point within panel bounds
            // TODO: replace centered starting point with a random
            // position anywhere in-bounds - the ball should never
            // extend out of bounds, so you'll need to take RADIUS
            // into account. Use INIT_WIDTH and INIT_HEIGHT as the
            // screen width and height.
            x = INIT_WIDTH/2;
            y = INIT_HEIGHT/2;

            // Initialize deltas for x and y
            xDelta = 5;
            yDelta = 5;
            
             System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = DELAY;
            timer.Tick += new EventHandler(OnTick);
            timer.Start();
            
        }

         private void OnTick(object sender, EventArgs e)
        {
            this.Invalidate();// Triggers the Paint event
        }


}