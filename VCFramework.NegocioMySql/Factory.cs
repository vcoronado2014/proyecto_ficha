﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web.Configuration;
using System.Data.Odbc;
using System.Data;
using System.Runtime.Caching;

namespace VCFramework.NegocioMySql
{
    public class Factory
    {

        /// <summary>
        /// Elimina un Regitro, solo es necesario llenar la entidad con el ID a eliminar
        /// </summary>
        /// <typeparam name="T">Objeto entidad (clase)</typeparam>
        /// <param name="objeto">Etnidad</param>
        /// <returns>Mayor a cero</returns>
        public int Delete<T>(T objeto)
        {
            ObjetoTransformar obj = ProcesarEntidad(objeto.GetType());

            //para el caso del patrick, este id no se puede determinar
            //por lo tanto se tomará el primer ordinal con el elemento id
            string idEntidad = "";
            if (obj.ListaCampos != null && obj.ListaCampos.Count > 0)
                idEntidad = obj.ListaCampos[0].NombreColumna;


            int filasAfectadas = 0;
            Type tipo = objeto.GetType();
            var propiedades = tipo.GetProperties();
            for (int i = 0; i < propiedades.Length; i++)
            {
                if (propiedades[i].Name != "Nuevo" &&
                    propiedades[i].Name != "Borrado" && propiedades[i].Name != "Modificado" && propiedades[i].Name != "TimeStamp")
                {
                    object valor = propiedades[i].GetValue(objeto, null);
                    CamposTabla campo = obj.ListaCampos.Find(p => p.NombreEntidad == propiedades[i].Name);
                    if (campo != null)
                    {
                        campo.ValorEntidad = valor;
                    }

                }
            }
            int valorId = int.Parse(obj.ListaCampos.Find(p => p.NombreColumna == "ID").ValorEntidad.ToString());

            string conString = WebConfigurationManager.
                ConnectionStrings[Utiles.CNS].ConnectionString;
            using (OdbcConnection con = new OdbcConnection(conString))
            using (OdbcCommand cmd = new OdbcCommand(string.Format("DELETE FROM {0} WHERE {1} = {2}", obj.NombreTabla, idEntidad, valorId), con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
                filasAfectadas++;
                con.Close();
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Inserta un Regitro
        /// </summary>
        /// <typeparam name="T">Objeto entidad (clase)</typeparam>
        /// <param name="objeto">Etnidad</param>
        /// <returns>Mayor a cero</returns>
        public int Insertar<T>(T objeto)
        {
            long ultimoId = 0;
            ObjetoTransformar obj = ProcesarEntidad(objeto.GetType());

            int filasAfectadas = 0;
            Type tipo = objeto.GetType();
            var propiedades = tipo.GetProperties();
            var campos = new StringBuilder();
            var variables = new StringBuilder();

            for (int i = 0; i < propiedades.Length; i++)
            {
                if (propiedades[i].Name != "Nuevo" &&
                    propiedades[i].Name != "Borrado" && propiedades[i].Name != "Modificado" && propiedades[i].Name != "TimeStamp")
                {
                    object valor = propiedades[i].GetValue(objeto, null);
                    CamposTabla campo = obj.ListaCampos.Find(p => p.NombreEntidad == propiedades[i].Name);
                    if (campo != null)
                    {
                        campo.ValorEntidad = valor;
                    }

                }
            }
            if (obj.ListaCampos.Count > 0)
            {
                for (int i = 0; i < obj.ListaCampos.Count; i++)
                {
                    string nombreCampo = obj.ListaCampos[i].NombreColumna;
                    if (nombreCampo != "ID")
                    {
                        campos.Append(obj.ListaCampos[i].NombreColumna);
                        variables.Append("?");
                        if (i < obj.ListaCampos.Count - 1)
                        {
                            campos.Append(", ");
                            variables.Append(", ");
                        }
                    }
                }
            }

            //en este momento ya tenemos los valores de los elementos y la lista de elementos en sql
            string conString = WebConfigurationManager.
                ConnectionStrings[Utiles.CNS].ConnectionString;
            using (OdbcConnection con = new OdbcConnection(conString))
            using (OdbcCommand cmd = new OdbcCommand(string.Format("INSERT INTO {0} ({1}) VALUES ({2})", obj.NombreTabla, campos, variables), con))
            {
                con.Open();

                foreach (CamposTabla campo in obj.ListaCampos)
                {
                    if (campo.NombreColumna != "ID")
                        cmd.Parameters.Add("@" + campo.NombreColumna, ObtenerTipoODBC(campo)).Value = campo.ValorEntidad;
                }

                cmd.ExecuteNonQuery();
                //pruebas de last insert id
                cmd.CommandText = "SELECT LAST_INSERT_ID()";
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader != null && reader.Read())
                    ultimoId = reader.GetInt64(0);

                filasAfectadas++;
                con.Close();
            }


            return Convert.ToInt32(ultimoId);
        }

        /// <summary>
        /// Actualiza un Regitro
        /// </summary>
        /// <typeparam name="T">Objeto entidad (clase)</typeparam>
        /// <param name="objeto">Etnidad</param>
        /// <returns>Mayor a cero</returns>
        public int Update<T>(T objeto)
        {
            ObjetoTransformar obj = ProcesarEntidad(objeto.GetType());

            //para el caso del patrick, este id no se puede determinar
            //por lo tanto se tomará el primer ordinal con el elemento id
            string idEntidad = "";
            if (obj.ListaCampos != null && obj.ListaCampos.Count > 0)
                idEntidad = obj.ListaCampos[0].NombreColumna;

            int filasAfectadas = 0;
            Type tipo = objeto.GetType();
            var propiedades = tipo.GetProperties();

            for (int i = 0; i < propiedades.Length; i++)
            {
                if (propiedades[i].Name != "Nuevo" &&
                    propiedades[i].Name != "Borrado" && propiedades[i].Name != "Modificado" && propiedades[i].Name != "TimeStamp")
                {
                    object valor = propiedades[i].GetValue(objeto, null);
                    CamposTabla campo = obj.ListaCampos.Find(p => p.NombreEntidad == propiedades[i].Name);
                    if (campo != null)
                    {
                        campo.ValorEntidad = valor;
                    }
                }
            }

            int valorId = int.Parse(obj.ListaCampos.Find(p => p.NombreColumna.Contains("ID")).ValorEntidad.ToString());
            StringBuilder query = new StringBuilder();
            query.AppendFormat("UPDATE {0} SET ", obj.NombreTabla);
            foreach (CamposTabla campo in obj.ListaCampos)
            {
                if (campo.NombreColumna != "ID")
                {
                    if (campo.TipoDatoEntidad != "System.Int32")
                    {
                        if (campo.TipoDatoEntidad == "System.DateTime")
                            query.AppendFormat("{0} = '{1}',", campo.NombreColumna, ConvertirFecha(campo.ValorEntidad));
                        else
                            query.AppendFormat("{0} = '{1}',", campo.NombreColumna, campo.ValorEntidad);
                    }
                    else
                        query.AppendFormat("{0} = {1},", campo.NombreColumna, campo.ValorEntidad);
                }
            }
            query.Remove(query.Length - 1, 1).ToString();
            query.AppendFormat(" WHERE {0} = {1}", idEntidad, valorId.ToString());


            string conString = WebConfigurationManager.
                ConnectionStrings[Utiles.CNS].ConnectionString;
            using (OdbcConnection con = new OdbcConnection(conString))
            using (OdbcCommand cmd = new OdbcCommand(query.ToString(), con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
                filasAfectadas++;
                con.Close();
            }


            return filasAfectadas;
        }

        public int Update<T>(T objeto, string nombreIdBD)
        {
            ObjetoTransformar obj = ProcesarEntidad(objeto.GetType());

            int filasAfectadas = 0;
            Type tipo = objeto.GetType();
            var propiedades = tipo.GetProperties();

            //string nombreIdBD = Utiles.EntregaNombreId(nombreIdPropiedad);

            for (int i = 0; i < propiedades.Length; i++)
            {
                if (propiedades[i].Name != "Nuevo" &&
                    propiedades[i].Name != "Borrado" && propiedades[i].Name != "Modificado" && propiedades[i].Name != "TimeStamp")
                {
                    object valor = propiedades[i].GetValue(objeto, null);
                    CamposTabla campo = obj.ListaCampos.Find(p => p.NombreEntidad == propiedades[i].Name);
                    if (campo != null)
                    {
                        campo.ValorEntidad = valor;
                    }
                }
            }

            int valorId = int.Parse(obj.ListaCampos.Find(p => p.NombreColumna == nombreIdBD).ValorEntidad.ToString());
            StringBuilder query = new StringBuilder();
            query.AppendFormat("UPDATE {0} SET ", obj.NombreTabla);
            foreach (CamposTabla campo in obj.ListaCampos)
            {
                if (campo.NombreColumna != "ID")
                {
                    if (campo.TipoDatoEntidad != "System.Int32")
                    {
                        if (campo.TipoDatoEntidad == "System.DateTime")
                            query.AppendFormat("{0} = '{1}',", campo.NombreColumna, ConvertirFecha(campo.ValorEntidad));
                        else
                            query.AppendFormat("{0} = '{1}',", campo.NombreColumna, campo.ValorEntidad);
                    }
                    else
                        query.AppendFormat("{0} = {1},", campo.NombreColumna, campo.ValorEntidad);
                }
            }
            query.Remove(query.Length - 1, 1).ToString();
            query.AppendFormat(" WHERE {0} = {1}",nombreIdBD, valorId.ToString());


            string conString = WebConfigurationManager.
                ConnectionStrings[Utiles.CNS].ConnectionString;
            using (OdbcConnection con = new OdbcConnection(conString))
            using (OdbcCommand cmd = new OdbcCommand(query.ToString(), con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
                filasAfectadas++;
                con.Close();
            }


            return filasAfectadas;
        }

        /// <summary>
        /// Método Genérico que retorna una lista de Objetos de la entidad solicitada
        /// </summary>
        /// <typeparam name="T">Entidad solicitada</typeparam>
        /// <returns>List objetos</returns>
        public List<object> Leer<T>()
        {

            ObjetoTransformar obj = ProcesarEntidad(typeof(T));

            List<object> lista = new List<object>();

            var props = typeof(T).GetProperties();
            string conString = WebConfigurationManager.
              ConnectionStrings[Utiles.CNS].ConnectionString;

            using (OdbcConnection con = new OdbcConnection(conString))
            using (OdbcCommand cmd =
                  new OdbcCommand("SELECT * FROM " + obj.NombreTabla, con))
            {
                con.Open();
                using (OdbcDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object objClassInstance = GetInstance(obj.ObjetoType.FullName);
                        foreach (var prop in props)
                        {

                            for (int i = 0; i < reader.FieldCount; i++)
                            {

                                string nomCol = reader.GetName(i).ToUpper().Replace("_", "");
                                if (prop.Name.ToUpper() == nomCol)
                                {

                                    var propertyInfo = typeof(T).GetProperty(prop.Name);

                                    propertyInfo.SetValue(objClassInstance, Convert.ChangeType(reader.GetValue(i), propertyInfo.PropertyType), null);



                                }
                            }

                        }
                        lista.Add(objClassInstance);

                    }
                }
                con.Close();
            }
            return lista;
        }

        /// <summary>
        /// Método Genérico que retorna una lista de Objetos de la entidad solicitada
        /// </summary>
        /// <typeparam name="T">Entidad solicitada</typeparam>
        /// <param name="filtro">Filtro</param>
        /// <returns>List objetos</returns>
        public List<object> Leer<T>(FiltroGenerico filtro)
        {

            ObjetoTransformar obj = ProcesarEntidad(typeof(T));

            List<object> lista = new List<object>();

            var props = typeof(T).GetProperties();
            string conString = WebConfigurationManager.
              ConnectionStrings[Utiles.CNS].ConnectionString;

            //acá construimos la query de acuerdo al filtro
            string query = EntregaQueryFiltro(obj.NombreTabla, filtro);


            using (OdbcConnection con = new OdbcConnection(conString))
            using (OdbcCommand cmd =
                  new OdbcCommand(query, con))
            {
                con.Open();
                using (OdbcDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object objClassInstance = GetInstance(obj.ObjetoType.FullName);
                        foreach (var prop in props)
                        {

                            for (int i = 0; i < reader.FieldCount; i++)
                            {

                                string nomCol = reader.GetName(i).ToUpper().Replace("_", "");
                                if (prop.Name.ToUpper() == nomCol)
                                {

                                    var propertyInfo = typeof(T).GetProperty(prop.Name);
                                    propertyInfo.SetValue(objClassInstance, Convert.ChangeType(reader.GetValue(i), propertyInfo.PropertyType), null);

                                }
                            }
                        }
                        lista.Add(objClassInstance);

                    }
                }
                con.Close();
            }
            return lista;
        }

        /// <summary>
        /// Método Genérico que retorna una lista de Objetos de la entidad solicitada
        /// </summary>
        /// <typeparam name="T">Entidad solicitada</typeparam>
        /// <param name="filtro">List filtro</param>
        /// <returns>List object</returns>
        public List<object> Leer<T>(List<FiltroGenerico> filtro)
        {

            ObjetoTransformar obj = ProcesarEntidad(typeof(T));

            List<object> lista = new List<object>();

            var props = typeof(T).GetProperties();
            string conString = WebConfigurationManager.
              ConnectionStrings[Utiles.CNS].ConnectionString;

            //acá construimos la query de acuerdo al filtro
            string query = EntregaQueryFiltro(obj.NombreTabla, filtro);


            using (OdbcConnection con = new OdbcConnection(conString))
            using (OdbcCommand cmd =
                  new OdbcCommand(query, con))
            {
                con.Open();
                using (OdbcDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object objClassInstance = GetInstance(obj.ObjetoType.FullName);
                        foreach (var prop in props)
                        {

                            for (int i = 0; i < reader.FieldCount; i++)
                            {

                                string nomCol = reader.GetName(i).ToUpper().Replace("_", "");
                                if (prop.Name.ToUpper() == nomCol)
                                {

                                    var propertyInfo = typeof(T).GetProperty(prop.Name);
                                    //propertyInfo.SetValue(new Saydex.Core.Entidad.Otro.Cliente(), Convert.ChangeType(reader.GetValue(0), propertyInfo.PropertyType), null);
                                    //object objClassInstance = GetInstance(obj.ObjetoType.FullName);
                                    if (reader.GetValue(i) == null)
                                    {
                                        if (propertyInfo.PropertyType.ToString().Contains("Date"))
                                        {

                                        }
                                    }
                                    propertyInfo.SetValue(objClassInstance, Convert.ChangeType(reader.GetValue(i), propertyInfo.PropertyType), null);


                                    //lista.Add(objClassInstance);
                                }
                            }
                            //lista.Add(typeof(T));
                        }
                        lista.Add(objClassInstance);

                    }
                }
                con.Close();
            }
            return lista;
        }

        private object ConvertirFecha(object fecha)
        {
            StringBuilder sb = new StringBuilder();

            DateTime fechaStr = Convert.ToDateTime(fecha);
            string dia = "";
            string mes = "";
            string ano = "";
            string hora = "";
            string minutos = "";
            string segundos = "";

            ano = fechaStr.Year.ToString();
            if (fechaStr.Month < 10)
                mes = "0" + fechaStr.Month.ToString();
            else
                mes = fechaStr.Month.ToString();

            if (fechaStr.Day < 10)
                dia = "0" + fechaStr.Day.ToString();
            else
                dia = fechaStr.Day.ToString();

            if (fechaStr.Hour < 10)
                hora = "0" + fechaStr.Hour.ToString();
            else
                hora = fechaStr.Hour.ToString();

            if (fechaStr.Minute < 10)
                minutos = "0" + fechaStr.Minute.ToString();
            else
                minutos = fechaStr.Minute.ToString();

            if (fechaStr.Second < 10)
                segundos = "0" + fechaStr.Second.ToString();
            else
                segundos = fechaStr.Second.ToString();
            sb.AppendFormat("{0}/{1}/{2} {3}:{4}:{5}", ano, mes, dia, hora, minutos, segundos);

            return sb.ToString();
        }

        private OdbcType ObtenerTipoODBC(CamposTabla campo)
        {
            OdbcType retorno = OdbcType.Int;
            switch (campo.TipoDatoEntidad)
            {
                case "System.Int32":
                    retorno = OdbcType.Int;
                    break;
                case "System.String":
                    retorno = OdbcType.VarChar;
                    break;
                case "System.DateTime":
                    retorno = OdbcType.DateTime;
                    break;
            }

            return retorno;
        }

        private ObjetoTransformar ProcesarEntidad(Type myEntidad)
        {

            ObjetoTransformar objeto = new ObjetoTransformar();
            objeto.ObjetoType = myEntidad;
            objeto.NombreEntidad = objeto.ObjetoType.Name;
            objeto.NombreTabla = DeterminarNombreTabla(objeto.NombreEntidad);
            PropertyInfo[] propiedades = myEntidad.GetProperties();
            List<CamposTabla> listaCampos = ListaCamposTabla(objeto.NombreTabla);
            List<CamposTabla> listaCamposProcesada = ListaCamposProcesada(listaCampos, propiedades);
            objeto.ListaCampos = new List<CamposTabla>();
            objeto.ListaCampos = listaCamposProcesada;

            return objeto;
        }



        private string EntregaQueryFiltro(string nombreTabla, FiltroGenerico filtro)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("SELECT * FROM {0} WHERE ", nombreTabla);
            sb.AppendFormat("{0} = '{1}'", filtro.Campo.ToUpper(), filtro.Valor);

            return sb.ToString();
        }

