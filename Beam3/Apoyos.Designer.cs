namespace Beam3 {
	partial class Apoyos {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.botonAgregarApoyos = new System.Windows.Forms.Button();
			this.botonCerrarApoyos = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// botonAgregarApoyos
			// 
			this.botonAgregarApoyos.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.botonAgregarApoyos.Location = new System.Drawing.Point(620, 265);
			this.botonAgregarApoyos.Name = "botonAgregarApoyos";
			this.botonAgregarApoyos.Size = new System.Drawing.Size(75, 23);
			this.botonAgregarApoyos.TabIndex = 0;
			this.botonAgregarApoyos.Text = "Agregar";
			this.botonAgregarApoyos.UseVisualStyleBackColor = true;
			this.botonAgregarApoyos.Click += new System.EventHandler(this.botonAgregarApoyos_Click);
			// 
			// botonCerrarApoyos
			// 
			this.botonCerrarApoyos.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.botonCerrarApoyos.Location = new System.Drawing.Point(719, 265);
			this.botonCerrarApoyos.Name = "botonCerrarApoyos";
			this.botonCerrarApoyos.Size = new System.Drawing.Size(75, 23);
			this.botonCerrarApoyos.TabIndex = 1;
			this.botonCerrarApoyos.Text = "Cerrar";
			this.botonCerrarApoyos.UseVisualStyleBackColor = true;
			this.botonCerrarApoyos.Click += new System.EventHandler(this.botonCerrarApoyos_Click);
			// 
			// Apoyos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(827, 359);
			this.Controls.Add(this.botonCerrarApoyos);
			this.Controls.Add(this.botonAgregarApoyos);
			this.Name = "Apoyos";
			this.Text = "Apoyos";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button botonAgregarApoyos;
		private System.Windows.Forms.Button botonCerrarApoyos;
	}
}