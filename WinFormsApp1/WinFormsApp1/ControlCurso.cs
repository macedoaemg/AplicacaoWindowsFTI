using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class ControlCurso
    {

        public void insertCurso(SqlConnection conn, int codigo, string nome, int periodo, double valor)
        {
            string query = "INSERT INTO CURSO values(@IDCURSO, @DESCRICAO, @PERIODO, @VALORCURSO)";

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.Parameters.Add(new SqlParameter("@IDCURSO", codigo));
                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", nome));
                cmd.Parameters.Add(new SqlParameter("@PERIODO", periodo));
                cmd.Parameters.Add(new SqlParameter("@VALORCURSO", valor));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Curso inserido com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception)
            {
                MessageBox.Show("Erro no banco de dados... ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

            }
        }

        public void updateCurso(SqlConnection conn, string nome, int periodo, double valor, int codigo)
        {
            string query = "UPDATE CURSO " +
                           "   SET DESCRICAO  = @DESCRICAO," +
                           "       PERIODO    = @PERIODO,"+
                           "       VALORCURSO = @VALORCURSO"+
                           " WHERE IDCURSO = @IDCURSO";

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {                
                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", nome));
                cmd.Parameters.Add(new SqlParameter("@PERIODO", periodo));
                cmd.Parameters.Add(new SqlParameter("@VALORCURSO", valor));
                cmd.Parameters.Add(new SqlParameter("@IDCURSO", codigo));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Curso alterado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Erro no banco de dados... ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }

        public Curso selectCurso(SqlConnection conn, int codigo, Curso curso)
        {
            string query = "SELECT * FROM CURSO WHERE IDCURSO = '" + codigo + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    curso.setIdCurso(int.Parse(reader[0].ToString()));
                    curso.setDescricao(reader[1].ToString());
                    curso.setPeriodo(int.Parse(reader[2].ToString()));
                    curso.setValor(double.Parse(reader[3].ToString()));
                }

                reader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(" *** Erro ao pesquisar o Curso *** " + e.Message);
            }

            return curso;
        }

        public Curso deleteCurso(SqlConnection conn, int codigo, Curso curso)
        {
            string query = "DELETE FROM CURSO WHERE IDCURSO = @IDCURSO";

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.Parameters.Add(new SqlParameter("@IDCURSO", codigo));
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Curso excluido com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Erro no banco de dados... ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            return curso;
        }

    }
}
