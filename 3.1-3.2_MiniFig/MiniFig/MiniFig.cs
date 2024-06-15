using System.Drawing;
using System.Drawing.Drawing2D;
namespace MiniFig
{
    /**
 * Represents a MiniFig graphical object.
 * <p>
 * <img alt="MiniFig blueprint" src="https://github.com/BoiseState/CS121-Public/blob/master/resources/MiniFig/minifig-blueprint.jpg?raw=true" width="90%">
 * </p>
 * @author Luke Hindman
 */
    public class MiniFig{
        private Graphics canvas;
        private int mid,top;
        private double scaleFactor;
        	/* Color attributes for the MiniFig */
		private Color headColor, eyeColor, torsoColor, beltColor, legColor, footColor, armColor, handColor, handHoleColor, outlineColor;

		/* Attributes for MiniFig Head */
		private int knobWidth, knobHeight, knobCurve;
		private Point knobAnchor;
		private int faceWidth,faceHeight,faceCurve;
		private int eyeSpacing, eyeDiameter, eyeDistFromTopOfFace;
		private int mouthOvalDiameter, mouthDistFromTopOfFace;
		private Point faceAnchor;
		private int neckWidth, neckHeight;
		private Point neckAnchor;
		
		/* Attributes for MiniFig Torso */
		private int torsoShoulderWidth, torsoWaistWidth, torsoHeight;
		private Point rightShoulder, leftShoulder, leftWaist, rightWaist;
		
		/* Attributes for MiniFig Belt */
		private int beltWidth,beltHeight;
		private Point beltAnchor;
		
		/* Attributes for MiniFig Legs */
		private int ankleWidth, legSpacing, legLength;
		private int footWidth, footHeight;
		private int legDividerWidth, legDividerHeight;
		private Point rightHip, rightInseam, rightInnerAnkle, rightOuterAnkle;
		private Point leftHip, leftInseam, leftInnerAnkle, leftOuterAnkle;
		private Point legDividerAnchor;
		
		/* Attributes for MiniFig Arms */
		private int armUpperWidth, armUpperHeight, armCuffWidth;
		private Point rightArmAnchor, rightArmSleeve, rightArmElbow, rightArmCuffOuter, rightArmCuffInner, rightArmPit;
		private Point leftArmAnchor, leftArmSleeve, leftArmElbow, leftArmCuffOuter, leftArmCuffInner, leftArmPit;
		
		/* Attributes for MiniFig Hands */
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
		public MiniFig(Graphics canvas, int midX, int topY):this(canvas,1.0,midX,topY)
		{
		}

		/**
		* @param canvas Graphics canvas on which to draw the MiniFig
		* @param scaleFactor Decimal scaler to resize MiniFig
		* @param midX X component of the MiniFig anchor point, located at the top, center of the MiniFig
		* @param topY Y component of the MiniFig anchor point, located at the top, center of the MiniFig
		*/
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
		/**
		* Constructor for a new MiniFig with a fixed size
		* @param canvas Graphics canvas on which to draw the MiniFig
		* @param anchor The MiniFig anchor point is located at the top, center of the MiniFig
		*/
		public MiniFig(Graphics canvas, Point anchor):this(canvas,anchor.X,anchor.Y)
		{
		}
		/**
		* Constructor for a new MiniFig with a fixed size
		* @param canvas Graphics canvas on which to draw the MiniFig
		* @param scaleFactor Decimal scaler to resize MiniFig
		* @param anchor The MiniFig anchor point is located at the top, center of the MiniFig
		*/
		public MiniFig(Graphics canvas, double scaleFactor, Point anchor):this(canvas,scaleFactor,anchor.X,anchor.Y)
		{
		}

