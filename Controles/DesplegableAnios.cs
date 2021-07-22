using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.UI.WebControls;

namespace Controles
{
    public class DesplegableAnios : DropDownList
    {
        private int[] anios;   
        private int anio_actual = DateTime.Now.Year;

        public DesplegableAnios() : base()
        {
            int tope = 25;
            int tamanio = 50;
            anios = new int[tamanio];

            for (int i = 0; i <= anios.Length; i++)
            {
                if ((i <= 24) && (anio_actual > anio_actual- tope))
                {
                    anios[i] = anio_actual - tope;
                    tope--;
                }

                if ((i > 24 && i < tamanio) && (anio_actual <= anio_actual + tope))
                {
                    anios[i] = anio_actual + tope;
                    tope++;
                }
            }

            this.DataSource = anios;
            this.DataBind();
        }

        public int SeleccionarAnio
        {
            get { return (this.SelectedIndex); }

            set
            {
                if (value > 0)
                    this.SelectedIndex = value;
                else
                    throw new InvalidCastException("El número asignado no corresponde a ningún año.");
            }
        }
    }
}
