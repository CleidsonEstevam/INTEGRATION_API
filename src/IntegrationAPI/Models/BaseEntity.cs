namespace IntegrationAPI.Models
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        internal List<string> _errors;

        //--Ao acessar os erros o programador só vai poder ler e não manipular os dados ex: _erros.Exemplo--
        public IReadOnlyCollection<string> Erros => _errors;
        public abstract bool Validate();
    }
}
