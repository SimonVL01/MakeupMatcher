using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MakeupMatcher.Core.ViewModels;
using Airbnb.Lottie;

using UIKit;

namespace MakeupMatcher.UI.iOS.Views
{
    public partial class UserView : MvxViewController<UserViewModel>
    {
        public UserView() : base("UserView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            LOTAnimationView animation = LOTAnimationView.AnimationNamed("heart");
            View.AddSubview(animation);
            animation.Play();


        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

