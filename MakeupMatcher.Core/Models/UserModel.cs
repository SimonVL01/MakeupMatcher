using System;

namespace MakeupMatcher.Core.Models
{
    public class UserModel
    {
 
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public MakeupModel MakeupProfile { get; set; }

    }
}