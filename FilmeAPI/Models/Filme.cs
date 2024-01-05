using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models;
/// <summary>
/// Representa um filme.
/// </summary>
public class Filme
{
    /// <summary>
    /// Identificador único do filme.
    /// </summary>
    [Key]
    [Required]
    public int Id { get; set; }
   
    /// <summary>
    /// Título do filme.
    /// </summary>
    [Required (ErrorMessage ="O título é obrigatorio")]

    /// <summary>
    /// Gênero do filme.
    /// </summary>
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O gênero é obrigatorio")]
    [MaxLength (50, ErrorMessage ="O tamanho máximo do gênero nao pode exceder 50 caracteres.")]

    /// <summary>
    /// Duração do filme em minutos.
    /// </summary>
    public string Genero  { get; set; }
    [Required(ErrorMessage = "A duração é obrigatoria")]
    [Range(60,240, ErrorMessage ="A duração deve ser de no mínimo 60 e máximo 240 minutos.")]
    public int Duracao { get; set; }

}
