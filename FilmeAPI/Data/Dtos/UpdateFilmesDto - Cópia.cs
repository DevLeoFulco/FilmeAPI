using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Data.Dtos;

public class UpdateFilmesDto
{
    
    [Required(ErrorMessage = "O título é obrigatorio")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O gênero é obrigatorio")]
    [StringLength(50, ErrorMessage = "O tamanho máximo do gênero nao pode exceder 50 caracteres.")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A duração é obrigatoria")]
    [Range(60, 240, ErrorMessage = "A duração deve ser de no mínimo 60 e máximo 240 minutos.")]
    public int Duracao { get; set; }
}
