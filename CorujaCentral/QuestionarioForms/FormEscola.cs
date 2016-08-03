using System;
using System.Windows.Forms;
using Library.Persistencia;
using MetroFramework.Forms;

namespace QuestionarioForms
{
    public partial class FormEscola : MetroForm
    {
        

        public FormEscola()
        {
            InitializeComponent();

            carregarEscolas();
        }

        void carregarEscolas()
        {
            comboEscola.Items.Clear();

            foreach (var instituicao in Instituicao.obterTodos())
            {
                comboEscola.Items.Add(instituicao);
            }

            comboEscola.DisplayMember = "Nome";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNome.Text))
            {
                ((Master)MdiParent).MensagemAlerta("Digite um nome para a Escola.");
                return;
            }

            if (String.IsNullOrEmpty(txtDesc.Text))
            {
                ((Master)MdiParent).MensagemAlerta("Digite uma descrição para a Escola.");
                return;
            }

            var inti = new Instituicao();

            inti.Nome = txtNome.Text;
            inti.Descricao = txtDesc.Text;

            inti.adicionar(inti);

            ((Master)MdiParent).MensagemSucesso("Escola Cadastrada!");

            txtNome.Text = "";
            txtDesc.Text = "";

            carregarEscolas();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNome.Text))
            {
                ((Master)MdiParent).MensagemAlerta("Digite um nome para a Escola.");
                return;
            }

            if (String.IsNullOrEmpty(txtDesc.Text))
            {
                ((Master)MdiParent).MensagemAlerta("Digite uma descrição para a Escola.");
                return;
            }

            if (comboEscola.SelectedIndex >= 0)
            {
                var inst = (Instituicao)comboEscola.SelectedItem;

                inst.Nome = txtNomeEdit.Text;
                inst.Descricao = txtDescEdit.Text;

                inst.atualizar(inst);

                ((Master)MdiParent).MensagemSucesso("Escola atualizada!");

                txtNomeEdit.Text = "";
                txtDescEdit.Text = "";

                pnlDados.Enabled = false;

                comboEscola.SelectedIndex = -1;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

             DialogResult di = ((Master) MdiParent).MensagemValidarExclusao("Tem certeza que deseja excluir essa escola e todas as suas turmas?");

            if (di == DialogResult.OK)
            {
                if (comboEscola.SelectedIndex >= 0)
                {
                    var inst = (Instituicao)comboEscola.SelectedItem;

                    inst.deletar(inst);

                    txtNomeEdit.Text = "";
                    txtDescEdit.Text = "";

                    pnlDados.Enabled = false;

                    comboEscola.SelectedIndex = -1;

                    carregarEscolas();
                }
            }
        }

        private void comboEscola_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEscola.SelectedIndex >= 0)
            {
                Instituicao inst = (Instituicao)comboEscola.SelectedItem;

                txtNomeEdit.Text = inst.Nome;
                txtDescEdit.Text = inst.Descricao;

                pnlDados.Enabled = true;
            }
            else
            {
                txtNomeEdit.Text = "";
                txtDescEdit.Text = "";

                pnlDados.Enabled = false;
            }
        }

    
    }
}
