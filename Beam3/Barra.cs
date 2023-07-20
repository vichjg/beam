using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSML;

namespace Beam3 {
	class Barra:Claro {
		double b, h, I=100, E=10000;
		public Matrix[,] matrizDeRigidezDelElemento = new Matrix[2,2];
		public Fuerza fuerzasExtremoi = new Fuerza();
		public Fuerza fuerzasExtremoj = new Fuerza();
		public Barra(double L):base(L) {
			base.l = L;

			matrizDeRigidezDelElemento[0,0] = new Matrix(new double[,] { { 12 * E * I / Math.Pow(L,3),6 * E * I / Math.Pow(L,2) },{ 6 * E * I / Math.Pow(L,2),4 * E * I / L } });
			matrizDeRigidezDelElemento[0,1] = new Matrix(new double[,] { { -12 * E * I / Math.Pow(L,3),6 * E * I / Math.Pow(L,2) },{ -6 * E * I / Math.Pow(L,2),2 * E * I / L } });
			matrizDeRigidezDelElemento[1,0] = new Matrix(new double[,] { { -12 * E * I / Math.Pow(L,3),-6 * E * I / Math.Pow(L,2) },{ 6 * E * I / Math.Pow(L,2),2 * E * I / L } });
			matrizDeRigidezDelElemento[1,1] = new Matrix(new double[,] { { 12 * E * I / Math.Pow(L,3),-6 * E * I / Math.Pow(L,2) },{ -6 * E * I / Math.Pow(L,2),4 * E * I / L } });
		}
	}
}
