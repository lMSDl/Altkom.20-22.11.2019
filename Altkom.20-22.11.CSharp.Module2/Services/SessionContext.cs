using Altkom._20_22._11.CSharp.Models;
using Altkom._20_22._11.CSharp.Module2.Models;
using System;

namespace Altkom._20_22._11.CSharp.Module2
{
    public static class SessionContext
    {
        public static Guid UserID;
        public static Role UserRole;
        public static Student CurrentStudent;
        public static Teacher CurrentTeacher;
    }

}