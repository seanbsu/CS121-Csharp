namespace bouncyBall;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        BouncyBall bBall = new BouncyBall();
        this.Controls.Add(bBall);
    }
}
