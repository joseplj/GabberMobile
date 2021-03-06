﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Foundation;
using GabberPCL.Models;
using GabberPCL.Resources;
using UIKit;

namespace Gabber.iOS.ViewSources
{
    public class LanguagePickerViewModel : UIPickerViewModel
    {
        private readonly List<LanguageChoice> rows;
        private Action<LanguageChoice> selectCallback;

        public LanguagePickerViewModel(List<LanguageChoice> data, Action<LanguageChoice> didSelect = null)
        {
            rows = data;
            selectCallback = didSelect;
        }

        public bool SelectById(UIPickerView pickerView, int id)
        {
            int index = rows.FindIndex((LanguageChoice obj) => obj.Id == id);

            pickerView.Select(index + 1, 0, true);

            // found?
            return index != -1;
        }

        public LanguageChoice GetChoice(UIPickerView pickerView)
        {
            int row = (int)pickerView.SelectedRowInComponent(0);

            if (row == 0) return null;

            return rows[row - 1];
        }

        [Export("pickerView:didSelectRow:inComponent:")]
        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            LanguageChoice choice = null;
            if ((int)row != 0)
            {
                choice = rows[(int)row - 1];
            }

            selectCallback?.Invoke(choice);
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return rows.Count + 1;
        }

        public override nfloat GetRowHeight(UIPickerView picker, nint component)
        {
            return 27f;
        }

        public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
        {
            UILabel lbl = new UILabel(new RectangleF(0, 0, 130f, 40f));
            lbl.TextColor = UIColor.Black;
            lbl.Font = UIFont.SystemFontOfSize(16f);
            lbl.TextAlignment = UITextAlignment.Center;
            lbl.Text = (row == 0) ? StringResources.common_ui_forms_language_default : rows[(int)row - 1].Endonym;
            return lbl;
        }
    }
}
