using Library.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace QuestionarioForms
{
    public partial class FormArea : MetroForm
    {
        public FormArea()
        {
            InitializeComponent();

            carregarTela();
        }

        private void carregarTela()
        {
            comboDisciplina.DataSource = Disciplina.obterTodos().OrderBy(d => d.Nome).ToList();
            comboDisciplina.DisplayMember = "Nome";

            foreach(Disciplina dis in Disciplina.obterTodos().OrderBy(d => d.Nome).ToList())
            {
                comboDisciplinaEdit.Items.Add(dis);
            }

            comboDisciplinaEdit.DisplayMember = "Nome";

            btnExcluirArea.Enabled = false;
        }



        private void comboDisciplinaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboDisciplinaEdit.SelectedIndex >= 0)
            {
                if (Area.obterTodos() != null)
                {
                    comboArea.Items.Clear();
                    txtEditArea.Text = "";

                    List<Area> listaArea =
                        Area.obterTodos()
                            .FindAll(a => a.Disciplina == comboDisciplinaEdit.SelectedItem)
                            .OrderBy(a => a.Nome)
                            .ToList();

                    foreach (Area ar in listaArea)
                    {
                        comboArea.Items.Add(ar);
                    }

                    comboArea.DisplayMember = "Nome";

                    txtEditArea.Enabled = false;
                    btnExcluirArea.Enabled = false;
                }
            }
            else
            {
                comboArea.Items.Clear();
                txtEditArea.Text = "";
                txtEditArea.Enabled = false;
                btnExcluirArea.Enabled = false;
            }
        }

        private void comboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboArea.SelectedIndex >= 0)
            {
                var area = comboArea.SelectedItem as Area;
                if (area != null) txtEditArea.Text = area.Nome;

                txtEditArea.Enabled = true;
                btnExcluirArea.Enabled = true;
            }
            else
            {
                txtEditArea.Text = "";

                txtEditArea.Enabled = false;
                btnExcluirArea.Enabled = false;
            }
        }

        private void btnExcluirArea_Click(object sender, EventArgs e)
        {
            Area area = comboArea.SelectedItem as Area;
            bool deleta;


            if(area != null && area.Questao.Count > 0)
            {
                 DialogResult di = ((Master) MdiParent).MensagemValidarExclusao("Esse Eixo está associada a alguma(s) questões. Tem certeza que deseja excluir o Eixo e deixar as questões relacionadas sem Eixo?");

                 if (di == DialogResult.OK)
                 {
                     deleta = true;

                     area.Questao.ToList().ForEach(i => i.Area_id = null);
                     area.Questao.ToList().ForEach(i => i.atualizar(i));
                 }
                 else
                 {
                     deleta = false;
                 }
            }
            else
            {
                deleta = true;
            }

            if(deleta)
            {
                if (area != null) area.deletar(area);

                ((Master) MdiParent).MensagemSucesso("Eixo excluído!");

                comboDisciplinaEdit.SelectedIndex = -1;
                comboArea.SelectedIndex = -1;
                txtEditArea.Text = "";
                txtEditArea.Enabled = false;
                comboArea.Items.Clear();
            }
        }

        private void btnSalvarNova_Click(object sender, EventArgs e)
        {
            var area = new Area();
            area.Nome = txtNovaArea.Text;
            area.Disciplina = comboDisciplina.SelectedItem as Disciplina;

            area.adicionar(area);

            ((Master) MdiParent).MensagemSucesso("Eixo Cadastrado!");
            comboDisciplinaEdit.SelectedIndex = -1;
            comboArea.SelectedIndex = -1;
            txtEditArea.Text = "";
            txtEditArea.Enabled = false;
            txtNovaArea.Text = "";
        }

        private void btnSalvarEdit_Click(object sender, EventArgs e)
        {
            if(comboArea.SelectedIndex >= 0)
            {
                if(txtEditArea.Text.Length > 0)
                {
                    Area area = comboArea.SelectedItem as Area;
                    if (area != null)
                    {
                        area.Nome = txtEditArea.Text;
                        area.Disciplina = comboDisciplinaEdit.SelectedItem as Disciplina;

                        area.atualizar(area);
                    }

                    ((Master) MdiParent).MensagemSucesso("Eixo Atualizado!");
                    comboDisciplinaEdit.SelectedIndex = -1;
                    comboArea.SelectedIndex = -1;
                    txtEditArea.Text = "";
                    txtEditArea.Enabled = false;
                    comboArea.Items.Clear();
                }
                else
                {
                    ((Master) MdiParent).MensagemAlerta("Insira um Texto.");
                }
            }
            else
            {
                ((Master) MdiParent).MensagemAlerta("Selecione um Eixo.");
            }

          
        }
    }
}