		/**
		* Helper method to set initial component colors
		*/
		private void InitializeColors() {
			/* Define colors for each of the MiniFig components */
			headColor =  Color.FromArgb(255,227,48);
			eyeColor = Color.Black;
			torsoColor = Color.FromArgb(7,60,145);
			beltColor = Color.FromArgb (104,3,33);
			legColor = Color.Black;
			footColor = Color.DarkGray;
			armColor = Color.FromArgb (14, 250, 20);
			handColor = Color.FromArgb(255,227,48);
			handHoleColor = Color.FromArgb(255,255,255,200);
			outlineColor = Color.Black;

		}
		/**
		* Helper method to initialize anchor points and dimensions for head
		*/
		private void InitializeHead(){

			// Calculate scaled knob dimensions
			knobWidth = (int) (40 * scaleFactor);
			knobHeight = (int) (16 * scaleFactor);
			knobCurve = Math.Min(5, (int) (5 * scaleFactor));

			// Define (x,y) coordinates for knob anchor point and store to Point object 
			knobAnchor = new Point(mid-knobWidth / 2, top);

			// Calculate scaled face dimensions
			faceWidth = (int) (84 * scaleFactor);
			faceHeight = (int) (75 * scaleFactor);
			faceCurve = Math.Min(28, (int) (28 * scaleFactor));
			eyeSpacing = (int) (30 * scaleFactor);
			eyeDiameter = (int) (10 * scaleFactor);
			eyeDistFromTopOfFace = (int) (28 * scaleFactor); 
			mouthOvalDiameter = (int) (40 * scaleFactor);
			mouthDistFromTopOfFace = (int) (18 * scaleFactor);
			
			// Define (x,y) coordinates for face anchor point and store to Point object 
			faceAnchor = new Point (mid - faceWidth / 2,top + knobHeight );
			

			// Calculate scaled neck dimensions
			neckWidth = (int) (54 * scaleFactor);
			neckHeight = (int) (10 * scaleFactor);
			
			// Define (x,y) coordinates for neck anchor point and store to Point object 
			neckAnchor = new Point (mid - neckWidth / 2, faceAnchor.Y + faceHeight);
			
		
		}

		/**
		* Helper method to initialize anchor points and dimensions for torso
		*/
		private void InitializeTorso(){
			// Calculate scaled torso dimensions
			torsoShoulderWidth = (int) (90 * scaleFactor);
			torsoWaistWidth = (int) (130 * scaleFactor);
			torsoHeight = (int) (114 * scaleFactor);
			
			// Calculate the Y axis position for shoulders and waist
			int torsoShoulderYOffset = neckAnchor.Y + neckHeight;
			int torsoWaistYOffset = neckAnchor.Y + neckHeight + torsoHeight;
			
			// Use the scaled dimensions to calculate x,y Points for torso
			rightShoulder = new Point(mid - torsoShoulderWidth / 2, torsoShoulderYOffset);
			leftShoulder = new Point(mid + torsoShoulderWidth / 2, torsoShoulderYOffset);
			leftWaist = new Point(mid + torsoWaistWidth / 2, torsoWaistYOffset);
			rightWaist = new Point(mid - torsoWaistWidth / 2, torsoWaistYOffset);
		}

		/**
		* Helper method to initialize anchor points and dimensions for belt
		*/
		private void InitializeBelt(){
			// Calculate scaled belt dimensions
			beltWidth = (int) (120 * scaleFactor);
			beltHeight = (int) (20 * scaleFactor);
			
			// Define (x,y) coordinates for belt anchor point and store to Point object
			beltAnchor = new Point(mid - beltWidth/2, leftWaist.Y);
		}

		/**
		* Helper method to initialize anchor points and dimensions for legs
		*/
		private void InitializeLegs(){
			
			// Calculate scaled leg dimensions
			ankleWidth = (int) (60 * scaleFactor);
			legSpacing = (int) (10 * scaleFactor);
			legLength = (int) (94 * scaleFactor);
			footHeight = (int) (28 * scaleFactor);
			footWidth = ankleWidth;
			legDividerWidth = (int) (12 * scaleFactor);
			legDividerHeight = (int) (54 * scaleFactor);
			
			// Calculate the Y axis positions for upper and lower leg
			int upperLegYOffset = beltAnchor.Y + beltHeight;
			int lowerLegYOffset = upperLegYOffset + legLength;
			
			// Use the scaled dimensions to calculate x,y Points for right leg
			rightHip = new Point(mid - beltWidth/2, upperLegYOffset);
			rightInseam = new Point(mid - (legSpacing / 2), upperLegYOffset);
			rightInnerAnkle = new Point(mid - (legSpacing / 2), lowerLegYOffset);
			rightOuterAnkle = new Point(mid - (legSpacing / 2 + ankleWidth),lowerLegYOffset);
			
			// Use the scaled dimensions to calculate x,y Points for left leg
			leftHip = new Point(mid + beltWidth/2, upperLegYOffset);
			leftInseam = new Point(mid + (legSpacing / 2), upperLegYOffset);
			leftInnerAnkle = new Point(mid + (legSpacing / 2), lowerLegYOffset);
			leftOuterAnkle= new Point(mid + (legSpacing / 2 + ankleWidth),lowerLegYOffset);
			
			// Use the scaled dimensions to calculate anchor point for leg divider
			legDividerAnchor = new Point(mid - legDividerWidth / 2, beltAnchor.Y + beltHeight);
		}
		
