using Kameyo.Core.Application.Common.Enums;

namespace Kameyo.Core.Application.Modules.Person.Model
{
    public class PersonTypeModel
    {
        internal PersonTypeModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static List<PersonTypeModel> LoadPersonTypes()
        {
            return new List<PersonTypeModel>() {
            new PersonTypeModel(UsersTypeEnum.Contact.Id, UsersTypeEnum.Contact.Name),
            new PersonTypeModel(UsersTypeEnum.Employee.Id, UsersTypeEnum.Employee.Name),
            new PersonTypeModel(UsersTypeEnum.Administrator.Id, UsersTypeEnum.Administrator.Name),
            new PersonTypeModel(UsersTypeEnum.Manager.Id, UsersTypeEnum.Manager.Name),
            };
        }
    }
}
