using System.ComponentModel.DataAnnotations;

namespace Frontend.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Email must be filled")]
    [EmailAddress(ErrorMessage = "Format email tidak valid")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password wajib diisi")]
    [MinLength(8, ErrorMessage = "Password minimal 8 karakter")]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[\W_]).{8,}$", ErrorMessage = "Password harus mengandung minimal 1 angka dan 1 simbol")]
    public string Password { get; set; }
}