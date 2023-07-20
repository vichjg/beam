using System;
using System.Collections.Generic;
using CSML;

namespace Beam3 {
	
	class Viga {
		int claroActual = 0;
		int nodoActual = 0;
		int coordenadaActual = 0;
		public List<Claro> claros = new List<Claro>();
		public Coordenada[] coordenadas;
		List<FuerzaEnBarra> listaDeCargas = new List<FuerzaEnBarra>();
		Fuerza[,] matrizDeFuerzasExternas;
		List<int> GDLR=new List<int>();
		List<int> GDLnR = new List<int>();
		Matrix K_E; // Matriz de rigidez reducida global de la estructura;
		Matrix P_E;
		//Matrix D;
		Matrix D_E;
		Matrix[] Deltas;
		Fuerza[,] matrizDeFuerzasExtremo;
		Fuerza[] reacciones;
		public Viga() {

			NuevoClaro(1.1);
			NuevoClaro(1.1);
			//NuevoClaro(7);
			//NuevoClaro(3);
			//QuitarUltimoClaro();

			DefineCoordenadas();

			NuevaCargaDistribuida(0,0,1.1,0.47,0.47);
			NuevaCargaDistribuida(1,0,1.1,0.47,0.47);
			/*NuevaCargaDistribuida(0,1,3,1,3);
			NuevaCargaPuntual(0,5,20);
			NuevaCargaPuntual(0,1,3);
			NuevaCargaDistribuida(1,1,2,1,4);
			NuevaCargaDistribuida(1,1,2,1,5);
			NuevaCargaPuntual(1,1,1);*/


			//			NuevaCargaDistribuida(0,2,6,10,5);
			//			NuevaCargaPuntual(0,3,5);

			//			NuevaCargaDistribuida(1,1,3,2,4);
			//			NuevaCargaPuntual(1,5,2);
			//NuevaCargaPuntual(1,1,5);
			//NuevaCargaPuntual(2,1,5);

			DefineMatrizDeFuerzasExternas();

			//imp(printF(matrizDeFuerzasExternas));

			coordenadas[0].RestriccionV = true;
			coordenadas[1].RestriccionV = true;
			coordenadas[2].RestriccionV = true;
			//coordenadas[2].RestriccionV = true;

			ObtenGDLR();

			EnsamblaK_E();

			ObtenP_E();

			ObtenD_E();

			ObtenFuerzasDeExtremo();

			ObtenReacciones();

//			imp("----------------------");
//			imp(EvaluaV(0,3));
//			imp(EvaluaM(0,3));

			//new CargaDistribuida(new Barra(10),2,6,10,5);//.Vtrapecio(10,10-2,10-6,10,5);
			//new CargaPuntual(new Barra(10),3,5);
			//imp(EvaluaM(1,0.8));
			Console.WriteLine();
		}

