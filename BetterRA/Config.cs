using System.ComponentModel;

namespace BetterRA
{
    public class Config
    {
        [Description("BetterRA permission access (ensure this is the same in the 'permission.yml' file ")]
        public string RaPermission { get; set; } = "betterra.access";
    }
}