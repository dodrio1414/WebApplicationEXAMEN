using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class employee : System.Web.UI.Page
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
            string emp_id = txtId.Text.Trim();
            string fname = txtNombre.Text.Trim();
            string minit = TextMinit.Text.Trim();
            string lname = TextLastname.Text.Trim();
            int job_id = Convert.ToInt32(Textjob_id.Text.Trim());
            int job_lvl = Convert.ToInt32(Textjob_lvl.Text.Trim());
            string pub_id = Textpub_id.Text.Trim();

            DateTime hire_date = Convert.ToDateTime(Texthire_date.Text.Trim());



            bool rsta = servicio.AgregarEmployee(emp_id, fname, minit, lname, job_id, job_lvl, pub_id, hire_date);
            if (rsta)
            {
                Listar();
            }
            else Response.Write("<script>alert('No se agrego Empleados nuevos');<script/>");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string emp_id = txtId.Text.Trim();
            bool rsta = servicio.EliminarEmployee(emp_id);
            if (rsta)
            {
                Listar();
            }
            else Response.Write("<script>alert('No se Elimino el Empleado');<script/>");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string emp_id = txtId.Text.Trim();
            string fname = txtNombre.Text.Trim();
            string minit = TextMinit.Text.Trim();
            string lname = TextLastname.Text.Trim();
            int job_id = Convert.ToInt32(Textjob_id.Text.Trim());
            int job_lvl = Convert.ToInt32(Textjob_lvl.Text.Trim());
            string pub_id = Textpub_id.Text.Trim();

            DateTime hire_date = Convert.ToDateTime(Texthire_date.Text.Trim());


            //bool rsta = servicio.
            bool rsta = servicio.ActualizarEmployee(emp_id, fname, minit, lname, job_id, job_lvl, pub_id, hire_date);
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
                gvExamen.DataSource = servicio.BuscarEmployee(cod, tipo).Tables[0];
                gvExamen.DataBind();
            }
            else if (tipo == "Nombre")
            {
                gvExamen.DataSource = servicio.BuscarEmployee(cod, tipo).Tables[0];
                gvExamen.DataBind();
            }
            else if (tipo == "Apellido")
            {
                gvExamen.DataSource = servicio.BuscarEmployee(cod, tipo).Tables[0];
                gvExamen.DataBind();
            }
        }
    }
}