using Foundation;
using System;
using UIKit;
using GabberPCL.Models;

namespace Gabber.iOS
{
    public partial class ParticipantsCollectionViewCell : UICollectionViewCell
    {
        public static NSString CellID = new NSString("ParticipantCollectionCell");

        public ParticipantsCollectionViewCell (IntPtr handle) : base (handle) {}

        public void UpdateContent(User participant)
        {
            var themeColor = UIColor.FromRGB(.43f, .80f, .79f);
            ParticipantName.Text = participant.Name;
            ParticipantName.TextColor = participant.Selected ? UIColor.White : UIColor.Black;
            BackgroundColor = participant.Selected ? themeColor : UIColor.White;
            Layer.BorderColor = themeColor.CGColor;
        }

        public override UICollectionViewLayoutAttributes PreferredLayoutAttributesFittingAttributes(UICollectionViewLayoutAttributes layoutAttributes)
        {
            var autoLayoutAttributes = base.PreferredLayoutAttributesFittingAttributes(layoutAttributes);
            var targetSize = new CoreGraphics.CGSize(layoutAttributes.Frame.Width, 0);
            var autoLayoutSize = ContentView.SystemLayoutSizeFittingSize(targetSize, 1000, 250);
            var autoLayoutFrame = new CoreGraphics.CGRect(autoLayoutAttributes.Frame.Location, autoLayoutSize);
            autoLayoutAttributes.Frame = autoLayoutFrame;
            return autoLayoutAttributes;
        }
    }
}