		public void DefineCoordenadas() {
			if(claros.Count == 0) { coordenadas = null; return; }
			coordenadas = new Coordenada[claros.Count + 1];
			coordenadas[0] = new Coordenada(0);
			coordenadaActual = 0;
			//coordenadas[0].Indice = coordenadaActual++;
			for(int i=0 ; i<claros.Count ; i++) {
				coordenadas[i+1] = new Coordenada(this.claros[i].L);
				coordenadas[i+1].Indice = coordenadaActual++;
			}
		}
		public void NuevoClaro(double L) {
			coordenadaActual = 0;
			Claro c = new Barra(L);
			//Barra b = new Barra(L);
			c.Indice = claroActual++;
			c.Nudoi = nodoActual;
			c.Nudof = ++nodoActual;
			claros.Add(c);
			DefineCoordenadas();
		}
		public void QuitarUltimoClaro() { claros.RemoveAt(claros.Count - 1); --claroActual; --nodoActual; DefineCoordenadas(); }
		public void NuevaCargaDistribuida(int indClaro, double a,double b,double qa,double qb) {
			if(indClaro < 0 || indClaro >= coordenadas.Length) {
				imp("no es posible aplicar carga distribuida, claro no encontrado");
				return;
			}
			Claro cl = claros[indClaro];
			if(a >= 0 && a <= claros[indClaro].L && b >= 0 && b <= claros[indClaro].L)	listaDeCargas.Add(new CargaDistribuida(ref cl,a,b,qa,qb));
			else imp("error al aplicar nueva carga distribuida, se sale de los limites");
			claros[indClaro] = cl;
		}
		public void NuevaCargaPuntual(int indClaro,double a,double p) {
			if(indClaro < 0 || indClaro >= coordenadas.Length) {
				imp("no es posible aplicar carga puntual, claro no encontrado");
				return;
			}
			Claro cl = claros[indClaro];
			if(a >= 0 && a <= claros[indClaro].L)	listaDeCargas.Add(new CargaPuntual(ref cl,a,p));
			else imp("error al aplicar nueva carga puntual, se sale de los limites");
			claros[indClaro] = cl;
		}
		public void DefineMatrizDeFuerzasExternas() {
			matrizDeFuerzasExternas = new Fuerza[coordenadas.Length,coordenadas.Length];
			for(int i=0 ; i < coordenadas.Length ; i++) {
				for(int j=0 ; j < coordenadas.Length ; j++) {
					matrizDeFuerzasExternas[i,j] = new Fuerza(); // inicializacion de los elemenstos de la matriz;
				}
			}
			// asignacion de la contribucion de los nudos en la matriz;
			for(int i=0 ; i < listaDeCargas.Count ; i++) {
				matrizDeFuerzasExternas[listaDeCargas[i].Fuerzai.Nudo,listaDeCargas[i].Fuerzai.Nudo] += listaDeCargas[i].Fuerzai;
				matrizDeFuerzasExternas[listaDeCargas[i].Fuerzai.Nudo,listaDeCargas[i].Fuerzaj.Nudo] += listaDeCargas[i].Fuerzai;
				matrizDeFuerzasExternas[listaDeCargas[i].Fuerzaj.Nudo,listaDeCargas[i].Fuerzai.Nudo] += listaDeCargas[i].Fuerzaj;
				matrizDeFuerzasExternas[listaDeCargas[i].Fuerzaj.Nudo,listaDeCargas[i].Fuerzaj.Nudo] += listaDeCargas[i].Fuerzaj;
			}
		}

		public void ObtenGDLR() {
			GDLR = new List<int>();
			GDLnR = new List<int>();
			for(int i=0 ; i<coordenadas.Length ; i++) {
				GDLnR.Add(i * 2 + 0);
				GDLnR.Add(i * 2 + 1);
				if(coordenadas[i].RestriccionM) {
					GDLR.Add(i * 2 + 0);
					GDLR.Add(i * 2 + 1);
					GDLnR.Remove(i * 2 + 0);
					GDLnR.Remove(i * 2 + 1);
				}
				else if(coordenadas[i].RestriccionV) {
					GDLR.Add(i * 2 + 0);
					GDLnR.Remove(i * 2 + 0);
				}
			}
		}
		/*public void ObtenGDLnR() {
			for(int i = 0 ; i < coordenadas.Length ; i++) {
				if(!GDLR[i].re).rest) GDLnR.Add();
				} else if(coordenadas[i].RestriccionV)
					GDLR.Add(i * 2 + 0);
			}
		}*/

