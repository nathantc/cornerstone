namespace DataAPI.Data;

using System.ComponentModel.DataAnnotations;

public class LicenseType
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
}
