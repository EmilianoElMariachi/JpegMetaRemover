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

        public string AccessibleName { get; set; }

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


    }

}
