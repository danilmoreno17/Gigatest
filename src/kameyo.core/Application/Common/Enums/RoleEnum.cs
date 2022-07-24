namespace Kameyo.Core.Application.Common.Enums
{
    public class RoleEnum
    {
        public static List<RolEnum> Role() => new()
        {
            User,
            Customer,
            Consultant,
            Manager,
            Administrator
        };

        public static readonly RolEnum User = new(new Guid("1b48ee96-5788-4fef-90f0-34e891ad661f"), "Usuario", "USUARIO");
        public static readonly RolEnum Customer = new(new Guid("da7afbba-57a0-40da-a3b4-4542c20ff2a5"), "Cliente", "CLIENTE");
        public static readonly RolEnum Consultant = new(new Guid("fd4535d2-7103-498e-85bd-9651778a4b72"), "Consultor", "CONSULTOR");
        public static readonly RolEnum Manager = new(new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), "Gerente", "GERENTE");
        public static readonly RolEnum Administrator = new(new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), "Administrador", "ADMINISTRADOR");
    }
}
