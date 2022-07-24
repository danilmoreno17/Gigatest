namespace Kameyo.Core.Application.Common.Enums
{
    public class CatalogEnum
    {
        public CatalogEnum(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