		/**
		* Helper method to initialize anchor points and dimensions for arms
		*/
		private void InitializeArms(){

			// Calculate scaled arm dimensions
			armUpperWidth = (int) (31 * scaleFactor);
			armUpperHeight = (int) (20 * scaleFactor); 
			armCuffWidth = (int) (35 * scaleFactor);
			
			// Calculate the Y axis positions for left and right arms
			int armShoulderYOffset = leftShoulder.Y + (int) (8 * scaleFactor);
			int armElbowYOffset = armShoulderYOffset + (int) (58 * scaleFactor);
			int armUpperCuffYOffset = armElbowYOffset + (int) (34 * scaleFactor);
			int armLowerCuffYOffset = armElbowYOffset + (int) (38 * scaleFactor);
			
			// Use the scaled dimensions to calculate x,y Points for right arm
			rightArmAnchor = new Point(mid - (torsoShoulderWidth / 2 + armUpperWidth ), armShoulderYOffset);
			rightArmSleeve = new Point(rightArmAnchor.X - (int) (2 * scaleFactor), rightArmAnchor.Y + armUpperHeight - (int) (2 * scaleFactor));
			rightArmElbow = new Point(rightArmAnchor.X - (int) (18 * scaleFactor), armElbowYOffset);
			rightArmCuffOuter = new Point(rightArmAnchor.X - (int) (24 * scaleFactor), armUpperCuffYOffset);
			rightArmCuffInner = new Point(rightArmCuffOuter.X + armCuffWidth, armLowerCuffYOffset);
			rightArmPit = new Point(rightArmAnchor.X + armUpperWidth , rightArmAnchor.Y);
			
			// Use the scaled dimensions to calculate x,y Points for left arm
			leftArmAnchor = new Point(mid + (torsoShoulderWidth / 2 - armUpperWidth), armShoulderYOffset);
			leftArmSleeve = new Point(leftArmAnchor.X  + armUpperWidth * 2 + (int) (2 * scaleFactor), leftArmAnchor.Y + armUpperHeight - (int) (2 * scaleFactor) );
			leftArmElbow = new Point(leftArmAnchor.X + armUpperWidth*2 + (int) (18 * scaleFactor), armElbowYOffset);
			leftArmCuffOuter = new Point(leftArmAnchor.X + armUpperWidth*2 + (int) (24 * scaleFactor), armUpperCuffYOffset);
			leftArmCuffInner = new Point(leftArmAnchor.X + armUpperWidth + (int) (20 * scaleFactor), armLowerCuffYOffset);
			leftArmPit = new Point(leftArmAnchor.X + armUpperWidth, leftArmAnchor.Y);
		}
		
