namespace Kameyo.Core.Application.Modules.Person.Dtos.Response
{
    public class PersonLookUpResponse
    {
        public Guid Id { get; set; }
        public Guid PersonTypeId { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }

    }
}
