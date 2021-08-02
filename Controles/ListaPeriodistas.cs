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
    public class ListaPeriodistas : WebControl, INamingContainer
    {
        private Panel panel;
        private Label titulo;
        private Button btnAgregar;
        private Button btnQuitar;
        private TextBox txtCedula;
        private TextBox txtNombre;
        private TextBox txtEmail;
        private ListBox lbPeriodistas;
        private Label lblError;
        

        public List<Periodista> lista_ptas
        {
            get
            {
                List<Periodista> listado = new List<Periodista>();

                foreach (ListItem pta in lbPeriodistas.Items)
                {
                    listado.Add(new Periodista(txtCedula.Text,txtNombre.Text,txtEmail.Text));
                }
                return listado;
            }

            set
            {
                lbPeriodistas.Items.Clear();
                foreach (Periodista p in value)
                {
                    lbPeriodistas.Items.Add(p.Nombre);
                }
            }
        }

       
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            panel = new Panel();

            // titulo
            titulo = new Label();
            titulo.Text = "PERIODISTAS";
            titulo.ForeColor = System.Drawing.Color.Black;
            titulo.Font.Bold = true;
            titulo.Font.Underline = true;

            panel.Controls.Add(titulo);
            panel.Controls.Add(new LiteralControl("<BR />"));

            // agregar
            btnAgregar = new Button();
            btnAgregar.Text = "Agregar Tel";
            btnAgregar.Click += new EventHandler(AgregarPeriodista);

            panel.Controls.Add(btnAgregar);

            // borrar
            btnQuitar = new Button();
            btnQuitar.Text = "Borrar Tel";
            btnQuitar.Click += new EventHandler(QuitarPeriodista);

            panel.Controls.Add(btnQuitar);

            // listbox
            lbPeriodistas = new ListBox();
            
            panel.Controls.Add(lbPeriodistas);
            panel.Controls.Add(new LiteralControl("<BR />"));


            // textbox
            txtCedula = new TextBox();
            txtCedula.Text = "";
            txtCedula.Controls.Add(txtCedula);
            
            panel.Controls.Add(new LiteralControl("<BR />"));

            // label
            lblError = new Label();
            lblError.Text = "";

            //agrego el panel al control costumizado
            this.Controls.Add(panel);

        }


        protected void AgregarPeriodista(object sender, EventArgs e)
        {
            if (txtCedula.Text.Trim().Length > 0)
            {
                lbPeriodistas.Items.Add(txtCedula.Text.Trim());
                txtCedula.Text = "";
                lblError.Text = "Se agrego Correctamente el Periodista a la Lista";
            }
            else
                lblError.Text = "No se Pudo agregar el Periodista a la lista";
        }

        protected void QuitarPeriodista(object sender, EventArgs e)
        {
            //determino si hay una linea de la lista seleccionada
            if (lbPeriodistas.SelectedIndex >= 0)
            {
                lbPeriodistas.Items.RemoveAt(lbPeriodistas.SelectedIndex);
                lbPeriodistas.Text = "Se eliminó el Periodista de la Lista con Exito";
            }
            else
                lblError.Text = "Debe Seleccionar un Periodisya de la lista para eliminar";
        }

        public void LimpiarTodo()
        {
            lbPeriodistas.Items.Clear();
        }
    }
}
