using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    }
}
