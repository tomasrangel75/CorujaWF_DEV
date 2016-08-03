using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Library.Persistencia;
using MetroFramework.Forms;
using System.Text;

namespace QuestionarioForms
{
    public partial class FormAlunos : MetroForm
    {

        private string nomeArquivoAlunos;

        public FormAlunos()
        {
            InitializeComponent();

            carregar();
        }

        public void carregar()
        {
            comboTurma.Items.Clear();
            comboTUrmaEdit.Items.Clear();
            foreach (var turma in Turma.obterTodos())
            {
                comboTurma.Items.Add(turma);
                comboTUrmaEdit.Items.Add(turma);
                comboTurmaArquivo.Items.Add(turma);
            }

            comboTurma.DisplayMember = "Nome";
            comboTUrmaEdit.DisplayMember = "Nome";
            comboTurmaArquivo.DisplayMember = "Nome";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (comboTurma.SelectedIndex >= 0)
            {
                if (String.IsNullOrEmpty(txtNome.Text))
                {
                    ((Master)MdiParent).MensagemAlerta("Digite um nome para o Aluno.");
                    return;
                }

                if (ckFeminino.Checked && ckMasculino.Checked)
                {
                    ((Master)MdiParent).MensagemAlerta("Selecione Masculino ou Feminino");
                    return;
                }

                if (!ckFeminino.Checked && !ckMasculino.Checked)
                {
                    ((Master)MdiParent).MensagemAlerta("Selecione o Sexo");
                    return;
                }

                string sexo = "";
                if (ckMasculino.Checked)
                {
                    sexo = "M";
                }
                else
                {
                    sexo = "F";
                }

                Aluno aluno = new Aluno();
                aluno.Nome = txtNome.Text;
                aluno.Turma = (Turma)comboTurma.SelectedItem;
                aluno.DataCadastro = DateTime.Now;
                aluno.DataNascimento = dtDataNascimento.Value;
                aluno.Sexo = sexo;

                aluno.adicionar(aluno);

                ((Master)MdiParent).MensagemSucesso("Aluno cadastrado!");

                txtNome.Text = "";
                comboAluno.Items.Clear();
                comboTUrmaEdit.SelectedIndex = -1;
                txtNomeEdit.Text = "";
                ckMasculino.Checked = false;
                ckFeminino.Checked = false;
                dtDataNascimento.Value = DateTime.Now;
                btnEdicao.Enabled = false;
                btnExcluir.Enabled = false;
            }
            else
            {
                ((Master)MdiParent).MensagemAlerta("Selecione uma Turma!");
            }
        }

