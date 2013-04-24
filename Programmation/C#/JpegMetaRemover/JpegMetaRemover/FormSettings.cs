using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JpegMetaRemover
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

            var appIndex = 0;
            foreach (JpegMetaTypes value in Enum.GetValues(typeof(JpegMetaTypes)))
            {
                if (value != JpegMetaTypes.NONE)
                {
                    var item = _listViewMetadatasToRemove.Items.Add(value.ToString() + " (APP" + appIndex++.ToString() + ")");
                    item.Tag = value;
                    item.Checked = ((value & SettingsManager.MetaTypesToRemove) == value);
                }
            }

        }

        private void _buttonSaveSettings_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public JpegMetaTypes GetJpegMetaTypesToRemove()
        {
            var jpegMetaTypesToRemove = JpegMetaTypes.NONE;

            foreach (ListViewItem item in _listViewMetadatasToRemove.Items)
            {
                if (item.Checked)
                {
                    jpegMetaTypesToRemove = jpegMetaTypesToRemove | (JpegMetaTypes)item.Tag;
                }
            }

            return jpegMetaTypesToRemove;
        }

    }
}
