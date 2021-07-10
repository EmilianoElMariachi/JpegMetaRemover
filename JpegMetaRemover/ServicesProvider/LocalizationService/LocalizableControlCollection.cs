using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using JpegMetaRemover.Log;

namespace JpegMetaRemover.ServicesProvider.LocalizationService
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
            this.AddIfLocalizable(new LocalizableControlWrapper
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
                if (rawControl is MenuStrip menuStrip)
                {
                    this.AddIfLocalizable(new LocalizableControlWrapper
                    {
                        AccessibleName = menuStrip.AccessibleName,
                        WrappedControl = menuStrip
                    });
                    UpdateFromControls(menuStrip.Items);
                }
                else if (rawControl is Control wrappedControl)
                {
                    this.AddIfLocalizable(new LocalizableControlWrapper
                    {
                        AccessibleName = wrappedControl.AccessibleName,
                        WrappedControl = wrappedControl
                    });
                    UpdateFromControls(wrappedControl.Controls);

                    if (wrappedControl.ContextMenuStrip != null)
                    {
                        UpdateFromControls(wrappedControl.ContextMenuStrip.Items);
                    }
                }
                else if (rawControl is ToolStripItem toolStripItem)
                {
                    this.AddIfLocalizable(new LocalizableControlWrapper
                    {
                        AccessibleName = toolStripItem.AccessibleName,
                        WrappedControl = toolStripItem
                    });

                    if (toolStripItem is ToolStripDropDownItem dropDown)
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
