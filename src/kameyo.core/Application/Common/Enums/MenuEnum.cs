namespace Kameyo.Core.Application.Common.Enums
{
    public class MenuEnum
    {
        public MenuEnum(Guid id, Guid? parentId, string name, string description, string url, string icon, int order)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
            Description = description;
            Url = url;
            Icon = icon;
            Order = order;
        }
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
