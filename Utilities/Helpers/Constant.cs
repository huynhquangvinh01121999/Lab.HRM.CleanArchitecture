namespace Utilities.Helpers
{
    public static class Constant
    {
        public class RoleValue
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }

        public class Path
        {
            public const string ImageSavePath = @"/LAB/API/Images/";
        }

        public class Message
        {
            public const string FETCHING_DATA_SUCCESSES = "Fetching data successed!";
            public const string CREATED_SUCCESSES = "Created Successes!";
            public const string DELETE_SUCCESSES = "Deleted successes!";
            public const string UPDATE_SUCCESSES = "Updated successes!";
            public const string NOTFOUND = "Not found!";
            public const string EMPTY_DATA = "Empty data";
            public const string EXCEPTIONS = "An exception error has occurred: ";
            public const string FAILURE = "Failure";


            public const string AUTHENTICATE_OK = "Log in successed!";
            public const string USER_NOT_EXIST = "Username is not existed!";
            public const string USER_EXIST = "User already exists";
            public const string PWD_NOT_CORRECT = "Password is not correct!";

            public const string USERNAME_ERROR = "Username must start with a letter, allow letter or number, length between 6 to 12. Example: johnny99";
        }

        public class JWT
        {
            public const int EXPIRES_TOKEN = 3;
            public const string SECRET = "JWT:Secret";
            public const string VALID_ISSUER = "JWT:ValidIssuer";
            public const string VALID_AUDIENCE = "JWT:ValidAudience";
            public const string CLAIM_TYPE = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        }
    }
}
