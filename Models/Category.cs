namespace ProjetoCalendario.Models
{
    /// <summary>
    /// Representa uma categoria para classificar eventos no calendário pessoal.
    /// Exemplos: Trabalho, Estudo, Saúde, Lazer, etc.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Identificador único da categoria.
        /// É gerado automaticamente pela base de dados.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da categoria atribuída pelo utilizador.
        /// </summary>
        public string Name { get; set; }
    }
}
