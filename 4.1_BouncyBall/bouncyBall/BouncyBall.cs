namespace bouncyBall;
public class BouncyBall : Panel
{
    private const int INIT_WIDTH = 600;
	private const int INIT_HEIGHT = 400;
	private const int DELAY = 60;       // milliseconds between Timer events

	private Random random;              // random number generator
	private Color color;                // initial ball color

	private int x, y;                   // ball anchor point coordinates
	private int xDelta, yDelta,radiusDelta;         // change in x and y from one step to the next

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
            radius += radiusDelta;
            if(radius < 0){
                radius =1;
                radiusDelta = -radiusDelta;
            }
            if(x-radius < 0)
            {
                xDelta=-xDelta;
                x=radius;
                radiusDelta = -radiusDelta;

            }else if(x+radius > width)
            {
                xDelta =-xDelta;
                x=width-radius;
                radiusDelta = -radiusDelta;
            }

            // Calculate new y anchor point value
            y += yDelta;
            // TODO: Add conditional statements to keep ball in bounds
            //       in the y axis (e.g. top and bottom edges)
            if(y-radius < 0){
                yDelta = -yDelta;
                y=radius;
                radiusDelta = -radiusDelta;
            }else if(y+radius > height){
                yDelta = -yDelta;
                y= height-radius;
                radiusDelta = -radiusDelta;
            }

            
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
            Random r = new Random();
            color = Color.FromArgb(r.Next(256),r.Next(256),r.Next(256));

            // Initialize ball anchor point within panel bounds
            // TODO: replace centered starting point with a random
            // position anywhere in-bounds - the ball should never
            // extend out of bounds, so you'll need to take RADIUS
            // into account. Use INIT_WIDTH and INIT_HEIGHT as the
            // screen width and height.
            x = r.Next(INIT_WIDTH-radius);
            y = r.Next(INIT_HEIGHT-radius);

            // Initialize deltas for x and y
            xDelta = 5;
            yDelta = 5;
            radiusDelta = 1;
            
             System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = DELAY;
            timer.Tick += new EventHandler(OnTick);
            timer.Start();
            
        }

         private void OnTick(object sender, EventArgs e)
        {
            radius+=radiusDelta;
            this.Invalidate();// Triggers the Paint event
        }


}