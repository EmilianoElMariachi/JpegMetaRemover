using System.Reflection;

namespace JpegMetaRemover.ServicesProvider.LocalizationService
{
    internal class LocalizableControlWrapper
    {
        private object _wrappedControl;

        private PropertyInfo TextMember { get; set; }

        public string AccessibleName { get; set; }

        public object WrappedControl
        {
            get => _wrappedControl;
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
            get => (string)this.TextMember.GetValue(this.WrappedControl, null);
            set => this.TextMember.SetValue(this.WrappedControl, value, null);
        }


    }

}
