using Foundation;
using System;
using UIKit;
using GabberPCL.Models;

namespace Gabber.iOS
{
    public partial class TopicsCollectionViewCell : UICollectionViewCell
    {
        public static NSString CellID = new NSString("TopicCollectionCell");

        public TopicsCollectionViewCell(IntPtr handle) : base(handle) { }

        public void UpdateContent(Topic topic)
        {
            ProjectTopic.Text = topic.Text;

            var topCorrect = (ProjectTopic.Bounds.Size.Height - ProjectTopic.ContentSize.Height * ProjectTopic.ZoomScale) / 2.0;
            topCorrect = (topCorrect < 0.0 ? 0.0 : topCorrect);
            ProjectTopic.ContentInset = new UIEdgeInsets((nfloat)topCorrect, 0, 0, 0);

            ProjectTopic.TextColor = UIColor.Black;
            Layer.BorderColor = Application.MainColour;

            if (topic.SelectionState == Topic.SelectedState.current)
            {
                ProjectTopic.TextColor = UIColor.White;
                ProjectTopic.BackgroundColor = UIColor.FromCGColor(Application.MainColour);
                Layer.BorderColor = Application.MainColour;
            }
            else if (topic.SelectionState == Topic.SelectedState.previous)
            {
                ProjectTopic.BackgroundColor = UIColor.FromRGB(232, 206, 206);
            }
            else
            {
                ProjectTopic.BackgroundColor = UIColor.White;
            }
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