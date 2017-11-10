using System;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core.Models;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform;

namespace MakeupMatcher.Core.ViewModels
{
    public class UserViewModel : MvxViewModel
    {
        readonly UserModel _user;

        //Constructor

        public UserViewModel()
        {
            _user = Mvx.IocConstruct<UserModel>();
        }

        //State

        int _userId;

        public int UserId
        {
            get { return _user.UserId; }
        }

        string _username;

        public string Username
        {
            get { return _user.UserName; }
            set
            {
                _username = value;
                _user.UserName = value;
                RaisePropertyChanged(() => Username);
            }
        }

        string _userImage;

        public string UserImage
        {
            get { return _user.UserImage; }
            set
            {
                _userImage = value;
                _user.UserImage = value;
                RaisePropertyChanged(() => UserImage);
            }
        }

        MakeupModel _makeupModel;

        public MakeupModel MakeupModel
        {
            get { return _user.MakeupModel; }
            set
            {
                _makeupModel = value;
                _user.MakeupModel = value;
                RaisePropertyChanged(() => MakeupModel);
            }
        }

        //Methods & Services
       
    }
}
