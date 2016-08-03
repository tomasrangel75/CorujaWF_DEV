using System;
using System.Linq;
using System.Windows.Forms;
using Library.Persistencia;
using MetroFramework.Forms;

namespace QuestionarioForms
{
    public partial class FormTurma : MetroForm
    {
        public FormTurma()
        {
            InitializeComponent();

            carregar();
        }

        public void carregar()
        {
            comboEscola.Items.Clear();

            foreach (var instituicao in Instituicao.obterTodos().OrderBy(n =>n.Nome))
            {
                comboEscola.Items.Add(instituicao);
            }
            comboEscola.DisplayMember = "Nome";

             gridAlunos.Columns.Clear();

            gridAlunos.Columns.Add("Col1", "Nome");

            txtNome.Text = "";
            comboTurma.SelectedIndex = -1;
        }

        private void btnNova_Click(object sender, EventArgs e)
        {
            comboTurma.Enabled = false;
            txtNome.Enabled = true;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            gridAlunos.Visible = false;

            txtNome.Text = "";

            comboTurma.Items.Clear();
        }

        private void comboTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTurma.SelectedIndex >= 0)
            {
                txtNome.Enabled = true;
                btnExcluir.Enabled = true;
                var turma = comboTurma.SelectedItem as Turma;
                if (turma != null) txtNome.Text = turma.Nome;

               
                gridAlunos.Visible = true;
                btnSalvar.Enabled = true;

                gridAlunos.Rows.Clear();
                 
                if ( (turma.Aluno != null) && (turma.Aluno.Count > 0))
                    foreach (var aluno in turma.Aluno.OrderBy(a => a.Nome))
                    {
                        gridAlunos.Rows.Add(aluno.Nome);
                    }
            }
            else
            {
                txtNome.Enabled = false;
                btnExcluir.Enabled = false;
                txtNome.Text = "";

                gridAlunos.DataSource = null;
                gridAlunos.Visible = false;

                gridAlunos.Rows.Clear();
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Turma turma;

            if (String.IsNullOrEmpty(txtNome.Text))
            {
                ((Master)MdiParent).MensagemAlerta("Digite um nome para a Turma.");
                return;
            }

            if ((comboTurma.Enabled) &&  (comboTurma.SelectedIndex >= 0))
            {
                turma = (Turma)comboTurma.SelectedItem;
                turma.Nome = txtNome.Text;
                turma.Instituicao = (Instituicao)comboEscola.SelectedItem;

                turma.atualizar(turma);

                ((Master)MdiParent).MensagemSucesso("Turma atualizada!");
            }
            else
            {
                turma = new Turma();
                turma.Nome = txtNome.Text;
                turma.Instituicao = (Instituicao)comboEscola.SelectedItem;

                turma.adicionar(turma);

                ((Master)MdiParent).MensagemSucesso("Turma cadastrada!");
            }

            txtNome.Text = "";
            txtNome.Enabled = false;

            var inst = (Instituicao)comboEscola.SelectedItem;

            comboTurma.Items.Clear();
            foreach (var t in inst.Turma)
            {
                comboTurma.Items.Add(t);
            }

            gridAlunos.DataSource = null;

            gridAlunos.Rows.Clear();

            comboTurma.DisplayMember = "Nome";

            txtNome.Text = "";
            txtNome.Enabled = false;
            comboTurma.SelectedIndex = -1;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (comboTurma.SelectedIndex >= 0)
            {
                DialogResult di = ((Master) MdiParent).MensagemValidarExclusao("Tem certeza que deseja excluir essa Turma e Todos os Alunos dela?");

                if (di == DialogResult.OK)
                {
                    Turma turma = (Turma)comboTurma.SelectedItem;

                    turma.deletar(turma);

                    ((Master)MdiParent).MensagemSucesso("Turma excluída!");

                    comboTurma.Items.Clear();

                    gridAlunos.DataSource = null;

                    gridAlunos.Rows.Clear();

                    comboTurma.DisplayMember = "Nome";

                    txtNome.Text = "";
                    txtNome.Enabled = false;

                }
            }
            else
            {
                ((Master)MdiParent).MensagemAlerta("Selecione uma Turma!");
            }
        }

        private void comboEscola_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEscola.SelectedIndex >= 0)
            {
                var instituicao = (Instituicao)comboEscola.SelectedItem;

                comboTurma.Items.Clear();
                foreach (var turma in instituicao.Turma)
                {
                    comboTurma.Items.Add(turma);
                }

                comboTurma.DisplayMember = "Nome";

                comboTurma.Enabled = true;
            }
            else
            {
                comboTurma.Items.Clear();
                comboTurma.Enabled = false;
            }

            txtNome.Text = "";
            gridAlunos.DataSource = null;

            gridAlunos.Rows.Clear();
        }


    }
}
