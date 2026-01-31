using System;

namespace ProjetoCalendario.Models
{
    /// <summary>
    /// Representa um evento no calendário pessoal.
    /// Pode ser uma reunião, lembrete ou qualquer outro comprimisso.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Identificador único do evento.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título do evento.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Descrição detalhada do evento.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Data e hora de início do evento.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Data e hora de término do evento.
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Categoria do evento para classificação.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Prioridade do evento (Baixa, Média, Alta).
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// Valida as datas do evento.
        /// Garante que a data de fim é posterior à data de início.
        /// </summary>
        /// <exception cref="Exception">
        /// Lançada se a data de fim não for superior à data de início.
        /// </exception>
        public void Validate()
        {
            if (End <= Start)
                throw new Exception("A data de fim deve ser superior à de início.");
        }
    }
}
