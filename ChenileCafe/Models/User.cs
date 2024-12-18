using System.ComponentModel.DataAnnotations;

namespace ChenileCafe.Models
{
	public class User
	{
		public int Id { get; set; }
		[MaxLength(100)]
		public string? Name { get; set; } = string.Empty;
		[MaxLength(11)]
		public int? PhoneNumber { get; set; }
		public DateTime? Birth { get; set; }
		[MaxLength(100)]
		public string Email { get; set; } = string.Empty;
		[MaxLength(100)]
		public string Password { get; set; } = string.Empty;
		[MaxLength(100)]
		public string Roles {  get; set; } = string.Empty;
	}
}
