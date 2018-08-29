// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Gabber.iOS
{
	[Register ("RegisterViewController")]
	partial class RegisterViewController
	{
		[Outlet]
		UIKit.UILabel ChooseLanguagePromptLabel { get; set; }

		[Outlet]
		UIKit.UITextField ConfirmPasswordTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITextField EmailRegisterTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITextField FullNameRegisterTextField { get; set; }

		[Outlet]
		UIKit.UIPickerView LanguagePicker { get; set; }

		[Outlet]
		UIKit.UIView LoadingOverlay { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITextField PasswordRegisterTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIActivityIndicatorView RegisterActivityIndicator { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIView RegisterMasterView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIButton RegisterUIButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITextView Terms { get; set; }

		[Action ("Register:")]
		partial void Register (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (EmailRegisterTextField != null) {
				EmailRegisterTextField.Dispose ();
				EmailRegisterTextField = null;
			}

			if (FullNameRegisterTextField != null) {
				FullNameRegisterTextField.Dispose ();
				FullNameRegisterTextField = null;
			}

			if (PasswordRegisterTextField != null) {
				PasswordRegisterTextField.Dispose ();
				PasswordRegisterTextField = null;
			}

			if (ConfirmPasswordTextField != null) {
				ConfirmPasswordTextField.Dispose ();
				ConfirmPasswordTextField = null;
			}

			if (RegisterActivityIndicator != null) {
				RegisterActivityIndicator.Dispose ();
				RegisterActivityIndicator = null;
			}

			if (ChooseLanguagePromptLabel != null) {
				ChooseLanguagePromptLabel.Dispose ();
				ChooseLanguagePromptLabel = null;
			}

			if (LanguagePicker != null) {
				LanguagePicker.Dispose ();
				LanguagePicker = null;
			}

			if (RegisterMasterView != null) {
				RegisterMasterView.Dispose ();
				RegisterMasterView = null;
			}

			if (RegisterUIButton != null) {
				RegisterUIButton.Dispose ();
				RegisterUIButton = null;
			}

			if (Terms != null) {
				Terms.Dispose ();
				Terms = null;
			}

			if (LoadingOverlay != null) {
				LoadingOverlay.Dispose ();
				LoadingOverlay = null;
			}
		}
	}
}
