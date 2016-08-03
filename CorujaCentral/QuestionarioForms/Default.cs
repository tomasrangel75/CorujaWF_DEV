using Library.Persistencia;
using MetroFramework.Forms;

namespace QuestionarioForms
{
    public partial class Default : MetroForm
    {
        public Default()
        {
            InitializeComponent();

            lblQuestionarios.Text = Questionario.obterTodos().Count.ToString();
            lblQuestoes.Text = Questao.obterTodos().Count.ToString();
            lblAlunos.Text = Aluno.obterTodos().Count.ToString();

        }

        public void refaz()
        {
            lblQuestionarios.Text = Questionario.obterTodos().Count.ToString();
            lblQuestoes.Text = Questao.obterTodos().Count.ToString();
            lblAlunos.Text = Aluno.obterTodos().Count.ToString();
        }
    }
}
