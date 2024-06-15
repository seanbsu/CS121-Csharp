using System.Drawing;
using System.Drawing.Drawing2D;

namespace MiniFig
{
    /// <summary>
    /// Represents a MiniFig graphical object.
    /// </summary>
    /// <remarks>
    /// <img alt="MiniFig blueprint" src="https://github.com/BoiseState/CS121-Public/blob/master/resources/MiniFig/minifig-blueprint.jpg?raw=true" width="90%">
    /// </remarks>
    /// <author>Luke Hindman</author>
    public class MiniFig
    {
        private Graphics canvas;
        private int mid, top;
        private double scaleFactor;
        private Color headColor, eyeColor, torsoColor, beltColor, legColor, footColor, armColor, handColor, handHoleColor, outlineColor;
        private int knobWidth, knobHeight, knobCurve;
        private Point knobAnchor;
        private int faceWidth, faceHeight, faceCurve;
        private int eyeSpacing, eyeDiameter, eyeDistFromTopOfFace;
        private int mouthOvalDiameter, mouthDistFromTopOfFace;
        private Point faceAnchor;
        private int neckWidth, neckHeight;
        private Point neckAnchor;
        private int torsoShoulderWidth, torsoWaistWidth, torsoHeight;
        private Point rightShoulder, leftShoulder, leftWaist, rightWaist;
        private int beltWidth, beltHeight;
        private Point beltAnchor;
        private int ankleWidth, legSpacing, legLength;
        private int footWidth, footHeight;
        private int legDividerWidth, legDividerHeight;
        private Point rightHip, rightInseam, rightInnerAnkle, rightOuterAnkle;
        private Point leftHip, leftInseam, leftInnerAnkle, leftOuterAnkle;
        private Point legDividerAnchor;
        private int armUpperWidth, armUpperHeight, armCuffWidth;
        private Point rightArmAnchor, rightArmSleeve, rightArmElbow, rightArmCuffOuter, rightArmCuffInner, rightArmPit;
        private Point leftArmAnchor, leftArmSleeve, leftArmElbow, leftArmCuffOuter, leftArmCuffInner, leftArmPit;
        private Point rightWristCuffOuter, rightWristCuffInner, rightWristHandOuter, rightWristHandInner;
        private Point leftWristCuffOuter, leftWristCuffInner, leftWristHandOuter, leftWristHandInner;
        private int handDiameter, handHoleDiameter;
        private Point leftHandAnchor, rightHandAnchor;

        /// <summary>
        /// Constructor for a new MiniFig with a fixed size.
        /// </summary>
        /// <param name="canvas">Graphics canvas on which to draw the MiniFig.</param>
        /// <param name="midX">X component of the MiniFig anchor point, located at the top, center of the MiniFig.</param>
        /// <param name="topY">Y component of the MiniFig anchor point, located at the top, center of the MiniFig.</param>
        public MiniFig(Graphics canvas, int midX, int topY) : this(canvas, 1.0, midX, topY)
        {
        }

        /// <summary>
        /// Constructor for a new MiniFig with a fixed size and scale factor.
        /// </summary>
        /// <param name="canvas">Graphics canvas on which to draw the MiniFig.</param>
        /// <param name="scaleFactor">Decimal scaler to resize MiniFig.</param>
        /// <param name="midX">X component of the MiniFig anchor point, located at the top, center of the MiniFig.</param>
        /// <param name="topY">Y component of the MiniFig anchor point, located at the top, center of the MiniFig.</param>
        public MiniFig(Graphics canvas, double scaleFactor, int midX, int topY)
        {
            this.canvas = canvas;
            this.scaleFactor = scaleFactor;
            this.mid = midX;
            this.top = topY;

            InitializeColors();
            InitializeHead();
            InitializeTorso();
            InitializeBelt();
            InitializeLegs();
            InitializeArms();
            InitializeHands();
        }

        /// <summary>
        /// Constructor for a new MiniFig with a fixed size.
        /// </summary>
        /// <param name="canvas">Graphics canvas on which to draw the MiniFig.</param>
        /// <param name="anchor">The MiniFig anchor point is located at the top, center of the MiniFig.</param>
        public MiniFig(Graphics canvas, Point anchor) : this(canvas, anchor.X, anchor.Y)
        {
        }

        /// <summary>
        /// Constructor for a new MiniFig with a fixed size and scale factor.
        /// </summary>
        /// <param name="canvas">Graphics canvas on which to draw the MiniFig.</param>
        /// <param name="scaleFactor">Decimal scaler to resize MiniFig.</param>
        /// <param name="anchor">The MiniFig anchor point is located at the top, center of the MiniFig.</param>
        public MiniFig(Graphics canvas, double scaleFactor, Point anchor) : this(canvas, scaleFactor, anchor.X, anchor.Y)
        {
        }