        private void comboTUrmaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTUrmaEdit.SelectedIndex >= 0)
            {
                comboAluno.Items.Clear();
                foreach (var aluno in ((Turma) comboTUrmaEdit.SelectedItem).Aluno.OrderBy(a => a.Nome))
                {
                    comboAluno.Items.Add(aluno);
                }

                comboAluno.DisplayMember = "Nome";
                txtNomeEdit.Text = "";
                txtNomeEdit.Enabled = false;
                
            }
            else
            {
                comboAluno.Items.Clear();
                txtNomeEdit.Text = "";
                txtNomeEdit.Enabled = false;
            }
        }

        private void comboAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAluno.SelectedIndex >= 0)
            {
                txtNomeEdit.Enabled = true;
                txtNomeEdit.Text = ((Aluno) comboAluno.SelectedItem).Nome;
                if (((Aluno) comboAluno.SelectedItem).Sexo.Equals("M"))
                {
                    ckMasculinoEdit.Checked = true;
                    ckFemininoEdit.Checked = false;
                }
                else
                {
                    ckMasculinoEdit.Checked = false;
                    ckFemininoEdit.Checked = true;
                }
                if (((Aluno)comboAluno.SelectedItem).DataNascimento != null)
                        dtDataNascimentoEdit.Value = (DateTime)((Aluno) comboAluno.SelectedItem).DataNascimento;
                else
                {
                    dtDataNascimentoEdit.Value = DateTime.Now;
                }
                btnExcluir.Enabled = true;
                btnEdicao.Enabled = true;
            }
            else
            {
                txtNomeEdit.Enabled = false;
                txtNomeEdit.Text = "";
                btnExcluir.Enabled = false;
                btnEdicao.Enabled = false;
            }
        }

        private void btnEdicao_Click(object sender, EventArgs e)
        {
            if (comboAluno.SelectedIndex >= 0)
            {
                Aluno aluno = ((Aluno) comboAluno.SelectedItem);

                if (String.IsNullOrEmpty(txtNomeEdit.Text))
                {
                    ((Master)MdiParent).MensagemAlerta("Digite um nome para o Aluno.");
                    return;
                }

                if (ckFemininoEdit.Checked && ckMasculinoEdit.Checked)
                {
                    ((Master)MdiParent).MensagemAlerta("Selecione Masculino ou Feminino");
                    return;
                }

                if (!ckFemininoEdit.Checked && !ckMasculinoEdit.Checked)
                {
                    ((Master)MdiParent).MensagemAlerta("Selecione o Sexo");
                    return;
                }

                string sexo = "";
                if (ckMasculinoEdit.Checked)
                {
                    sexo = "M";
                }
                else
                {
                    sexo = "F";
                }

                aluno.Nome = txtNomeEdit.Text;
                aluno.DataNascimento = dtDataNascimentoEdit.Value;
                aluno.Sexo = sexo;
                aluno.atualizar(aluno);

                ((Master)MdiParent).MensagemSucesso("Aluno atualizado!");

                txtNomeEdit.Enabled = false;
                txtNomeEdit.Text = "";
                btnExcluir.Enabled = false;
                btnEdicao.Enabled = false;
                comboAluno.Items.Clear();
                ckMasculinoEdit.Checked = false;
                ckFemininoEdit.Checked = false;
                dtDataNascimentoEdit.Value = DateTime.Now;

                comboTurma.SelectedIndex = -1;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (comboAluno.SelectedIndex >= 0)
            {
                DialogResult di = ((Master) MdiParent).MensagemValidarExclusao("Tem certeza que deseja excluir esse Aluno?");

                if (di == DialogResult.OK)
                {
                    Aluno aluno = ((Aluno)comboAluno.SelectedItem);
                    aluno.deletar(aluno);

                    ((Master)MdiParent).MensagemSucesso("Aluno excluído!");

                    txtNomeEdit.Enabled = false;
                    txtNomeEdit.Text = "";
                    btnExcluir.Enabled = false;
                    btnEdicao.Enabled = false;
                    comboAluno.Items.Clear();

                    comboTurma.SelectedIndex = -1;
                }
            }
        }

        private void comboTurmaArquivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTurmaArquivo.SelectedIndex >= 0)
            {
                btnSelecaoArquivoAlunos.Enabled = true;
            }
            else
            {
                btnSelecaoArquivoAlunos.Enabled = false;
            }
        }

        private void btnSelecaoArquivoAlunos_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;

            dialog.CheckPathExists = true;
            dialog.Multiselect = false;
            dialog.Title = "Selecione o arquivo de Alunos";
            dialog.DefaultExt = "txt";

            DialogResult result = dialog.ShowDialog();

            Turma turma = new Turma();
            if (comboTurmaArquivo.SelectedIndex >= 0)
            {
                turma = comboTurmaArquivo.SelectedItem as Turma;
            }
            else
            {
                ((Master)MdiParent).MensagemAlerta("Selecione uma turma");
                return;
            }

            if (result.Equals(DialogResult.OK))
            {
                string nomeArquivo = dialog.FileName;

                if (File.Exists(nomeArquivo))
                {
                    int counter = 0;
                    string line;

                    StreamReader file = new StreamReader(nomeArquivo, Encoding.GetEncoding("iso-8859-1"));

                    while ((line = file.ReadLine()) != null)
                    {
                        string[] infos = line.Split(",".ToCharArray());

                        if (infos.Count() < 3)
                        {
                            ((Master)MdiParent).MensagemAlerta("Formato inválido na linha:" + counter);
                            return;
                        }

                        string nome = infos[0].TrimEnd().TrimStart();
                        string sexo = infos[1].TrimEnd().TrimStart();
                        string dataNascimentoStr = infos[2].TrimEnd().TrimStart();

                        if (nome.Length < 3)
                        {
                            ((Master)MdiParent).MensagemAlerta("Nome de aluno muito pequeno na linha: " + counter);
                            return;
                        }

                        if (!(sexo.Equals("M") || sexo.Equals("F")))
                        {
                            ((Master)MdiParent).MensagemAlerta("Sexo inválido na linha: " + counter);
                            return;
                        }

                        DateTime dataNascimento;
                        if (!DateTime.TryParse(dataNascimentoStr, out dataNascimento))
                        {
                            ((Master)MdiParent).MensagemAlerta("Data de nascimento inválida na linha: " + counter);
                            return;
                        }

                        counter++;
                    }

                    file.Close();
                    nomeArquivoAlunos = nomeArquivo;

                    btnimportarAlunos.Enabled = true;
                }
            }

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string line;

            StreamReader file2 = new StreamReader(nomeArquivoAlunos, Encoding.GetEncoding("iso-8859-1"));
            while ((line = file2.ReadLine()) != null)
            {
                string[] infos = line.Split(",".ToCharArray());

                string nome = infos[0].TrimEnd().TrimStart();
                string sexo = infos[1].TrimEnd().TrimStart();
                string dataNascimentoStr = infos[2].TrimEnd().TrimStart();

                DateTime dataNascimento;
                if (!DateTime.TryParse(dataNascimentoStr, out dataNascimento))
                {
                    ((Master)MdiParent).MensagemAlerta("Data de nascimento inválida na linha: " + counter);
                    return;
                }

                Aluno aluno = new Aluno();
                aluno.Nome = nome;
                aluno.Turma = (Turma)comboTurmaArquivo.SelectedItem;
                aluno.DataCadastro = DateTime.Now;
                aluno.DataNascimento = dataNascimento;
                aluno.Sexo = sexo;

                aluno.adicionar(aluno);
            }

            ((Master)MdiParent).MensagemSucesso("Alunos cadastrado!");

            file2.Close();
        }
    }
}
