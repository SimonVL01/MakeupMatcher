using System;
//using SQLite.Net.Attributes;

namespace MakeupMatcher.Core.Models
{
    public class UserModel
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public string UserPassWord { get; set; }
        //public MakeupModel MakeupProfile { get; set; }

    }
}