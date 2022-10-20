using PP.Domain.Shared;
using System.ComponentModel;

namespace PP.Domain.Models.Enums;
[TypeConverter(typeof(EnumDescriptionTypeConverter))]

public enum ServiceType
{
    [Description("Create Passport")]
    CreatePassport,
    [Description("Create Foreign Passport")]
    CreateForeignPassport,
    [Description("Change Passport")]
    ChangePassport,
    [Description("Change Foreign Passport")]
    ChangeForeignPassport
}
