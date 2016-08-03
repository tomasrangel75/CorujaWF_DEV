using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Persistencia;

namespace QuestionarioForms
{
    public partial class FormAuxilioQuestionario : MetroFramework.Forms.MetroForm
    {
        public FormAuxilioQuestionario()
        {
            InitializeComponent();

            comboQuestionario.Items.Clear();
            foreach (var quest in Questionario.obterTodos())
            {
                comboQuestionario.Items.Add(quest);
            }

            comboQuestionario.DisplayMember = "Nome";
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            if (comboQuestionario.SelectedIndex >= 0)
            {
                Questionario questionario = (Questionario)comboQuestionario.SelectedItem;

                dataGridViewSaltos.Columns.Clear();

                dataGridViewSaltos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridViewSaltos.RowHeadersVisible = false;

                dataGridViewSaltos.Columns.Add("Col1", "Questão");
                dataGridViewSaltos.Columns.Add("Col2", "Acerto");
                dataGridViewSaltos.Columns.Add("Col3", "Erro");
                dataGridViewSaltos.Columns.Add("Col4", "Eixo");

                dataGridViewSaltos.Columns[0].DefaultCellStyle.BackColor = Color.MintCream;
                dataGridViewSaltos.Columns[1].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                dataGridViewSaltos.Columns[2].DefaultCellStyle.BackColor = Color.OrangeRed;

                dataGridViewSaltos.Rows.Clear();

                List<Questao> vetQuestoesValidas = questionario.Questao.ToList().OrderBy(q => q.Ordem).ToList();
                vetQuestoesValidas.RemoveAll(q => q.TipoQuestao_id == 4);

                foreach (var questao in vetQuestoesValidas)
                {
                    // Carrega as arestas baseado nos saltos
                    Salto saltoAcerto = null;
                    Salto saltoErro = null;

                    // Verifica se é multipla escolha
                    if (questao.TipoQuestao_id == 1)
                    {
                        foreach (var itemQuestao in questao.ItemQuestao)
                        {
                            if (itemQuestao.Eresposta != null && itemQuestao.Eresposta == true)
                            {
                                if (itemQuestao.Salto.Count > 0)
                                {
                                    if (itemQuestao.OpcaoCorreta != null && itemQuestao.OpcaoCorreta == true)
                                    {
                                        saltoAcerto = itemQuestao.Salto.ToList()[0];
                                    }
                                    else
                                    {
                                        saltoErro = itemQuestao.Salto.ToList()[0];
                                    }
                                }
                                else
                                {
                                    saltoAcerto = null;
                                    saltoErro = null;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var itemQuestao in questao.ItemQuestao)
                        {
                            if (saltoAcerto != null && saltoErro != null)
                                break;

                            if (itemQuestao.Salto.Count > 0)
                            {
                                foreach (var salto in itemQuestao.Salto)
                                {
                                    if (salto.SaltarAoErrar == true)
                                    {
                                        saltoErro = salto;
                                    }
                                    else
                                    {
                                        saltoAcerto = salto;
                                    }
                                }
                            }
                        }
                    }

                    string saltoAcertoStr = "";
                    string saltoErroStr = "";

                    if (saltoAcerto != null)
                    {
                        // É um salto para o fim
                        if (saltoAcerto.VoltarDoSalto != null)
                        {
                            saltoAcertoStr = "FIM";
                        }
                        else
                        {
                            saltoAcertoStr = saltoAcerto.Questao.Ordem.ToString();
                        }
                    }

                    if (saltoErro != null)
                    {
                        // É um salto para o fim
                        if (saltoErro.VoltarDoSalto != null)
                        {
                            saltoErroStr = "FIM";
                        }
                        else
                        {
                            saltoErroStr = saltoErro.Questao.Ordem.ToString();
                        }
                        
                    }

                    dataGridViewSaltos.Rows.Add(questao.Ordem.ToString(), saltoAcertoStr,
                        saltoErroStr, questao.Area.Nome);
                }


                // Carrega a grid de pontuacao
                // CARRREGA AS AREAS CONTEMPLADAS NO RELATORIO
                List<Area> vetAreasRelatorio = new List<Area>();

                List<Area> areasPortugues = new List<Area>();

                vetQuestoesValidas.ForEach(q => areasPortugues.Add(q.Area));
                areasPortugues = areasPortugues.ToList().FindAll(a => a.Disciplina_id == 1).Distinct().ToList();
               
                vetAreasRelatorio.AddRange(areasPortugues);

                List<Area> areasMatematica = new List<Area>();

                vetQuestoesValidas.ForEach(q => areasMatematica.Add(q.Area));
                areasMatematica = areasMatematica.ToList().FindAll(a => a.Disciplina_id == 2).Distinct().ToList();
       
                vetAreasRelatorio.AddRange(areasMatematica);


                gridGrafo.Columns.Clear();

                gridGrafo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                gridGrafo.RowHeadersVisible = false;

                gridGrafo.Columns.Add("Col1", "Eixo");
                gridGrafo.Columns.Add("Col2", "Min/Máx");
                gridGrafo.Columns.Add("Col3", "Azul");
                gridGrafo.Columns.Add("Col3", "Verde");
                gridGrafo.Columns.Add("Col3", "Amarelo");
                gridGrafo.Columns.Add("Col3", "Vermelho");

                gridGrafo.Columns[0].DefaultCellStyle.BackColor = Color.MintCream;
                gridGrafo.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                gridGrafo.Columns[2].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                gridGrafo.Columns[3].DefaultCellStyle.BackColor = Color.LawnGreen;
                gridGrafo.Columns[4].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                gridGrafo.Columns[5].DefaultCellStyle.BackColor = Color.OrangeRed;

                gridGrafo.Rows.Clear();

                foreach (var area in vetAreasRelatorio)
                {
                    List<Questao> vetQuestoesArea = vetQuestoesValidas.FindAll(p => p.Area_id.Equals(area.idArea));

                    if (vetQuestoesArea.Count > 0)
                    {
                        int maxOrd = (int)vetQuestoesValidas.OrderByDescending(q => q.Ordem).ToList()[0].Ordem;

                        GrafoQuestionario novoGrafo = new GrafoQuestionario();


                        try
                        {
                            novoGrafo.gerarGrafo(vetQuestoesArea, maxOrd);
                        }
                        catch (Exception)
                        {

                            ((Master)MdiParent).MensagemErro("Erro ao gerar a árvore de eixo:" + area.Nome + " Possível loop na árvore, verifique os saltos!");
                            continue;
                        }
                        

                        int minAzul = -1;
                        int maxAzul = -1;

                        novoGrafo.getMinMaxCor(3, out minAzul, out maxAzul);

                        int minVerde = -1;
                        int maxVerde = -1;

                        novoGrafo.getMinMaxCor(2, out minVerde, out maxVerde);

                        int minAmarelo = -1;
                        int maxAmarelo = -1;

                        novoGrafo.getMinMaxCor(1, out minAmarelo, out maxAmarelo);

                        int minVermelho = -1;
                        int maxVermelho = -1;

                        novoGrafo.getMinMaxCor(0, out minVermelho, out maxVermelho);

                        gridGrafo.Rows.Add(area.Nome, "Mínimo", getStringTela(minAzul), getStringTela(minVerde), getStringTela(minAmarelo),
                            getStringTela(minVermelho));

                        gridGrafo.Rows.Add(area.Nome, "Máximo", getStringTela(maxAzul), getStringTela(maxVerde), getStringTela(maxAmarelo),
                            getStringTela(maxVermelho));
                    }
                    else
                    {
                        gridGrafo.Rows.Add(area.Nome, "Mínimo", getStringTela(-1), getStringTela(-1), getStringTela(-1),
                            getStringTela(-1));

                        gridGrafo.Rows.Add(area.Nome, "Máximo", getStringTela(-1), getStringTela(-1), getStringTela(-1),
                            getStringTela(-1));
                    }
                }
            }
        }

        private string getStringTela(int num)
        {
            if (num >= 0)
                return num.ToString();
            else
            {
                return "";
            }
        }

        private void gridGrafo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