        /// <summary>
        /// Helper method to set initial component colors.
        /// </summary>
        private void InitializeColors()
        {
            headColor = Color.FromArgb(255, 227, 48);
            eyeColor = Color.Black;
            torsoColor = Color.FromArgb(7, 60, 145);
            beltColor = Color.FromArgb(104, 3, 33);
            legColor = Color.Black;
            footColor = Color.DarkGray;
            armColor = Color.FromArgb(14, 250, 20);
            handColor = Color.FromArgb(255, 227, 48);
            handHoleColor = Color.FromArgb(255, 255, 255, 200);
            outlineColor = Color.Black;
        }

        /// <summary>
        /// Helper method to initialize anchor points and dimensions for head.
        /// </summary>
        private void InitializeHead()
        {
            knobWidth = (int)(40 * scaleFactor);
            knobHeight = (int)(16 * scaleFactor);
            knobCurve = Math.Min(5, (int)(5 * scaleFactor));
            knobAnchor = new Point(mid - knobWidth / 2, top);
            faceWidth = (int)(84 * scaleFactor);
            faceHeight = (int)(75 * scaleFactor);
            faceCurve = Math.Min(28, (int)(28 * scaleFactor));
            eyeSpacing = (int)(30 * scaleFactor);
            eyeDiameter = (int)(10 * scaleFactor);
            eyeDistFromTopOfFace = (int)(28 * scaleFactor);
            mouthOvalDiameter = (int)(40 * scaleFactor);
            mouthDistFromTopOfFace = (int)(18 * scaleFactor);
            faceAnchor = new Point(mid - faceWidth / 2, top + knobHeight);
            neckWidth = (int)(54 * scaleFactor);
            neckHeight = (int)(10 * scaleFactor);
            neckAnchor = new Point(mid - neckWidth / 2, faceAnchor.Y + faceHeight);
        }

        /// <summary>
        /// Helper method to initialize anchor points and dimensions for torso.
        /// </summary>
        private void InitializeTorso()
        {
            torsoShoulderWidth = (int)(90 * scaleFactor);
            torsoWaistWidth = (int)(130 * scaleFactor);
            torsoHeight = (int)(114 * scaleFactor);
            int torsoShoulderYOffset = neckAnchor.Y + neckHeight;
            int torsoWaistYOffset = neckAnchor.Y + neckHeight + torsoHeight;
            rightShoulder = new Point(mid - torsoShoulderWidth / 2, torsoShoulderYOffset);
            leftShoulder = new Point(mid + torsoShoulderWidth / 2, torsoShoulderYOffset);
            leftWaist = new Point(mid + torsoWaistWidth / 2, torsoWaistYOffset);
            rightWaist = new Point(mid - torsoWaistWidth / 2, torsoWaistYOffset);
        }

        /// <summary>
        /// Helper method to initialize anchor points and dimensions for belt.
        /// </summary>
        private void InitializeBelt()
        {
            beltWidth = (int)(120 * scaleFactor);
            beltHeight = (int)(20 * scaleFactor);
            beltAnchor = new Point(mid - beltWidth / 2, leftWaist.Y);
        }

        /// <summary>
        /// Helper method to initialize anchor points and dimensions for legs.
        /// </summary>
        private void InitializeLegs()
        {
            ankleWidth = (int)(60 * scaleFactor);
            legSpacing = (int)(10 * scaleFactor);
            legLength = (int)(94 * scaleFactor);
            footHeight = (int)(28 * scaleFactor);
            footWidth = ankleWidth;
            legDividerWidth = (int)(12 * scaleFactor);
            legDividerHeight = (int)(54 * scaleFactor);
            int upperLegYOffset = beltAnchor.Y + beltHeight;
            int lowerLegYOffset = upperLegYOffset + legLength;
            rightHip = new Point(mid - beltWidth / 2, upperLegYOffset);
            rightInseam = new Point(mid - (legSpacing / 2), upperLegYOffset);
            rightInnerAnkle = new Point(mid - (legSpacing / 2), lowerLegYOffset);
            rightOuterAnkle = new Point(mid - (legSpacing / 2 + ankleWidth), lowerLegYOffset);
            leftHip = new Point(mid + beltWidth / 2, upperLegYOffset);
            leftInseam = new Point(mid + (legSpacing / 2), upperLegYOffset);
            leftInnerAnkle = new Point(mid + (legSpacing / 2), lowerLegYOffset);
            leftOuterAnkle = new Point(mid + (legSpacing / 2 + ankleWidth), lowerLegYOffset);
            legDividerAnchor = new Point(mid - legDividerWidth / 2, beltAnchor.Y + beltHeight);
        }

