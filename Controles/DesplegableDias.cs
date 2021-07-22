using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.UI.WebControls;

namespace Controles
{
    public class DesplegableDias : DropDownList
    {
        private int[] dias;

        public DesplegableDias() : base()
        {
            dias = new int[31];
            int unDia = 1;

            for (int i = 0; i <= dias.Length; i++)
            {
                if (unDia <= 31)
                {
                    dias[i] = unDia;
                    unDia++;
                }    
            }

            this.DataSource = dias;
            this.DataBind();
        }

        public int SeleccionarDia
        {
            get { return (this.SelectedIndex); }

            set
            {
                if (value >= 1 && value <= 31)
                    this.SelectedIndex = value;
                else
                    throw new InvalidCastException("El número asignado no corresponde a ningún dia.");
            }
        }


    }
}
