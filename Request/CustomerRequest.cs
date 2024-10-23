using Microsoft.IdentityModel.Tokens;
using ShopAppApi.Data;
using System.ComponentModel.DataAnnotations;

namespace ShopAppApi.Request
{
    public class CustomerRequest : BaseRequest
    {
        public int? Status { get; set; }
    }
    public class EmailCustomerUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var idProperty = validationContext.ObjectType.GetProperty("Id");
            //var idValue = idProperty != null ? idProperty.GetValue(validationContext.ObjectInstance) : null;

            var httpContextAccessor = validationContext.GetRequiredService<IHttpContextAccessor>();

            var getIdFromRouteValue = httpContextAccessor.HttpContext.GetRouteValue("Id");

            ShopAppContext? _context = validationContext.GetService(typeof(ShopAppContext)) as ShopAppContext;
            var entity = new Object { };
            if (getIdFromRouteValue != null)
            {
                entity = _context.Customers.SingleOrDefault(e => e.Email == value.ToString() && !e.Id.Equals(getIdFromRouteValue));
            }
            else
            {
                entity = _context.Customers.SingleOrDefault(e => e.Email == value.ToString());
            }

            if (entity != null && !value.ToString().IsNullOrEmpty())
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage(string email)
        {
            return $"Email {email} is already in use.";
        }
    }

    public class StoreCustomerRequest
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailCustomerUnique]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; } = null!;

        [StringLength(32, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string Password { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public byte Status { get; set; } = 0;
        public byte Gender { get; set; } = 0;
    }

    public class UpdateCustomerRequest
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        [EmailCustomerUnique]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public byte Status { get; set; } = 0;
        public byte Gender { get; set; } = 0;
    }
}
