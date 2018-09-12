// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CoreGraphics;
using Foundation;
using Gabber.iOS.Helpers;
using Gabber.iOS.ViewSources;
using GabberPCL;
using GabberPCL.Interfaces;
using GabberPCL.Models;
using GabberPCL.Resources;
using UIKit;
using static Gabber.iOS.ViewSources.CreateUserTableViewSource;

namespace Gabber.iOS
{
    public partial class CreateUserController : UITableViewController
    {
        private string enteredName;
        private string enteredEmail;
        private string enteredPassword;
        private AgeRange selectedAgeGroup;
        private Gender selectedGender;
        private IFRC_Society selectedSociety;
        private IFRC_Role selectedRole;
        private IProfileOption tempPickerOption;
        private CreateUserTableViewSource source;

        public CreateUserController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView.RowHeight = UITableView.AutomaticDimension;
            TableView.EstimatedRowHeight = 190;

            FinishButton.SetTitle(StringResources.common_ui_forms_done, UIControlState.Normal);

            FinishButton.TouchUpInside += FinishButton_TouchUpInside;

            source = new CreateUserTableViewSource(new List<UserOption> { });
            TableView.Source = source;
            TableView.Delegate = this;
            RefreshTableData();
        }

        [Export("tableView:didSelectRowAtIndexPath:")]
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            switch (indexPath.Row)
            {
                case 0:
                    ShowInputDialog(StringResources.register_ui_fullname_label, "", UIKeyboardType.Default, enteredName, false,
                                    (entered) => { enteredName = entered; });
                    break;
                case 1:
                    ShowInputDialog(StringResources.common_ui_forms_email_label, "", UIKeyboardType.EmailAddress, enteredEmail, false,
                                    (entered) => { enteredEmail = entered; });
                    break;
                case 2:
                    ShowInputDialog(StringResources.common_ui_forms_password_label, "Enter your password", UIKeyboardType.Default, enteredPassword, true,
                                    (entered) => { enteredPassword = entered; });
                    break;
                case 3:
                    ShowPickerDialog(StringResources.common_ui_forms_age, AgeRange.GetOptions().ToList<IProfileOption>(), () =>
                    {
                        AgeRange chosen = tempPickerOption as AgeRange;
                        selectedAgeGroup = chosen;
                        RefreshTableData();
                    });
                    break;
                case 4:
                    ShowPickerDialog(StringResources.common_ui_forms_gender_default, Gender.GetOptions().ToList<IProfileOption>(), () =>
                    {
                        Gender chosen = tempPickerOption as Gender;

                        if (chosen.Enum == Gender.GenderEnum.Custom)
                        {
                            ShowInputDialog(StringResources.common_ui_forms_gender_custom_label, "", UIKeyboardType.Default, "", false,
                                    (entered) =>
                                    {
                                        selectedGender = chosen;
                                        selectedGender.Data = entered;
                                        RefreshTableData();
                                    });
                        }
                        else
                        {
                            selectedGender = chosen;
                            selectedGender.Data = chosen.LocalisedName;
                            RefreshTableData();
                        }
                    });
                    break;
                case 5:
                    ShowPickerDialog(StringResources.common_ui_forms_society_default, IFRC_Society.GetOptions().ToList<IProfileOption>(), () =>
                    {
                        IFRC_Society chosen = tempPickerOption as IFRC_Society;
                        selectedSociety = chosen;
                        RefreshTableData();
                    });
                    break;
                case 6:
                    ShowPickerDialog(StringResources.participants_ui_add_role_default, IFRC_Role.GetOptions().ToList<IProfileOption>(), () =>
                    {
                        IFRC_Role chosen = tempPickerOption as IFRC_Role;
                        selectedRole = chosen;
                        RefreshTableData();
                    });
                    break;
            }
        }

        private void ShowInputDialog(string title, string message, UIKeyboardType keyboardType, string previous, bool isPassword, Action<string> OnOk)
        {
            UIAlertController alert = UIAlertController.Create(
                title, message, UIAlertControllerStyle.Alert);
            UITextField field = null;

            alert.AddTextField((textField) =>
            {
                field = textField;
                field.Text = previous;
                field.AutocorrectionType = UITextAutocorrectionType.No;
                field.KeyboardType = keyboardType;
                field.SecureTextEntry = isPassword;
                field.ReturnKeyType = UIReturnKeyType.Done;
                field.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            });

            alert.AddAction(UIAlertAction.Create(StringResources.common_comms_cancel, UIAlertActionStyle.Cancel, null));
            alert.AddAction(UIAlertAction.Create(StringResources.common_comms_ok, UIAlertActionStyle.Default, (actionOK) =>
            {
                OnOk(field.Text);
                RefreshTableData();
            }));

            PresentViewController(alert, true, null);
        }

        private void ShowPickerDialog(string title, List<IProfileOption> data, Action OnOk)
        {
            UIAlertController alert = UIAlertController.Create(title, "\n\n\n\n\n\n",
                UIAlertControllerStyle.Alert);
            UIPickerView pickerView = new UIPickerView(new CGRect(0, 20, 250, 140));

            tempPickerOption = null;

            var pickerModel = new ProfileOptionPickerViewModel(data, null,
                    (IProfileOption obj) => tempPickerOption = obj);

            pickerView.Model = pickerModel;

            alert.View.AddSubview(pickerView);
            alert.AddAction(UIAlertAction.Create(StringResources.common_comms_cancel, UIAlertActionStyle.Cancel, null));
            alert.AddAction(UIAlertAction.Create(StringResources.common_comms_ok, UIAlertActionStyle.Default, (actionOK) =>
            {
                if (tempPickerOption == null)
                {
                    tempPickerOption = data.FirstOrDefault();
                }
                OnOk();
            }));

            PresentViewController(alert, true, null);
            pickerView.Select(0, 0, false);
        }

        private void RefreshTableData()
        {
            List<UserOption> options = new List<UserOption>
            {
                new UserOption
                {
                    Title = StringResources.register_ui_fullname_label,
                    ShownData = enteredName,
                },

                new UserOption
                {
                    Title = StringResources.common_ui_forms_email_label,
                    ShownData = enteredEmail
                },

                new UserOption
                {
                    Title = StringResources.common_ui_forms_password_label,
                    ShownData = string.IsNullOrWhiteSpace(enteredPassword)? "" : "*********"
                },

                new UserOption
                {
                    Title = StringResources.common_ui_forms_age,
                    ShownData = (selectedAgeGroup == null)? "" : selectedAgeGroup.DisplayName
                },

                new UserOption
                {
                    Title = StringResources.common_ui_forms_gender_default,
                    ShownData = (selectedGender == null)? "" : selectedGender.Data
                },

                new UserOption
                {
                    Title = StringResources.common_ui_forms_society_default,
                    ShownData = (selectedSociety == null)? "" : selectedSociety.Name
                },

                new UserOption
                {
                    Title = StringResources.common_ui_forms_role_default,
                    ShownData = (selectedRole == null)? "" : selectedRole.LocalisedName
                }
            };

            source.Rows = options;
            TableView.ReloadData();
        }

        private void ErrorMessageDialog(string title)
        {
            var dialog = new MessageDialog();
            var errorDialog = dialog.BuildErrorMessageDialog(title, "");
            PresentViewController(errorDialog, true, null);
        }

        private async void FinishButton_TouchUpInside(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(enteredName))
            {
                ErrorMessageDialog(StringResources.register_ui_fullname_validate_empty);
            }
            else if (string.IsNullOrWhiteSpace(enteredEmail))
            {
                ErrorMessageDialog(StringResources.common_ui_forms_email_validate_empty);
            }
            else if (string.IsNullOrWhiteSpace(enteredPassword))
            {
                ErrorMessageDialog(StringResources.common_ui_forms_password_validate_empty);
            }
            else if (!Regex.Match(enteredEmail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                ErrorMessageDialog(StringResources.common_ui_forms_email_validate_invalid);
            }
            else if (selectedAgeGroup == null)
            {
                ErrorMessageDialog(StringResources.common_ui_forms_age_error);
            }
            else if (selectedGender == null)
            {
                ErrorMessageDialog(StringResources.common_ui_forms_gender_error);
            }
            else if (selectedSociety == null)
            {
                ErrorMessageDialog(StringResources.common_ui_forms_society_error);
            }
            else if (selectedRole == null)
            {
                ErrorMessageDialog(StringResources.common_ui_forms_role_error);
            }
            else
            {
                FinishButton.Enabled = false;
                Logger.LOG_EVENT_WITH_ACTION("REGISTER", "ATTEMPT");

                var response = await RestClient.Register(
                    enteredName,
                    enteredEmail,
                    enteredPassword,
                    1,
                    selectedSociety.Id,
                    selectedGender,
                    selectedRole.GetId(),
                    selectedAgeGroup.GetId());

                FinishButton.Enabled = true;

                if (response.Meta.Success)
                {
                    Logger.LOG_EVENT_WITH_ACTION("REGISTER", "SUCCESS");
                    NSUserDefaults.StandardUserDefaults.SetString(enteredEmail, "username");
                    PerformSegue("RegisterVerifySegue", this);
                }
                else if (response.Meta.Messages.Count > 0)
                {
                    Logger.LOG_EVENT_WITH_ACTION("REGISTER", "ERROR");
                    // Note: errors returned by register are the same as logjn, hence using that for lookup.
                    var err = StringResources.ResourceManager.GetString($"login.api.error.{response.Meta.Messages[0]}");
                    ErrorMessageDialog(err);
                }
            }
        }

    }
}