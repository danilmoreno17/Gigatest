namespace Kameyo.Core.Application.Modules.MenuUserType.Dtos.Response
{
    public class GetMenuUserTypeQueryResponse
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid RoleId { get; set; }
        public Guid CatalogMenuId { get; set; }
        public string UserTypeName { get; set; } = string.Empty;
        public string MenuName { get; set; } = string.Empty;
        public string SubMenuName { get; set; } = string.Empty;
        public bool MenuSelected { get; set; }
    }
}
