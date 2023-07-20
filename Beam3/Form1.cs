using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CSML;

namespace Beam3 {
	public partial class Form1:Form {
		//List<TabPage> listaDePaginas = new List<TabPage>();
		Viga pruebaViga = new Viga();
		/*int claroActual = 0;
		int nodoActual = 0;
		int coordenadaActual = 0;
		List<Claro> claros = new List<Claro>();
		Coordenada[] coordenadas;
		List<FuerzaEnBarra> listaDeCargas = new List<FuerzaEnBarra>();
		Fuerza[,] matrizDeFuerzasExternas;
		List<int> GDLR = new List<int>();
		List<int> GDLnR = new List<int>();
		Matrix K_E; // Matriz de rigidez reducida global de la estructura;
		Matrix P_E;
		//Matrix D;
		Matrix D_E;
		Matrix[] Deltas;
		Fuerza[,] matrizDeFuerzasExtremo;
		Fuerza[] reacciones;*/


		Cargas ventanaCargas = new Cargas();
		Apoyos ventanaApoyos = new Apoyos();


		public Form1() {
			InitializeComponent();
		}
		/*private void DefineCoordenadas() {
			coordenadaActual = 0;
			coordenadas = new Coordenada[claros.Count + 1];
			coordenadas[0] = new Coordenada(0);
			//coordenadas[0].Indice = coordenadaActual++;
			for(int i = 0 ; i < claros.Count ; i++) {
				coordenadas[i + 1] = new Coordenada(this.claros[i].L);
				coordenadas[i + 1].Indice = coordenadaActual++;
			}
		}*/

		/*public void NuevoClaro() {
			if(!(this.textBoxLongitud.Text == null || this.textBoxLongitud.Text == "")) {
				Claro c = new Barra(Convert.ToDouble(this.textBoxLongitud.Text));
				c.Indice = claroActual++;
				c.Nudoi = nodoActual;
				c.Nudof = ++nodoActual;
				claros.Add(c);
				DefineCoordenadas();
				this.textBoxLongitud.Text = "";
			}
		}*/
		//private void QuitarUltimoClaro() { claros.RemoveAt(claros.Count - 1); --claroActual; --nodoActual; DefineCoordenadas(); }
		public void NuevoClaro() {
			if(!(this.textBoxLongitud.Text == null || this.textBoxLongitud.Text == "")) {
				pruebaViga.NuevoClaro(Convert.ToDouble(this.textBoxLongitud.Text));
				this.textBoxLongitud.Text = "";
				//ventanaApoyos.coordenadas = pruebaViga.coordenadas;
				//ventanaApoyos.EstablecerApoyos();
			}
		}
	#region tabcontrol
	//tabControl1.Size = new Size(this.Bounds.Width,this.Bounds.Height);

	/*listaDePaginas.Add(new TabNueva("pagina1"));
	listaDePaginas.Add(new TabNueva("    +"));

	/*this.tabControl1.Controls.Add(listaDePaginas[0]);
	this.tabControl1.Controls.Add(listaDePaginas[1]);

	/*Button b = new Button();
	b.Text = "x";
	//b.AutoSize = true;
	b.Parent = this.tabControl1;
	b.Location = new Point(5,200); //rect.Right - b.Width - 3,rect.Top + 3);
	b.Tag = 1;
	//b.Click += CloseTab_ButtonClick;
	closeButtons.Add(b);*/

	//SetTabButtons();
	/*}
	private void seleccionado(object sender,TabControlEventArgs e) {

		if(e.TabPage.Name=="    +") {
			//this.listaDePaginas.Add(new TabNueva());

			TabPage aux = listaDePaginas[listaDePaginas.Count - 1];
			listaDePaginas[listaDePaginas.Count - 1] = new TabPage("otra");
			listaDePaginas.Add(aux);
			this.tabControl1.TabPages[this.tabControl1.TabPages.Count - 1] = listaDePaginas[listaDePaginas.Count - 2];
			this.tabControl1.TabPages.Add(aux);
		}
	}*/
	///
	/// <summary>mouseEvent</summary>
	/// 
	///
	/*
	public void OnMouseDown(object sender,MouseEventArgs e) {
		switch(e.Button) {
			case MouseButtons.Left:
				MessageBox.Show(this,"Left Button Click");
				break;
			case MouseButtons.Right:
				MessageBox.Show(this,"Right Button Click");
				break;
			case MouseButtons.Middle:
				MessageBox.Show(this,"Middle Button Click");
				break;
			default:
				break;
		}
	}

	private void OnMouseMove(object sender,MouseEventArgs e) {
		this.Text = "Mouse Position:" + e.X.ToString() + "," + e.Y.ToString();
	}*/
	/*private void NuevaPestagna() {
		this.listaDePaginas.Add(new TabNueva());
		this.tabControl1.TabPages.Add(listaDePaginas.Last());
	}*/
	/*private void SetTabButtons() {
		// first remove all existing buttons
		for(int i = 0 ; i < closeButtons.Count ; i++)
			closeButtons[i].Parent = null;
		closeButtons.Clear();
		// create the close buttons
		for(int i = 0 ; i < this.tabControl1.TabPages.Count ; i++) {
			// add some spaces to tab text for the close button
			this.tabControl1.TabPages[i].Text = this.tabControl1.TabPages[i].Text + "     ";
			Rectangle rect = this.tabControl1.GetTabRect(i);
			//this.tabControl1.Location = new System.Drawing.Point(1,1);
			Button b = new Button();
			b.Text = "x";
			b.AutoSize = true;
			b.Parent = this;
			b.Location = new Point(5,200); //rect.Right - b.Width - 3,rect.Top + 3);
			b.Tag = i;
			b.Click += CloseTab_ButtonClick;
			closeButtons.Add(b);
		}
	}

	private void CloseTab_ButtonClick(object sender,EventArgs e) {
		int theTabPageIndex = (int)((Button)sender).Tag;
		// remove the tabpage here 

		// reset the buttons
		SetTabButtons();
	}*/
	#endregion
		private void Dibujar() {
			/*using(Graphics g = panel.CreateGraphics()) {
				g.DrawLine(new Pen(Color.White,3),new Point(45,86),new Point(293,228));
			}*/
			using(Graphics g = panel.CreateGraphics()) {
				for(int i = 0 ; i < pruebaViga.claros.Count ; i++) {
					g.DrawLine(new Pen(Color.White),pruebaViga.claros[i].punto1,pruebaViga.claros[i].punto2);
				}
				if(pruebaViga.coordenadas != null) {
					for(int i = 0 ; i < pruebaViga.coordenadas.Length ; i++) {
						if(pruebaViga.coordenadas[i].apoyo.Length==0)
							continue;
						g.DrawLines(new Pen(Color.White),pruebaViga.coordenadas[i].apoyo);
					}
				}
			}
		}
		private void DimensionesClaros() {
			int separacion = 20;
			double longitudTotal = LongitudHastaLaCoordenada(pruebaViga.claros.Count);
			double anchoEfectivo = panel.Width - 2 * separacion;
			double r = anchoEfectivo / longitudTotal;
			double h = panel.Height / 2;
			for(int i = 0 ; i < pruebaViga.claros.Count ; i++) 
			{
				pruebaViga.claros[i].punto1 = new Point((int)(r * LongitudHastaLaCoordenada(pruebaViga.claros[i].Nudoi) + separacion),(int)h);
				pruebaViga.claros[i].punto2 = new Point((int)(r * LongitudHastaLaCoordenada(pruebaViga.claros[i].Nudof) + separacion),(int)h);
			}
			for(int i = 0 ; i < pruebaViga.coordenadas.Length ; i++) {
				pruebaViga.coordenadas[i].panelPosicion=new Point((int)(r * LongitudHastaLaCoordenada(i) + separacion),(int)h);
			}

			panel.Refresh();
		}

