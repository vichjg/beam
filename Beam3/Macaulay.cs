using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam3 {
	class Macaulay {
		public double coeficiente, distanciaInicial;
		public int exponente;
		public Macaulay(double coeficiente, double distanciaInicial, int exponente) {
			this.coeficiente = coeficiente;
			this.distanciaInicial = distanciaInicial;
			this.exponente = exponente;
		}
		public double this[double x] { get { return this.Resultado(x); } }
		public double Resultado(double x) {
			double result = 0;
			if(x > distanciaInicial) result = coeficiente * Math.Pow(x - distanciaInicial,exponente);
			if(distanciaInicial==0 && x==0 && exponente == 0) result = coeficiente;
			if(exponente < 0) result = 0;
			return result;
		}
		public Macaulay Integral() {
			if(exponente >= 0)
				return new Macaulay(this.coeficiente / (this.exponente + 1),this.distanciaInicial,this.exponente + 1);
			else
				return new Macaulay(this.coeficiente,this.distanciaInicial,this.exponente + 1);
		}
	}
}
