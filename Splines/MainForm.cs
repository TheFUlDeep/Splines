using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Tutorial.Curves
{
	/// <summary> ������� ����� ����������. </summary>
	public partial class MainForm : Form
	{
		// ����������� ����� ��� ��������� ������
		private Point [] points = null;
		private int pointsCount = 8;
		private Point[] connectPoints = new Point[2];
		private int delete_points = 0;
		
		// ����� ���������� �����
		private int selectIndex = 0;
		private Random rnd = null;
		
		private void GeneratePoints()
        {
			points = new Point[pointsCount];
			for (uint i = 0; i < pointsCount; i++)
			{
				points[i].X = rnd.Next(100, 600);
				points[i].Y = rnd.Next(100, 600);
			}
		}

		/// <summary> ������� ������� ���� ����������. </summary> 
		public MainForm()
		{
			InitializeComponent();
			rnd = new Random();
			// ������������� ����������� ����� �� ���������
			points = new Point [] {new Point(100, 250), new Point(200, 150),
				                   new Point(300, 350), new Point(400, 250)};
			toolStripTextBox1.Text = pointsCount.ToString();
		}
		
		/// <summary> ������ ���������� ������. </summary> 
		private void DrawSpline(Graphics graphics)
		{
			delete_points = 0;
			// ������������� ����������� �����
			graphics.SmoothingMode = SmoothingMode.HighQuality;
		    
			// ������� �������� ��� ��������� ������
		    using (Pen pen = new Pen(Color.Blue, 2))
		    {
		    	// ������ ���������� ������ ���������� GDI+
		    	graphics.DrawCurve(pen, points);
		    }
		}
		
		/// <summary> ������ ������ �����. </summary> 
		private void DrawBezier(Graphics graphics)
		{
			if (pointsCount % 4 != 0)
				return;
			// ������������� ����������� �����
		    graphics.SmoothingMode = SmoothingMode.HighQuality;
		    
		    // ������� �������� ��� ��������� ����������� ��������
		    using (Pen pen = new Pen(Color.Gray, 1))
		    {
				// ������ ����������� ������� ������ �����
				for (int i = 0; i < pointsCount - 1; i++)
				{
					if (points.Length - i < delete_points + 1)
						continue;
					graphics.DrawLine(pen, points[i], points[i + 1]);
				}
		    }
		    		  
		    // ������� �������� ��� ��������� ������
		    using (Pen pen = new Pen(Color.Blue, 2))
		    {
				delete_points = 0;
				// ������ ������ ����� ���������� GDI+
				for (int i = 0; i < pointsCount - 4; i += 3)
				{
					delete_points++;
					//graphics.DrawCurve()
					if (i - 1 > 0)
                    {
						var diffX = points[i].X - points[i - 1].X;
						var diffY = points[i].Y - points[i - 1].Y;
						points[i + 1].X = points[i].X + diffX;
						points[i + 1].Y = points[i].Y + diffY;

					}
					graphics.DrawBezier(pen, points[i], points[i + 1], points[i + 2], points[i + 3]);
				}
		    }
		}




		private void DrawHermite(Graphics graphics)
		{
			//if (pointsCount % 2 == 0)
				//return;
			delete_points = 0;
			// ������������� ����������� �����
			graphics.SmoothingMode = SmoothingMode.HighQuality;

			var pts = new Point[pointsCount];
			for (int i = 0; i < pointsCount; i++)
				pts[i] = points[i];

			// ������� �������� ��� ��������� ������
			using (Pen pen = new Pen(Color.Blue, 2))
			{
				// ������ ���������� ������ ���������� GDI+
				for (int i = 0; i < pointsCount - 1; i++)
				{
					if((i-1)%2 == 0)
                    {
						pts[i].X = (points[i - 1].X + points[i + 1].X) / 2;
						pts[i].Y = (points[i - 1].Y + points[i + 1].Y) / 2;

						pts[i].X = (points[i].X + pts[i].X) / 2;
						pts[i].Y = (points[i].Y + pts[i].Y) / 2;
					}
				}
				graphics.DrawCurve(pen, pts);
				//graphics.DrawCurve(pen, points, 1f);
			}
			using (Pen pen = new Pen(Color.Gray, 1))
			{
				// ������ ����������� ������� ������ �����
				for (int i = 0; i < pointsCount - 1; i++)
				{
					if (points.Length - i < delete_points + 1)
						continue;
					graphics.DrawLine(pen, points[i], points[i + 1]);
				}
			}
		}

		/// <summary> ������ ����������� �����. </summary> 
		private void DrawPoints(Graphics graphics)
		{
			// ������ ������� ����������� �����
			int size = 5;
			
		    for (int i = 0; i < points.Length; i++)
		    {
				if (points.Length - i < delete_points)
					continue;
		    	// ���� ����������� ����� ��������...
		    	if (selectIndex == i)
		    	{
		    		// ...������ �� ������� ����������
				    using (Pen pen = new Pen(Color.Red, 3))
				    {
				    	graphics.DrawEllipse(pen,
				    	                     points[i].X - size / 2, points[i].Y - size / 2,
				    	                     size, size);
				    }		    	   
		    	}
		    	else
		    	{
		    		// ����� ������ �� ������� ����������
				    using (Pen pen = new Pen(Color.Green, 3))
				    {
				    	graphics.DrawEllipse(pen,
				    	                     points[i].X - size / 2, points[i].Y - size / 2,
				    	                     size, size);
				    }			    		
		    	}
		    }			
		}

		/// <summary> ������������ ���������� �������� ����. </summary> 
		private void MainFormPaint(object sender, PaintEventArgs e)
		{
			// �������� ������ ��� ��������� �� ������
			Graphics graphics = e.Graphics;
			
			// ������ ��������� ������
			if (menuItemSpline.Checked)
			{
				DrawSpline(graphics);
			}
			else if (menuItemBezier.Checked)
			{
				DrawBezier(graphics);
			}
            else
            {
				DrawHermite(graphics);

			}
			
			// ������ ����������� ����� ������ ������
			DrawPoints(graphics);
		}
		
		/// <summary> ������������ ����������� ����. </summary>
		private void MainFormMouseMove(object sender, MouseEventArgs e)
		{
		    // ���������� ��� ����������� �����
			for (int i = 0; i < points.Length; i++)
		    {
				// ���� ��������� ���� ����� � ����������� �����...
		    	if (Math.Abs(points[i].X - e.X) < 4)
		    	{
		    	    if (Math.Abs(points[i].Y - e.Y) < 4)
		        	{
		            	// ...�������� ������ �����
		    	    	selectIndex = i;
		            	break;
		    	    }
		    	}
		    }
		    
			// ���� ������ ����� ������ ����...
		    if (MouseButtons.Left == e.Button)
		    {
		        // ...���������� ���������� ����������� �����
		    	points[selectIndex] = e.Location;
		    }
		    
		    // �������������� ������� ����
		    Invalidate();
		}

		/// <summary> �������� ��� ������ '������ �����'. </summary>
		private void MenuItemBezierClick(object sender, EventArgs e)
		{
			menuItemBezier.Checked = true;
			menuItemSpline.Checked = false;
			������ToolStripMenuItem.Checked = false;
		}
		
		/// <summary> �������� ��� ������ '���������� ������'. </summary>
		private void MenuItemSplineClick(object sender, EventArgs e)
		{
			menuItemBezier.Checked = false;
			menuItemSpline.Checked = true;
			������ToolStripMenuItem.Checked = false;
		}

		private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			menuItemBezier.Checked = false;
			menuItemSpline.Checked = false;
			������ToolStripMenuItem.Checked = true;
		}

		private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
			uint min = 2;
			uint res = 0;
			var success = uint.TryParse(toolStripTextBox1.Text, out res);
			if (success)
			{
				if (res < min)
					res = min;
				toolStripTextBox1.Text = res.ToString();
				pointsCount = (int)res;
				GeneratePoints();
			}
			else
			{
				toolStripTextBox1.Text = min.ToString();
				pointsCount = (int)min;
				GeneratePoints();
			}
		}
    }
}
