using System;

namespace Beam3 {
	partial class Form1 {
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent() {
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.botonCalcular = new System.Windows.Forms.Button();
			this.botonApoyos = new System.Windows.Forms.Button();
			this.botonTablaDeCargas = new System.Windows.Forms.Button();
			this.panel = new System.Windows.Forms.FlowLayoutPanel();
			this.labelMetros = new System.Windows.Forms.Label();
			this.textBoxLongitud = new System.Windows.Forms.TextBox();
			this.botonQuitarUltimoClaro = new System.Windows.Forms.Button();
			this.botonNuevoClaro = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(763, 733);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.botonCalcular);
			this.tabPage1.Controls.Add(this.botonApoyos);
			this.tabPage1.Controls.Add(this.botonTablaDeCargas);
			this.tabPage1.Controls.Add(this.panel);
			this.tabPage1.Controls.Add(this.labelMetros);
			this.tabPage1.Controls.Add(this.textBoxLongitud);
			this.tabPage1.Controls.Add(this.botonQuitarUltimoClaro);
			this.tabPage1.Controls.Add(this.botonNuevoClaro);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(755, 707);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			// 
			// botonCalcular
			// 
			this.botonCalcular.Location = new System.Drawing.Point(526, 208);
			this.botonCalcular.Name = "botonCalcular";
			this.botonCalcular.Size = new System.Drawing.Size(53, 23);
			this.botonCalcular.TabIndex = 9;
			this.botonCalcular.Text = "Calcular";
			this.botonCalcular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.botonCalcular.UseVisualStyleBackColor = true;
			this.botonCalcular.Click += new System.EventHandler(this.botonCalcular_Click);
			// 
			// botonApoyos
			// 
			this.botonApoyos.Location = new System.Drawing.Point(526, 134);
			this.botonApoyos.Name = "botonApoyos";
			this.botonApoyos.Size = new System.Drawing.Size(52, 23);
			this.botonApoyos.TabIndex = 8;
			this.botonApoyos.Text = "Apoyos";
			this.botonApoyos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.botonApoyos.UseVisualStyleBackColor = true;
			this.botonApoyos.Click += new System.EventHandler(this.botonApoyos_Click);
			// 
			// botonTablaDeCargas
			// 
			this.botonTablaDeCargas.Location = new System.Drawing.Point(526, 93);
			this.botonTablaDeCargas.Name = "botonTablaDeCargas";
			this.botonTablaDeCargas.Size = new System.Drawing.Size(97, 23);
			this.botonTablaDeCargas.TabIndex = 7;
			this.botonTablaDeCargas.Text = "Tabla de cargas";
			this.botonTablaDeCargas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.botonTablaDeCargas.UseVisualStyleBackColor = true;
			this.botonTablaDeCargas.Click += new System.EventHandler(this.botonTablaDeCargas_Click);
			// 
			// panel
			// 
			this.panel.BackColor = System.Drawing.Color.Black;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(500, 300);
			this.panel.TabIndex = 6;
			this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
			// 
			// labelMetros
			// 
			this.labelMetros.AutoSize = true;
			this.labelMetros.Location = new System.Drawing.Point(608, 14);
			this.labelMetros.Name = "labelMetros";
			this.labelMetros.Size = new System.Drawing.Size(15, 13);
			this.labelMetros.TabIndex = 5;
			this.labelMetros.Text = "m";
			// 
			// textBoxLongitud
			// 
			this.textBoxLongitud.Location = new System.Drawing.Point(526, 8);
			this.textBoxLongitud.Name = "textBoxLongitud";
			this.textBoxLongitud.Size = new System.Drawing.Size(75, 20);
			this.textBoxLongitud.TabIndex = 4;
			this.textBoxLongitud.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLongitud_KeyPress);
			// 
			// botonQuitarUltimoClaro
			// 
			this.botonQuitarUltimoClaro.Location = new System.Drawing.Point(643, 32);
			this.botonQuitarUltimoClaro.Name = "botonQuitarUltimoClaro";
			this.botonQuitarUltimoClaro.Size = new System.Drawing.Size(104, 23);
			this.botonQuitarUltimoClaro.TabIndex = 3;
			this.botonQuitarUltimoClaro.Text = "Quitar ultimo claro";
			this.botonQuitarUltimoClaro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.botonQuitarUltimoClaro.UseVisualStyleBackColor = true;
			this.botonQuitarUltimoClaro.Click += new System.EventHandler(this.botonQuitarUltimoClaro_Click);
			// 
			// botonNuevoClaro
			// 
			this.botonNuevoClaro.Location = new System.Drawing.Point(526, 32);
			this.botonNuevoClaro.Name = "botonNuevoClaro";
			this.botonNuevoClaro.Size = new System.Drawing.Size(75, 23);
			this.botonNuevoClaro.TabIndex = 0;
			this.botonNuevoClaro.Text = "Nuevo claro";
			this.botonNuevoClaro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.botonNuevoClaro.UseVisualStyleBackColor = true;
			this.botonNuevoClaro.Click += new System.EventHandler(this.botonNuevoClaro_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(763, 733);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.Text = "LU";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.ResumeLayout(false);

		}

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button botonNuevoClaro;
		private System.Windows.Forms.Label labelMetros;
		private System.Windows.Forms.TextBox textBoxLongitud;
		private System.Windows.Forms.Button botonQuitarUltimoClaro;
		private System.Windows.Forms.FlowLayoutPanel panel;
		private System.Windows.Forms.Button botonTablaDeCargas;
		private System.Windows.Forms.Button botonApoyos;
		private System.Windows.Forms.Button botonCalcular;
		//private System.Windows.Forms.TabPage tabPage2;

		#endregion

		//private System.Windows.Forms.TabPage tabPage1;
		//private System.Windows.Forms.TabPage tabPlus;
	}
}

