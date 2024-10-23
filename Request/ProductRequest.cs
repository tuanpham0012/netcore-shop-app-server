using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using ShopAppApi.Data;
using System.ComponentModel.DataAnnotations;

namespace ShopAppApi.Request
{
    public class ProductRequest : BaseRequest
    {
    }

    public partial class StoreProductRequest
    {
        public string Name { get; set; } = null!;

        public double Price { get; set; }

        public string? ImgThumb { get; set; }

        public string? Unit { get; set; }

        public string? Description { get; set; }

        public string? Alias { get; set; }
        [Required]
        public long CategoryId { get; set; }

        public long? SupplierId { get; set; }

        public virtual ICollection<OptionsRequest> Options { get; set; } = [];

        public virtual ICollection<SkusRequest> Skus { get; set; } = [];

    }

    public class OptionsRequest
    {
        [CodeUniqueAttribute("Options")]
        public string? Code { get; set; }

        public string Name { get; set; } = null!;

        public byte Visual { get; set; }

        public byte Order { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<OptionValuesRequest> OptionValues { get; set; } = [];
    }

    public class OptionValuesRequest
    {
        [CodeUniqueAttribute("OptionValues")]
        public string? Code { get; set; }

        public string? Value { get; set; }

        public string? Label { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
    public class SkusRequest {

        public string BarCode { get; set; } = null!;

        public double Price { get; set; }

        public string Name { get; set; } = null!;

        public int Stock { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<VariantRequest> Variants { get; set; } = [];
    }

    public class VariantRequest
    {
        public string? Code { get; set; }
    }

    public class CodeUniqueAttribute : ValidationAttribute
    {
        private string TableName;

        public CodeUniqueAttribute(String _TableName)
        {
            TableName = _TableName;
        }
        // Type
        //var dynamicTable = dbContext.Set(dynamicTableType);      // DbSet

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var context = (ShopAppContext)validationContext.GetService(typeof(ShopAppContext));
            bool checkUnique;
            switch (TableName)
            {
                case "OptionValues":
                    checkUnique = context.OptionValues.Any(a => a.Code == value.ToString());
                    break;
                case "Options":
                    checkUnique = context.Options.Any(a => a.Code == value.ToString());
                    break;
                default:
                    checkUnique = false;
                    break;
            }
            if (!checkUnique)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Code exists");
        }
    }
}
