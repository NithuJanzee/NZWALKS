using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;

namespace NZWalksWebApi.DTO
{
    public class RegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage ="Code has min lenth 3 and the maximum 3")]
        [MaxLength(3, ErrorMessage = "Code has min lenth 3 and the maximum 3")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage ="Name has to be Maximum 100 charactors")]
        public  string FullName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
