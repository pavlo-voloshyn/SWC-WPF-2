using PP.Domain.Shared;
using System.ComponentModel;

namespace PP.Domain.Models.Enums;
[TypeConverter(typeof(EnumDescriptionTypeConverter))]

public enum Status
{
    [Description("In Review")]
    InReview,
    [Description("In Progress")]
    InProgress,
    [Description("Done")]
    Done,
    [Description("Received")]
    Received
}