        /// <summary>
        /// Helper method to initialize anchor points and dimensions for arms.
        /// </summary>
        private void InitializeArms()
        {
            armUpperWidth = (int)(30 * scaleFactor);
            armUpperHeight = (int)(76 * scaleFactor);
            armCuffWidth = (int)(16 * scaleFactor);
            rightArmAnchor = rightShoulder;
            rightArmSleeve = new Point(rightArmAnchor.X - armUpperWidth, rightArmAnchor.Y);
            rightArmElbow = new Point(rightArmSleeve.X, rightArmSleeve.Y + armUpperHeight);
            rightArmCuffOuter = new Point(rightArmElbow.X + armCuffWidth, rightArmElbow.Y);
            rightArmCuffInner = new Point(rightArmCuffOuter.X, rightArmCuffOuter.Y + armCuffWidth);
            rightArmPit = new Point(rightArmAnchor.X, rightArmAnchor.Y + armCuffWidth);
            leftArmAnchor = leftShoulder;
            leftArmSleeve = new Point(leftArmAnchor.X + armUpperWidth, leftArmAnchor.Y);
            leftArmElbow = new Point(leftArmSleeve.X, leftArmSleeve.Y + armUpperHeight);
            leftArmCuffOuter = new Point(leftArmElbow.X - armCuffWidth, leftArmElbow.Y);
            leftArmCuffInner = new Point(leftArmCuffOuter.X, leftArmCuffOuter.Y + armCuffWidth);
            leftArmPit = new Point(leftArmAnchor.X, leftArmAnchor.Y + armCuffWidth);
            rightWristCuffOuter = new Point(rightArmCuffOuter.X - armCuffWidth, rightArmCuffOuter.Y);
            rightWristCuffInner = new Point(rightWristCuffOuter.X, rightWristCuffOuter.Y + armCuffWidth);
            rightWristHandOuter = new Point(rightWristCuffInner.X - armCuffWidth, rightWristCuffInner.Y);
            rightWristHandInner = new Point(rightWristHandOuter.X, rightWristHandOuter.Y + armCuffWidth);
            leftWristCuffOuter = new Point(leftArmCuffOuter.X + armCuffWidth, leftArmCuffOuter.Y);
            leftWristCuffInner = new Point(leftWristCuffOuter.X, leftWristCuffOuter.Y + armCuffWidth);
            leftWristHandOuter = new Point(leftWristCuffInner.X + armCuffWidth, leftWristCuffInner.Y);
            leftWristHandInner = new Point(leftWristHandOuter.X, leftWristHandOuter.Y + armCuffWidth);
        }

        /// <summary>
        /// Helper method to initialize anchor points and dimensions for hands.
        /// </summary>
        private void InitializeHands()
        {
            handDiameter = (int)(24 * scaleFactor);
            handHoleDiameter = (int)(8 * scaleFactor);
            leftHandAnchor = new Point(leftWristHandOuter.X - handDiameter / 2, leftWristHandOuter.Y + handDiameter / 2);
            rightHandAnchor = new Point(rightWristHandOuter.X - handDiameter / 2, rightWristHandOuter.Y + handDiameter / 2);
        }

        /// <summary>
        /// Draw the MiniFig on the canvas.
        /// </summary>
		public void draw(){
			/* 
			* Component: Head
			*/
			// Draw the knob component on the canvas
			int knobHeightPadded = knobHeight + 2; // extend knob below head to hide curved border
			using (Brush headBrush = new SolidBrush(headColor))
			{
				FillRoundedRectangle(canvas, headBrush, knobAnchor.X, knobAnchor.Y, knobWidth, knobHeightPadded, knobCurve);
			}
			
		}

		/**
		* Helper method for port from java. Fills a Rounded rectangle
		*/
		private void FillRoundedRectangle(Graphics g, Brush brush, int x, int y, int width, int height, int radius)
		{
			GraphicsPath path = new GraphicsPath();
			path.AddArc(x, y, radius, radius, 180, 90);
			path.AddArc(x + width - radius, y, radius, radius, 270, 90);
			path.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);
			path.AddArc(x, y + height - radius, radius, radius, 90, 90);
			path.CloseFigure();

			g.FillPath(brush, path);
		}

		/**
		* Helper method for port from java. Draws a Rounded rectangle
		*/
		private void DrawRoundedRectangle(Graphics g, Pen pen, int x, int y, int width, int height, int radius)
		{
			GraphicsPath path = new GraphicsPath();
			path.AddArc(x, y, radius, radius, 180, 90);
			path.AddArc(x + width - radius, y, radius, radius, 270, 90);
			path.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);
			path.AddArc(x, y + height - radius, radius, radius, 90, 90);
			path.CloseFigure();

			g.DrawPath(pen, path);
		}

    }
}