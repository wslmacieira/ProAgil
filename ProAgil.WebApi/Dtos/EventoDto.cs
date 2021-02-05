using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebApi.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Local obrigatório")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Local deve ter no minímo 3 carateres e no máximo 100 caracteres")]
        public string Local { get; set; }
        public string DataEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public string Tema { get; set; }

        [Range(10, 12000, ErrorMessage = "O Campo {0} é entre 10 e 12000")]
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }

        [Phone(ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes { get; set; }
    }
}
