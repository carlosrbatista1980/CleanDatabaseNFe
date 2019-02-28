using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.Sql;
namespace CleanDatabaseNFe
{
    class Conexao
    {
        private string str_nome_do_Banco = "";
        private string str_connString = "";
        private string str_banco = "";        
        private string str_instancia = "";
        
        SqlConnection oConnection;
        SqlDataAdapter oDataAdapter;
        SqlCommand oSQLCommand;
        SqlDataSourceEnumerator enum_instance = SqlDataSourceEnumerator.Instance;
        DataTable table;

        public List<String> ListarInstanciasSQL()
        {
            var lista = new List<string>();            
            table = enum_instance.GetDataSources();
            string item = string.Empty;
            foreach (DataRow row in table.Rows)
            {            
                if (row["ServerName"] != DBNull.Value && Environment.MachineName.Equals(row["ServerName"].ToString()))
                {                    
                    item = row["ServerName"].ToString();
                    if (row["ServerName"] != DBNull.Value || !string.IsNullOrEmpty(Convert.ToString(row["InstanceName"]).Trim()))
                    {
                        //item += @"\" + Convert.ToString(row["InstanceName"]).Trim();
                        //item += Convert.ToString(row["InstanceName"]).Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(row["InstanceName"]).Trim()))
                        {
                            item += @"\" + Convert.ToString(row["InstanceName"]).Trim();
                        }
                    }

                    lista.Add(item);
                }
            }

            return lista;
        }

        public List<string> ListarBasesDeDados(string nome_do_servidor)
        {
                var lista = new List<string>();
                string cnn = "";            
                string sSQL = "SELECT name FROM sys.databases where (name <> 'master' and name <> 'tempdb' and name <> 'model' and name <> 'msdb')";
                sSQL += " order by";
                sSQL += " CASE WHEN name = 'NFe' THEN name";
                sSQL += " END DESC";

                try
                {
                    cnn = "Server=" + nome_do_servidor + ";User Id=sa;" + "pwd=sa;";
                    oConnection = new SqlConnection(cnn);
                    oConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQL, oConnection))
                    {
                        using (IDataReader da = cmd.ExecuteReader())
                        {
                            while (da.Read())
                            {
                                lista.Add(da[0].ToString());
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Gerenciador do sistema");
                    oConnection.Close();
                }

            oConnection.Close();            
            return lista;            
        }


        public bool ExecutarQuery(string sql)
        {
            try
            {
                oConnection.Open();
                //oSQLCommand.CommandTimeout = 900;
                oSQLCommand = new SqlCommand(sql, oConnection);
                oSQLCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                oConnection.Close();
            }

        }

        public bool ConfiguraConexaoSQL(string NomeDoBanco, string NomeDaInstanciaSQL)
        {
            try
            {
                this.str_banco = NomeDoBanco;
                this.str_instancia = NomeDaInstanciaSQL;
                this.str_connString = "Data Source=" + NomeDaInstanciaSQL + ";Initial Catalog=" + NomeDoBanco + ";User ID=sa;Password=sa";
                oConnection = new SqlConnection(this.str_connString);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ConectarSQLServer_NaoUSAR(string connectionString, string computerName)
        {
            try
            {
                oConnection.Open();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


    }
}
