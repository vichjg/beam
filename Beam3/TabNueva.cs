using System.Windows.Forms;

namespace Beam3 {
	class TabNueva:TabPage{
		public TabNueva() {
			this.Location = new System.Drawing.Point(4,22);
			this.Name = "Nueva";
			this.Padding = new System.Windows.Forms.Padding(3);
			//this.Size = new System.Drawing.Size(DefaultMaximumSize.Width,DefaultMaximumSize.Height);
			//this.TabIndex = 1;
			this.Text = "Nueva";
			this.UseVisualStyleBackColor = true;
			//this.Click += new System.EventHandler(this.tabPage2_Click);
		}

		public TabNueva(string nombre) {
			this.Location = new System.Drawing.Point(4,22);
			this.Name = nombre;
			this.Padding = new System.Windows.Forms.Padding(3);
			//this.Size = new System.Drawing.Size(DefaultMaximumSize.Width,DefaultMaximumSize.Height);
			//this.TabIndex = 1;
			this.Text = nombre;
			this.UseVisualStyleBackColor = true;
			//this.Click += new System.EventHandler(this.tabPage2_Click);
		}
	}
}
