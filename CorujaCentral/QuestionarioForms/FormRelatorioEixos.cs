using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Library.Persistencia;
using QuestionarioForms.DataSets;
using CrystalDecisions.Shared;

namespace QuestionarioForms
{
    public partial class FormRelatorioEixos : MetroForm
    {
        private List<ItemRelatorioAluno> vetItensRelatorio;
        private List<Area> vetAreasRelatorio;

        public FormRelatorioEixos()
        {
            InitializeComponent();

            comboEscola.Items.Clear();
            foreach (var escola in Instituicao.obterTodos())
            {
                comboEscola.Items.Add(escola);
            }

            comboEscola.DisplayMember = "Nome";
        }

        private void comboEscola_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEscola.SelectedIndex >= 0)
            {
                Instituicao escola = comboEscola.SelectedItem as Instituicao;

                if (escola.Turma.Count > 0)
                {
                    comboTurma.Enabled = true;
                    comboTurma.Items.Clear();
                    foreach (var turma in escola.Turma)
                    {
                        comboTurma.Items.Add(turma);
                    }

                    comboTurma.DisplayMember = "Nome";
                }
            }
            else
            {
                comboTurma.Enabled = false;
            }
        }

        private void comboTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTurma.SelectedIndex >= 0)
            {
                Turma turma = comboTurma.SelectedItem as Turma;

                List<Questionario> vetQuestionario = new List<Questionario>();

                foreach (var aluno in turma.Aluno)
                {
                    foreach (var resultado in aluno.Resultado)
                    {
                        if (!vetQuestionario.Contains(resultado.Questionario))
                        {
                            vetQuestionario.Add(resultado.Questionario);
                        }
                    }
                }

                if (vetQuestionario.Count >= 0)
                {
                    comboQuestionario.Enabled = true;
                    comboQuestionario.Items.Clear();
                    foreach (var quest in vetQuestionario)
                    {
                        comboQuestionario.Items.Add(quest);
                    }

                    comboQuestionario.DisplayMember = "Nome";
                }
            }
            else
            {
                comboQuestionario.Enabled = false;
            }
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            listVermelho.Items.Clear();
            listAmarelo.Items.Clear();
            listVerde.Items.Clear();
            listAzul.Items.Clear();

            if (comboTurma.SelectedIndex < 0)
            {
                ((Master) MdiParent).MensagemAlerta("Selecione uma Turma.");
                return;
            }

            if (comboQuestionario.SelectedIndex < 0)
            {
                ((Master) MdiParent).MensagemAlerta("Selecione um Questionario.");
                return;
            }

            vetItensRelatorio = new List<ItemRelatorioAluno>();

            Turma turma = comboTurma.SelectedItem as Turma;
            Questionario questionario = comboQuestionario.SelectedItem as Questionario;

            // CARRREGA AS AREAS CONTEMPLADAS NO RELATORIO
            vetAreasRelatorio = new List<Area>();

            List<Area> areasPortugues = new List<Area>();

            List<Questao> vetQuestoesValidas = questionario.Questao.ToList();
            vetQuestoesValidas.RemoveAll(q => q.TipoQuestao_id == 4);

            vetQuestoesValidas.ForEach(q => areasPortugues.Add(q.Area));
            areasPortugues = areasPortugues.ToList().FindAll(a => a.Disciplina_id == 1).Distinct().ToList();

            if (areasPortugues.Count > 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    vetAreasRelatorio.Add(areasPortugues[i]);
                }
            }
            else
            {
                vetAreasRelatorio.AddRange(areasPortugues);
            }

            List<Area> areasMatematica = new List<Area>();

            vetQuestoesValidas.ForEach(q => areasMatematica.Add(q.Area));
            areasMatematica = areasMatematica.ToList().FindAll(a => a.Disciplina_id == 2).Distinct().ToList();

            if (areasMatematica.Count > 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    vetAreasRelatorio.Add(areasMatematica[i]);
                }
            }
            else
            {
                vetAreasRelatorio.AddRange(areasMatematica);
            }

            List<Control> vetRadios = new List<Control>();
            foreach (Control control in pnlRadios.Controls)
            {
                if (control is RadioButton)
                {
                    vetRadios.Add(control);
                }
            }

            vetRadios.Reverse();

            areasMatematica = areasMatematica.OrderBy(a => a.idArea).ToList();
            areasPortugues = areasPortugues.OrderBy(a => a.idArea).ToList();
            vetAreasRelatorio = vetAreasRelatorio.OrderBy(a => a.idArea).ToList();

            vetAreasRelatorio = vetAreasRelatorio.OrderBy(o => o.Disciplina_id).ToList();

            int ia = 0;
            int indArea = 0;
            foreach (Control control in vetRadios)
            {
                if (vetAreasRelatorio.Count > indArea)
                {
                    if (vetAreasRelatorio[indArea].Disciplina_id == 1 && ia <= 3)
                    {
                        if (vetAreasRelatorio[indArea].Nome.Length > 18)
                            (control as RadioButton).Text = vetAreasRelatorio[indArea].Nome.Substring(0, 18);
                        else
                            (control as RadioButton).Text = vetAreasRelatorio[indArea].Nome;
                            
                        
                        (control as RadioButton).Tag = vetAreasRelatorio[indArea];
                        (control as RadioButton).CheckedChanged += AllCheckBoxes_CheckedChanged;
                        (control as RadioButton).Visible = true;
                        indArea++;
                    }
                    else if (vetAreasRelatorio[indArea].Disciplina_id == 2 && ia >= 4)
                    {
                        if (vetAreasRelatorio[indArea].Nome.Length > 18)
                            (control as RadioButton).Text = vetAreasRelatorio[indArea].Nome.Substring(0, 18);
                        else
                            (control as RadioButton).Text = vetAreasRelatorio[indArea].Nome;
                        (control as RadioButton).Tag = vetAreasRelatorio[indArea];
                        (control as RadioButton).CheckedChanged += AllCheckBoxes_CheckedChanged;
                        (control as RadioButton).Visible = true;
                        indArea++;
                    }
                    else
                    {
                        (control as RadioButton).Visible = false;
                    }

                }
                else
                {
                    (control as RadioButton).Visible = false;
                }

                ia++;
            }
          

            foreach (var aluno in turma.Aluno.OrderBy(a => a.Nome))
            {
                ItemRelatorioAluno itemRelatorio = new ItemRelatorioAluno();
                itemRelatorio.vetCorEixo = new List<int>();
                itemRelatorio.aluno = aluno;

                List<Pontuacao> vetPontuacaoAluno =
                    aluno.Pontuacao.ToList().FindAll(p => (p.Questao != null) && p.Questao.Questionario_id.Equals(questionario.idQuestionario));

                vetPontuacaoAluno.RemoveAll(p => p.Questao.TipoQuestao_id == 4);

                if (vetPontuacaoAluno.Count > 0)
                {
                    // Pega a cor das Areas do aluno
                    foreach (var area in vetAreasRelatorio)
                    {
                        List<Pontuacao> pontuacoesNaArea =
                            vetPontuacaoAluno.ToList().FindAll(p => p.Questao.Area_id.Equals(area.idArea));

                        if (pontuacoesNaArea.Count > 0)
                        {
                            pontuacoesNaArea = pontuacoesNaArea.OrderBy(p => p.DataHora).ToList();
                            Pontuacao ultima = pontuacoesNaArea.Last();

                            int corUltima = 0;

                            if (ultima.Acertou == true)
                            {
                                Color ultimaCor = ColorTranslator.FromHtml(ultima.Questao.Cor);

                                ItemRelatorioAluno.corRelatorio ultimaCorParse =
                                    ItemRelatorioAluno.convertCorRelatorioFromColor(ultimaCor);
                                corUltima = (int)ultimaCorParse;
                            }
                            else
                            {
                                Color ultimaCor = ColorTranslator.FromHtml(ultima.Questao.Cor);

                                ItemRelatorioAluno.corRelatorio ultimaCorParse =
                                    ItemRelatorioAluno.convertCorRelatorioFromColor(ultimaCor);
                                corUltima = (int)ultimaCorParse;
                                if(corUltima > 0)
                                    corUltima = corUltima - 1;
                            }

                            itemRelatorio.vetCorEixo.Add(corUltima);
                        }
                        else
                        {
                            itemRelatorio.vetCorEixo.Add((int)ItemRelatorioAluno.corRelatorio.branco);
                        }
                    }

                    // Pega a cor do aluno
                    //Color corFinal =
                    //    ColorTranslator.FromHtml(vetPontuacaoAluno.OrderBy(p => p.Questao.Ordem).Last().Questao.Cor);

                    //ItemRelatorioAluno.corRelatorio corFinalParse =
                    //    ItemRelatorioAluno.convertCorRelatorioFromColor(corFinal);

                    itemRelatorio.corAluno = -1;
                }

                vetItensRelatorio.Add(itemRelatorio);
            }

            pnlPrincipal.Visible = true;

            btnPDF.Enabled = true;
            btnPDFMt.Enabled = true;
        }

        private void AllCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            // Check of the raiser of the event is a checked Checkbox.
            // Of course we also need to to cast it first.
            if (((RadioButton)sender).Checked)
            {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;
                Area areaSelecionada = rb.Tag as Area;

                int indice = vetAreasRelatorio.IndexOf(areaSelecionada);

                listVermelho.Items.Clear();
                listAmarelo.Items.Clear();
                listVerde.Items.Clear();
                listAzul.Items.Clear();

                foreach (var itemRelatorioAluno in vetItensRelatorio)
                {
                    if (itemRelatorioAluno.vetCorEixo.Count > 0)
                    {
                        if (
                            itemRelatorioAluno.vetCorEixo[indice].Equals(
                                (int) QuestionarioForms.ItemRelatorioAluno.corRelatorio.vermelho))
                        {
                            listVermelho.Items.Add(itemRelatorioAluno.aluno.Nome);
                        }

                        if (
                            itemRelatorioAluno.vetCorEixo[indice].Equals(
                                (int) QuestionarioForms.ItemRelatorioAluno.corRelatorio.amarelo))
                        {
                            listAmarelo.Items.Add(itemRelatorioAluno.aluno.Nome);
                        }

                        if (
                            itemRelatorioAluno.vetCorEixo[indice].Equals(
                                (int) QuestionarioForms.ItemRelatorioAluno.corRelatorio.verde))
                        {
                            listVerde.Items.Add(itemRelatorioAluno.aluno.Nome);
                        }

                        if (
                            itemRelatorioAluno.vetCorEixo[indice].Equals(
                                (int) QuestionarioForms.ItemRelatorioAluno.corRelatorio.azul))
                        {
                            listAzul.Items.Add(itemRelatorioAluno.aluno.Nome);
                        }
                    }
                }

            }
        }

        private void pnlVermelho_Paint(object sender, PaintEventArgs e)
        {
            int thickness = 3;

            int halfThickness = thickness/2;

            using (Pen p = new Pen(Color.IndianRed, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                    halfThickness,
                    pnlVermelho.ClientSize.Width - thickness,
                    pnlVermelho.ClientSize.Height - thickness));
            }

        }

        private void pnlAmarelo_Paint(object sender, PaintEventArgs e)
        {
            int thickness = 3;

            int halfThickness = thickness/2;

            using (Pen p = new Pen(Color.Khaki, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                    halfThickness,
                    pnlAmarelo.ClientSize.Width - thickness,
                    pnlAmarelo.ClientSize.Height - thickness));
            }
        }

        private void pnlVerde_Paint(object sender, PaintEventArgs e)
        {
            int thickness = 3;

            int halfThickness = thickness/2;

            using (Pen p = new Pen(Color.LightGreen, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                    halfThickness,
                    pnlVerde.ClientSize.Width - thickness,
                    pnlVerde.ClientSize.Height - thickness));
            }
        }

        private void pnlAzul_Paint(object sender, PaintEventArgs e)
        {
            int thickness = 3;

            int halfThickness = thickness/2;

            using (Pen p = new Pen(Color.LightSkyBlue, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                    halfThickness,
                    pnlAzul.ClientSize.Width - thickness,
                    pnlAzul.ClientSize.Height - thickness));
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {

                List<Area> areasPortugues = vetAreasRelatorio.FindAll(a => a.Disciplina_id == 1);
                    

                if (areasPortugues.Count == 4)
                {

                    FormPDF formpdf = new FormPDF();

                    formpdf.ShowDialog();

                    string nomeProfessor = formpdf.nomeProfessor;

                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.AddExtension = true;
                    dialog.Filter = "PDF|*.pdf";
                    dialog.DefaultExt = ".pdf";

                    DialogResult result = dialog.ShowDialog();

                    if (result.Equals(DialogResult.OK))
                    {
                        string path = dialog.FileName;

                        PDFReporGrupoPT report = new PDFReporGrupoPT();

                        // Cria listas para representar o relatorio pdf
                        List<itemPDFGrupo> vetEixo1 = new List<itemPDFGrupo>();
                        List<itemPDFGrupo> vetEixo2 = new List<itemPDFGrupo>();
                        List<itemPDFGrupo> vetEixo3 = new List<itemPDFGrupo>();
                        List<itemPDFGrupo> vetEixo4 = new List<itemPDFGrupo>();


                        foreach (var itemRelatorioAluno in vetItensRelatorio)
                        {
                            if (itemRelatorioAluno.vetCorEixo.Count > 0)
                            {
                                itemPDFGrupo item1 = new itemPDFGrupo();
                                item1.nome = itemRelatorioAluno.aluno.Nome;
                                item1.corint = itemRelatorioAluno.vetCorEixo[0];
                                item1.cor = itemRelatorioAluno.vetCorEixo[0].ToString();
                                vetEixo1.Add(item1);
                            }

                            if (itemRelatorioAluno.vetCorEixo.Count > 1)
                            {
                                itemPDFGrupo item2 = new itemPDFGrupo();
                                item2.nome = itemRelatorioAluno.aluno.Nome;
                                item2.corint = itemRelatorioAluno.vetCorEixo[1];
                                item2.cor = itemRelatorioAluno.vetCorEixo[1].ToString();
                                vetEixo2.Add(item2);
                            }

                            if (itemRelatorioAluno.vetCorEixo.Count > 2)
                            {
                                itemPDFGrupo item3 = new itemPDFGrupo();
                                item3.nome = itemRelatorioAluno.aluno.Nome;
                                item3.corint = itemRelatorioAluno.vetCorEixo[2];
                                item3.cor = itemRelatorioAluno.vetCorEixo[2].ToString();
                                vetEixo3.Add(item3);
                            }

                            if (itemRelatorioAluno.vetCorEixo.Count > 3)
                            {
                                itemPDFGrupo item4 = new itemPDFGrupo();
                                item4.nome = itemRelatorioAluno.aluno.Nome;
                                item4.corint = itemRelatorioAluno.vetCorEixo[3];
                                item4.cor = itemRelatorioAluno.vetCorEixo[3].ToString();
                                vetEixo4.Add(item4);
                            }
                        }

                        // ordena as listas pelas cores
                        vetEixo1 = vetEixo1.OrderBy(l => l.corint).ToList();
                        vetEixo2 = vetEixo2.OrderBy(l => l.corint).ToList();
                        vetEixo3 = vetEixo3.OrderBy(l => l.corint).ToList();
                        vetEixo4 = vetEixo4.OrderBy(l => l.corint).ToList();

                        // Constroi DataSet
                        DataSetGrupo ds = new DataSetGrupo();


                        int i = 0;
                        foreach (var itemRelatorioAluno in vetItensRelatorio)
                        {
                            DataRow row = ds.DataTable1.NewRow();
                            bool teveLinha = false;

                            if (vetEixo4.Count > i)
                            {
                                row[0] = "  " + vetEixo1[i].nome;
                                row[4] = vetEixo1[i].cor;
                                teveLinha = true;
                            }

                            if (vetEixo1.Count > i)
                            {
                                row[1] = "  " + vetEixo2[i].nome;
                                row[5] = vetEixo2[i].cor;
                                teveLinha = true;
                            }

                            if (vetEixo2.Count > i)
                            {
                                row[2] = "  " + vetEixo4[i].nome;
                                row[6] = vetEixo4[i].cor;
                                teveLinha = true;
                            }

                            if (vetEixo3.Count > i)
                            {
                                row[3] = "  " + vetEixo3[i].nome;
                                row[7] = vetEixo3[i].cor;
                                teveLinha = true;
                            }

                           
                            if (teveLinha)
                                ds.DataTable1.Rows.Add(row);

                            i++;
                        }


                        // Constroi Report
                        PageMargins margem = report.PrintOptions.PageMargins;
                        margem.bottomMargin = 0;
                        margem.leftMargin = 0;
                        margem.rightMargin = 0;
                        margem.topMargin = 0;

                        report.PrintOptions.ApplyPageMargins(margem);

                        //report.SetDataSource(ds);
                        report.Database.Tables[0].SetDataSource(ds);

                        Turma turma = (comboTurma.SelectedItem as Turma);
                        Questionario questionario = (comboQuestionario.SelectedItem as Questionario);

                        Pontuacao pontuacao =
                            Pontuacao.obterTodos()
                                .Find(
                                    p =>
                                        p.Aluno.Turma_id.Equals(turma.idTurma) &&
                                        p.Questao.Questionario_id.Equals(questionario.idQuestionario));

                        // Popula as Variaveis fixas do Report
                        (report.Section2.ReportObjects["txtProfessor"] as
                            CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text = nomeProfessor;
                        (report.Section2.ReportObjects["txtTurma"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text =
                            turma.Nome;
                        (report.Section2.ReportObjects["txtEscola"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text =
                            (comboEscola.SelectedItem as Instituicao).Nome;
                        (report.Section2.ReportObjects["txtData"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            ((DateTime) pontuacao.DataHora).ToShortDateString();


                        // Exporta o Report
                        report.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        report.ExportToDisk(ExportFormatType.PortableDocFormat, path);

                        ((Master) MdiParent).MensagemSucesso("PDF Exportado!");
                    }
                }
                else
                {
                    ((Master) MdiParent).MensagemErro(
                        "Não contém resultados de Português suficientes para gerar o relatório!");
                }

            }
            catch (Exception)
            {
                ((Master) MdiParent).MensagemErro(
                    "Não foi possível gerar o PDF. Verifique se está com o programa de relatórios instalado.");
            }
        }

        private string getNomeEixoFormatado(string nome)
        {
            if (nome.Contains("-"))
            {
                string res = nome;
                int traco = nome.IndexOf("-");
                res = res.Substring(0, traco);
                return res;
            }
            else
            {
                return nome;
            }
        }

        private void btnPDFMt_Click(object sender, EventArgs e)
        {
            try
            {

                List<Area> areasMatematica = vetAreasRelatorio.FindAll(a => a.Disciplina_id == 2);

                if (areasMatematica.Count == 4)
                {

                    FormPDF formpdf = new FormPDF();

                    formpdf.ShowDialog();

                    string nomeProfessor = formpdf.nomeProfessor;

                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.AddExtension = true;
                    dialog.Filter = "PDF|*.pdf";
                    dialog.DefaultExt = ".pdf";

                    DialogResult result = dialog.ShowDialog();

                    if (result.Equals(DialogResult.OK))
                    {
                        string path = dialog.FileName;

                        PDFReporGrupo_MT report = new PDFReporGrupo_MT();

                        // Cria listas para representar o relatorio pdf
                        List<itemPDFGrupo> vetEixo1 = new List<itemPDFGrupo>();
                        List<itemPDFGrupo> vetEixo2 = new List<itemPDFGrupo>();
                        List<itemPDFGrupo> vetEixo3 = new List<itemPDFGrupo>();
                        List<itemPDFGrupo> vetEixo4 = new List<itemPDFGrupo>();

                        bool contemDuasDisciplinas = false;
                        foreach (var item in vetItensRelatorio)
                        {
                            if (item.vetCorEixo.Count > 4)
                            {
                                contemDuasDisciplinas = true;
                            }
                        }


                        if (!contemDuasDisciplinas)
                        {
                            foreach (var itemRelatorioAluno in vetItensRelatorio)
                            {
                                if (itemRelatorioAluno.vetCorEixo.Count > 0)
                                {
                                    itemPDFGrupo item1 = new itemPDFGrupo();
                                    item1.nome = itemRelatorioAluno.aluno.Nome;
                                    item1.corint = itemRelatorioAluno.vetCorEixo[0];
                                    item1.cor = itemRelatorioAluno.vetCorEixo[0].ToString();
                                    vetEixo1.Add(item1);
                                }

                                if (itemRelatorioAluno.vetCorEixo.Count > 1)
                                {
                                    itemPDFGrupo item2 = new itemPDFGrupo();
                                    item2.nome = itemRelatorioAluno.aluno.Nome;
                                    item2.corint = itemRelatorioAluno.vetCorEixo[1];
                                    item2.cor = itemRelatorioAluno.vetCorEixo[1].ToString();
                                    vetEixo2.Add(item2);
                                }

                                if (itemRelatorioAluno.vetCorEixo.Count > 2)
                                {
                                    itemPDFGrupo item3 = new itemPDFGrupo();
                                    item3.nome = itemRelatorioAluno.aluno.Nome;
                                    item3.corint = itemRelatorioAluno.vetCorEixo[2];
                                    item3.cor = itemRelatorioAluno.vetCorEixo[2].ToString();
                                    vetEixo3.Add(item3);
                                }

                                if (itemRelatorioAluno.vetCorEixo.Count > 3)
                                {
                                    itemPDFGrupo item4 = new itemPDFGrupo();
                                    item4.nome = itemRelatorioAluno.aluno.Nome;
                                    item4.corint = itemRelatorioAluno.vetCorEixo[3];
                                    item4.cor = itemRelatorioAluno.vetCorEixo[3].ToString();
                                    vetEixo4.Add(item4);
                                }
                            }
                        }
                        else
                        {
                            foreach (var itemRelatorioAluno in vetItensRelatorio)
                            {
                                if (itemRelatorioAluno.vetCorEixo.Count > 4)
                                {
                                    itemPDFGrupo item1 = new itemPDFGrupo();
                                    item1.nome = itemRelatorioAluno.aluno.Nome;
                                    item1.corint = itemRelatorioAluno.vetCorEixo[4];
                                    item1.cor = itemRelatorioAluno.vetCorEixo[4].ToString();
                                    vetEixo1.Add(item1);
                                }

                                if (itemRelatorioAluno.vetCorEixo.Count > 5)
                                {
                                    itemPDFGrupo item2 = new itemPDFGrupo();
                                    item2.nome = itemRelatorioAluno.aluno.Nome;
                                    item2.corint = itemRelatorioAluno.vetCorEixo[5];
                                    item2.cor = itemRelatorioAluno.vetCorEixo[5].ToString();
                                    vetEixo2.Add(item2);
                                }

                                if (itemRelatorioAluno.vetCorEixo.Count > 6)
                                {
                                    itemPDFGrupo item3 = new itemPDFGrupo();
                                    item3.nome = itemRelatorioAluno.aluno.Nome;
                                    item3.corint = itemRelatorioAluno.vetCorEixo[6];
                                    item3.cor = itemRelatorioAluno.vetCorEixo[6].ToString();
                                    vetEixo3.Add(item3);
                                }

                                if (itemRelatorioAluno.vetCorEixo.Count > 7)
                                {
                                    itemPDFGrupo item4 = new itemPDFGrupo();
                                    item4.nome = itemRelatorioAluno.aluno.Nome;
                                    item4.corint = itemRelatorioAluno.vetCorEixo[7];
                                    item4.cor = itemRelatorioAluno.vetCorEixo[7].ToString();
                                    vetEixo4.Add(item4);
                                }
                            }
                        }



                        // ordena as listas pelas cores
                        vetEixo1 = vetEixo1.OrderBy(l => l.corint).ToList();
                        vetEixo2 = vetEixo2.OrderBy(l => l.corint).ToList();
                        vetEixo3 = vetEixo3.OrderBy(l => l.corint).ToList();
                        vetEixo4 = vetEixo4.OrderBy(l => l.corint).ToList();

                        // Constroi DataSet
                        DataSetGrupo ds = new DataSetGrupo();


                        int i = 0;
                        foreach (var itemRelatorioAluno in vetItensRelatorio)
                        {
                            DataRow row = ds.DataTable1.NewRow();
                            bool teveLinha = false;

                            if (vetEixo1.Count > i)
                            {
                                row[0] = "  " + vetEixo1[i].nome;
                                row[4] = vetEixo1[i].cor;
                                teveLinha = true;
                            }

                            if (vetEixo2.Count > i)
                            {
                                row[1] = "  " + vetEixo2[i].nome;
                                row[5] = vetEixo2[i].cor;
                                teveLinha = true;
                            }

                            if (vetEixo3.Count > i)
                            {
                                row[2] = "  " + vetEixo3[i].nome;
                                row[6] = vetEixo3[i].cor;
                                teveLinha = true;
                            }

                            if (vetEixo3.Count > i)
                            {
                                row[3] = "  " + vetEixo4[i].nome;
                                row[7] = vetEixo4[i].cor;
                                teveLinha = true;
                            }
                            if (teveLinha)
                                ds.DataTable1.Rows.Add(row);

                            i++;
                        }


                        // Constroi Report
                        PageMargins margem = report.PrintOptions.PageMargins;
                        margem.bottomMargin = 0;
                        margem.leftMargin = 0;
                        margem.rightMargin = 0;
                        margem.topMargin = 0;

                        report.PrintOptions.ApplyPageMargins(margem);

                        //report.SetDataSource(ds);
                        report.Database.Tables[0].SetDataSource(ds);

                        Turma turma = (comboTurma.SelectedItem as Turma);
                        Questionario questionario = (comboQuestionario.SelectedItem as Questionario);

                        Pontuacao pontuacao =
                            Pontuacao.obterTodos()
                                .Find(
                                    p =>
                                        p.Aluno.Turma_id.Equals(turma.idTurma) &&
                                        p.Questao.Questionario_id.Equals(questionario.idQuestionario));

                        // Popula as Variaveis fixas do Report
                        (report.Section2.ReportObjects["txtProfessor"] as
                            CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text = nomeProfessor;
                        (report.Section2.ReportObjects["txtTurma"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text =
                            turma.Nome;
                        (report.Section2.ReportObjects["txtEscola"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text =
                            (comboEscola.SelectedItem as Instituicao).Nome;
                        (report.Section2.ReportObjects["txtData"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            ((DateTime) pontuacao.DataHora).ToShortDateString();

           


                        // Exporta o Report
                        report.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        report.ExportToDisk(ExportFormatType.PortableDocFormat, path);

                        ((Master) MdiParent).MensagemSucesso("PDF Exportado!");
                    }
                }
                else
                {
                    ((Master) MdiParent).MensagemErro(
                        "Não contém resultados de Matemática suficientes para gerar o relatório!");
                }

            }
            catch (Exception)
            {
                ((Master) MdiParent).MensagemErro(
                    "Não foi possível gerar o PDF. Verifique se está com o programa de relatórios instalado.");
            }
        }
    }

    public class itemPDFGrupo
    {
        public string nome { get; set; }
        public int corint { get; set; }
        public string cor { get; set; }

    }
}
