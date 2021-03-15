namespace Tutorial.Curves
{
	partial class MainForm
	{
		private System.ComponentModel.IContainer components = null;
		
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		private void InitializeComponent()
		{
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBezier = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSpline = new System.Windows.Forms.ToolStripMenuItem();
            this.числоТочекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.эрмитаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemCurve,
            this.числоТочекToolStripMenuItem,
            this.toolStripTextBox1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(521, 27);
            this.menuStrip.TabIndex = 3;
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(48, 23);
            this.menuItemFile.Text = "Файл";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(109, 22);
            this.menuItemExit.Text = "Выход";
            // 
            // menuItemCurve
            // 
            this.menuItemCurve.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBezier,
            this.menuItemSpline,
            this.эрмитаToolStripMenuItem});
            this.menuItemCurve.Name = "menuItemCurve";
            this.menuItemCurve.Size = new System.Drawing.Size(39, 23);
            this.menuItemCurve.Text = "Тип";
            // 
            // menuItemBezier
            // 
            this.menuItemBezier.Name = "menuItemBezier";
            this.menuItemBezier.Size = new System.Drawing.Size(180, 22);
            this.menuItemBezier.Text = "Безье";
            this.menuItemBezier.Click += new System.EventHandler(this.MenuItemBezierClick);
            // 
            // menuItemSpline
            // 
            this.menuItemSpline.Checked = true;
            this.menuItemSpline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemSpline.Name = "menuItemSpline";
            this.menuItemSpline.Size = new System.Drawing.Size(180, 22);
            this.menuItemSpline.Text = "Catmull-Rom-a";
            this.menuItemSpline.Click += new System.EventHandler(this.MenuItemSplineClick);
            // 
            // числоТочекToolStripMenuItem
            // 
            this.числоТочекToolStripMenuItem.Enabled = false;
            this.числоТочекToolStripMenuItem.Name = "числоТочекToolStripMenuItem";
            this.числоТочекToolStripMenuItem.Size = new System.Drawing.Size(88, 23);
            this.числоТочекToolStripMenuItem.Text = "Число точек";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "4";
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // эрмитаToolStripMenuItem
            // 
            this.эрмитаToolStripMenuItem.Name = "эрмитаToolStripMenuItem";
            this.эрмитаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.эрмитаToolStripMenuItem.Text = "Эрмита";
            this.эрмитаToolStripMenuItem.Click += new System.EventHandler(this.эрмитаToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(521, 508);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Сплайны";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFormPaint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseMove);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem menuItemSpline;
		private System.Windows.Forms.ToolStripMenuItem menuItemBezier;
		private System.Windows.Forms.ToolStripMenuItem menuItemCurve;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
		private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem числоТочекToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem эрмитаToolStripMenuItem;
    }
}
