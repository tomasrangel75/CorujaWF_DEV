using MetroFramework.Forms;
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
    public partial class FormPDF : Form
    {
        public string nomeProfessor { get; set; }

        public FormPDF()
        {
            InitializeComponent();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            nomeProfessor = txtProfessor.Text;
            this.Close();
        }
    }
}
