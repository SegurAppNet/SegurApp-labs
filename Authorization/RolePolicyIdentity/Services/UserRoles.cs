namespace PoliticaDeRolesIdentity.Services
{
    public static class UserRoles
    {
        public const string Admin = "Administrador";
        public const string User = "User";
        public const string Manager = "Manager";

        public static string[] GetAllRoles()
        {
            return new[] { Admin, User, Manager };
        }
    }
}