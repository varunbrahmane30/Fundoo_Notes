namespace CommonLayer
{
    using System.ComponentModel.DataAnnotations;
    public class LogInModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
