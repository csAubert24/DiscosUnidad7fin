using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using proyecto_dominio;

namespace proyecto_negocio
{
     public class DiscosNegocio
    {
        public List<Discos> listar()
        {
            List<Discos> lista = new List<Discos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security = true" ;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Titulo,CantidadCanciones,UrlImagenTapa, E.Descripcion estilo, T.Descripcion formato from DISCOS D, ESTILOS E, TIPOSEDICION T where E.Id = D.IdEstilo and T.Id = D.IdTipoEdicion";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();


                while (lector.Read())
                {
                    Discos aux = new Discos();
                    aux.titulo = (string)lector["Titulo"];
                    aux.canciones = (int)lector["CantidadCanciones"];

                    if (!(lector["UrlImagenTapa"]is DBNull))
                        aux.url = (string)lector["UrlImagenTapa"];


                    aux.Estilo = new elemento();
                    aux.Estilo.Descripcion = (string)lector["estilo"];
                    aux.formato = new elemento();
                    aux.formato.Descripcion = (string)lector["formato"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch ( Exception ex)
            {

                throw ex;
            }
           
        }

        public void agregar(Discos nuevo)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("insert into DISCOS (Titulo,CantidadCanciones,UrlImagenTapa,IdEstilo,IdTipoEdicion)values('" + nuevo.titulo + "',"+nuevo.canciones+",'" + nuevo.url + "',@IdEstilo,@IdTipoEdicion)");
                datos.setearParametro("@IdEstilo", nuevo.Estilo.Id);
                datos.setearParametro("@IdTipoEdicion", nuevo.formato.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Discos modificar)
        {

        }

    }
}
