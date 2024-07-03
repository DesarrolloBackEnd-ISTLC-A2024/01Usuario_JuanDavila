using _01Usuario_JuanDavila.Modelos;
using System.Data;
using System.Data.SqlClient;


namespace _01Usuario_JuanDavila.Comunes
{
    public class ConexionBD
    {
        public static SqlConnection conexion;
        public static SqlConnection abrir_Conexion() 
        {
            conexion = new SqlConnection("SERVER=Juank-Davila\\LICEO;DATABASE=PROYECTO_1;Trusted_Connection=true");
            conexion.Open();
            return conexion;

        }
        public static List<Usuario> GetUsuarios()
        {
            
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = abrir_Conexion();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_GET_USUARIOS";

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return fillUsuarios(ds);
            }                  
        }
       

        private static List<Usuario> fillUsuarios(DataSet ds)
        {
            List<Usuario>lrespuesta = new List<Usuario>();
            for (int i = 0; i <= ds.Tables[0].Rows.Count-1; i++)
            {
                
                
                    Usuario objUsuario = new Usuario();
                    objUsuario.id_usuario = Convert.ToInt32(ds.Tables[0].Rows[i]["ID_USUARIO"].ToString());
                    objUsuario.nombres = ds.Tables[0].Rows[i]["NOMBRES"].ToString();
                    objUsuario.apellidos = ds.Tables[0].Rows[i]["APELLIDOS"]?.ToString();
                    objUsuario.fecha_nacimiento = Convert.ToDateTime(ds.Tables[0].Rows[i]["FECHA_NACIMIENTO"].ToString());
                    objUsuario.contrasena = ds.Tables[0].Rows[i]["CONTRASENA"].ToString();
                    objUsuario.estado = ds.Tables[0].Rows[i]["ESTADO"].ToString();
                    objUsuario.fecha_ultima_conexion = Convert.ToDateTime(ds.Tables[0].Rows[i]["FECHA_ULTIMA_CONEXION"].ToString());
                    objUsuario.usuario_creacion = Convert.ToInt32(ds.Tables[0].Rows[i]["USUARIO_CREACION"].ToString());
                    objUsuario.fecha_creacion = Convert.ToDateTime(ds.Tables[0].Rows[i]["FECHA_CREACION"].ToString());
                    objUsuario.usuario_modificacion = Convert.ToInt32(ds.Tables[0].Rows[i]["USUARIO_MODIFICACION"].ToString());
                    objUsuario.fecha_modificacion = Convert.ToDateTime(ds.Tables[0].Rows[i]["FECHA_MODIFICACION"].ToString());

                    lrespuesta.Add(objUsuario);
            }
            return lrespuesta;      
          
        }
    }   
    
}
