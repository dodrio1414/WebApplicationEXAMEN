using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplicationEXAMEN
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]

    public class WebService1 : System.Web.Services.WebService
    {
        //Accesder a la cadena de conexion o enrutamiento
        //por medio de una variable privada extraemos el enrutamiento a la base de datos de SQL server
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        //empaquetar el string "cadena" para llevar a la base de datos
        //uso del enrutamiento
        private static SqlConnection conexion = new SqlConnection(cadena);


        //
        ////METODOS LISTAR
        //

        //Entorno desconectado
        //No tenemos q aperturar conexion y desconeccion es automatico
        [WebMethod(Description = "Listar la tabla authors")]
        public DataSet ListarAuthors()
        {
            //la consulta sql que se va hacer a la DB
            string consulta = "select * from authors";
            //entorno desconectado para acceder a la tabla TEscuela
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);

            //metodo para setear los datos a algun lado
            DataSet data = new DataSet();
            //adaptar los datos a un adapter
            adapter.Fill(data);
            return data;
        }

        //Entorno desconectado
        //No tenemos q aperturar conexion y desconeccion es automatico
        [WebMethod(Description = "Listar la tabla employee")]
        public DataSet ListarEmployee()
        {
            //la consulta sql que se va hacer a la DB
            string consulta = "select * from employee";
            //entorno desconectado para acceder a la tabla TEscuela
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);

            //metodo para setear los datos a algun lado
            DataSet data = new DataSet();
            //adaptar los datos a un adapter
            adapter.Fill(data);
            return data;
        }


        //Entorno desconectado
        //No tenemos q aperturar conexion y desconeccion es automatico
        [WebMethod(Description = "Listar la tabla titleauthor")]
        public DataSet ListarTitleauthor()
        {
            //la consulta sql que se va hacer a la DB
            string consulta = "select * from titleauthor";
            //entorno desconectado para acceder a la tabla TEscuela
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);

            //metodo para setear los datos a algun lado
            DataSet data = new DataSet();
            //adaptar los datos a un adapter
            adapter.Fill(data);
            return data;
        }



        //
        ////METODOS AGREGAR
        //

        //Entorno conectado
        //Servicios criticos como eliminar o agregar datos
        //tenemos q aperturar conexion y desconeccion
        [WebMethod(Description = "Agregar un registro a la tabla authors")]
        public bool AgregarAuthors(string au_id,string au_lname, string au_fname, string phone, string address, string city, string state, int zip, string contract)
        {

            try
            {
                //la consulta sql que se va hacer a la DB
                string consulta = "insert into authors values ('" + au_id + "','" + au_lname + "','" + au_fname + "','" + phone + "','" + address + "','" + city + "','" + state + "','" + zip + "','" + contract + "')";
                //Entorno de conexion 
                //procesos criticos donde yo genero al tipo de conexion
                SqlCommand comando = new SqlCommand(consulta, conexion);
                //abirmos la conexion a la DB
                conexion.Open();
                //ejecutar la consulta para addItem to data base
                //nos devuelve cuantos registros se hicieron o se ejecutaron
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                //cerramos conexion
                conexion.Close();
                //condicional si se agrego datos o no
                if (i == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }


        [WebMethod(Description = "Agregar un registro a la tabla employee")]
        public bool AgregarEmployee(string emp_id, string fname, string minit, string lname, int job_id, int job_lvl, string pub_id, DateTime hire_date)
        {

            try
            {
                //la consulta sql que se va hacer a la DB
                string consulta = "insert into employee values ('" + emp_id + "','" + fname + "','" + minit + "','" + lname + "','" + job_id + "','" + job_lvl + "','" + pub_id + "','" + hire_date +"')";
                //Entorno de conexion 
                //procesos criticos donde yo genero al tipo de conexion
                SqlCommand comando = new SqlCommand(consulta, conexion);
                //abirmos la conexion a la DB
                conexion.Open();
                //ejecutar la consulta para addItem to data base
                //nos devuelve cuantos registros se hicieron o se ejecutaron
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                //cerramos conexion
                conexion.Close();
                //condicional si se agrego datos o no
                if (i == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }


        [WebMethod(Description = "Agregar un registro a la tabla titleauthor")]
        public bool AgregarTitleauthor(string au_id, string title_id, int au_ord, int royaltyper)
        {

            try
            {
                //la consulta sql que se va hacer a la DB
                string consulta = "insert into titleauthor values ('" + au_id + "','" + title_id + "','" + au_ord + "','" + royaltyper + "')";
                //Entorno de conexion 
                //procesos criticos donde yo genero al tipo de conexion
                SqlCommand comando = new SqlCommand(consulta, conexion);
                //abirmos la conexion a la DB
                conexion.Open();
                //ejecutar la consulta para addItem to data base
                //nos devuelve cuantos registros se hicieron o se ejecutaron
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                //cerramos conexion
                conexion.Close();
                //condicional si se agrego datos o no
                if (i == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }

        //
        ////METODOS ELIMINAR
        //

        //Eliminar
        [WebMethod(Description = "Eliminar un authors")]
        public bool EliminarAuthors(string au_id)
        {
            try
            {
                string consulta = "delete from authors where au_id = @au_id";
                SqlCommand command = new SqlCommand(consulta, conexion);
                command.Parameters.AddWithValue("@au_id", au_id);
                conexion.Open();
                byte i = Convert.ToByte(command.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            //si o si se ejecuta al compilar todo este fragmento de codigo y cierra la conexion
            finally
            {
                conexion.Close();
            }

        }





        [WebMethod(Description = "Eliminar un employee")]
        public bool EliminarEmployee(string emp_id)
        {
            try
            {
                string consulta = "delete from employee where emp_id = @emp_id";
                SqlCommand command = new SqlCommand(consulta, conexion);
                command.Parameters.AddWithValue("@emp_id", emp_id);
                conexion.Open();
                byte i = Convert.ToByte(command.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            //si o si se ejecuta al compilar todo este fragmento de codigo y cierra la conexion
            finally
            {
                conexion.Close();
            }

        }






        [WebMethod(Description = "Eliminar un titleauthor")]
        public bool EliminarTitleauthor(string au_id)
        {
            try
            {
                string consulta = "delete from titleauthor where au_id = @au_id";
                SqlCommand command = new SqlCommand(consulta, conexion);
                command.Parameters.AddWithValue("@au_id", au_id);
                conexion.Open();
                byte i = Convert.ToByte(command.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            //si o si se ejecuta al compilar todo este fragmento de codigo y cierra la conexion
            finally
            {
                conexion.Close();
            }

        }




        //
        ////METODOS BUSCAR
        //

        //Buscar
        [WebMethod(Description = "Buscar en la tabla authors")]
        public DataSet BuscarAuthors(string texto, string criterio)
        {
            string consulta = string.Empty;
            SqlCommand comando;
            SqlDataAdapter adapter;
            DataSet data = new DataSet();
            if (criterio == "Id")
            {
                // Busqueda exacta
                consulta = "select * from authors where au_id = @texto";
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@texto", texto);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(data);
            }
            else if (criterio == "Nombre")
            {
                // Busqueda sensitiva
                consulta = "select * from authors where au_fname like @texto + '%'";
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@texto", texto);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(data);
            }
            else if (criterio == "Apellido")
            {
                // Busqueda sensitiva
                consulta = "select * from authors where au_lname like @texto + '%'";
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@texto", texto);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(data);
            }
            return data;
        }




        [WebMethod(Description = "Buscar en la tabla employee")]
        public DataSet BuscarEmployee(string texto, string criterio)
        {
            string consulta = string.Empty;
            SqlCommand comando;
            SqlDataAdapter adapter;
            DataSet data = new DataSet();
            if (criterio == "Id")
            {
                // Busqueda exacta
                consulta = "select * from employee where emp_id = @texto";
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@texto", texto);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(data);
            }
            else if (criterio == "Nombre")
            {
                // Busqueda sensitiva
                consulta = "select * from employee where fname like @texto + '%'";
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@texto", texto);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(data);
            }
            else if (criterio == "Apellido")
            {
                // Busqueda sensitiva
                consulta = "select * from employee where lname like @texto + '%'";
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@texto", texto);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(data);
            }
            return data;
        }



        [WebMethod(Description = "Buscar en la tabla titleauthor")]
        public DataSet BuscarTitleauthor(string texto, string criterio)
        {
            string consulta = string.Empty;
            SqlCommand comando;
            SqlDataAdapter adapter;
            DataSet data = new DataSet();
            if (criterio == "Id")
            {
                // Busqueda exacta
                consulta = "select * from titleauthor where title_id = @texto";
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@texto", texto);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(data);
            }
            else if (criterio == "Id del autor")
            {
                // Busqueda sensitiva
                consulta = "select * from titleauthor where au_id like @texto + '%'";
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@texto", texto);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(data);
            }
            
            return data;
        }



        //
        ////METODO EDITAR
        ///
         //Actualizar
        [WebMethod(Description = "Actualizar en la tabla authors y actualizar los datos")]
        public bool ActualizarAuthors(string au_id, string au_lname, string au_fname, string phone, string address, string city, string state, int zip, string contract)
        {
            try
            {
                string consulta = "update authors set au_lname = @au_lname, au_fname = @au_fname, phone = @phone, address = @address, city = @city, state = @state, zip = @zip, contract=@contract where au_id = @au_id";
                SqlCommand command = new SqlCommand(consulta, conexion);

                command.Parameters.AddWithValue("@au_id", au_id);
                command.Parameters.AddWithValue("@au_lname", au_lname);
                command.Parameters.AddWithValue("@au_fname", au_fname);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@city", city);
                command.Parameters.AddWithValue("@state", state);
                command.Parameters.AddWithValue("@zip", zip);
                command.Parameters.AddWithValue("@contract", contract);

                conexion.Open();

                byte i = Convert.ToByte(command.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            //si o si se ejecuta al compilar todo este fragmento de codigo y cierra la conexion
            finally
            {
                conexion.Close();
            }
        }





        [WebMethod(Description = "Actualizar en la tabla authors y actualizar los datos")]
        public bool ActualizarEmployee(string emp_id, string fname, string minit, string lname, int job_id, int job_lvl, string pub_id, DateTime hire_date)
        {
            try
            {
                string consulta = "update employee set fname = @fname, minit = @minit, lname = @lname, job_id = @job_id, job_lvl = @job_lvl, hire_date = @hire_date where emp_id = @emp_id";
                SqlCommand command = new SqlCommand(consulta, conexion);

                command.Parameters.AddWithValue("@emp_id", emp_id);
                command.Parameters.AddWithValue("@fname", fname);
                command.Parameters.AddWithValue("@minit", minit);
                command.Parameters.AddWithValue("@lname", lname);
                command.Parameters.AddWithValue("@job_id", job_id);
                command.Parameters.AddWithValue("@job_lvl", job_lvl);
                command.Parameters.AddWithValue("@pub_id", pub_id);
                command.Parameters.AddWithValue("@hire_date", hire_date);

                conexion.Open();

                byte i = Convert.ToByte(command.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            //si o si se ejecuta al compilar todo este fragmento de codigo y cierra la conexion
            finally
            {
                conexion.Close();
            }
        }



        [WebMethod(Description = "Actualizar en la tabla titleauthor y actualizar los datos")]
        public bool ActualizarTitleauthor(string au_id, string title_id, int au_ord, int royaltyper)
        {
            try
            {
                string consulta = "update titleauthor set  au_ord = @au_ord, royaltyper = @royaltyper where au_id = @au_id and title_id = @title_id";
                SqlCommand command = new SqlCommand(consulta, conexion);

                command.Parameters.AddWithValue("@au_id", au_id);
                command.Parameters.AddWithValue("@title_id", title_id);
                command.Parameters.AddWithValue("@au_ord", au_ord);
                command.Parameters.AddWithValue("@royaltyper", royaltyper);

                conexion.Open();

                byte i = Convert.ToByte(command.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            //si o si se ejecuta al compilar todo este fragmento de codigo y cierra la conexion
            finally
            {
                conexion.Close();
            }
        }




        


        










    }


}
