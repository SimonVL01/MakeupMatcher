﻿using System;
using MvvmCross.Core.ViewModels;
using MakeupMatcher.Core.Models;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform;
using MvvmCross.Core.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MakeupMatcher.Core.ViewModels
{
    public class UserViewModel : MvxViewModel
    {
        //readonly UserModel _user;
        private readonly IMvxNavigationService _navigationService;

        //Constructor

        public UserViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            //_user = 
            Mvx.IocConstruct<UserModel>();
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

        string _userPassword;

        public string UserPassword
        {
            get { return _userPassword; }
            set 
            {
                _userPassword = value;
                RaisePropertyChanged(() => UserPassword);
            }
        }

        byte[] _imageData;

        public byte[] ImageData
        {
            get { return _imageData; }
            set
            {
                _imageData = value;
                RaisePropertyChanged(() => ImageData);
            }
        }

        //Navigation

        private IMvxAsyncCommand _goToMakeupCommand;
        public IMvxAsyncCommand GoToMakeupCommand
        {
            get
            {
                _goToMakeupCommand = _goToMakeupCommand ?? new MvxAsyncCommand(() => _navigationService.Navigate<MakeupViewModel, DetailParameters>(new DetailParameters() { User = Username }));
                return _goToMakeupCommand;
            }
        }
    }
}
