
namespace ReadingPleasure.Common.Constants
{
    public partial class Constants
    {
        public class ApiEndpoints
        {
            private const string IdPlaceholder = "{id}";

            public static class Books
            {
                public const string Base = "/api/v1/books";
                public const string GetAll = Base;
                public const string GetByAuthorId = "/api/v1/authors/{authorId}/books";
                public const string GetById = $"{Base}/{IdPlaceholder}";
                public const string Create = Base;
                public const string Update = $"{Base}/{IdPlaceholder}";
                public const string Delete = $"{Base}/{IdPlaceholder}";
            }

            public static class Authors
            {
                public const string Base = "/api/v1/authors";
                public const string GetAll = Base;
                public const string GetById = $"{Base}/{IdPlaceholder}";
                public const string Create = Base;
                public const string Update = $"{Base}/{IdPlaceholder}";
                public const string Delete = $"{Base}/{IdPlaceholder}";
            }

            public static class Editions
            {
                public const string Base = "/api/v1/editions";
                public const string GetAll = Base;
                public const string GetById = $"{Base}/{IdPlaceholder}";
                public const string Create = Base;
                public const string Update = $"{Base}/{IdPlaceholder}";
                public const string Delete = $"{Base}/{IdPlaceholder}";
            }

            public static class Genres
            {
                public const string Base = "/api/v1/genres";
                public const string GetAll = Base;
                public const string GetById = $"{Base}/{IdPlaceholder}";
                public const string Create = Base;
                public const string Update = $"{Base}/{IdPlaceholder}";
                public const string Delete = $"{Base}/{IdPlaceholder}";
            }

            public static class Readers
            {
                public const string Base = "/api/v1/readers";
                public const string GetAll = Base;
                public const string GetById = $"{Base}/{IdPlaceholder}";
                public const string Create = Base;
                public const string Update = $"{Base}/{IdPlaceholder}";
                public const string Delete = $"{Base}/{IdPlaceholder}";
            }

            public static class Reviews
            {
                public const string Base = "/api/v1/reviews";
                public const string GetAll = Base;
                public const string GetByReaderId = "/api/v1/readers/{readerId}/reviews";
                public const string GetByBookId = "/api/v1/books/{bookId}/reviews";
                public const string GetById = $"{Base}/{IdPlaceholder}";
                public const string Create = Base;
                public const string Update = $"{Base}/{IdPlaceholder}";
                public const string Delete = $"{Base}/{IdPlaceholder}";
            }

            public static class PublishingHouses
            {
                public const string Base = "/api/v1/publishingHouses";
                public const string GetAll = Base;
                public const string GetById = $"{Base}/{IdPlaceholder}";
                public const string Create = Base;
                public const string Update = $"{Base}/{IdPlaceholder}";
                public const string Delete = $"{Base}/{IdPlaceholder}";
            }

            public static class Roles
            {
                public const string Base = "/api/v1/roles";
                public const string GetAll = Base;
                public const string GetById = $"{Base}/{IdPlaceholder}";
                public const string Create = Base;
                public const string Update = $"{Base}/{IdPlaceholder}";
                public const string Delete = $"{Base}/{IdPlaceholder}";
                public const string AddPermissions = $"{Base}/{IdPlaceholder}/permissions";
                public const string RemovePermissions = $"{Base}/{IdPlaceholder}/permissions";
            }

            public static class Auth
            {
                public const string Base = "/api/v1/auth";
                public const string Login = $"{Base}/login";
                public const string Signup = $"{Base}/signup";
            }

            public static class Users
            {
                public const string Base = "/api/v1/users";
                public const string GetAll = Base;
                public const string GetById = $"{Base}/{IdPlaceholder}";
            }

            public static class CurrentUser
            {
                public const string Base = "/api/v1";
                public const string Info = $"{Base}/me";
            }
        }
    }
}
