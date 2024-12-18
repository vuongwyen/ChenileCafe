using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ChenileCafe.Models
{
	public class UserDto
	{
		[Required, MaxLength(100)]
		public string? Name { get; set; } = string.Empty;
		[Required]
		public int? PhoneNumber { get; set; }
		[Required]
        [DataType(DataType.DateTime)]
        public DateTime? Birth { get; set; }
		[Required, MaxLength(100)]
		public string Email { get; set; } = string.Empty;
		[Required, MaxLength(100)]
		public string Password { get; set; } = string.Empty;
		[Required, MaxLength(100)]
		public string Roles { get; set; } = string.Empty;
	}
}
