using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ComputeCollisionCylinderPoint
{
    public partial class frmMain : Form
    {
        private readonly Font font = new Font("arial", 8.0f, FontStyle.Regular);
        private readonly Brush fontBrush = new SolidBrush(Color.Black);
        private readonly Pen linePen = new Pen(Color.FromArgb(192, 192, 192));

        private Bitmap renderBitmap;
        private Graphics renderGraphics;
        private Point[] points = new Point[] { new Point(50, 150), new Point(150, 100), new Point(400, 175) };
        private int currentPointIndex = -1;

        public frmMain()
		{
			InitializeComponent();

			picRender.MouseDown += OnRenderMouseEvent;
			picRender.MouseMove += OnRenderMouseEvent;
		}

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Modifiers != 0)
                return;

            if (e.KeyData == Keys.NumPad1 || e.KeyData == Keys.D1 || e.KeyData == Keys.A)
                currentPointIndex = 0;
            else if (e.KeyData == Keys.NumPad2 || e.KeyData == Keys.D2 || e.KeyData == Keys.K)
                currentPointIndex = 1;
            else if (e.KeyData == Keys.NumPad3 || e.KeyData == Keys.D3 || e.KeyData == Keys.B)
                currentPointIndex = 2;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            currentPointIndex = -1;
        }

        private void OnRenderMouseEvent(object sender, MouseEventArgs e)
		{
            if (e.Button != MouseButtons.Left || currentPointIndex < 0)
                return;

			points[currentPointIndex] = new Point(e.X, e.Y);

			Render();
		}

        private void Render()
		{
			if (renderGraphics == null)
				return;

			renderGraphics.Clear(Color.White);

			renderGraphics.DrawLine(linePen, points[0], points[1]);
			renderGraphics.DrawLine(linePen, points[1], points[2]);
			renderGraphics.DrawLine(linePen, points[2], points[0]);

			ComputeAndDraw(fontBrush, font);

            DrawPoint(points[0], "A");
            DrawPoint(points[1], "K");
            DrawPoint(points[2], "B");

			picRender.Image = renderBitmap;
		}

		private void ComputeAndDraw(Brush fontBrush, Font font)
		{
			PointF o = points[0];
			PointF a = points[1];
			PointF b = points[2];

			PointF vecOA = new PointF(a.X - o.X, a.Y - o.Y);
			PointF vecOB = new PointF(b.X - o.X, b.Y - o.Y);

			PointF vecOANorm = Normalize(vecOA);
			PointF vecOBNorm = Normalize(vecOB);

			float cosTheta = DotProduct(vecOANorm, vecOBNorm);
            float len = Length(vecOA) * cosTheta;

			PointF newPos = new PointF(o.X + (vecOBNorm.X * len), o.Y + (vecOBNorm.Y * len));

            DrawPoint(newPos, "n");

			if (cosTheta > 0.0f)
				renderGraphics.DrawLine(new Pen(Color.Blue), a, newPos);
			else
				renderGraphics.DrawLine(new Pen(Color.Red), a, newPos);
		}

        private void DrawPoint(PointF point, string name)
        {
            renderGraphics.DrawLine(new Pen(Color.Black), point.X - 3, point.Y, point.X + 3, point.Y);
            renderGraphics.DrawLine(new Pen(Color.Black), point.X, point.Y - 3, point.X, point.Y + 3);
            renderGraphics.DrawString(name, font, fontBrush, point.X + 3, point.Y + 3);
        }

        private float Length(PointF p)
		{
			return ((float)Math.Sqrt(p.X * p.X + p.Y * p.Y));
		}

		private PointF Normalize(PointF p)
		{
			float len = Length(p);
			return (new PointF(p.X / len, p.Y / len));
		}

		private float DotProduct(PointF p1, PointF p2)
		{
			return (p1.X * p2.X + p1.Y * p2.Y);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			if (renderBitmap != null)
				renderBitmap.Dispose();

			if (renderGraphics != null)
				renderGraphics.Dispose();

			renderBitmap = new Bitmap(picRender.Width, picRender.Height);
			renderGraphics = Graphics.FromImage(renderBitmap);
			renderGraphics.SmoothingMode = SmoothingMode.AntiAlias;

			Render();
		}
	}
}
