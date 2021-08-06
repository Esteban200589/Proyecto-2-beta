using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

namespace Controles
{
    public class NoticiaIndividual : WebControl, INamingContainer
    {
        private Panel panel;
        private Label fecha;
        private Label titulo;
        private TextBox cuerpo;
        private TextBox importancia;
        private TextBox periodistas;
        private TextBox pais;
        private TextBox seccion;

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            panel = new Panel();

            //// titulo
            //titulo = new Label();
            //titulo.Text = "PERIODISTAS";
            //titulo.ForeColor = System.Drawing.Color.Black;
            //titulo.Font.Bold = true;
            //titulo.Font.Underline = true;

            //panel.Controls.Add(titulo);
            //panel.Controls.Add(new LiteralControl("<BR />"));

            //// agregar
            //btnAgregar = new Button();
            //btnAgregar.Text = "Agregar Tel";
            //btnAgregar.Click += new EventHandler(AgregarPeriodista);

            //panel.Controls.Add(btnAgregar);

            //// borrar
            //btnQuitar = new Button();
            //btnQuitar.Text = "Borrar Tel";
            //btnQuitar.Click += new EventHandler(QuitarPeriodista);

            //panel.Controls.Add(btnQuitar);

            //// listbox
            //lbPeriodistas = new ListBox();

            //panel.Controls.Add(lbPeriodistas);
            //panel.Controls.Add(new LiteralControl("<BR />"));


            //// textbox
            //txtCedula = new TextBox();
            //txtCedula.Text = "";
            //txtCedula.Controls.Add(txtCedula);

            //panel.Controls.Add(new LiteralControl("<BR />"));

            //// label
            //lblError = new Label();
            //lblError.Text = "";

            //agrego el panel al control costumizado
            this.Controls.Add(panel);

        }

    }


}
