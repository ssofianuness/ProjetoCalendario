namespace ProjetoCalendario.Models
{
    /// <summary>
    /// Representa um utilizador do sistema de gestão de calendário pessoal.
    /// Cada utilizador pode ter eventos associados e um perfil único.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identificador único do utilizador.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome completo do utilizador.   
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email utilizado para login e identificação.
        /// Deve ser o único no sistema.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password para autenticação do utilizador.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Perfil do utilizador.
        /// Pode ser "user" ou "admin".
        /// Por defeito, todos os novos utilizadores são "user".
        /// </summary>
        public string Role { get; set; } = "user";
    }
}
