using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam3 {
	class CargaDistribuida:FuerzaEnBarra{
		private double a, b, qa, qb;
		List<Macaulay> mcy = new List<Macaulay>();

		public double A { get { return this.a; } set { this.a=value; } }
		public double B { get { return this.b; } set { this.b=value; } }
		public double Qa { get { return this.qa; } set { this.qa=value; } }
		public double Qb { get { return this.qb; } set { this.qb=value; } }
		//public CargaDistribuida(){}
		public CargaDistribuida(ref Claro cl,double a,double b,double qa,double qb) {
			Cl = cl;

			b = b + a;

			A = a; B = b; Qa = qa; Qb = qb;

			this.fuerzai.Nudo = cl.Nudoi;
			this.fuerzaj.Nudo = cl.Nudof;
			this.fuerzai.M = Mtrapecio(cl.L,A,B,Qa,Qb);
			this.fuerzaj.M = Mtrapecio(cl.L,cl.L - A,cl.L - B,Qa,Qb);
			this.fuerzai.V = -Vtrapecio(cl.L,A,B,Qa,Qb) - (this.fuerzai.M + this.fuerzaj.M) / cl.L;
			this.fuerzaj.V = Vtrapecio(cl.L,cl.L - A,cl.L - B,Qa,Qb) + (this.fuerzai.M + this.fuerzaj.M) / cl.L;

			this.fuerzai.M = -Math.Abs(this.fuerzai.M);
			this.fuerzaj.M = Math.Abs(this.fuerzaj.M);
			this.fuerzai.V = -Math.Abs(this.fuerzai.V);
			this.fuerzaj.V = -Math.Abs(this.fuerzaj.V);
			/*pruebaViga.imp(this.fuerzai.M);
			pruebaViga.imp(this.fuerzai.V);
			pruebaViga.imp(this.fuerzaj.M);
			pruebaViga.imp(this.fuerzaj.V);*/
			mcy.Add(new Macaulay(-(Qb - Qa) / (B - A),A,1));
			mcy.Add(new Macaulay(-Qa,A,0));
			mcy.Add(new Macaulay((Qb - Qa) / (B - A),B,1));
			mcy.Add(new Macaulay(Qb,B,0));

			cl.qMacaulays.Add(mcy);
		}
		private double MrecFix(double L,double a,double q) {
			double r = q * Math.Pow(a,2) / 12 * (6 - 8 * a / L + 3 * Math.Pow(a / L,2));
			return q * Math.Pow(a,2) / 12 * (6 - 8 * a / L + 3 * Math.Pow(a / L,2));
		}
		private double MTriFix(double L,double a,double q) {
			double r = q * Math.Pow(a,2) / 60 * (10 - 10 * a / L + 3 * Math.Pow(a / L,2));
			return q * Math.Pow(a,2) / 60 * (10 - 10 * a / L + 3 * Math.Pow(a / L,2));
		}
		private double Mtrapecio(double L,double a,double b,double qa,double qb) {
			double c = qb - ((qb - qa) / (b - a)) * b;
			/*pruebaViga.imp(MrecFix(L,a,qa));//////////////////
			pruebaViga.imp(MTriFix(L,a,c-qa));////////////////
			pruebaViga.imp(MrecFix(L,b,qb));//////////////////
			pruebaViga.imp(MTriFix(L,b,c - qb));
			pruebaViga.imp(MrecFix(L,a,qa) + MTriFix(L,a,c - qa) - MrecFix(L,b,qb) - MTriFix(L,b,c - qb));*/
			double r= MrecFix(L,a,qa) + MTriFix(L,a,c - qa) - MrecFix(L,b,qb) - MTriFix(L,b,c - qb);
			return r;
		}
		private double VrecFix(double L,double a, double q) {
			return q * a * (2 * L - a) / (2 * L);
		}
		private double VTriFix(double L,double a,double q) {
			return (3 * q * a * L - q * a * a) / (6 * L);
		}
		private double Vtrapecio(double L,double a,double b,double qa,double qb) {
			double c = qb - ((qb - qa) / (b - a)) * b;
			/*pruebaViga.imp(VrecFix(L,a,qa));
			pruebaViga.imp(VTriFix(L,a,c - qa));
			pruebaViga.imp(VrecFix(L,b,qb));
			pruebaViga.imp(VTriFix(L,b,c - qb));
			pruebaViga.imp(Math.Abs(VrecFix(L,a,qa) + VTriFix(L,a,c - qa) - VrecFix(L,b,qb) - VTriFix(L,b,c - qb)));*/
			return VrecFix(L,a,qa) + VTriFix(L,a,c - qa) - VrecFix(L,b,qb) - VTriFix(L,b,c - qb);
		}
	}
}