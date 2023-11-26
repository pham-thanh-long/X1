using BusinessObjects.Models;
using System.ComponentModel.DataAnnotations;

namespace xAPI.Dto.Account
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email là trường bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [MaxLength(55, ErrorMessage = "Email tối đa 55 ký tự")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu là trường bắt buộc")]
        [MaxLength(23, ErrorMessage = "Mật khẩu tối đa 23 ký tự")]
        public string Password { get; set; }

    }
}
