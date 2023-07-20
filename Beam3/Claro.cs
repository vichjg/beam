using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSML;

namespace Beam3 {
	class Claro {
		protected int indice, nudoi, nudof;
		protected double l;
		public List<List<Macaulay>> qMacaulays = new List<List<Macaulay>>();
		public List<Macaulay> vMacaulays = new List<Macaulay>();
		public List<Macaulay> mMacaulays = new List<Macaulay>();
		//public Matrix[,] matrizDeRigidezDelElemento = new Matrix[2,2];
		public Point punto1, punto2;

		public int Indice { set { this.indice = value; } }
		public int Nudoi { get { return this.nudoi; } set {this.nudoi=value; } }
		public int Nudof { get { return this.nudof; } set {this.nudof=value; } }
		public double L { get { return this.l; } set { this.l = value; } }
		public Claro(double l) {
			L = l;
		}
	}
}
