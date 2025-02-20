namespace DataAPI.Data;

using System.ComponentModel.DataAnnotations;

public class IndustryType
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
}
