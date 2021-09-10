using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class FCurso : Form
    {

        private static SqlConnection conn;


        public FCurso()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

            if (txtDescricao.Text == "" || txtCodigo.Text == "") 
            {
                MessageBox.Show("Campo descrição do Curso obrigatório", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                ControlCurso control = new ControlCurso();
                Curso curso = new Curso();

                curso.setIdCurso(int.Parse(txtCodigo.Text));
                curso.setDescricao(txtDescricao.Text);
                curso.setPeriodo(int.Parse(txtPeriodo.Text));
                curso.setValor(double.Parse(txtValor.Text));

                control.insertCurso(conn, curso.getIdCurso(), curso.getDescricao(),
                                         curso.getPeriodo(), curso.getValor());

                //controle de botões
                txtCodigo.Clear();
                txtDescricao.Clear();
                txtPeriodo.Clear();
                txtValor.Clear();

                btnInserir.Enabled = true;
                btnGravar.Enabled = false;
                btnCancelar.Enabled = false;                


            }



        }

        private void FCurso_Load(object sender, EventArgs e)
        {
            Connection c = new Connection();
            conn = c.conectar();


            btnInserir.Enabled = true;
            btnGravar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;            
            btnPesquisar.Enabled = false;


            txtDescricao.CharacterCasing = CharacterCasing.Upper;
            toolStripStatusLabel1.Text = "";
            


        }

        private void FCurso_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            btnInserir.Enabled = false;
            btnGravar.Enabled = true;
            btnAlterar.Enabled = false;
            btnCancelar.Enabled = true;

            txtCodigo.Select();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Enabled = false;
            btnGravar.Enabled = false;
            btnInserir.Enabled = true;

            txtCodigo.Clear();
            txtDescricao.Clear();
            txtPeriodo.Clear();
            txtValor.Clear();

        }
        private void controlaBotoes()
        {



        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "" || txtCodigo.Text == "")
            {
                MessageBox.Show("Campo descrição do Curso obrigatório", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                ControlCurso control = new ControlCurso();
                Curso curso = new Curso();

                curso.setIdCurso(int.Parse(txtCodigo.Text));
                curso.setDescricao(txtDescricao.Text);
                curso.setPeriodo(int.Parse(txtPeriodo.Text));
                curso.setValor(double.Parse(txtValor.Text));

                control.updateCurso(conn, curso.getDescricao(),
                                          curso.getPeriodo(), curso.getValor(),
                                          curso.getIdCurso());

                //controle de botões
                txtCodigo.Clear();
                txtDescricao.Clear();
                txtPeriodo.Clear();
                txtValor.Clear();

                btnInserir.Enabled = true;
                btnAlterar.Enabled = false;
                btnGravar.Enabled = false;
                btnCancelar.Enabled = false;


            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

            ControlCurso control = new ControlCurso();
            Curso curso = new Curso();

            curso.setIdCurso(int.Parse(txtCodigo.Text));
            curso = control.selectCurso(conn, curso.getIdCurso(), curso);

            if (curso.getDescricao() != null)
            {
                txtCodigo.Text = curso.getIdCurso().ToString();
                txtDescricao.Text = curso.getDescricao();
                txtPeriodo.Text = curso.getPeriodo().ToString();
                txtValor.Text = curso.getValor().ToString();


                //controle de botões           

                btnInserir.Enabled = true;
                btnAlterar.Enabled = true;
                btnGravar.Enabled = false;
                btnCancelar.Enabled = true;

            }
            else
            {
                MessageBox.Show("Curso não encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Clear();
                txtDescricao.Clear();
                txtPeriodo.Clear();
                txtValor.Clear();
            }

            

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                btnPesquisar.Enabled = true;
                btnExcluir.Enabled = true;

            }
            else
            {
                btnPesquisar.Enabled = false;
                btnExcluir.Enabled = false;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            ControlCurso control = new ControlCurso();
            Curso curso = new Curso();

            curso.setIdCurso(int.Parse(txtCodigo.Text));

            //curso = control.selectCurso(conn, curso.getIdCurso(), curso);

            curso = control.deleteCurso(conn, curso.getIdCurso(), curso);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = "Buscando Dados...";
            statusStrip1.Refresh();

            try
            {

                string sqlQuery = "SELECT idcurso as Código, descricao as Nome, periodo, valorcurso FROM Curso";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn))
                {
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }

                }

                toolStripStatusLabel1.Text = "Dados exibidos...";
                statusStrip1.Refresh();


            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Erro ao buscar Dados...";
                statusStrip1.Refresh();
                MessageBox.Show("Erro ao processar busca..." + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            
            


        }
    }
}
