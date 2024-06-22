namespace MiniFig;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
     protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics canvas = e.Graphics;
            int midX = this.ClientSize.Width / 2;
            int topY = 10; // Arbitrary top margin

            // Create a new MiniFig object and draw it
            MiniFig miniFig = new MiniFig(canvas, midX, topY);
            miniFig.draw();
        }
}
