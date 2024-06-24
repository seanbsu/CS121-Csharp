
using System.Drawing.Drawing2D;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ObjectiveC;
using System.Xml;
namespace geoOrbit
{    
    public class Orbit : Panel
    {
        private const int INIT_WIDTH = 600;
        private const int INIT_HEIGHT = 600;
        private const int DELAY = 100;

        private readonly Bitmap EARTH_ICON;

        private int orbitTheta;
        private int orbitTDelta;

        ///<summary>
        ///  Constructor. Sets the initial dimensions and starts the animation.
        ///</summary>
        public Orbit() 
        {
            this.BackColor =Color.White;
            this.Size = new Size(INIT_WIDTH,INIT_HEIGHT);
            this.DoubleBuffered = true;
            EARTH_ICON = new Bitmap(@"..\..\..\earth.png");

            orbitTheta = 0;
            // TODO: Generate random theta delta value from -10 to 20.
            orbitTDelta = 10;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = DELAY;
            timer.Tick += new EventHandler(OnTick);
            timer.Start();
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics page = e.Graphics;
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            // Define earth radius and position.
            int earthRadius = Math.Min(width/5, height/5);
            int earthX = width / 2;
            int earthY = height / 2;

            using(Brush pBrush = new SolidBrush(Color.White))
            {
                page.FillRectangle(pBrush, 0,0,width,height);
            }

            // HINT: If you end up with a solid circle of objects surrounding your earth instead of a 
            // single object smoothly circling it, try drawing (below) a filled rectangle to blank the 
            // window each time paintComponent() is called.
            
            // Draw earth
            page.DrawImage(EARTH_ICON,earthX - earthRadius, earthY - earthRadius, 
				    earthRadius * 2, earthRadius * 2);
           
            // TODO: Define orbit radius
		    // HINT: What is the difference between radius and diameter?
            
            // TODO: Draw orbit path
            
            // TODO: Define the radius of your object
		
            // TODO: Calculate x and y using Math.sin and Math.cos.
            // HINT: The Math.sin and Math.cos methods use radians for the parameter units. orbitTheta is in degrees.  
            //       Try using the Math.toRadians() method to convert orbitTheta from degrees to radians. This will 
            //       smooth out the orbit of your object.
            
           
            
            // TODO: Create a random color and draw your object as an oval with that random color.
           
            // Add to theta (for animation)
		    this.orbitTheta = orbitTheta + orbitTDelta;
            
        }

        private void OnTick(object sender, EventArgs e)
        {
            orbitTheta = (orbitTheta + orbitTDelta) % 360;
            this.Invalidate(); // Triggers the Paint event
        }

    }
}