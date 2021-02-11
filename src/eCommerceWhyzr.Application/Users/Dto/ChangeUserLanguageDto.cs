using System.ComponentModel.DataAnnotations;

namespace eCommerceWhyzr.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}