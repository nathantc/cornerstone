using System.ComponentModel.DataAnnotations;

namespace DataAPI.Data;

public abstract class LookupType
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}

public class FilingType : LookupType {}
public class IndustryType : LookupType {}
public class LicenseType : LookupType {}