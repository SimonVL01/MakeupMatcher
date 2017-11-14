using System;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core.Models;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform;
using MvvmCross.Core.Navigation;
using System.Threading.Tasks;

namespace MakeupMatcher.Core.ViewModels
{
    public class UserViewModel : MvxViewModel
    {
        readonly UserModel _user;
        private readonly IMvxNavigationService _navigationService;

        //Constructor

        public UserViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
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

        string _userPassword;

        public string UserPassword
        {
            get { return _user.UserPassWord; }
            set 
            {
                _userPassword = value;
                _user.UserPassWord = value;
                RaisePropertyChanged(() => UserPassword);
            }
        }

        /*MakeupModel _makeupProfile;

        public MakeupModel MakeupProfile
        {
            get { return _user.MakeupProfile; }
            set
            {
                _makeupProfile = value;
                _user.MakeupProfile = value;
                RaisePropertyChanged(() => MakeupProfile);
            }
        }*/

        //NavigationService
       
        public override void Prepare()
        {
            //
        }

        /*public IMvxCommand GoCommand()
        {
            await _navigationService.Navigate<MakeupViewModel>();
            //ShowViewModel<MakeupViewModel>();
        }*/



        private IMvxAsyncCommand _goToMakeupCommand;
        public IMvxAsyncCommand GoToMakeupCommand
        {
            get
            {
                _goToMakeupCommand = _goToMakeupCommand ?? new MvxAsyncCommand(() => _navigationService.Navigate<MakeupViewModel>());
                return _goToMakeupCommand;
            }
        }


    }
}
