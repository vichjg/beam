using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam3 {
	class FuerzaEnBarra{
		protected Fuerza fuerzai=new Fuerza(), fuerzaj=new Fuerza();
		protected Claro cl;

		public Fuerza Fuerzai { get { return this.fuerzai; } set { this.fuerzai=value; } }
		public Fuerza Fuerzaj { get { return this.fuerzaj; } set { this.fuerzaj=value; } }
		public Claro Cl { get { return cl; } set { this.cl=value; } }
	}
}
