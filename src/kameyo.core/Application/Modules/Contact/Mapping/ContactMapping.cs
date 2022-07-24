using Kameyo.Core.Application.Modules.Contact.Dtos.Response;

namespace Kameyo.Core.Application.Modules.Contact.Mapping
{
    public class ContactMapping
    {
        public ContactMapping()
        {

        }

        public static ContactDtoResponse MapToContactDTO(Domain.Entities.Contact entity)
        {
            return new ContactDtoResponse
            {
                Id = entity.Id,
                ParentId = entity.ParentId,
                CustomerId = entity.CustomerId,
                Names = entity.Names,
                LastName = entity.LastName,
                Area = entity.Area,
                Department = entity.Department,
                Position = entity.Position,
                Email = entity.Email,
                PhoneOffice = entity.PhoneOffice,
                PhoneMobile = entity.PhoneMobile,
                PhoneOfficeExt = entity.PhoneOfficeExt,
            };
        }

        public static List<ContactDtoResponse> MapListToContactsDTO(ICollection<Domain.Entities.Contact> contactsEntity)
        {
            var list = new List<ContactDtoResponse>();
            foreach (var entity in contactsEntity)
            {
                list.Add(MapToContactDTO(entity));
            }
            return list;
        }
    }
}
