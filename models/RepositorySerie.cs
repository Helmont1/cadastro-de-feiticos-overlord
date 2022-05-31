using cadastro_de_series.interfaces;
using cadastro_de_series.models;

namespace cadastro_de_series.models
{
    public class RepositorioFeitico : IRepositorio<Feitico>
    {
        private List<Feitico> Feiticos = new List<Feitico>();

        public void Atualiza(int id, Feitico entidade)
        {
            Feiticos[id] = entidade;
        }

        public void Exclui(int id)
        {
            Feiticos[id].Excluir();
        }

        public void Insere(Feitico entidade)
        {
            Feiticos.Add(entidade);
        }

        public List<Feitico> Lista()
        {
            return Feiticos;
        }

        public int ProximoId()
        {
            return Feiticos.Count;
        }
        
        public Feitico RetornaPorId(int id)
        {
            return Feiticos[id];
        }
    }
}