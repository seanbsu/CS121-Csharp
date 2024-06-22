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
        armUpperWidth = (int)(31 * scaleFactor);
        armUpperHeight = (int)(20 * scaleFactor);
        armCuffWidth = (int)(35 * scaleFactor);
        
        int armShoulderYOffset = rightShoulder.Y + (int)(8 * scaleFactor);
        int armElbowYOffset = armShoulderYOffset + (int)(58 * scaleFactor);
        int armUpperCuffYOffset = armElbowYOffset + (int)(34 * scaleFactor);
        int armLowerCuffYOffset = armElbowYOffset + (int)(38 * scaleFactor);
        
        rightArmAnchor = new Point(mid - (torsoShoulderWidth / 2 + armUpperWidth), armShoulderYOffset);
        rightArmSleeve = new Point(rightArmAnchor.X - (int)(2 * scaleFactor), rightArmAnchor.Y + armUpperHeight - (int)(2 * scaleFactor));
        rightArmElbow = new Point(rightArmAnchor.X - (int)(18 * scaleFactor), armElbowYOffset);
        rightArmCuffOuter = new Point(rightArmAnchor.X - (int)(24 * scaleFactor), armUpperCuffYOffset);
        rightArmCuffInner = new Point(rightArmCuffOuter.X + armCuffWidth, armLowerCuffYOffset);
        rightArmPit = new Point(rightArmAnchor.X + armUpperWidth, rightArmAnchor.Y);
        
        leftArmAnchor = new Point(mid + (torsoShoulderWidth / 2 - armUpperWidth), armShoulderYOffset);
        leftArmSleeve = new Point(leftArmAnchor.X + armUpperWidth * 2 + (int)(2 * scaleFactor), leftArmAnchor.Y + armUpperHeight - (int)(2 * scaleFactor));
        leftArmElbow = new Point(leftArmAnchor.X + armUpperWidth * 2 + (int)(18 * scaleFactor), armElbowYOffset);
        leftArmCuffOuter = new Point(leftArmAnchor.X + armUpperWidth * 2 + (int)(24 * scaleFactor), armUpperCuffYOffset);
        leftArmCuffInner = new Point(leftArmAnchor.X + armUpperWidth + (int)(20 * scaleFactor), armLowerCuffYOffset);
        leftArmPit = new Point(leftArmAnchor.X + armUpperWidth, leftArmAnchor.Y);
    }


        /// <summary>
        /// Helper method to initialize anchor points and dimensions for hands.
        /// </summary>
        private void InitializeHands()
        {
            int wristLength = (int)(15 * scaleFactor);
            
            // Calculate width of cuff using Pythagorean Theorem
            double cuffWidth = Math.Sqrt(Math.Pow(Math.Abs(rightArmCuffOuter.X - rightArmCuffInner.X), 2) +
                                        Math.Pow(Math.Abs(rightArmCuffOuter.Y - rightArmCuffInner.Y), 2));

            // Right Wrist
            double rightCuffSlope = ((double)rightArmCuffOuter.Y - rightArmCuffInner.Y) / (rightArmCuffOuter.X - rightArmCuffInner.X);
            double rightCuffAngle = Math.Atan(rightCuffSlope);

            // Distance from outer cuff edge to outer wrist edge (1/5 cuffWidth)
            double rightWristDist1 = cuffWidth / 5.0;
            // Distance from outer cuff edge to inner wrist edge (4/5 cuffWidth)
            double rightWristDist2 = 4 * cuffWidth / 5.0;

            // Use trig functions to calculate x,y components of Points required to draw wrist perpendicular to cuff on arm
            rightWristCuffOuter = new Point(
                (int)(rightArmCuffOuter.X - (rightWristDist1 * (rightArmCuffOuter.X - rightArmCuffInner.X)) / cuffWidth),
                (int)(rightArmCuffOuter.Y - (rightWristDist1 * (rightArmCuffOuter.Y - rightArmCuffInner.Y)) / cuffWidth)
            );

            rightWristCuffInner = new Point(
                (int)(rightArmCuffOuter.X - (rightWristDist2 * (rightArmCuffOuter.X - rightArmCuffInner.X)) / cuffWidth),
                (int)(rightArmCuffOuter.Y - (rightWristDist2 * (rightArmCuffOuter.Y - rightArmCuffInner.Y)) / cuffWidth)
            );

            rightWristHandOuter = new Point(
                (int)(rightWristCuffOuter.X + wristLength * Math.Cos(rightCuffAngle + Math.PI / 2.0)),
                (int)(rightWristCuffOuter.Y + wristLength * Math.Sin(rightCuffAngle + Math.PI / 2.0))
            );

            rightWristHandInner = new Point(
                (int)(rightWristCuffInner.X + wristLength * Math.Cos(rightCuffAngle + Math.PI / 2.0)),
                (int)(rightWristCuffInner.Y + wristLength * Math.Sin(rightCuffAngle + Math.PI / 2.0))
            );

            // Left Wrist
            double leftCuffSlope = ((double)leftArmCuffOuter.Y - leftArmCuffInner.Y) / (leftArmCuffOuter.X - leftArmCuffInner.X);
            double leftCuffAngle = Math.Atan(leftCuffSlope);

            // Distance from outer cuff edge to outer wrist edge (1/5 cuffWidth)
            double leftWristDist1 = cuffWidth / 5.0;
            // Distance from outer cuff edge to inner wrist edge (4/5 cuffWidth)
            double leftWristDist2 = 4 * cuffWidth / 5.0;

            // Use trig functions to calculate x,y components of Points required to draw wrist perpendicular to cuff on arm
            leftWristCuffOuter = new Point(
                (int)(leftArmCuffOuter.X - (leftWristDist1 * (leftArmCuffOuter.X - leftArmCuffInner.X)) / cuffWidth),
                (int)(leftArmCuffOuter.Y - (leftWristDist1 * (leftArmCuffOuter.Y - leftArmCuffInner.Y)) / cuffWidth)
            );

            leftWristCuffInner = new Point(
                (int)(leftArmCuffOuter.X - (leftWristDist2 * (leftArmCuffOuter.X - leftArmCuffInner.X)) / cuffWidth),
                (int)(leftArmCuffOuter.Y - (leftWristDist2 * (leftArmCuffOuter.Y - leftArmCuffInner.Y)) / cuffWidth)
            );

            leftWristHandOuter = new Point(
                (int)(leftWristCuffOuter.X + wristLength * Math.Cos(leftCuffAngle + Math.PI / 2.0)) + 1,
                (int)(leftWristCuffOuter.Y + wristLength * Math.Sin(leftCuffAngle + Math.PI / 2.0))
            );

            leftWristHandInner = new Point(
                (int)(leftWristCuffInner.X + wristLength * Math.Cos(leftCuffAngle + Math.PI / 2.0)) + 1,
                (int)(leftWristCuffInner.Y + wristLength * Math.Sin(leftCuffAngle + Math.PI / 2.0))
            );

            // Calculate scaled hand dimensions and position offsets
            handDiameter = (int)(45 * scaleFactor);
            handHoleDiameter = (int)(30 * scaleFactor);
            int leftHandXShift = (int)(-30 * scaleFactor);
            int leftHandYShift = (int)(-1 * scaleFactor);
            int rightHandXShift = (int)(-16 * scaleFactor);
            int rightHandYShift = (int)(-1 * scaleFactor);

            leftHandAnchor = new Point(leftWristHandOuter.X + leftHandXShift, leftWristHandOuter.Y + leftHandYShift);
            rightHandAnchor = new Point(rightWristHandOuter.X + rightHandXShift, rightWristHandOuter.Y + rightHandYShift);
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
			using (Pen outlinePen = new Pen(outlineColor))
			{
				DrawRoundedRectangle(canvas, outlinePen, knobAnchor.X, knobAnchor.Y, knobWidth, knobHeightPadded, knobCurve);
			}
			// Calculate eye positions based upon scaled dimensions and anchor point
			int leftEyeXOffset = mid - (eyeSpacing / 2 + eyeDiameter / 2);
			int rightEyeXOffset = mid + (eyeSpacing / 2 - eyeDiameter / 2);
			int eyeYOffset = faceAnchor.Y + eyeDistFromTopOfFace;
			int mouthXOffset = mid - mouthOvalDiameter / 2;
			int mouthYOffset = faceAnchor.Y + mouthDistFromTopOfFace;

			// Draw the face components on the canvas
			using (Brush faceBrush = new SolidBrush(headColor))
			{
				FillRoundedRectangle(canvas,faceBrush,faceAnchor.X,faceAnchor.Y,faceWidth,faceHeight,faceCurve);
			}
			using (Pen outlinePen = new Pen(outlineColor))
			{
				DrawRoundedRectangle(canvas, outlinePen,faceAnchor.X,faceAnchor.Y,faceWidth,faceHeight,faceCurve);
			}
			using (Brush eyeBrush = new SolidBrush(eyeColor))
			{
				canvas.FillEllipse(eyeBrush, leftEyeXOffset, eyeYOffset, eyeDiameter, eyeDiameter); // left eye
            	canvas.FillEllipse(eyeBrush, rightEyeXOffset, eyeYOffset, eyeDiameter, eyeDiameter); // right eye
			}
			using (Pen outlinePen = new Pen(outlineColor))
			{
				canvas.DrawArc(outlinePen, mouthXOffset, mouthYOffset, mouthOvalDiameter, mouthOvalDiameter, 45, 90); // mouth
			}

			// Draw the neck component on the canvas
			using (Brush neckBrush = new SolidBrush(headColor))
			{
				canvas.FillRectangle(neckBrush, neckAnchor.X, neckAnchor.Y, neckWidth, neckHeight);
			}
			using (Pen outlinePen = new Pen(outlineColor))
			{
				canvas.DrawRectangle(outlinePen, neckAnchor.X, neckAnchor.Y, neckWidth, neckHeight);
			}

			/*
			* Component: Belt
			*/
			// Draw the belt component on the canvas
			using (Brush beltBrush = new SolidBrush(beltColor))
			{
				canvas.FillRectangle(beltBrush, beltAnchor.X, beltAnchor.Y, beltWidth, beltHeight);
			}
			using (Pen outlinePen = new Pen(outlineColor))
			{
				canvas.DrawRectangle(outlinePen, beltAnchor.X, beltAnchor.Y, beltWidth, beltHeight);
			}

			/* 
			* Component: Legs
			*/
			// Draw the right leg components on the canvas
			Point[] rightLegPoints = { rightHip, rightInseam, rightInnerAnkle, rightOuterAnkle };
			using (Brush legBrush = new SolidBrush(legColor))
			{
				canvas.FillPolygon(legBrush, rightLegPoints);
			}
			using (Pen outlinePen = new Pen(outlineColor))
			{
				canvas.DrawPolygon(outlinePen, rightLegPoints);
			}
			using (Brush footBrush = new SolidBrush(footColor))
			{
				canvas.FillRectangle(footBrush, rightOuterAnkle.X, rightOuterAnkle.Y, footWidth, footHeight);
			}
			using (Pen outlinePen = new Pen(outlineColor))
			{
				canvas.DrawRectangle(outlinePen, rightOuterAnkle.X, rightOuterAnkle.Y, footWidth, footHeight);
			}

			// Draw the left leg components on the canvas
			Point[] leftLegPoints = { leftHip, leftInseam, leftInnerAnkle, leftOuterAnkle };
			using (Brush legBrush = new SolidBrush(legColor))
			{
				canvas.FillPolygon(legBrush, leftLegPoints);
			}
			using (Pen outlinePen = new Pen(outlineColor))
			{
				canvas.DrawPolygon(outlinePen, leftLegPoints);
			}
			using (Brush footBrush = new SolidBrush(footColor))
			{
				canvas.FillRectangle(footBrush, leftInnerAnkle.X, leftInnerAnkle.Y, footWidth, footHeight);
			}
			using (Pen outlinePen = new Pen(outlineColor))
			{
				canvas.DrawRectangle(outlinePen, leftInnerAnkle.X, leftInnerAnkle.Y, footWidth, footHeight);
			}

			// Draw the leg divider components on the canvas
			using (Brush footBrush = new SolidBrush(footColor))
			{
				canvas.FillRectangle(footBrush, legDividerAnchor.X, legDividerAnchor.Y, legDividerWidth, legDividerHeight);
			}
			using (Pen outlinePen = new Pen(outlineColor))
			{
				canvas.DrawRectangle(outlinePen, legDividerAnchor.X, legDividerAnchor.Y, legDividerWidth, legDividerHeight);
			}

        /* 
		 * Component: Arms
		 */
		// Create a new Polygon object for the right arm using the above Points
        Point[] rightArmPoints = {
            rightArmSleeve,
            rightArmElbow,
            rightArmCuffOuter,
            rightArmCuffInner,
            rightArmPit
        };

        // Draw the right arm components on the canvas
        using (Brush armBrush = new SolidBrush(armColor))
        {
            canvas.FillPolygon(armBrush, rightArmPoints);
        }
        
        using (Pen outlinePen = new Pen(outlineColor))
        {
            canvas.DrawPolygon(outlinePen, rightArmPoints);
        }
        
        using (Brush armBrush = new SolidBrush(armColor))
        {
            canvas.FillPie(armBrush, rightArmAnchor.X-2, rightArmAnchor.Y+2, armUpperWidth * 2, armUpperHeight * 2, -90, -90);
        }
        
        using (Pen outlinePen = new Pen(outlineColor))
        {
            canvas.DrawArc(outlinePen, rightArmAnchor.X-2, rightArmAnchor.Y+2, armUpperWidth * 2, armUpperHeight * 2, -90, -85);
        }
    
    // Create a new Polygon object for the left arm using the above Points
        Point[] leftArmPoints = {
            leftArmSleeve,
            leftArmElbow,
            leftArmCuffOuter,
            leftArmCuffInner,
            leftArmPit
        };

        // Draw the left arm components on the canvas
        using (Brush armBrush = new SolidBrush(armColor))
        {
            canvas.FillPolygon(armBrush, leftArmPoints);
        }
        
        using (Pen outlinePen = new Pen(outlineColor))
        {
            canvas.DrawPolygon(outlinePen, leftArmPoints);
        }
        
        using (Brush armBrush = new SolidBrush(armColor))
        {
            canvas.FillPie(armBrush, leftArmAnchor.X+5, leftArmAnchor.Y, armUpperWidth * 2, armUpperHeight * 2, -90, 90);
        }
        
        using (Pen outlinePen = new Pen(outlineColor))
        {
            canvas.DrawArc(outlinePen, leftArmAnchor.X+2, leftArmAnchor.Y, armUpperWidth * 2, armUpperHeight * 2, -90, 85);
        }

        /* 
		 * Component: Torso 
		 */
		// Create a new Polygon object for the torso using the above Points
        Point[] torsoPoints = { 
            rightShoulder,
            leftShoulder,
            leftWaist,
            rightWaist
            };
        using(Brush torsoBrush = new SolidBrush(torsoColor))
        {
            canvas.FillPolygon(torsoBrush,torsoPoints);
        }
        using( Pen outlinePen = new Pen(outlineColor))
        {
            canvas.DrawPolygon(outlinePen,torsoPoints);
        }
        /* 
		 * Components: Wrists
		 */
         Point[] rightWristPoints = { 
            rightWristCuffOuter,
            rightWristCuffInner,
            rightWristHandInner,
            rightWristHandOuter
            };
        using(Brush wristBrush = new SolidBrush(handColor))
        {
            canvas.FillPolygon(wristBrush,rightWristPoints);
        }
        using(Pen outlinePen = new Pen(outlineColor))
        {
            canvas.DrawPolygon(outlinePen,rightWristPoints);
        }
        Point[] leftWristPoints = { 
            leftWristCuffOuter,
            leftWristCuffInner,
            leftWristHandInner,
            leftWristHandOuter
            };
        using(Brush wristBrush = new SolidBrush(handColor))
        {
            canvas.FillPolygon(wristBrush,leftWristPoints);
        }
        using(Pen outlinePen = new Pen(outlineColor))
        {
            canvas.DrawPolygon(outlinePen,leftWristPoints);
        }

        /* 
		 * Component:  Hands
		 */
         //left hand
        var state = canvas.Save();

        // Translate to the hand's anchor point
        canvas.TranslateTransform(leftHandAnchor.X + handDiameter / 2, leftHandAnchor.Y + handDiameter / 2);

        // Rotate the canvas by 170 degrees to have hand face down instead of up
        canvas.RotateTransform(170);

        // Translate back
        canvas.TranslateTransform(-(leftHandAnchor.X + handDiameter / 2), -(leftHandAnchor.Y + handDiameter / 2));

       
        using (Brush handBrush = new SolidBrush(handColor))
        {
            canvas.FillPie(handBrush, leftHandAnchor.X, leftHandAnchor.Y, handDiameter, handDiameter, -45, 290);
        }

        using (Brush handHoleBrush = new SolidBrush(handHoleColor))
        {
            int handHoleX = leftHandAnchor.X + (handDiameter - handHoleDiameter) / 2;
            int handHoleY = leftHandAnchor.Y + (handDiameter - handHoleDiameter) / 2;
            canvas.FillEllipse(handHoleBrush, handHoleX, handHoleY, handHoleDiameter, handHoleDiameter);
        }

        using (Pen outlinePen = new Pen(outlineColor))
        {
            canvas.DrawArc(outlinePen, leftHandAnchor.X, leftHandAnchor.Y, handDiameter, handDiameter, -45, 290);
            int handHoleX = leftHandAnchor.X + (handDiameter - handHoleDiameter) / 2;
            int handHoleY = leftHandAnchor.Y + (handDiameter - handHoleDiameter) / 2;
            canvas.DrawArc(outlinePen, handHoleX, handHoleY, handHoleDiameter, handHoleDiameter, -45, 290);
        }
        // Restore the state of the canvas
        canvas.Restore(state);

        //right hand
        state = canvas.Save();

        // Translate to the hand's anchor point
        canvas.TranslateTransform(rightHandAnchor.X + handDiameter / 2, rightHandAnchor.Y + handDiameter / 2);

        // Rotate the canvas by 185 degrees to have hand face down instead of up and account for righthand side of the canvas
        canvas.RotateTransform(185);

        // Translate back
        canvas.TranslateTransform(-(rightHandAnchor.X + handDiameter / 2), -(rightHandAnchor.Y + handDiameter / 2));
        using (Brush handBrush = new SolidBrush(handColor))
        {
            canvas.FillPie(handBrush, rightHandAnchor.X, rightHandAnchor.Y, handDiameter, handDiameter, -60, 290);
        }

        using (Brush handHoleBrush = new SolidBrush(handHoleColor))
        {
            int handHoleX = rightHandAnchor.X + (handDiameter - handHoleDiameter) / 2;
            int handHoleY = rightHandAnchor.Y + (handDiameter - handHoleDiameter) / 2;
            canvas.FillEllipse(handHoleBrush, handHoleX, handHoleY, handHoleDiameter, handHoleDiameter);
        }

        using (Pen outlinePen = new Pen(outlineColor))
        {
            canvas.DrawArc(outlinePen, rightHandAnchor.X, rightHandAnchor.Y, handDiameter, handDiameter, -60, 290);
            int handHoleX = rightHandAnchor.X + (handDiameter - handHoleDiameter) / 2;
            int handHoleY = rightHandAnchor.Y + (handDiameter - handHoleDiameter) / 2;
            canvas.DrawArc(outlinePen, handHoleX, handHoleY, handHoleDiameter, handHoleDiameter, -60, 290);
        }

        // Restore the state of the canvas
        canvas.Restore(state);
         

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