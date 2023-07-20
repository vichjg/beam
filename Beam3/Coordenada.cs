using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam3 {
	class Coordenada {
		double x;
		private bool restricionV = false;
		private bool restricionM = false;

		private int indice;

		public double deltaV=0, deltaM=0;

		public Point[] apoyo=new Point[] { };

		public Point panelPosicion;

		public bool RestriccionV {
			get { return this.restricionV; }
			set {
				if(RestriccionM) {
					this.restricionV = true;
				}
				else this.restricionV = value;
			}
		}
		public bool RestriccionM {
			get { return this.restricionM; }
			set {
				if(value) {
					RestriccionV = true;
					this.restricionM = value;
				}
			}
		}
		public int Indice { get { return this.indice; } set { this.indice=value; } }

		public Coordenada(){}
		public Coordenada(double x) {this.x = x;}

		public void apoyoArticulado() {
			apoyo = new Point[] {
				panelPosicion,
				new Point(panelPosicion.X - 10,panelPosicion.Y + 20),
				new Point(panelPosicion.X + 10,panelPosicion.Y + 20),panelPosicion
			};
		}

		public void apoyoFijo() {
			apoyo = new Point[] {
				new Point(panelPosicion.X - 10,panelPosicion.Y - 5),
				new Point(panelPosicion.X ,panelPosicion.Y - 10),
				panelPosicion,
				new Point(panelPosicion.X - 10,panelPosicion.Y + 5),
				panelPosicion,
				new Point(panelPosicion.X,panelPosicion.Y + 10),
				new Point(panelPosicion.X - 10,panelPosicion.Y + 15)
			};
		}
	}
}
