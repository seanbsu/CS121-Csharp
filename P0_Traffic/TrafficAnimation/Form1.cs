namespace TrafficAnimation;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        TrafficAnimation animation = new TrafficAnimation();
        this.Controls.Add(animation);
    }
}
