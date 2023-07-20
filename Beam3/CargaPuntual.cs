using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam3 {
	class CargaPuntual:FuerzaEnBarra {
		double a, p;// a tiene que estar entre 0 y L, sino seria carga en nudo
		List<Macaulay> mcy = new List<Macaulay>();

		public double A { get { return this.a; } set { this.a=value; } }
		public double P { get { return this.p; } set { this.p=value; } }
		public CargaPuntual(ref Claro cl,double a,double p) {
			Cl = cl;
			A = a; P = p;

			this.fuerzai.Nudo = cl.Nudoi;
			this.fuerzaj.Nudo = cl.Nudof;
			this.fuerzai.M = -Mflex(cl.L,A,P);
			this.fuerzaj.M = Mflex(cl.L,cl.L - A,P);
			this.fuerzai.V = Vcort(cl.L,A,P) - (this.fuerzai.M + this.fuerzaj.M) / cl.L;
			this.fuerzaj.V = Vcort(cl.L,cl.L - a,P) + (this.fuerzai.M + this.fuerzaj.M) / cl.L;

			this.fuerzai.M = -Math.Abs(this.fuerzai.M);
			this.fuerzaj.M = Math.Abs(this.fuerzaj.M);
			this.fuerzai.V = -Math.Abs(this.fuerzai.V);
			this.fuerzaj.V = -Math.Abs(this.fuerzaj.V);
			/*pruebaViga.imp(this.fuerzai.M);
			pruebaViga.imp(this.fuerzai.V);
			pruebaViga.imp(this.fuerzaj.M);
			pruebaViga.imp(this.fuerzaj.V);*/
			mcy.Add(new Macaulay(-P,A,-1));

			cl.qMacaulays.Add(mcy);
		}
		private double Mflex(double L,double a,double p) {
			return p*a*(L-a)*(L-a)/Math.Pow(L,2);
		}
		private double Vcort(double L,double a,double p) {
			return Math.Abs(p * (L - a) / L);
		}
	}
}
