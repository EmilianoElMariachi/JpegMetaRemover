using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using JpegMetaRemover.Log;

namespace JpegMetaRemover.Translation
{
    internal class LocalizableControlWrapper
    {
        private object _wrappedControl;

        private PropertyInfo TextMember { get; set; }

        public string Name { get; set; }

        public object WrappedControl
        {
            get
            {
                return _wrappedControl;
            }
            set
            {
                _wrappedControl = value;

                if (value != null)
                {
                    this.TextMember = value.GetType().GetProperty("Text");
                }
            }
        }

        public string Text
        {
            get
            { return (string)this.TextMember.GetValue(this.WrappedControl, null); }
            set { this.TextMember.SetValue(this.WrappedControl, value, null); }
        }

        public static List<LocalizableControlWrapper> FetchFormLocalizableControls(Form form)
        {
            var controlWrappers = new List<LocalizableControlWrapper>();
            FetchLocalizableControls(form.Controls, controlWrappers);
            return controlWrappers;
        }

        private static void FetchLocalizableControls(IEnumerable controls, List<LocalizableControlWrapper> localizableControlWrappers)
        {
            foreach (var rawControl in controls)
            {
                if (rawControl is MenuStrip)
                {
                    var control = (MenuStrip)rawControl;
                    localizableControlWrappers.Add(new LocalizableControlWrapper()
                    {
                        Name = control.Name,
                        WrappedControl = control
                    });
                    FetchLocalizableControls(control.Items, localizableControlWrappers);
                }
                else if (rawControl is Control)
                {
                    var control = (Control)rawControl;
                    localizableControlWrappers.Add(new LocalizableControlWrapper()
                    {
                        Name = control.Name,
                        WrappedControl = control
                    });
                    FetchLocalizableControls(control.Controls, localizableControlWrappers);
                }
                else if (rawControl is ToolStripItem)
                {
                    var control = (ToolStripItem)rawControl;
                    localizableControlWrappers.Add(new LocalizableControlWrapper()
                    {
                        Name = control.Name,
                        WrappedControl = control
                    });

                    var dropDown = control as ToolStripDropDownItem;
                    if (dropDown != null)
                    {
                        FetchLocalizableControls(dropDown.DropDownItems, localizableControlWrappers);
                    }
                }
                else
                {
                    Logger.LogError(typeof(LocalizationManager), "Unsupported element of type \"" + rawControl.GetType().Name + "\" found for localization");
                }
            }
        }

    }

}
