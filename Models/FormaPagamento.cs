using System;

namespace API.Models
{
    public class FormaPagamento
    {
        public int FormaPagamentoId { get; set; }
        public DateTime CriadoEm { get; set; }
        public string Descricao { get; set; }
        public string TipoPagamento { get; set; }
        public FormaPagamento() => CriadoEm = DateTime.Now;

    }
}