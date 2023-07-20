using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beam3 {
	partial class Apoyos:Form {
		public Coordenada[] coordenadas;//= new Coordenada{ };
		public List<GroupBox> gruposApoyo = new List<GroupBox>();
		List<List<RadioButton>> radioBotonesApoyos = new List<List<RadioButton>>();
		public Apoyos() {
			InitializeComponent();
		}

		public void EstablecerApoyos() {
			gruposApoyo = new List<GroupBox>();
			radioBotonesApoyos = new List<List<RadioButton>>();
			if(coordenadas == null) return;
			for(int i = 0 ; i < coordenadas.Length ; i++) {
				gruposApoyo.Add(new GroupBox());
				this.gruposApoyo[i].Location = new System.Drawing.Point(12+110*i,12);
				this.gruposApoyo[i].Name = "Apoyo" + (i + 1);
				this.gruposApoyo[i].Size = new System.Drawing.Size(100,100);
				//this.groupBox1.TabIndex = 5;
				//this.gruposApoyo[i].TabStop = false;
				this.gruposApoyo[i].Text = "Apoyo"+(i+1);
				this.gruposApoyo[i].SuspendLayout();
				this.gruposApoyo[i].ResumeLayout(false);
				this.gruposApoyo[i].PerformLayout();
				this.Controls.Add(this.gruposApoyo[i]);

				this.radioBotonesApoyos.Add(new List<RadioButton>());

				this.radioBotonesApoyos[i].Add(new RadioButton());
				this.radioBotonesApoyos[i][0].AutoSize = true;
				this.radioBotonesApoyos[i][0].Location = new System.Drawing.Point(0,19);
				this.radioBotonesApoyos[i][0].Name = "RadioBoton0" + (i + 1);
				this.radioBotonesApoyos[i][0].Size = new System.Drawing.Size(85,17);
				//this.radioBotonesApoyos[i][0].TabIndex = 2;
				//this.radioBotonesApoyos[i][0].TabStop = true;
				this.radioBotonesApoyos[i][0].Text = "Articulado";
				this.radioBotonesApoyos[i][0].UseVisualStyleBackColor = true;
				this.gruposApoyo[i].Controls.Add(this.radioBotonesApoyos[i][0]);

				this.radioBotonesApoyos[i].Add(new RadioButton());
				this.radioBotonesApoyos[i][1].AutoSize = true;
				this.radioBotonesApoyos[i][1].Location = new System.Drawing.Point(0,19*2);
				this.radioBotonesApoyos[i][1].Name = "RadioBoton1" + (i + 1);
				this.radioBotonesApoyos[i][1].Size = new System.Drawing.Size(85,17);
				//this.radioBotonesApoyos[i][1].TabIndex = 2;
				//this.radioBotonesApoyos[i][1].TabStop = true;
				this.radioBotonesApoyos[i][1].Text = "Empotrado";
				this.radioBotonesApoyos[i][1].UseVisualStyleBackColor = true;
				this.gruposApoyo[i].Controls.Add(this.radioBotonesApoyos[i][1]);

				this.radioBotonesApoyos[i].Add(new RadioButton());
				this.radioBotonesApoyos[i][2].AutoSize = true;
				this.radioBotonesApoyos[i][2].Location = new System.Drawing.Point(0,19*3);
				this.radioBotonesApoyos[i][2].Name = "RadioBoton2" + (i + 1);
				this.radioBotonesApoyos[i][2].Size = new System.Drawing.Size(85,17);
				//this.radioBotonesApoyos[i][2].TabIndex = 2;
				//this.radioBotonesApoyos[i][2].TabStop = true;
				this.radioBotonesApoyos[i][2].Text = "Cantiliever";
				this.radioBotonesApoyos[i][2].UseVisualStyleBackColor = true;
				this.gruposApoyo[i].Controls.Add(this.radioBotonesApoyos[i][2]);
			}
		}

		public void QuitarUltimoApoyo() {
			if(this.coordenadas == null) return;
			this.gruposApoyo.RemoveAt(this.gruposApoyo.Count - 1);
			this.Controls.Remove(this.Controls.Find("Apoyo" + (coordenadas.Length+1),false)[0]);
			this.Controls.Find("Apoyo" + (coordenadas.Length + 1),false)[0].Controls.Clear();
			this.Controls.Find("Apoyo" + (coordenadas.Length + 1),false)[0].Hide();
			if(this.coordenadas == null) this.gruposApoyo = null;
		}

		private void Restricciones() {
			for(int i = 0 ; i < gruposApoyo.Count ; i++) {
				if(this.radioBotonesApoyos[i][0].Checked)
					coordenadas[i].RestriccionV = true;
				if(this.radioBotonesApoyos[i][1].Checked)
					coordenadas[i].RestriccionM = true;
			}
			for(int i = 0 ; i < coordenadas.Length ; i++) {
				if(coordenadas[i].RestriccionM)
					coordenadas[i].apoyoFijo();
				else if(coordenadas[i].RestriccionV)
					coordenadas[i].apoyoArticulado();
			}
		}

		private void botonAgregarApoyos_Click(object sender,EventArgs e) {
			//EstablecerApoyos();
			Restricciones();
		}



		private void botonCerrarApoyos_Click(object sender,EventArgs e) {
			Restricciones();
			this.Close();
		}
	}
}
