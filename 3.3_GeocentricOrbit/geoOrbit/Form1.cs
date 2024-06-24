namespace geoOrbit;

public partial class Form1 : Form
{
    public Form1()
    {
        // InitializeComponent();
        this.Height = 700;
        this.Width = 700;
        Orbit geoCentricOrbit = new Orbit();
        this.Controls.Add(geoCentricOrbit);
    }
}
