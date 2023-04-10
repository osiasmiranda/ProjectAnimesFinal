using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RedeSocial.Domain.Entities
{
    public class PostEntity
    {

        public int Id { get; set; }
        [DisplayName("Título")]
        public string? Title { get; set; }
        [DisplayName("Decrição")]
        public string? Description { get; set; }
        [DisplayName("Imagem da publicação")]
        [DataType(DataType.Upload)]
        public string? PostUrlImage { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public ProfileEntity? ProfileEntity { get; set; }

        public string? UserEmail { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDateTime { get; set; }
    }
}
