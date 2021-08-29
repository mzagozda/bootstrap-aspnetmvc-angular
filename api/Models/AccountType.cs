using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// Account type depends on the Balance value and should change based on the following rules:
    /// </summary>
    /// <remarks>Camel-case serialization is enforced.</remarks>
    public enum AccountType
    {
        [EnumMember(Value = "Other")]
        Other,

        [EnumMember(Value = "Bronze")]
        Bronze,

        [EnumMember(Value = "Silver")]
        Silver,

        [EnumMember(Value = "Gold")]
        Gold,
    }
}
