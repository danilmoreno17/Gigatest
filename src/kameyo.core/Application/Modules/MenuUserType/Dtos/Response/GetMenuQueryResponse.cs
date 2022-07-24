namespace Kameyo.Core.Application.Modules.MenuUserType.Dtos.Response
{
    public class GetMenuQueryResponse
    {
        public Guid Id { get; set; }
        public Guid MenuId { get; set; }
        public Guid? MenuParentId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string? Icon { get; set; }
        public int Order { get; set; }

    }
}
