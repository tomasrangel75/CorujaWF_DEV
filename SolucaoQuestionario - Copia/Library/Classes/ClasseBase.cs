using System.Data;

namespace Library.Persistencia
{
    public abstract class ClasseBase
    {
        public virtual bool deletar(object objeto)
        {
            Gerenciador.getContexto().Entry(objeto).State = EntityState.Deleted;

            return Salvar();
        }

        public virtual bool adicionar(object objeto)
        {
            Gerenciador.getContexto().Entry(objeto).State = EntityState.Added;

            return Salvar();
        }

        public virtual bool atualizar(object objeto)
        {
            Gerenciador.getContexto().Entry(objeto).State = EntityState.Modified;

            return Salvar();
        }

        public virtual bool Salvar()
        {
            return Gerenciador.getContexto().SaveChanges() > 0;
        }
    }
}
