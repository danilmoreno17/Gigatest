namespace Kameyo.Core.Application.Common.Enums
{
    public static class MenusEnum
    {

        public static List<MenuEnum> Menus() => new()
        {
            Dashboard,
            DashboardAnalytical,

            Maintenance,
            MaintenanceCompanies,
            MaintenanceCustomers,
            MaintenanceProjects,
            MaintenanceCatalogs,
            MaintenanceUsers,
            MaintenanceRoles,
            MaintenanceSubsidiaries,
            MaintenanceContacts,
            MaintenanceEmployees,
            MaintenanceProjectTasks,
            MaintenanceMenus,

            Movements,
            MovementsBilling,
            MovementsProjectActivities,
            MovementsProjectReport,
            MovementsProjectReportPM,
            MovementsProjectReportCustomer,

            Reports,
            ReportsProjectsActivities,
            ReportsBillingActivities,
            ReportsUnifiedClientStates,

            Participations,
            ParticipationsResume,
            ParticipationsDiscretionary
        };

        public static readonly MenuEnum Dashboard = new(new Guid("43c4bce9-c056-43e7-84f3-1c67877a2c70"), null, "Dashboard", "Dashboard", "", "icon-home", 0);
        public static readonly MenuEnum DashboardAnalytical = new(new Guid("2565e61d-86d4-4a72-8886-296733908e5b"), new Guid("43c4bce9-c056-43e7-84f3-1c67877a2c70"), "Analytical", "Dashboard Analytical", "/dashboard/index",null, 0);

        public static readonly MenuEnum Maintenance = new(new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), null, "Mantenimientos", "Mantenimientos", "", "icon-grid", 1);
        public static readonly MenuEnum MaintenanceCompanies = new(new Guid("aebe7952-8a9d-49fa-bc6f-dc501bc89082"), new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), "Empresas", "Mantenimientos Empresas", "/mantenimientos/empresas",null, 0);
        public static readonly MenuEnum MaintenanceCustomers = new(new Guid("655b2ad6-6c94-4a67-a3de-9cbe3501d7c0"), new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), "Clientes", "Mantenimientos Clientes", "/mantenimientos/clientes", null, 2);
        public static readonly MenuEnum MaintenanceProjects = new(new Guid("84e9e9c9-afbb-4944-9699-67cf269b91ae"), new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), "Proyectos", "Mantenimientos Proyectos", "/mantenimientos/proyectos", null, 3);
        public static readonly MenuEnum MaintenanceCatalogs = new(new Guid("749d90e3-e39c-4630-9316-71cc814ab1ee"), new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), "Catalogos", "Mantenimientos Catalogos", "/mantenimientos/catalogos", null, 4);
        public static readonly MenuEnum MaintenanceUsers = new(new Guid("4fd6aa25-040a-4a58-8f3d-ea1aeff04bd6"), new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), "Usuarios", "Mantenimientos Usuarios", "/mantenimientos/usuarios", null, 5);
        public static readonly MenuEnum MaintenanceRoles = new(new Guid("f3f6bde7-0c6a-4dc2-b785-674f1ca77b95"), new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), "Roles", "Mantenimientos Roles", "/mantenimientos/roles", null, 6);
        public static readonly MenuEnum MaintenanceSubsidiaries = new(new Guid("bf39e8be-8707-4a80-bf9b-a30486a6b4bb"), new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), "Filiales", "Mantenimientos Filiales", "/mantenimientos/filiales", null, 7);
        public static readonly MenuEnum MaintenanceContacts = new(new Guid("b2e7412c-d120-4cc3-a77e-b97b3796a46f"), new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), "Contactos", "Mantenimientos Contactos", "/mantenimientos/empresas/contactos", null, 8);
        public static readonly MenuEnum MaintenanceEmployees = new(new Guid("f535972a-7807-4335-91ec-a82b19eea803"), new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), "Empleados", "Mantenimientos Empleados", "/mantenimientos/empleados", null, 9);
        public static readonly MenuEnum MaintenanceProjectTasks = new(new Guid("8804915e-1694-486b-8fa0-5b47d0fdaa11"), new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), "Tareas", "Mantenimientos Tareas", "/mantenimientos/proyectos/tareas", null, 10);
        public static readonly MenuEnum MaintenanceMenus = new(new Guid("90eba23b-5ccd-49b2-9e58-c86b440ae431"), new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), "Menu", "Mantenimientos Menus", "/mantenimientos/menus", null, 11);
        

        public static readonly MenuEnum Movements = new(new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), null, "Movimientos", "Movimientos", "", "icon-folder", 2);
        public static readonly MenuEnum MovementsBilling = new(new Guid("b05309c0-9b19-4474-a025-b59b526f1930"), new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), "Facturacion", "Movimientos Facturacion", "/movimientos/facturacion", null, 0);
        public static readonly MenuEnum MovementsProjectActivities = new(new Guid("85db29c8-6df0-481b-8065-c10f55d4050b"), new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), "Actividades proyecto", "Movimientos Actividades proyecto", "/movimientos/proyectos/actividades", null, 1);
        public static readonly MenuEnum MovementsProjectReport = new(new Guid("abc3cd41-a3bf-4167-b7c9-c0d03cb6c84f"), new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), "Generar Reporte de Proyectos", "Movimientos Reporte de Proyectos", "/movimientos/proyectos/reportes", null, 3);
        public static readonly MenuEnum MovementsProjectReportPM = new(new Guid("917F29EA-ADE8-4B47-BBF4-1B13B5EA3FA8"), new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), "Revisión de Reportes PM", "Revisión de Reportes PM", "/movimientos/proyectos/reportes-pm", null, 4);
        public static readonly MenuEnum MovementsProjectReportCustomer = new(new Guid("bc49bc14-4834-4b5a-a1e8-26715ae2c57e"), new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), "Aprob. de Reportes Cust", "Aprob. de Reportes Cust", "/movimientos/proyectos/reportes-customer", null, 5);

        public static readonly MenuEnum Reports = new(new Guid("dd84c814-812e-4a54-a7d3-ea863da1a5c8"), null, "Reportes", "Reportes", "", "icon-globe", 3);
        public static readonly MenuEnum ReportsProjectsActivities = new(new Guid("fb439685-8613-4b10-bed0-64dfc71a433c"), new Guid("dd84c814-812e-4a54-a7d3-ea863da1a5c8"), "Proyectos y actividades", "Reportes Proyectos y actividades", "/reportes/proyectos/actividades", null, 0);
        public static readonly MenuEnum ReportsBillingActivities = new(new Guid("15be86da-51b5-40d8-92ee-e426a2a5df8f"), new Guid("dd84c814-812e-4a54-a7d3-ea863da1a5c8"), "Facturación vs Actividades", "Reportes Facturación vs Actividades", "/reportes/facturacion/actividades", null, 1);
        public static readonly MenuEnum ReportsUnifiedClientStates = new(new Guid("38d321e1-6c32-4adf-bc6e-461061fc2b66"), new Guid("dd84c814-812e-4a54-a7d3-ea863da1a5c8"), "Estados de Clientes Unificados", "Reportes Estados de Clientes Unificados", "/reportes/clientes/unificados", null, 2);

        public static readonly MenuEnum Participations = new(new Guid("6a9157ad-d1a8-464d-8f6f-a065a9b6c61c"), null, "Participaciones", "Participaciones", "", "icon-folder", 4);
        public static readonly MenuEnum ParticipationsResume = new(new Guid("02647d85-581b-4e74-acce-9adddaecf680"), new Guid("6a9157ad-d1a8-464d-8f6f-a065a9b6c61c"), "Resumen", "Resumen de Participaciones", "/participaciones/general", null, 0);
        public static readonly MenuEnum ParticipationsDiscretionary = new(new Guid("4c748e6e-60a6-47fd-b83a-d91fc57feb0f"), new Guid("6a9157ad-d1a8-464d-8f6f-a065a9b6c61c"), "Participaciones Discrecionales", "Participaciones Discrecionales", "/participaciones/discresionales", null, 1);

    }
}

