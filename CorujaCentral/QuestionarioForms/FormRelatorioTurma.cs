using System.Windows.Forms.VisualStyles;
using CrystalDecisions.Shared;
using Library.Persistencia;
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
using System.IO;
using QuestionarioForms.DataSets;

namespace QuestionarioForms
{
    public partial class FormRelatorioTurma : MetroForm
    {
        List<ItemRelatorioAluno> vetItensRelatorio { get; set; }
        List<Area> vetAreasRelatorio { get; set; }

        public FormRelatorioTurma()
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
            gridAlunos.Columns.Clear();

            if (comboTurma.SelectedIndex < 0)
            {
                ((Master)MdiParent).MensagemAlerta("Selecione uma Turma.");
                return;
            }

            if (comboQuestionario.SelectedIndex < 0)
            {
                ((Master)MdiParent).MensagemAlerta("Selecione um Questionario.");
                return;
            }

            vetItensRelatorio = new List<ItemRelatorioAluno>();

            Turma turma = comboTurma.SelectedItem as Turma;
            Questionario questionario = comboQuestionario.SelectedItem as Questionario;

            // CARRREGA AS AREAS CONTEMPLADAS NO RELATORIO
            vetAreasRelatorio = new List<Area>();

            //PORTUGUES/////////////////////////////////////////////////////////////////////////////////////////////////////
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

            // MATEMATICA ////////////////////////////////////////////////////////////////////////////////////////////////
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



            // APRENDIZAGEM ////////////////////////////////////////////////////////////////////////////////////////////////
            List<Area> areasAprendizagem = new List<Area>();

            vetQuestoesValidas.ForEach(q => areasAprendizagem.Add(q.Area));
            areasAprendizagem = areasAprendizagem.ToList().FindAll(a => a.Disciplina_id == 3).Distinct().ToList();

            if (areasAprendizagem.Count > 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    vetAreasRelatorio.Add(areasAprendizagem[i]);
                }
            }
            else
            {
                vetAreasRelatorio.AddRange(areasAprendizagem);
            }

                       


            if (vetAreasRelatorio.Count > 4)
            {
                //vetAreasRelatorio = vetAreasRelatorio.OrderBy(a => a.idArea).ToList();
            }
            else
            {
                vetAreasRelatorio = vetAreasRelatorio.OrderBy(a => a.idArea).ToList();
            }

            foreach (var area in vetAreasRelatorio)
            {
                List<Questao> vetQuestoesArea = vetQuestoesValidas.FindAll(p => p.Area_id.Equals(area.idArea));

                int maxOrd = (int)vetQuestoesValidas.OrderByDescending(q => q.Ordem).ToList()[0].Ordem;

                GrafoQuestionario novoGrafo = new GrafoQuestionario();
                novoGrafo.gerarGrafo(vetQuestoesArea, maxOrd);


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
                                if (corUltima > 0)
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
                    //Color corFinal = ColorTranslator.FromHtml(vetPontuacaoAluno.OrderBy(p => p.Questao.Ordem).Last().Questao.Cor);

                    //ItemRelatorioAluno.corRelatorio corFinalParse =
                    //           ItemRelatorioAluno.convertCorRelatorioFromColor(corFinal);

                    itemRelatorio.corAluno = -1;
                }

                vetItensRelatorio.Add(itemRelatorio);

