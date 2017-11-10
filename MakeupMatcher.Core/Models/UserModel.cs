using System;
//using SQLite.Net.Attributes;

namespace MakeupMatcher.Core.Models
{
    public class UserModel
    {
        //Constructor

        /*public UserModel(string name, string image)
        {
            UserName = name;
            UserImage = image;
            //MakeupProfile = makeup;
        }*/

        public UserModel()
        {

        }

        //[PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        //public MakeupModel MakeupProfile { get; set; }

        //Method

        public override string ToString()
        {
            return string.Format("[UserModel: UserId={0}, UserName={1}, UserImage={2}]", UserId, UserName, UserImage);
        }

    }
}