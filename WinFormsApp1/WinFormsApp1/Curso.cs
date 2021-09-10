using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class Curso
    {

        private int idcurso;
        private string descricao;
        private int periodo;
        private double valor;

        public void setIdCurso(int idCurso)
        {
            this.idcurso = idCurso;
        }

        public int getIdCurso()
        {
            return this.idcurso;
        }

        public void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }

        public string getDescricao()
        {
            return this.descricao;
        }

        public void setPeriodo(int periodo)
        {
            this.periodo = periodo;
        }

        public int getPeriodo()
        {
            return this.periodo;
        }

        public void setValor(double valor)
        {
            this.valor = valor;
        }

        public double getValor()
        {
            return this.valor;
        }


    }
}
