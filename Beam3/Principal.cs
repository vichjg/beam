using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beam3 {
	class Principal : Form{
		//Main f = new Main();
		public Principal() {
			InitializeComponent();
		}

		protected void InitializeComponent() {
			this.SuspendLayout();
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(763,733);
			this.Name = "Form1";
			this.Text = "LU1";
			//this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);
		}
	}
}
