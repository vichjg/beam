using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSML;

namespace Beam3 {
	class FuerzasExternas {
		Matrix fzs = new Matrix();

		//public Complex this[int i] { get { return this.fzs[i]; } set { this.fzs[i] = value; } }
		public Complex this[int i,int j] { get { return this.fzs[i,j]; } set { this.fzs[i,j] = value; } }
		public FuerzasExternas(){}
		public FuerzasExternas(int n) {
			this.fzs = new Matrix(n);
		}
	}
}