		public void EnsamblaK_E() {
			Matrix[,] K = new Matrix[coordenadas.Length,coordenadas.Length];
			for(int i = 0 ; i < coordenadas.Length ; i++) {
				for(int j = 0 ; j < coordenadas.Length ; j++) {
					K[i,j] = new Matrix(2);
				}
			}
			for(int i = 0 ; i < claros.Count ; i++) {
				K[claros[i].Nudoi,claros[i].Nudoi] += ((Barra)claros[i]).matrizDeRigidezDelElemento[0,0];
				K[claros[i].Nudoi,claros[i].Nudof] += ((Barra)claros[i]).matrizDeRigidezDelElemento[0,1];
				K[claros[i].Nudof,claros[i].Nudoi] += ((Barra)claros[i]).matrizDeRigidezDelElemento[1,0];
				K[claros[i].Nudof,claros[i].Nudof] += ((Barra)claros[i]).matrizDeRigidezDelElemento[1,1];
			}

			K_E = new Matrix(2*coordenadas.Length);

			for(int i = 0 ; i < coordenadas.Length ; i++) {
				for(int j = 0 ; j < coordenadas.Length ; j++) {
					K_E[2 * i + 1,2 * j + 1] = K[i,j][1,1];
					K_E[2 * i + 1,2 * j + 2] = K[i,j][1,2];
					K_E[2 * i + 2,2 * j + 1] = K[i,j][2,1];
					K_E[2 * i + 2,2 * j + 2] = K[i,j][2,2];
				}
			}

			for(int i = GDLR.Count -1 ; i >= 0 ; i--) {
				K_E.DeleteRow(GDLR[i] + 1);
				K_E.DeleteColumn(GDLR[i] + 1);
			}
			//imp(K_E.ToString());
		}
		public void ObtenP_E() {
			P_E = new Matrix(new Complex[2 * coordenadas.Length]);
			for(int i = 0 ; i < coordenadas.Length ; i++) {
				P_E[2 * i + 1].Re = matrizDeFuerzasExternas[i,i].V;
				P_E[2 * i + 2].Re = matrizDeFuerzasExternas[i,i].M;
			}
			for(int i = GDLR.Count - 1 ; i >= 0 ; i--) {
				P_E.DeleteRow(GDLR[i] + 1);
			}
			//imp(P_E.ToString());
		}
		public void ObtenD_E() {
			D_E = K_E.Inverse() * P_E;
			int c = 1;
			for(int i = 0 ; i < 2*coordenadas.Length ; i++) {
				if(GDLnR.Contains(i)) {
					if(i % 2 == 0) {
						coordenadas[i / 2].deltaV = D_E[c].Re;
						c++;
					}
					if(i % 2 == 1) {
						coordenadas[(i-1) / 2].deltaM = D_E[c].Re;
						c++;
					}
				}
			}
			Deltas = new Matrix[coordenadas.Length];
			for(int i = 0 ; i < coordenadas.Length ; i++) {
				Deltas[i] = new Matrix(new double[] { 0.0,0.0 });
			}
			for(int i = 0 ; i < coordenadas.Length ; i++) {
				Deltas[i][1].Re = coordenadas[i].deltaV;
				Deltas[i][2].Re = coordenadas[i].deltaM;
			}
			//imp(D_E); 
		}
		public void ObtenFuerzasDeExtremo() {
			matrizDeFuerzasExtremo = new Fuerza[coordenadas.Length,coordenadas.Length];
			for(int i = 0 ; i < coordenadas.Length ; i++) {
				for(int j = 0 ; j < coordenadas.Length ; j++) {
					matrizDeFuerzasExtremo[i,j] = new Fuerza(); // inicializacion de los elemenstos de la matriz;
				}
			}
			for(int i = 0 ; i < claros.Count ; i++) {
				((Barra)claros[i]).fuerzasExtremoi.V = 0;
				((Barra)claros[i]).fuerzasExtremoi.M = 0;
				((Barra)claros[i]).fuerzasExtremoj.V = 0;
				((Barra)claros[i]).fuerzasExtremoj.M = 0;
			}
			// asignacion de la contribucion de los nudos en la matriz;
			for(int i = 0 ; i < claros.Count ; i++) {
				((Barra)claros[i]).fuerzasExtremoi.V += -matrizDeFuerzasExternas[claros[i].Nudoi,claros[i].Nudof].V + (((Barra)claros[i]).matrizDeRigidezDelElemento[0,0] * Deltas[claros[i].Nudoi])[1].Re + (((Barra)claros[i]).matrizDeRigidezDelElemento[0,1] * Deltas[claros[i].Nudof])[1].Re;
				((Barra)claros[i]).fuerzasExtremoi.M += -matrizDeFuerzasExternas[claros[i].Nudoi,claros[i].Nudof].M + (((Barra)claros[i]).matrizDeRigidezDelElemento[0,0] * Deltas[claros[i].Nudoi])[2].Re + (((Barra)claros[i]).matrizDeRigidezDelElemento[0,1] * Deltas[claros[i].Nudof])[2].Re;
				//se repite para V y M;
				((Barra)claros[i]).fuerzasExtremoj.V += -matrizDeFuerzasExternas[claros[i].Nudof,claros[i].Nudoi].V + (((Barra)claros[i]).matrizDeRigidezDelElemento[1,0] * Deltas[claros[i].Nudoi])[1].Re + (((Barra)claros[i]).matrizDeRigidezDelElemento[1,1] * Deltas[claros[i].Nudof])[1].Re;
				((Barra)claros[i]).fuerzasExtremoj.M += -matrizDeFuerzasExternas[claros[i].Nudof,claros[i].Nudoi].M + (((Barra)claros[i]).matrizDeRigidezDelElemento[1,0] * Deltas[claros[i].Nudoi])[2].Re + (((Barra)claros[i]).matrizDeRigidezDelElemento[1,1] * Deltas[claros[i].Nudof])[2].Re;
			}
			for(int i = 0 ; i < claros.Count ; i++) {
				if(Math.Abs(((Barra)claros[i]).fuerzasExtremoi.V) < 0.000000001) ((Barra)claros[i]).fuerzasExtremoi.V = 0.0;
				if(Math.Abs(((Barra)claros[i]).fuerzasExtremoi.M) < 0.000000001) ((Barra)claros[i]).fuerzasExtremoi.M = 0.0;
				if(Math.Abs(((Barra)claros[i]).fuerzasExtremoj.V) < 0.000000001) ((Barra)claros[i]).fuerzasExtremoj.V = 0.0;
				if(Math.Abs(((Barra)claros[i]).fuerzasExtremoj.M) < 0.000000001) ((Barra)claros[i]).fuerzasExtremoj.M = 0.0;


				imp(((Barra)claros[i]).fuerzasExtremoi.V);
				imp(((Barra)claros[i]).fuerzasExtremoi.M);
				imp(((Barra)claros[i]).fuerzasExtremoj.V);
				imp(((Barra)claros[i]).fuerzasExtremoj.M);
			}
			for(int i = 0 ; i < claros.Count ; i++) {
				claros[i].vMacaulays.Clear();
				claros[i].vMacaulays.Add(new Macaulay(((Barra)claros[i]).fuerzasExtremoi.V,0,0));
				for(int j = 0 ; j < claros[i].qMacaulays.Count ; j++) {
					for(int k = 0 ; k < claros[i].qMacaulays[j].Count ; k++) {
						claros[i].vMacaulays.Add(claros[i].qMacaulays[j][k].Integral());
					}
				}
			}
			for(int i = 0 ; i < claros.Count ; i++) {
				claros[i].mMacaulays.Clear();
				claros[i].mMacaulays.Add(new Macaulay(-((Barra)claros[i]).fuerzasExtremoi.M,0,0));
				for(int j = 0 ; j < claros[i].vMacaulays.Count ; j++) {
					claros[i].mMacaulays.Add(claros[i].vMacaulays[j].Integral());
				}
			}
		}
		public void ObtenReacciones() {

		}
		public double EvaluaV(int indiceClaro, double x) {
			double result = 0;
			foreach(Macaulay mC in claros[indiceClaro].vMacaulays) {
				result += mC[x];
			}
			return result;
		}
		public double EvaluaM(int indiceClaro,double x) {
			double result = 0;
			foreach(Macaulay mC in claros[indiceClaro].mMacaulays) {
				result += mC[x];
			}
			return result;
		}
		public static void imp(dynamic valor) {
			Console.WriteLine();
			Console.WriteLine(valor);
			Console.WriteLine();
		}
		public string printF(Fuerza[,] f) {
			string texto = "\n";

			for(int i = 0 ; i < this.coordenadas.Length ; i++) {
				for(int j = 0 ; j < this.coordenadas.Length ; j++) {
					texto = texto + "\t M=" + this.matrizDeFuerzasExternas[i,j].M + ", V=" + this.matrizDeFuerzasExternas[i,j].V;
					texto = texto + " | ";
				}
				texto = texto + "\n";
			}
			texto = texto + "\n";
			return texto;
		}
	}
}