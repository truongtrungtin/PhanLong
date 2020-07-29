using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanLong.Common
{
    public class CommonConstants
    {
        public static string MEMBER_GROUP = "MEMBER";
        public static string ADMIN_GROUP = "ADMIN";
        public static string BOSS_GROUP = "BOSS";

        public static string USER_SESSION = "USER_SESSION";
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CartSession = "CartSession";

        public static string CurrentCulture { set; get; }
    }
}