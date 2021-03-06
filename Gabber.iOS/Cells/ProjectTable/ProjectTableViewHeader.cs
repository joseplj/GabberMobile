// This file has been autogenerated from a class added in the UI designer.

using System;
using CoreGraphics;
using FFImageLoading;
using FFImageLoading.Transformations;
using FFImageLoading.Work;
using Foundation;
using GabberPCL;
using GabberPCL.Models;
using UIKit;
using Gabber.iOS.Helpers;

namespace Gabber.iOS
{
    public partial class ProjectTableViewHeader : UITableViewCell
    {
        public static NSString CellID = new NSString("ProjectTableViewHeader");
        public static readonly UINib Nib;

        private nint thisIndex;
        private Action<nint> TappedCallback;

        static ProjectTableViewHeader()
        {
            Nib = UINib.FromName("ProjectTableViewHeader", NSBundle.MainBundle);
        }

        public ProjectTableViewHeader(IntPtr handle) : base(handle)
        {
            AddGestureRecognizer(new UITapGestureRecognizer(Tapped));
        }

        private void Tapped()
        {
            TappedCallback?.Invoke(thisIndex);
        }

        public void UpdateContent(Project project, Action<nint> tappedCallback, nint index)
        {
            TitleLabel.Text = LanguageChoiceManager.ContentByLanguage(project).Title;
            TappedCallback = tappedCallback;
            thisIndex = index;

            CGAffineTransform rotatedTrans = CGAffineTransform.MakeRotation(3.14159f * 90 / 180f);

            if (ArrowLabel.Transform != rotatedTrans && project.IsExpanded)
            {
                ArrowLabel.Transform = rotatedTrans;
            }
            else if (ArrowLabel.Transform == rotatedTrans && !project.IsExpanded)
            {
                ArrowLabel.Transform = CGAffineTransform.MakeIdentity();
            }

            ImageService.Instance.LoadCompiledResource("Logo").Transform(new CircleTransformation()).Into(ProjectIcon);

            if (!string.IsNullOrWhiteSpace(project.image))
            {
                ImageService.Instance.LoadUrl(project.image).Transform(new CircleTransformation()).Into(ProjectIcon);
            }

        }
    }
}
