using System.IO;

namespace Library.Persistencia
{

    public partial class ItemArquivo : ClasseBase
    {
        public override bool deletar(object objeto)
        {
            Arquivo arquivo = Arquivo;
            string caminhoAnterior = ItemQuestao.Questao.Diretorio + arquivo.NomeFisico;

            base.deletar(objeto);

            arquivo.deletar(arquivo);

            if (File.Exists(caminhoAnterior))
            {
                File.Delete(caminhoAnterior);
            }

            return true;
        }
      
    }
}