                btnCSV.Enabled = true;
                btnPDF.Enabled = true;
                btnPDFMt.Enabled = true;
                btnPdfApr.Enabled = true;
            }

            // Construcao da Grid de resultados

            gridAlunos.Columns.Clear();

            gridAlunos.AllowUserToAddRows = false;
            gridAlunos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gridAlunos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            gridAlunos.ColumnHeadersDefaultCellStyle.Font = new Font("HelveticaRounded LT Std Bd", 11, FontStyle.Bold);
            gridAlunos.RowHeadersVisible = false;


            gridAlunos.Columns.Add("Col1", "Aluno");
            gridAlunos.Columns[0].Width = 250;

            int cont = 2;
            foreach (var area in vetAreasRelatorio)
            {
                gridAlunos.Columns.Add("Col" + cont, area.Nome);
                gridAlunos.Columns[cont - 1].Width = 110;
                cont++;
            }

            gridAlunos.Rows.Clear();

            foreach (var item in vetItensRelatorio)
            {
                int indice = gridAlunos.Rows.Add();

                DataGridViewRow linhaNova = gridAlunos.Rows[indice];

                int i = 0;
                foreach (var cell in linhaNova.Cells)
                {
                    if (i == 0)
                    {
                        (cell as DataGridViewCell).Value = item.aluno.Nome;
                        (cell as DataGridViewCell).Style.WrapMode = DataGridViewTriState.True;
                        //(cell as DataGridViewCell).Style.BackColor =
                        //    ItemRelatorioAluno.convertColorRelatorioFromCor(item.corAluno);

                        //(cell as DataGridViewCell).Style.SelectionBackColor =
                        //    ItemRelatorioAluno.convertColorRelatorioFromCor(item.corAluno);
                         
                        (cell as DataGridViewCell).Style.Font = new Font("HelveticaRounded LT Std Bd", 10, FontStyle.Bold);
                    }
                    else
                    {
                        if (item.vetCorEixo.Count > 0)
                        {
                            int corArea = item.vetCorEixo[i - 1];
                            (cell as DataGridViewCell).Value = corArea;
                            
                            
                            Color cor = ItemRelatorioAluno.convertColorRelatorioFromCor(corArea);
                            if (!cor.Equals(Color.White))
                            {
                                (cell as DataGridViewCell).Style.BackColor = cor;
                                (cell as DataGridViewCell).Style.SelectionBackColor = cor;
                            }

                            (cell as DataGridViewCell).Style.ForeColor = cor;
                        }
                    }

                    i++;
                }
            }


        }

        private void gridAlunos_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (e.Cell == null || e.StateChanged != DataGridViewElementStates.Selected)
                return;

            e.Cell.Selected = false;
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

                var headers = gridAlunos.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(";", headers.Select(column => column.HeaderText).ToArray()));

                foreach (DataGridViewRow row in gridAlunos.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();


                    sb.AppendLine(string.Join(";", cells.Select(cell => formataCelulas(cell.Value)).ToArray()));
                }

                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);

                ((Master)MdiParent).MensagemSucesso("Relatório Exportado!");
            }
        }

        private string formataCelulas(object value)
        {
            if (value == null)
                return "";

            string valor = value.ToString();


            if (valor.Length > 1)
                return valor;

            if (valor.Equals("0"))
            {
                return "Vermelho";
            }
            else if (valor.Equals("1"))
            {
                return "Amarelo";
            }
            else if (valor.Equals("2"))
            {
                return "Verde";
            }
            else if (valor.Equals("3"))
            {
                return "Azul";
            }

            if(valor.Length == 1)
                return "Branco";

            return "";
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {

            string dtAplic = this.txtDtAplic.Text;

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

                        PDFReporListaTurma report = new PDFReporListaTurma();
                        

                        // Constroi DataSet
                        DataSetTurmaLista ds = new DataSetTurmaLista();

                        foreach (var itemRelatorioAluno in vetItensRelatorio)
                        {
                            DataRow row = ds.DataTable1.NewRow();
                            row[0] = itemRelatorioAluno.aluno.Nome;
                            if (itemRelatorioAluno.vetCorEixo.Count > 0)
                                row[1] = itemRelatorioAluno.vetCorEixo[0].ToString();
                            if (itemRelatorioAluno.vetCorEixo.Count > 1)
                                row[2] = itemRelatorioAluno.vetCorEixo[1].ToString();
                            if (itemRelatorioAluno.vetCorEixo.Count > 2)
                                row[4] = itemRelatorioAluno.vetCorEixo[2].ToString();
                            if (itemRelatorioAluno.vetCorEixo.Count > 3)
                                row[3] = itemRelatorioAluno.vetCorEixo[3].ToString();
                            

                            ds.DataTable1.Rows.Add(row);
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
                           dtAplic;

                   
                      
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

        private void FormRelatorioTurma_Load(object sender, EventArgs e)
        {
        }

        private void btnPDFMt_Click(object sender, EventArgs e)
        {

            string dtAplic = this.txtDtAplic.Text;
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

                        PDFReporListaTurma_Mat report = new PDFReporListaTurma_Mat();

                        // Constroi DataSet
                        DataSetTurmaLista ds = new DataSetTurmaLista();

                        bool contemDuasDisciplinas = false;
                        foreach (var item in vetItensRelatorio)
                        {
                            if(item.vetCorEixo.Count > 4)
                            {
                                contemDuasDisciplinas = true;
                            }
                        }


                        if (!contemDuasDisciplinas)
                        {
                            foreach (var itemRelatorioAluno in vetItensRelatorio)
                            {
                                DataRow row = ds.DataTable1.NewRow();
                                row[0] = itemRelatorioAluno.aluno.Nome;
                                if (itemRelatorioAluno.vetCorEixo.Count > 0)
                                    row[1] = itemRelatorioAluno.vetCorEixo[0].ToString();
                                if (itemRelatorioAluno.vetCorEixo.Count > 1)
                                    row[2] = itemRelatorioAluno.vetCorEixo[1].ToString();
                                if (itemRelatorioAluno.vetCorEixo.Count > 2)
                                    row[3] = itemRelatorioAluno.vetCorEixo[2].ToString();
                                if (itemRelatorioAluno.vetCorEixo.Count > 3)
                                    row[4] = itemRelatorioAluno.vetCorEixo[3].ToString();

                                ds.DataTable1.Rows.Add(row);
                            }
                        }
                        //else
                        //{
                        //    foreach (var itemRelatorioAluno in vetItensRelatorio)
                        //    {
                        //        DataRow row = ds.DataTable1.NewRow();
                        //        row[0] = itemRelatorioAluno.aluno.Nome;
                        //        if (itemRelatorioAluno.vetCorEixo.Count > 4)
                        //            row[1] = itemRelatorioAluno.vetCorEixo[4].ToString();
                        //        if (itemRelatorioAluno.vetCorEixo.Count > 5)
                        //            row[2] = itemRelatorioAluno.vetCorEixo[5].ToString();
                        //        if (itemRelatorioAluno.vetCorEixo.Count > 6)
                        //            row[3] = itemRelatorioAluno.vetCorEixo[6].ToString();
                        //        if (itemRelatorioAluno.vetCorEixo.Count > 7)
                        //            row[4] = itemRelatorioAluno.vetCorEixo[7].ToString();

                        //        ds.DataTable1.Rows.Add(row);
                        //    }
                        //}


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
                        //(report.Section2.ReportObjects["txtData"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                        //    .Text
                        //    =
                        //    ((DateTime)pontuacao.DataHora).ToShortDateString();

                        (report.Section2.ReportObjects["txtData"] as CrystalDecisions.CrystalReports.Engine.TextObject)
                            .Text
                            =
                            dtAplic;

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

        private void btnPdfApr_Click(object sender, EventArgs e)
        {
            string dtAplic = this.txtDtAplic.Text;

            try
            {

                List<Area> areasAprendizagem = vetAreasRelatorio.FindAll(a => a.Disciplina_id == 3);

                if (areasAprendizagem.Count == 4)
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

                        PDFReporListaTurma_Apr report = new PDFReporListaTurma_Apr();


                        // Constroi DataSet
                        DataSetTurmaLista ds = new DataSetTurmaLista();

                        foreach (var itemRelatorioAluno in vetItensRelatorio)
                        {
                            DataRow row = ds.DataTable1.NewRow();
                            row[0] = itemRelatorioAluno.aluno.Nome;
                            if (itemRelatorioAluno.vetCorEixo.Count > 0)
                                row[1] = itemRelatorioAluno.vetCorEixo[0].ToString();
                            if (itemRelatorioAluno.vetCorEixo.Count > 1)
                                row[2] = itemRelatorioAluno.vetCorEixo[1].ToString();
                            if (itemRelatorioAluno.vetCorEixo.Count > 2)
                                row[4] = itemRelatorioAluno.vetCorEixo[2].ToString();
                            if (itemRelatorioAluno.vetCorEixo.Count > 3)
                                row[3] = itemRelatorioAluno.vetCorEixo[3].ToString();


                            ds.DataTable1.Rows.Add(row);
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
                           dtAplic;



                        // Exporta o Report
                        report.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        report.ExportToDisk(ExportFormatType.PortableDocFormat, path);

                        ((Master)MdiParent).MensagemSucesso("PDF Exportado!");
                    }
                }
                else
                {
                    ((Master)MdiParent).MensagemErro(
                        "Não contém resultados de Aprendizagem suficientes para gerar o relatório!");
                }

            }
            catch (Exception)
            {
                ((Master)MdiParent).MensagemErro(
                    "Não foi possível gerar o PDF. Verifique se está com o programa de relatórios instalado.");
            }
        }
    }
}
