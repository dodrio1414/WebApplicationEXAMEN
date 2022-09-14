using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebClient
{
    public partial class titleauthor : System.Web.UI.Page
    {

        //Acceder al servicio web
        private static ServiceReference1.WebService1SoapClient servicio = new ServiceReference1.WebService1SoapClient();

        private void Listar()
        {
            gvExamen.DataSource = servicio.ListarEmployee().Tables[0];
            gvExamen.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Listar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string au_id = txtau_id.Text.Trim();
            string title_id = Texttitle_id.Text.Trim();
            int au_ord = Convert.ToInt32(Textau_ord.Text.Trim());
            int royaltyper = Convert.ToInt32(Textroyaltyper.Text.Trim());
            bool rsta = servicio.AgregarTitleauthor(au_id, title_id, au_ord, royaltyper);
            if (rsta)
            {
                Listar();
            }
            else Response.Write("<script>alert('No se agrego Titulos nuevos');<script/>");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string au_id = txtau_id.Text.Trim();
            bool rsta = servicio.EliminarTitleauthor(au_id);
            if (rsta)
            {
                Listar();
            }
            else Response.Write("<script>alert('No se Elimino el Empleado');<script/>");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string au_id = txtau_id.Text.Trim();
            string title_id = Texttitle_id.Text.Trim();
            int au_ord = Convert.ToInt32(Textau_ord.Text.Trim());
            int royaltyper = Convert.ToInt32(Textroyaltyper.Text.Trim());
            
            //bool rsta = servicio.
            bool rsta = servicio.ActualizarTitleauthor(au_id, title_id, au_ord, royaltyper);
            if (rsta)
            {
                Listar();
            }
            else Response.Write("<script>alert('No se actualizo los Empleados');</script>");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string cod = txtBuscar.Text.Trim();
            string tipo = List.SelectedItem.Value.ToString();
            if (tipo == "Id")
            {
                gvExamen.DataSource = servicio.BuscarTitleauthor(cod, tipo).Tables[0];
                gvExamen.DataBind();
            }
            else if (tipo == "Id del autor")
            {
                gvExamen.DataSource = servicio.BuscarTitleauthor(cod, tipo).Tables[0];
                gvExamen.DataBind();
            }
            
        }
    }
}