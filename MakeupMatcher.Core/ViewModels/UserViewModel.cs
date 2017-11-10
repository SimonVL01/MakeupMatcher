using System;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core.Models;

namespace MakeupMatcher.Core.ViewModels
{
    public class UserViewModel : MvxViewModel
    {

        //Constructor

        public UserViewModel()
        {
        }

        //State

        int _userId;

        public int UserId
        {
            get { return _userId; }
        }

        string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged(() => Username);
            }
        }

        string _userImage;

        public string UserImage
        {
            get { return _userImage; }
            set
            {
                _userImage = value;
                RaisePropertyChanged(() => UserImage);
            }
        }

        int[] _userColorPreference;

        public int[] UserColorPreference
        {
            get { return _userColorPreference; }
            set
            {
                _userColorPreference = value;
                RaisePropertyChanged(() => UserColorPreference);
            }
        }

        //Methods & Services
       
    }
}