		private double LongitudHastaLaCoordenada(int a) {
			//--a;
			double result=0;
			if(a > pruebaViga.claros.Count) return 0;
			for(int i = 0 ; i < a ; i++) {
				result += pruebaViga.claros[i].L;
			}
			return result;
		}

		private void botonNuevoClaro_Click(object sender,EventArgs e) {
			NuevoClaro();
			DimensionesClaros();
		}
		
		private void textBoxLongitud_KeyPress(object sender,KeyPressEventArgs e) {
			if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
				e.Handled = true;
			if((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
				e.Handled = true;
			if((e.KeyChar == (char)Keys.Enter)) {
				NuevoClaro();
				e.Handled = true;
			}
		}

		private void botonTablaDeCargas_Click(object sender,EventArgs e) {
			//ventanaCargas.form1 = this;
			DimensionesClaros();
			ventanaCargas.pruebaViga = pruebaViga;
			if(ventanaCargas.ShowDialog(this) == DialogResult.OK) {
				pruebaViga = ventanaCargas.pruebaViga;
			}
		}

		private void botonQuitarUltimoClaro_Click(object sender,EventArgs e) {
			if(pruebaViga.claros.Count==1) {
				pruebaViga.QuitarUltimoClaro();
				ventanaApoyos.coordenadas = pruebaViga.coordenadas;
				ventanaApoyos.QuitarUltimoApoyo();
				ventanaApoyos.QuitarUltimoApoyo();
				ventanaApoyos.EstablecerApoyos();
			}
			else if(pruebaViga.claros.Count>1) {
				pruebaViga.QuitarUltimoClaro();
				ventanaApoyos.coordenadas = pruebaViga.coordenadas;
				ventanaApoyos.QuitarUltimoApoyo();
				ventanaApoyos.EstablecerApoyos();
			}
		}

		private void botonApoyos_Click(object sender,EventArgs e) {
			DimensionesClaros();
			ventanaApoyos.coordenadas = pruebaViga.coordenadas;
			ventanaApoyos.EstablecerApoyos();
			if(ventanaApoyos.ShowDialog() == DialogResult.OK) {
				pruebaViga.coordenadas = ventanaApoyos.coordenadas;
				DimensionesClaros();
			}
			if(ventanaApoyos.ShowDialog() == DialogResult.Cancel) {
				pruebaViga.coordenadas = ventanaApoyos.coordenadas;
				DimensionesClaros();
			}
			/*ventanaApoyos.Show();
			pruebaViga.coordenadas = ventanaApoyos.coordenadas;*/
		}

		private void botonCalcular_Click(object sender,EventArgs e) {
			pruebaViga.DefineMatrizDeFuerzasExternas();
			pruebaViga.ObtenGDLR();
			pruebaViga.EnsamblaK_E();
			pruebaViga.ObtenP_E();
			pruebaViga.ObtenD_E();
			pruebaViga.ObtenFuerzasDeExtremo();
			pruebaViga.ObtenReacciones();
			DimensionesClaros();
			panel.Refresh();
		}

		private void panel_Paint(object sender,PaintEventArgs e) {
			//Graphics g = this.panel.CreateGraphics();
			Dibujar();

			/*Pen white = new Pen(Brushes.White);
			Graphics g = this.panel.CreateGraphics();
			g.DrawLine(white,20,20,panel.Width - 20,panel.Height-20);
			white.Dispose();*/
			//g.Dispose();
		}
	}
}
