using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp1
{
    class Connection
    {

        static string conexaoString = "DATA SOURCE=ANDERSON-PCWIND; INITIAL CATALOG=BancoAluno; Trusted_Connection=True";

        static SqlConnection conn;

        public SqlConnection conectar()
        {

            conn = new SqlConnection(conexaoString);

            try
            {
                conn.Open();
                //MessageBox.Show("Sistema Conectado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);                

            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao conectar no banco...", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Console.WriteLine("Erro ao conectar no banco..." + e.Message);
            }

            return conn;
        }

        public void fechar()
        {
            conn = new SqlConnection(conexaoString);

            try
            {
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao conectar no banco..." + e.Message);
            }


        }


    }
}
