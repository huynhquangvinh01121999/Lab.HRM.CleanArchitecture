using System;

namespace Utilities.Helpers
{
    public static class Validations
    {
        

        public static bool IsDateTimeNullorEmpty(DateTime? date)
        {
            return date == null ? true : false;
        }
    }
}
