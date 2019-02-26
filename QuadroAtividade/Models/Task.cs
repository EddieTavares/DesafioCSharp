using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuadroAtividade.Models
{
    [Table("Task")]
    public partial class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int Status { get; set; }

        [Required]
        [Display(Name = "Data de criação")]
        public DateTime DataCriacao { get; set; }

        [Display(Name = "Data de edição")]
        public DateTime DataEdicao { get; set; }

        [Display(Name = "Data de remoção")]
        public DateTime DataRemocao { get; set; }

        [Display(Name = "Data de conclusão")]
        public DateTime DataConclusao { get; set; }
    }
}