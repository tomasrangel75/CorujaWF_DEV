﻿using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionarioForms
{
    public partial class FormPDFEspecialista : Form
    {
        public string nomeProfessor { get; set; }
        public string ano { get; set; }
        public string dataAplicacao { get; set; }


        public FormPDFEspecialista()
        {
            InitializeComponent();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            nomeProfessor = txtProfessor.Text;
            ano = txtano.Text;
            dataAplicacao = txtAplicacao.Text;

            this.Close();
        }

        private void txtProfessor_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void txtAplicacao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
