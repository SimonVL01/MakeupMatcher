using System;

namespace MakeupMatcher.Core.Models
{
    public class UserModel
    {
 
        public int _userId { get; set; }
        public string _userName { get; set; }
        public string _userImage { get; set; }
        public MakeupModel _makeupModel { get; set; }

    }
}