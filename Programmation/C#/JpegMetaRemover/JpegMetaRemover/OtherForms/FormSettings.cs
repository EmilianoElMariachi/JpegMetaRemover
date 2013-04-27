using System;
using System.Windows.Forms;
using JpegMetaRemover.JpegTools;
using JpegMetaRemover.ServicesProvider;

namespace JpegMetaRemover.OtherForms
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
                }
            }

        }

        public new DialogResult ShowDialog()
        {
            this.UpdateFromSettings();
            return base.ShowDialog();
        }

        public new DialogResult ShowDialog(IWin32Window owner)
        {
            this.UpdateFromSettings();
            return base.ShowDialog(owner);
        }

        public void UpdateFromSettings()
        {
            foreach (ListViewItem item in _listViewMetadatasToRemove.Items)
            {
                var itemMeta = (JpegMetaTypes) item.Tag;
                item.Checked = (Services.SettingsManager.MetaTypesToRemove & itemMeta) == itemMeta;
            }

            _checkBoxCleanSavedSettingsOnClose.Checked = Services.SettingsManager.CleanUpSavedSettingsOnClose;            
        }

        private void _buttonSaveSettings_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            Services.SettingsManager.MetaTypesToRemove = this.GetJpegMetaTypesToRemove();
            Services.SettingsManager.CleanUpSavedSettingsOnClose = _checkBoxCleanSavedSettingsOnClose.Checked;

        }

        private JpegMetaTypes GetJpegMetaTypesToRemove()
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

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void _selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAllMetaTypesToGivenCheckedState(true);
        }

        private void _deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAllMetaTypesToGivenCheckedState(false);
        }

        private void SetAllMetaTypesToGivenCheckedState(bool isChecked)
        {
            foreach (ListViewItem item in _listViewMetadatasToRemove.Items)
            {
                item.Checked = isChecked;
            }
        }

    }
}
