namespace Kameyo.Core.Application.Common.Enums
{
    public static class UsersTypeEnum
    {
        public static List<UserTypeEnum> UserTypes() => new()
        {
            User,
            Contact,
            Employee,
            Administrator,
            Manager,            
        };

        public static readonly UserTypeEnum User = new(new Guid("2d5a5fb0-d3ca-44e1-abdc-bbe58d29fb6b"), "Usuario");
        public static readonly UserTypeEnum Contact = new(new Guid("f11d7e55-f12e-4214-b100-0989b38f66bc"), "Contacto");
        public static readonly UserTypeEnum Employee = new(new Guid("f35d8016-c93b-4a05-9301-4c228d639a02"), "Empleado");        
        public static readonly UserTypeEnum Manager = new(new Guid("f49725ee-8d2d-44b7-b995-1830348c6b86"), "Gerente");
        public static readonly UserTypeEnum Administrator = new(new Guid("efd0f32b-cbf5-460e-b6d1-f17dfee2a13e"), "Administrador");
    }
}
