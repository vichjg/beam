namespace Beam3 {
	partial class Cargas {
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
			this.tablaDeCargas = new System.Windows.Forms.DataGridView();
			this.columnaClaro = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnaQa = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnaQb = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnaAw = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnaB = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnaP = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnaAp = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1 = new System.Windows.Forms.Panel();
			this.botonAgregar = new System.Windows.Forms.Button();
			this.botonCerrar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.tablaDeCargas)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.tablaDeCargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tablaDeCargas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnaClaro,
            this.columnaQa,
            this.columnaQb,
            this.columnaAw,
            this.columnaB,
            this.columnaP,
            this.columnaAp});
			this.tablaDeCargas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tablaDeCargas.Location = new System.Drawing.Point(0, 0);
			this.tablaDeCargas.Name = "dataGridView1";
			this.tablaDeCargas.Size = new System.Drawing.Size(894, 373);
			this.tablaDeCargas.TabIndex = 0;
			// 
			// columnaClaro
			// 
			this.columnaClaro.HeaderText = "Claro";
			this.columnaClaro.Name = "columnaClaro";
			// 
			// columnaQa
			// 
			this.columnaQa.HeaderText = "Wa (T/m)";
			this.columnaQa.Name = "columnaQa";
			// 
			// columnaQb
			// 
			this.columnaQb.HeaderText = "Wb (T/m)";
			this.columnaQb.Name = "columnaQb";
			// 
			// columnaAw
			// 
			this.columnaAw.HeaderText = "a (m)";
			this.columnaAw.Name = "columnaAw";
			// 
			// columnaB
			// 
			this.columnaB.HeaderText = "b (m)";
			this.columnaB.Name = "columnaB";
			// 
			// columnaP
			// 
			this.columnaP.HeaderText = "P (Ton)";
			this.columnaP.Name = "columnaP";
			// 
			// columnaAp
			// 
			this.columnaAp.HeaderText = "a (m)";
			this.columnaAp.Name = "columnaAp";
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 226);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(742, 147);
			this.panel1.TabIndex = 1;
			// 
			// botonAgregar
			// 
			this.botonAgregar.Location = new System.Drawing.Point(741, 197);
			this.botonAgregar.Name = "botonAgregar";
			this.botonAgregar.Size = new System.Drawing.Size(72, 23);
			this.botonAgregar.TabIndex = 2;
			this.botonAgregar.Text = "Agregar";
			this.botonAgregar.UseVisualStyleBackColor = true;
			this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
			// 
			// botonCerrar
			// 
			this.botonCerrar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.botonCerrar.Location = new System.Drawing.Point(819, 197);
			this.botonCerrar.Name = "botonCerrar";
			this.botonCerrar.Size = new System.Drawing.Size(73, 23);
			this.botonCerrar.TabIndex = 3;
			this.botonCerrar.Text = "Cerrar";
			this.botonCerrar.UseVisualStyleBackColor = true;
			this.botonCerrar.Click += new System.EventHandler(this.botonCerrar_Click);
			// 
			// Cargas
			// 
			//this.AcceptButton = this.botonAgregar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(894, 373);
			this.Controls.Add(this.botonCerrar);
			this.Controls.Add(this.botonAgregar);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tablaDeCargas);
			this.Name = "Cargas";
			this.Text = "Cargas";
			((System.ComponentModel.ISupportInitialize)(this.tablaDeCargas)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView tablaDeCargas;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridViewTextBoxColumn columnaClaro;
		private System.Windows.Forms.DataGridViewTextBoxColumn columnaQa;
		private System.Windows.Forms.DataGridViewTextBoxColumn columnaQb;
		private System.Windows.Forms.DataGridViewTextBoxColumn columnaAw;
		private System.Windows.Forms.DataGridViewTextBoxColumn columnaB;
		private System.Windows.Forms.DataGridViewTextBoxColumn columnaP;
		private System.Windows.Forms.DataGridViewTextBoxColumn columnaAp;
		private System.Windows.Forms.Button botonAgregar;
		private System.Windows.Forms.Button botonCerrar;
	}
}