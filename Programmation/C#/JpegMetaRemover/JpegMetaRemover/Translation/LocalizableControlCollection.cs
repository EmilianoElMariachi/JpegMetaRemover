using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JpegMetaRemover.Log;

namespace JpegMetaRemover.Translation
{
    internal class LocalizableControlWrapperCollection : List<LocalizableControlWrapper>
    {
        public void AddIfLocalizable(LocalizableControlWrapper wrappedControl)
        {
            if (wrappedControl != null && !string.IsNullOrEmpty(wrappedControl.AccessibleName))
            {
                this.Add(wrappedControl);
            }
        }

        public void UpdateListFromForm(Form form)
        {
            this.AddIfLocalizable(new LocalizableControlWrapper()
                {
                    AccessibleName = form.AccessibleName,
                    WrappedControl = form,
                });
            UpdateFromControls(form.Controls);
        }

        private void UpdateFromControls(IEnumerable controls)
        {
            foreach (var rawControl in controls)
            {
                if (rawControl is MenuStrip)
                {
                    var control = (MenuStrip)rawControl;
                    this.AddIfLocalizable(new LocalizableControlWrapper()
                    {
                        AccessibleName = control.AccessibleName,
                        WrappedControl = control
                    });
                    UpdateFromControls(control.Items);
                }
                else if (rawControl is Control)
                {
                    var control = (Control)rawControl;

                    this.AddIfLocalizable(new LocalizableControlWrapper()
                    {
                        AccessibleName = control.AccessibleName,
                        WrappedControl = control
                    });
                    UpdateFromControls(control.Controls);

                    if (control.ContextMenuStrip != null)
                    {
                        UpdateFromControls(control.ContextMenuStrip.Items);
                    }
                }
                else if (rawControl is ToolStripItem)
                {
                    var control = (ToolStripItem)rawControl;
                    this.AddIfLocalizable(new LocalizableControlWrapper()
                    {
                        AccessibleName = control.AccessibleName,
                        WrappedControl = control
                    });

                    var dropDown = control as ToolStripDropDownItem;
                    if (dropDown != null)
                    {
                        UpdateFromControls(dropDown.DropDownItems);
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
