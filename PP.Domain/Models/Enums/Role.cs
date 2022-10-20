using PP.Domain.Shared;
using System.ComponentModel;

namespace PP.Domain.Models.Enums;
[TypeConverter(typeof(EnumDescriptionTypeConverter))]
public enum Role
{
    [Description("Officer")]
    Officer,
    [Description("Senior Officer")]
    SeniorOfficer,
    [Description("Admin")]
    Admin
}
