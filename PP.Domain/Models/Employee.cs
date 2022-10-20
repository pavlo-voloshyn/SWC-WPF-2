using PP.Domain.Models.Enums;
using System.Collections.Generic;

namespace PP.Domain.Models;

public class Employee : EntityBase
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Role ERole { get; set; }

    public string Office { get; set; }
}
