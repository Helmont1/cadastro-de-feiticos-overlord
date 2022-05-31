namespace cadastro_de_series.models
{
    public class Feitico : BaseEntity
    {
        private Tier Tier {get; set;}
        private string Nome {get; set;}
        private string Descricao {get; set;}
        private bool Excluido {get; set;}



        public Feitico(int id, Tier tier, string nome, string descricao)
        {
            this.Id = id;
            this.Tier = tier;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tier: " + this.Tier + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Descricao: " + this.Descricao + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaNome()
        {
            return this.Nome;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public bool EstaExcluido()
        {
            return this.Excluido;
        }
    }
}