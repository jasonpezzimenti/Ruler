﻿namespace Ruler
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.separator1 = new Controls.Separator();
            this.separator2 = new Controls.Separator();
            this.separator3 = new Controls.Separator();
            this.ruler = new Ruler();
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // separator1
            // 
            this.separator1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(26)))), ((int)(((byte)(27)))));
            this.separator1.Direction = "Vertical";
            this.separator1.DisabledColor = System.Drawing.Color.Empty;
            this.separator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.separator1.Location = new System.Drawing.Point(0, 0);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(1, 27);
            this.separator1.TabIndex = 0;
            this.separator1.Text = "separator1";
            this.separator1.Thickness = 1;
            // 
            // separator2
            // 
            this.separator2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(26)))), ((int)(((byte)(27)))));
            this.separator2.Direction = "Vertical";
            this.separator2.DisabledColor = System.Drawing.Color.Empty;
            this.separator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.separator2.Location = new System.Drawing.Point(799, 0);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(1, 27);
            this.separator2.TabIndex = 1;
            this.separator2.Text = "separator2";
            this.separator2.Thickness = 1;
            // 
            // separator3
            // 
            this.separator3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(26)))), ((int)(((byte)(27)))));
            this.separator3.Direction = "Horizontal";
            this.separator3.DisabledColor = System.Drawing.Color.Empty;
            this.separator3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator3.Location = new System.Drawing.Point(1, 26);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(798, 1);
            this.separator3.TabIndex = 2;
            this.separator3.Text = "separator3";
            this.separator3.Thickness = 1;
            // 
            // ruler
            // 
            this.ruler.Direction = Ruler.Directions.Horizontal;
            this.ruler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ruler.Font = new System.Drawing.Font("Saira", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ruler.IsDragging = false;
            this.ruler.Location = new System.Drawing.Point(1, 0);
            this.ruler.Marker = Ruler.Markers.All;
            this.ruler.Name = "ruler";
            this.ruler.Size = new System.Drawing.Size(798, 26);
            this.ruler.TabIndex = 3;
            this.ruler.Text = "ruler1";
            this.ruler.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ruler_MouseDown);
            this.ruler.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ruler_MouseMove);
            this.ruler.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ruler_MouseUp);
            // 
            // contextMenu
            // 
            this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem4});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3});
            this.menuItem1.Text = "Clear Marker(s)";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "All";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "Current";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "Exit";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(800, 27);
            this.Controls.Add(this.ruler);
            this.Controls.Add(this.separator3);
            this.Controls.Add(this.separator2);
            this.Controls.Add(this.separator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ruler";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Window_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Separator separator1;
        private Controls.Separator separator2;
        private Controls.Separator separator3;
        private Ruler ruler;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
    }
}

