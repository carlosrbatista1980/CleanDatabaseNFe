using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Threading;
using System.IO;

namespace CleanDatabaseNFe
{



    public partial class Form1 : Form
    {
        Conexao con = new Conexao();
        SqlConnection oConnection;
        SqlCommand oCommand;
        SqlDataReader oDataReader;
        SqlDataAdapter oDataAdapter;
        DataSet oDataSet = new DataSet();
        string connString = "";
        Thread worker = null;
        bool stopWorker = false;        
        
        public Form1()
        {
            InitializeComponent();
            //Application.DoEvents();
            //this.Update();
            //this.stopWorker = false;
            //this.worker = new Thread(new ThreadStart(CarregaTela));
            //worker.Start();
        }

        public bool ExecutarLimpeza()
        {
            try
            {                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Todos os direitos reservados.", "SCE Sistemas Computacionais e Engenharia EPP.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
                
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(Environment.MachineName);
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }
                
        private void CarregaTela()
        {
            pictureBox1.Visible = true;
            progressBar1.Visible = true;
            //Application.DoEvents();
            this.Update();
            foreach (string l in con.ListarInstanciasSQL())
            {
                comboBox1.Items.Add(l);                
            }

            /*
            if (comboBox1.Items.Count != 0)
            {
                comboBox1.SelectedIndex = 0;
                foreach (string k in con.ListarBasesDeDados(comboBox1.SelectedItem.ToString()))
                {
                    comboBox2.Items.Add(k);                    
                }

                if (comboBox2.Items.Count > 0)
                    comboBox2.SelectedIndex = 0;                
            }
             */

            

            pictureBox1.Visible = false;
            progressBar1.Visible = false;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            oDataSet.Reset();

            string sqlDeletar = "";            
            string existeRegistroParaDeletar = "";
            
            sqlDeletar = "BEGIN TRANSACTION";
            sqlDeletar += " WHILE (@Deleted_Rows > 0)";
            sqlDeletar += " BEGIN";
            sqlDeletar += " DELETE TOP(2000) FROM NFE";
			sqlDeletar += " WHERE (NFE.DtEmissaoNFe < @DATA)";			
            sqlDeletar += " END";
            sqlDeletar += " COMMIT TRANSACTION";


            string sql = "DELETE from " + comboBox2.SelectedItem.ToString() + " Where DtEmissaoNFe < " + dateTimePicker1.Value.ToString("yyyy-MM-dd"); //tem que converter para "yyyy:mm:dd"
            //con.ConfiguraConexaoSQL(comboBox2.SelectedItem.ToString(), comboBox1.SelectedItem.ToString());
            //dataGridView1.DataSource = con.ExecutarQuery(sql);
            using(oConnection = new SqlConnection("Data Source=" + comboBox1.SelectedItem.ToString() + ";Initial Catalog=" + comboBox2.SelectedItem.ToString() + ";User ID=sa;Password=sa"))
            {
                using (var cmd = oConnection.CreateCommand())
                {
                    try
                    {
                        oConnection.Open();
                        //oDataAdapter = new SqlDataAdapter(sql, oConnection);
                        //oDataAdapter.Fill(oDataSet);
                        //dataGridView1.DataSource = oDataSet.Tables[0];
                        //dataGridView1.Columns[0].HeaderText = "Registros Encontrados";
                        cmd.CommandText = sqlDeletar;
                        cmd.ExecuteNonQuery();
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Gerenciador do Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        oConnection.Close();
                        oConnection.Dispose();
                    }
                }
            }

        }
    }
}
