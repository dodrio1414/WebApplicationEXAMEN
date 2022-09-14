using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class authors : System.Web.UI.Page
    {
        //Acceder al servicio web
        private static ServiceReference1.WebService1SoapClient servicio = new ServiceReference1.WebService1SoapClient();

        private void Listar()
        {
            gvExamen.DataSource = servicio.ListarAuthors().Tables[0];
            gvExamen.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Listar();
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string au_id = txtId.Text.Trim();
            string au_lname = TextApellido.Text.Trim();
            string au_fname = txtNombre.Text.Trim();
            string phone = TextTelf.Text.Trim();
            string address = TextDirec.Text.Trim();
            string city = TextCity.Text.Trim();
            string state = TextState.Text.Trim();
            int zip =  Convert.ToInt32(TextZip.Text.Trim());
            string contract = TextContract.Text.Trim();



            bool rsta = servicio.AgregarAuthors( au_id, au_lname, au_fname, phone, address, city, state, zip, contract);
            if (rsta)
            {
                Listar();
            }
            else Response.Write("<script>alert('No se agrego Authors');<script/>");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string au_id = txtId.Text.Trim();
            bool rsta = servicio.EliminarAuthors(au_id);
            if (rsta)
            {
                Listar();
            }
            else Response.Write("<script>alert('No se Elimino el Authors');<script/>");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string au_id = txtId.Text.Trim();
            string au_lname = TextApellido.Text.Trim();
            string au_fname = txtNombre.Text.Trim();
            string phone = TextTelf.Text.Trim();
            string address = TextDirec.Text.Trim();
            string city = TextCity.Text.Trim();
            string state = TextState.Text.Trim();
            int zip = Convert.ToInt32(TextZip.Text.Trim());
            string contract = TextContract.Text.Trim();

            //bool rsta = servicio.
            bool rsta = servicio.ActualizarAuthors(au_id, au_lname, au_fname, phone, address, city, state, zip, contract);
            if (rsta)
            {
                Listar();
            }
            else Response.Write("<script>alert('No se actualizo Authors');</script>");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string cod = txtBuscar.Text.Trim();
            string tipo = List.SelectedItem.Value.ToString();
            if (tipo == "Id")
            {
                gvExamen.DataSource = servicio.BuscarAuthors(cod, tipo).Tables[0];
                gvExamen.DataBind();
            }
            else if (tipo == "Nombre")
            {
                gvExamen.DataSource = servicio.BuscarAuthors(cod, tipo).Tables[0];
                gvExamen.DataBind();
            }
            else if (tipo == "Apellido")
            {
                gvExamen.DataSource = servicio.BuscarAuthors(cod, tipo).Tables[0];
                gvExamen.DataBind();
            }
        }
    }
}