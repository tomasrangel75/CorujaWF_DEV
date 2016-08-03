using Library.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestionarioForms.DataSets;
using CrystalDecisions.Shared;

namespace QuestionarioForms
{
    public partial class FormRelatorioPsico : MetroFramework.Forms.MetroForm
    {
        public FormRelatorioPsico()
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

                if (turma.Aluno.Count > 0)
                {
                    comboAluno.Enabled = true;
                    comboAluno.Items.Clear();
                    foreach (var aluno in turma.Aluno)
                    {
                        comboAluno.Items.Add(aluno);
                    }

                    comboAluno.DisplayMember = "Nome";
                }
            }
            else
            {
                comboAluno.Enabled = false;
            }
        }

        private void comboAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAluno.SelectedIndex >= 0)
            {
                Aluno aluno = comboAluno.SelectedItem as Aluno;

                List<Questionario> vetQuestionario = new List<Questionario>();

              
                foreach (var resultado in aluno.Resultado)
                {
                    if (!vetQuestionario.Contains(resultado.Questionario))
                    {
                        vetQuestionario.Add(resultado.Questionario);
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
            if (comboQuestionario.SelectedIndex >= 0)
            {
                btnCSV.Enabled = true;
                btnPDF.Enabled = true;
                dataGridViewPsico.Columns.Clear();

                Aluno aluno = comboAluno.SelectedItem as Aluno;
                Questionario questionario = comboQuestionario.SelectedItem as Questionario;

                List<Pontuacao> vetPontuacaoAluno =
                         aluno.Pontuacao.ToList().FindAll(p => (p.Questao != null) && (p.Questao.Questionario_id.Equals(questionario.idQuestionario)) && (p.Questao.TipoQuestao_id == 4));

                vetPontuacaoAluno.Sort((ps1, ps2) => DateTime.Compare((DateTime)ps1.DataHora, (DateTime)ps2.DataHora));

                dataGridViewPsico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewPsico.RowHeadersVisible = false;

                dataGridViewPsico.Columns.Add("Col1", "Palavra-alvo");
                dataGridViewPsico.Columns.Add("Col2", "Produção");
                dataGridViewPsico.Columns.Add("Col3", "Hipótese");

                dataGridViewPsico.Columns[0].DefaultCellStyle.BackColor = Color.MintCream;
                dataGridViewPsico.Columns[1].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                dataGridViewPsico.Columns[2].DefaultCellStyle.BackColor = Color.AliceBlue;

                dataGridViewPsico.Rows.Clear();

                foreach (var pontuacao in vetPontuacaoAluno)
                {
                    string palavra =
                        pontuacao.Questao.ItemQuestao.ToList()
                            .Find(i => i.EPergunta != null && i.EPergunta == true)
                            .Titulo;

                    palavra = palavra.Substring(0, palavra.IndexOf("(")).Replace(";", "");

                    string resposta = pontuacao.Mouse;

                    int classificacaoBanco = (int)pontuacao.Tentativas;

                    TipoQuestao.TipoPsicogenese tipoClassificado = (TipoQuestao.TipoPsicogenese)classificacaoBanco;

                    string classificacao = "";

                    if (tipoClassificado == TipoQuestao.TipoPsicogenese.Alfabetico)
                        classificacao = "Alfabético";
                    else if (tipoClassificado == TipoQuestao.TipoPsicogenese.Ortografico)
                        classificacao = "Ortográfico";
                    else if (tipoClassificado == TipoQuestao.TipoPsicogenese.PreSilabico)
                        classificacao = "Pré-Silábico";
                    else if (tipoClassificado == TipoQuestao.TipoPsicogenese.SilabicoComValor)
                        classificacao = "Silábico com Valor";
                    else if (tipoClassificado == TipoQuestao.TipoPsicogenese.SilabicoSemValor)
                        classificacao = "Silábico sem Valor";

                    dataGridViewPsico.Rows.Add(palavra, resposta, classificacao);


                }
            }
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.Filter = "CSV|*.csv";
            dialog.DefaultExt = ".csv";
            DialogResult result = dialog.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                string path = dialog.FileName;
                var sb = new StringBuilder();

                var headers = dataGridViewPsico.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(";", headers.Select(column => column.HeaderText).ToArray()));

                foreach (DataGridViewRow row in dataGridViewPsico.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();

                    sb.AppendLine(string.Join(";", cells.Select(cell => cell.Value).ToArray()));
                }

            

                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);

                ((Master)MdiParent).MensagemSucesso("Relatório Exportado!");
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPsico.Rows.Count > 0)
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

                        PDFReportPsico report = new PDFReportPsico();

                        // Constroi DataSet
                        DataSetPsico ds = new DataSetPsico();


                        foreach (DataGridViewRow linha in dataGridViewPsico.Rows)
                        {

                            if (linha.Cells[0].Value != null)
                            {
                                DataRow row = ds.DataTable1.NewRow();

                                row[0] = linha.Cells[0].Value.ToString();
                                row[1] = linha.Cells[1].Value.ToString();
                                row[2] = linha.Cells[2].Value.ToString();

                                ds.DataTable1.Rows.Add(row);
                            }
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

                        (report.Section2.ReportObjects["txtDisciplina"] as
                            CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text =
                            "Psicogenese DA LÍNGUA ESCRITA";

                        (report.Section2.ReportObjects["txtAluno"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            (comboAluno.SelectedItem as Aluno).Nome;

                        (report.Section2.ReportObjects["Text3"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Palavra-alvo";

                        (report.Section2.ReportObjects["Text4"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Produção";

                        (report.Section2.ReportObjects["Text6"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            = "Hipótese";


                        // Exporta o Report
                        report.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        report.ExportToDisk(ExportFormatType.PortableDocFormat, path);

                        ((Master) MdiParent).MensagemSucesso("PDF Exportado!");
                    }
                }
                else
                {
                    ((Master) MdiParent).MensagemErro("Não contém resultados suficientes para gerar o relatório!");
                }
            }
            catch (Exception)
            {
                ((Master)MdiParent).MensagemErro("Não foi possível gerar o PDF. Verifique se está com o programa de relatórios instalado.");
            }
        }
    }
}
