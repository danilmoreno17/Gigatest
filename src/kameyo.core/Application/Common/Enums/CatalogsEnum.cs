namespace Kameyo.Core.Application.Common.Enums
{
    public static class CatalogsEnum
    {

        public static List<CatalogEnum> Menus() => new()
        {
            AREA,
            CITY,
            COSTCENTER,
            COUNTRIES,
            CURRENCY,
            DEPARTMEN,
            EMPLOYEEROL,
            EMPLOYEETYPE,
            IDENTIFICATIONTYPE,
            INDUSTRYSUBTYPE,
            INDUSTRYTYPE,
            POSITION,
            PRODUCTTYPE,
            PROJECTCATEGORY,
            PROJECTSTATE,
            PROJECTTASKSTATE,
            PROJECTTASKTYPE,
            PROJECTTYPE,
            STATES,
            USERSTYPE,
            MENUS,
            DISCRETIONARYTYPE,
        };

        public static readonly CatalogEnum AREA = new("AREA");
        public static readonly CatalogEnum CITY = new("CITY");
        public static readonly CatalogEnum COSTCENTER = new("COSTCENTER");
        public static readonly CatalogEnum COUNTRIES = new("COUNTRIES");
        public static readonly CatalogEnum CURRENCY = new("CURRENCY");
        public static readonly CatalogEnum DEPARTMEN = new("DEPARTMEN");
        public static readonly CatalogEnum EMPLOYEEROL = new("EMPLOYEEROL");
        public static readonly CatalogEnum EMPLOYEETYPE = new("EMPLOYEETYPE");
        public static readonly CatalogEnum IDENTIFICATIONTYPE = new("IDENTIFICATIONTYPE");
        public static readonly CatalogEnum INDUSTRYSUBTYPE = new("INDUSTRYSUBTYPE");
        public static readonly CatalogEnum INDUSTRYTYPE = new("INDUSTRYTYPE");
        public static readonly CatalogEnum POSITION = new("POSITION");
        public static readonly CatalogEnum PRODUCTTYPE = new("PRODUCTTYPE");
        public static readonly CatalogEnum PROJECTCATEGORY = new("PROJECTCATEGORY");
        public static readonly CatalogEnum PROJECTSTATE = new("PROJECTSTATE");
        public static readonly CatalogEnum PROJECTTASKSTATE = new("PROJECTTASKSTATE");
        public static readonly CatalogEnum PROJECTTASKTYPE = new("PROJECTTASKTYPE");
        public static readonly CatalogEnum PROJECTTYPE = new("PROJECTTYPE");
        public static readonly CatalogEnum STATES = new("STATES");
        public static readonly CatalogEnum USERSTYPE = new("USERSTYPE");
        public static readonly CatalogEnum MENUS = new("MENUS");
        public static readonly CatalogEnum DISCRETIONARYTYPE = new("DISCRETIONARYTYPE");


    }
}
