using System.ComponentModel.DataAnnotations;

namespace DataAPI.Data;

public interface ILookupType
{
    public int Id { get; set; }
    
    public string Name { get; set; }
}

public class FilingType : ILookupType
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
}

public class IndustryType : ILookupType
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
}

public class LicenseType : ILookupType
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
}
