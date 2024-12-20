using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class BaseEntity
{
    [Key]
    public int Id {get; set;}
}
