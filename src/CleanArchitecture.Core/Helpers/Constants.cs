using System;

namespace CleanArchitecture.Core.Helpers
{
    public static class Constants
    {
        public static Guid RolIdUsuario { get; set; } = new Guid("E0EAF800-68EA-47F4-8341-00E93F80C0E4");
        public static Guid RolIdContratista { get; set; } = new Guid("3EA87258-7A9D-40D1-B11F-0F7DD8A6BC4A");
        public static string RolContratista { get; set; } = "Contratista";
        public static string RolUsuario { get; set; } = "Usuario";
    }
}