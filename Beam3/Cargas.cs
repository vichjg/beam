using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Beam3 {
	partial class Cargas:Form {
		public Viga pruebaViga = new Viga();
		List<FuerzaEnBarra> listaDeCargas;// = new List<FuerzaEnBarra>();

		public Cargas() {
			InitializeComponent();
		}

		private void botonAgregar_Click(object sender,EventArgs e) {
			for(int i = 0 ; i < this.tablaDeCargas.RowCount - 1 ; i++) {
				if(Convert.ToInt32(this.tablaDeCargas[0,i].Value)>pruebaViga.claros.Count) {
					MessageBox.Show("No existe claro No. "+ Convert.ToInt32(this.tablaDeCargas[0,i].Value));
					return;
				}
			}
			ExtraerCargasDistribuidas();
		}

		private void botonCerrar_Click(object sender,EventArgs e) {
			this.Close();
		}

		public string TheValue {
			get {
				return this.columnaClaro.ToString();
			}
		}

		private void ExtraerCargasDistribuidas() {
			listaDeCargas = new List<FuerzaEnBarra>();
			int indexClaro = -1;
			for(int i = 0 ; i < this.tablaDeCargas.RowCount-1 ; i++) {
				double  a=0, b=0, qa=0, qb=0;
				if(Convert.ToInt32(tablaDeCargas[0,i].Value)>0) indexClaro = Convert.ToInt32(tablaDeCargas[0,i].Value) - 1;
				if(indexClaro>-1) {
					if((tablaDeCargas[1,i].Value != null || tablaDeCargas[2,i].Value != null) && (tablaDeCargas[3,i].Value != null )){//|| tablaDeCargas[i,4] != null)) {
						qa = aBQaQb(i)[0];
						qb = aBQaQb(i)[1];
						a = aBQaQb(i)[2];
						b = aBQaQb(i)[3];
						pruebaViga.NuevaCargaDistribuida(indexClaro,a,pruebaViga.claros[indexClaro].L - b,qa,qb);
					}
					if(tablaDeCargas[5,i].Value != null) {
						if(tablaDeCargas[6,i].Value != null) a = Convert.ToDouble(tablaDeCargas[6,i].Value);
						pruebaViga.NuevaCargaPuntual(indexClaro,a,Convert.ToDouble(tablaDeCargas[5,i].Value));
					}
				}
			}
		}

		private double[] aBQaQb(int fila) {
			double a = 0, b = 0, qa = 0, qb = 0;

			if(tablaDeCargas[1,fila].Value == null) 
				qb = Convert.ToDouble(tablaDeCargas[2,fila].Value);
			else if(tablaDeCargas[2,fila].Value == null) {
				qa = Convert.ToDouble(tablaDeCargas[1,fila].Value);
				qb = Convert.ToDouble(tablaDeCargas[1,fila].Value);
			}
			else {
				qa = Convert.ToDouble(tablaDeCargas[1,fila].Value);
				qb = Convert.ToDouble(tablaDeCargas[2,fila].Value);
			}
			if(tablaDeCargas[3,fila].Value == null) {
				b = Convert.ToDouble(tablaDeCargas[4,fila].Value);
				if(b > pruebaViga.claros[fila].L)	b = pruebaViga.claros[fila].L;
			} else if(tablaDeCargas[4,fila].Value == null) {
				a = Convert.ToDouble(tablaDeCargas[3,fila].Value);
				b = pruebaViga.claros[fila].L - a;
			}
			else {
				a = Convert.ToDouble(tablaDeCargas[3,fila].Value);
				b = Convert.ToDouble(tablaDeCargas[4,fila].Value);
				if(a + b > pruebaViga.claros[fila].L)	b = pruebaViga.claros[fila].L-a;
			}
			return new double[]{ qa,qb,a,b };
		}
	}
}
