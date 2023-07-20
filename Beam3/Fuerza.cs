using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam3 {
	class Fuerza{
		private double v=0, m=0;
		private int nudo;

		public double V { get { return this.v; } set { this.v=value; } }
		public double M { get { return this.m; } set { this.m=value; } }
		public int Nudo { get { return this.nudo; } set { this.nudo=value; } }
		public Fuerza(){ this.v=0; this.m=0; }
		public static Fuerza operator +(Fuerza A,Fuerza B) {
			A.M += B.M;
			A.V += B.V;
			return A;
		}
	}
}