        private string EntregaQueryFiltro(string nombreTabla, List<FiltroGenerico> filtros)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("SELECT * FROM {0} WHERE ", nombreTabla);
            int contador = 0;
            if (filtros != null && filtros.Count > 0)
            {
                foreach (FiltroGenerico fil in filtros)
                {
                    contador++;
                    if (fil.TipoDato == TipoDatoGeneral.Varchar)
                        sb.AppendFormat("{0} = '{1}'", fil.Campo.ToUpper(), fil.Valor);
                    else if (fil.TipoDato == TipoDatoGeneral.Fecha)
                        sb.AppendFormat("{0} = '{1}'", fil.Campo.ToUpper(), fil.Valor);
                    else
                        sb.AppendFormat("{0} = {1} ", fil.Campo.ToUpper(), fil.Valor);


                    if (filtros.Count > 1 && contador < filtros.Count)
                        sb.Append(" AND ");


                }
            }
            return sb.ToString();
        }


        public object GetInstance(string strFullyQualifiedName)
        {
            Type type = Type.GetType(strFullyQualifiedName);
            if (type != null)
                return Activator.CreateInstance(type);
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetType(strFullyQualifiedName);
                if (type != null)
                    return Activator.CreateInstance(type);
            }
            return null;
        }

        private DataSet Obtener(ObjetoTransformar objetoTransf)
        {
            DataSet ds = new DataSet();
            string conString = WebConfigurationManager.
               ConnectionStrings[Utiles.CNS].ConnectionString;
            OdbcDataAdapter da = null;
            OdbcCommand cmd = new OdbcCommand();

            using (OdbcConnection con = new OdbcConnection(conString))
            {
                con.Open();

                try
                {
                    string query = "Select * from " + objetoTransf.NombreTabla;
                    da = new OdbcDataAdapter(query, con);
                    da.Fill(ds, objetoTransf.NombreTabla);
                    //ds.Tables[0].Rows.Find(
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                con.Close();
            }
            return ds;
        }

        private List<CamposTabla> ListaCamposProcesada(List<CamposTabla> listaProcesar, PropertyInfo[] propiedades)
        {
            List<CamposTabla> listaRetorno = new List<CamposTabla>();

            if (listaProcesar != null && listaProcesar.Count > 0)
            {
                foreach (CamposTabla campo in listaProcesar)
                {
                    string campoComoEntidad = campo.NombreColumna.Replace("_", "").ToUpper();
                    PropertyInfo prop = propiedades.FirstOrDefault(p => p.Name.ToUpper() == campoComoEntidad);
                    if (prop != null)
                    {
                        campo.NombreEntidad = prop.Name;
                        campo.TipoDatoEntidad = prop.PropertyType.FullName;
                        //por mientras nulo
                        campo.ValorEntidad = null;
                        listaRetorno.Add(campo);
                    }

                }
            }

            return listaRetorno;
        }



        private List<CamposTabla> ListaCamposTabla(string nombreTabla)
        {
            List<CamposTabla> lista = new List<CamposTabla>();

            StringBuilder sb = new StringBuilder();
            string conString = WebConfigurationManager.
                ConnectionStrings[Utiles.CNS].ConnectionString;

            //if (fileContents == null)
            //{

            try
            {
                using (OdbcConnection con = new OdbcConnection(conString))
                using (OdbcCommand cmd =
                      new OdbcCommand("SELECT distinct column_name,  ordinal_position, data_type, CHARACTER_MAXIMUM_LENGTH FROM information_schema.COLUMNS where table_name ='" + nombreTabla + "'", con))
                {
                    con.Open();
                    using (OdbcDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CamposTabla campo = new CamposTabla();
                            campo.NombreColumna = reader.GetString(0);
                            campo.Ordinal = int.Parse(reader.GetString(1));
                            campo.TipoDato = reader.GetString(2);
                            campo.LargoBD = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
                            if (!lista.Exists(p => p.NombreColumna == campo.NombreColumna))
                            {
                                lista.Add(campo);
                            }
                        }
                    }
                    con.Close();

                }
                //CacheItemPolicy policy = new CacheItemPolicy();
                //policy.AbsoluteExpiration = tiempoCache;

                //List<string> filePaths = new List<string>();
                //string cacheFilePath = AppDomain.CurrentDomain.BaseDirectory + nombreArchivo;

                //filePaths.Add(cacheFilePath);

                //policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));

                //fileContents = lista;

                //cache.Set("fileContentsCampos", fileContents, policy);

            }
            catch (Exception ex)
            {
                Utiles.Log(ex);
                throw ex;
            }
            //}
            //else
            //{
            //    lista = fileContents;
            //}
            return lista;
        }

        static ObjectCache cache = MemoryCache.Default;
        private static List<string> fileContents = cache["fileContentsTablaSistema"] as List<string>;
        private static DateTimeOffset tiempoCache = Cache.Minimo();
        private static string nombreArchivo = "cacheTablaSistema.txt";

        private string DeterminarNombreTabla(string nombreEntidad)
        {


            StringBuilder sb = new StringBuilder();
            string conString = WebConfigurationManager.
                ConnectionStrings[Utiles.CNS].ConnectionString;
            string query = string.Format("SELECT table_name FROM information_schema.TABLES where table_schema = {0}", Utiles.NombreBaseDatos());
            try
            {
                List<string> listaTablas = new List<string>();

                if (fileContents == null)
                {

                    using (OdbcConnection con = new OdbcConnection(conString))
                    using (OdbcCommand cmd = new OdbcCommand(query, con))
                    {
                        con.Open();
                        using (OdbcDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaTablas.Add(reader.GetString(0));
                            }
                        }
                        con.Close();

                    }

                    CacheItemPolicy policy = new CacheItemPolicy();
                    policy.AbsoluteExpiration = tiempoCache;

                    List<string> filePaths = new List<string>();
                    string cacheFilePath = AppDomain.CurrentDomain.BaseDirectory + nombreArchivo;

                    filePaths.Add(cacheFilePath);

                    policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));

                    fileContents = listaTablas;

                    cache.Set("fileContentsTablaSistema", fileContents, policy);

                }
                else
                {
                    listaTablas = fileContents;
                }
                if (listaTablas != null && listaTablas.Count > 0)
                {
                    int cantidad = 0;
                    foreach (string s in listaTablas)
                    {
                        //descomponemos los elementos
                        if (nombreEntidad.ToUpper() == s.Replace("_","").ToUpper())
                            cantidad++;

                        if (cantidad > 0)
                        {
                            sb.Append(s);
                            break;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Utiles.Log(ex);
                throw ex;
            }

            return sb.ToString();
        }
    }


    public class FiltroGenerico
    {
        public string Campo { get; set; }
        public string Valor { get; set; }
        public TipoDatoGeneral TipoDato { get; set; }
    }
    public class ObjetoTransformar
    {
        public string NombreEntidad { get; set; }
        public string NombreTabla { get; set; }
        public Type ObjetoType { get; set; }
        public List<CamposTabla> ListaCampos { get; set; }
    }

    public class CamposTabla
    {
        public string NombreColumna { get; set; }
        public int Ordinal { get; set; }
        public string TipoDato { get; set; }
        public string NombreEntidad { get; set; }
        public string TipoDatoEntidad { get; set; }
        public object ValorEntidad { get; set; }
        public decimal LargoBD { get; set; }
    }

    public enum TipoDatoGeneral
    {
        Entero = 0,
        Fecha = 1,
        Varchar = 2
    }

    public enum TipoMovimiento
    {
        Insert,
        Select,
        Update,
        Delete
    }
}
