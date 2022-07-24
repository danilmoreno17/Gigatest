namespace Kameyo.Core.Application.Common.Enums
{
    public class UserTypeEnum
    {
        public UserTypeEnum(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
