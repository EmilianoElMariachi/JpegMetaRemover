using System;
using System.Windows.Forms;
using JpegMetaRemover.JpegTools;
using JpegMetaRemover.ServicesProvider;
using JpegMetaRemover.ServicesProvider.SettingsService;

namespace JpegMetaRemover.OtherForms
{
    public partial class FormSettings : Form
    {

        private class Metadata
        {
            public JpegMetaTypes Meta { get; set; }

            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }


        private static string AppNToAppNames(JpegMetaTypes metaTypes)
        {
            return metaTypes switch
            {
                JpegMetaTypes.APP0 => "JFIF JFXX CIFF AVI1 Ocad",
                JpegMetaTypes.APP1 => "EXIF ExtendedXMP XMP QVCI FLIR RawThermalImage",
                JpegMetaTypes.APP2 => "ICC_Profile FPXR MPF PreviewImage",
                JpegMetaTypes.APP3 => "Meta Stim JPS ThermalData PreviewImage",
                JpegMetaTypes.APP4 => "Scalado FPXR ThermalParams PreviewImage",
                JpegMetaTypes.APP5 => "RMETA SamsungUniqueID ThermalCalibration PreviewImage",
                JpegMetaTypes.APP6 => "EPPIM NITF HP_TDHD GoPro DJI_DTAT",
                JpegMetaTypes.APP7 => "Pentax Huawei Qualcomm",
                JpegMetaTypes.APP8 => "SPIFF",
                JpegMetaTypes.APP9 => "MediaJukebox",
                JpegMetaTypes.APP10 => "Comment",
                JpegMetaTypes.APP11 => "JPEG-HDR JUMBF",
                JpegMetaTypes.APP12 => "PictureInfo Ducky",
                JpegMetaTypes.APP13 => "Photoshop Adobe_CM",
                JpegMetaTypes.APP14 => "Adobe",
                JpegMetaTypes.APP15 => "GraphicConverter",
                _ => throw new ArgumentOutOfRangeException(nameof(metaTypes), metaTypes, null)
            };
        }

        public FormSettings()
        {
            InitializeComponent();

            foreach (JpegMetaTypes value in Enum.GetValues(typeof(JpegMetaTypes)))
            {
                if (value == JpegMetaTypes.NONE)
                    continue;

                var appNames = AppNToAppNames(value);
                CheckedListBoxMetadataToRemove.Items.Add(new Metadata
                {
                    Text = $"{value} ({appNames})",
                    Meta = value
                });
            }

        }

        public new DialogResult ShowDialog(IWin32Window owner)
        {
            this.InitializeFromSettings();
            return base.ShowDialog(owner);
        }

        private void InitializeFromSettings()
        {
            for (var i = 0; i < CheckedListBoxMetadataToRemove.Items.Count; i++)
            {
                var metadata = (Metadata)CheckedListBoxMetadataToRemove.Items[i];
                var metaToRemove = Services.SettingsManager.MetaTypesToRemove.HasFlag(metadata.Meta);

                CheckedListBoxMetadataToRemove.SetItemChecked(i, metaToRemove);
            }

            CheckBoxCleanOnDragAndDrop.Checked = Services.SettingsManager.CleanOnDragAndDrop;
        }

        private void ButtonSaveSettings_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            Services.SettingsManager.MetaTypesToRemove = this.GetJpegMetaTypesToRemove();
            Services.SettingsManager.CleanOnDragAndDrop = CheckBoxCleanOnDragAndDrop.Checked;
        }

        private JpegMetaTypes GetJpegMetaTypesToRemove()
        {
            var metasToRemove = JpegMetaTypes.NONE;

            for (var i = 0; i < CheckedListBoxMetadataToRemove.Items.Count; i++)
            {
                if (!CheckedListBoxMetadataToRemove.GetItemChecked(i)) 
                    continue;

                var metadata = (Metadata)CheckedListBoxMetadataToRemove.Items[i];
                metasToRemove |= metadata.Meta;
            }

            return metasToRemove;
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAllMetaTypesToGivenCheckedState(true);
        }

        private void DeselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAllMetaTypesToGivenCheckedState(false);
        }

        private void SetAllMetaTypesToGivenCheckedState(bool isChecked)
        {
            for (var i = 0; i < CheckedListBoxMetadataToRemove.Items.Count; i++)
            {
                CheckedListBoxMetadataToRemove.SetItemChecked(i, isChecked);
            }
        }

        private void ButtonResetSettings_Click(object sender, EventArgs e)
        {
            Services.SettingsManager.CleanRegistry();
            Services.SettingsManager.InitializeFromRegistry();
            InitializeFromSettings();
        }
    }
}
