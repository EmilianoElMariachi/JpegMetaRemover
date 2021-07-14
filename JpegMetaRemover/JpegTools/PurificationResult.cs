namespace JpegMetaRemover.JpegTools
{

    public class PurificationResult
    {
        public int NbMetasFound { get; internal set; }

        public int NbMetasRemoved { get; internal set; }

        public JpegMetaTypes MetaTypesToRemove { get; internal set; }

        public JpegMetaTypes MetaTypesFound { get; internal set; }

        public JpegMetaTypes MetaTypesRemoved { get; internal set; }

        public int NbCommentsFound { get; internal set; }

        public int NbCommentsRemoved { get; internal set; }

        public bool ResultStreamDiffersFromOriginal { get; internal set; }

    }
}
