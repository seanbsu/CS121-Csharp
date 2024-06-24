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

    
}