		/**
		* Helper method to initialize anchor points and dimensions for hands
		*/
		private void InitializeHands(){
			// Calculate width of cuff using Pythagorean Theorem */
			int wristLength = (int)(15*scaleFactor);
			double cuffWidth = Math.Sqrt(Math.Pow(Math.Abs(rightArmCuffOuter.X - rightArmCuffInner.X),2)+
					Math.Pow(Math.Abs(rightArmCuffOuter.Y - rightArmCuffInner.Y),2));
			
			
			// Right Wrist
			double rightCuffSlope = ((double) rightArmCuffOuter.Y - rightArmCuffInner.Y) / (rightArmCuffOuter.X - rightArmCuffInner.X);
			double rightCuffAngle = Math.Atan(rightCuffSlope);

			// Distance from outer cuff edge to outer wrist edge (1/5 cuffWidth)
			double rightWristDist1 = cuffWidth / 5.0;
			// Distance from outer cuff edge to inner wrist edge (4/5 cuffWidth)
			double rightWristDist2 = 4 * cuffWidth / 5.0; 

			// Use trig functions to calculate x,y components of Points required to draw wrist perpendicular to cuff on arm
			rightWristCuffOuter = new Point();
			rightWristCuffOuter.X = (int) (rightArmCuffOuter.X - (rightWristDist1 * (rightArmCuffOuter.X - rightArmCuffInner.X)) / cuffWidth);
			rightWristCuffOuter.Y = (int) (rightArmCuffOuter.Y - (rightWristDist1 * (rightArmCuffOuter.Y - rightArmCuffInner.Y)) / cuffWidth);
			
			rightWristCuffInner = new Point();
			rightWristCuffInner.X = (int) (rightArmCuffOuter.X - (rightWristDist2 * (rightArmCuffOuter.X - rightArmCuffInner.X)) / cuffWidth);
			rightWristCuffInner.Y = (int) (rightArmCuffOuter.Y - (rightWristDist2 * (rightArmCuffOuter.Y - rightArmCuffInner.Y)) / cuffWidth);
			
			rightWristHandOuter = new Point();
			rightWristHandOuter.X = (int)(rightWristCuffOuter.X + wristLength * Math.Cos(rightCuffAngle + Math.PI/2.0));
			rightWristHandOuter.Y = (int)(rightWristCuffOuter.Y + wristLength * Math.Sin(rightCuffAngle + Math.PI/2.0));
			
			rightWristHandInner = new Point();
			rightWristHandInner.X = (int)(rightWristCuffInner.X + wristLength * Math.Cos(rightCuffAngle + Math.PI/2.0));
			rightWristHandInner.Y = (int)(rightWristCuffInner.Y + wristLength * Math.Sin(rightCuffAngle + Math.PI/2.0));
			
			// Left Wrist
			double leftCuffSlope = ((double)leftArmCuffOuter.Y - leftArmCuffInner.Y) / (leftArmCuffOuter.X - leftArmCuffInner.X);
			double leftCuffAngle = Math.Atan(leftCuffSlope);

			/* Distance from outer cuff edge to outer wrist edge (1/5 cuffWidth) */
			double leftWristDist1 = cuffWidth / 5.0;
			/* Distance from outer cuff edge to inner wrist edge (4/5 cuffWidth) */
			double leftWristDist2 = 4 * cuffWidth / 5.0; 
		
			// Use trig functions to calculate x,y components of Points required to draw wrist perpendicular to cuff on arm
			leftWristCuffOuter = new Point();
			leftWristCuffOuter.X = (int) (leftArmCuffOuter.X - (leftWristDist1 * (leftArmCuffOuter.X - leftArmCuffInner.X)) / cuffWidth);
			leftWristCuffOuter.Y = (int) (leftArmCuffOuter.Y - (leftWristDist1 * (leftArmCuffOuter.Y - leftArmCuffInner.Y)) / cuffWidth);
			
			leftWristCuffInner = new Point();
			leftWristCuffInner.X = (int) (leftArmCuffOuter.X - (leftWristDist2 * (leftArmCuffOuter.X - leftArmCuffInner.X)) / cuffWidth);
			leftWristCuffInner.Y = (int) (leftArmCuffOuter.Y - (leftWristDist2 * (leftArmCuffOuter.Y - leftArmCuffInner.Y)) / cuffWidth);
			
			leftWristHandOuter = new Point();
			leftWristHandOuter.X = (int)(leftWristCuffOuter.X + wristLength * Math.Cos(leftCuffAngle + Math.PI / 2.0  )) + 1;
			leftWristHandOuter.Y = (int)(leftWristCuffOuter.Y + wristLength * Math.Sin(leftCuffAngle + Math.PI / 2.0 ));
			
			leftWristHandInner = new Point();
			leftWristHandInner.X = (int)(leftWristCuffInner.X + wristLength * Math.Cos(leftCuffAngle + Math.PI / 2.0 )) + 1;
			leftWristHandInner.Y = (int)(leftWristCuffInner.Y + wristLength * Math.Sin(leftCuffAngle + Math.PI / 2.0 ));
			
			// Calculate scaled hand dimensions and position offsets		
			handDiameter = (int) (45 * scaleFactor);
			handHoleDiameter = (int) (30 * scaleFactor);
			int leftHandXShift = (int) (-30 * scaleFactor);
			int leftHandYShift = (int) (-1 * scaleFactor);
			int rightHandXShift = (int) (-16 * scaleFactor);
			int rightHandYShift = (int) (-1 * scaleFactor);
			
			leftHandAnchor = new Point (leftWristHandOuter.X + leftHandXShift,leftWristHandOuter.Y + leftHandYShift );
			rightHandAnchor = new Point (rightWristHandOuter.X  +rightHandXShift,rightWristHandOuter.Y + rightHandYShift );
			
		}

		/**
		* Draws the MiniFig on the canvas
		*/
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