using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JpegMetaRemover
{

    public enum ActionType
    {
        REMOVE,
        KEEP,
    }

    public class PurificationResult
    {
        public int NbMetadatasEncountered { get; private set; }

        public JpegMetaTypes MetaTypesToRemove { get; private set; }

        public JpegMetaTypes MetaTypesEncountered { get; private set; }

        public int NbCommentsEncountered { get; private set; }

        public ActionType ActionPerformedOnComments { get; private set; }


        public PurificationResult(int nbMetadatasEncountered, JpegMetaTypes metadatasTypesToRemove, JpegMetaTypes metaTypesEncountered, int nbCommentsEncountered, ActionType actionPerformedOnComments)
        {
            NbMetadatasEncountered = nbMetadatasEncountered;
            MetaTypesToRemove = metadatasTypesToRemove;
            MetaTypesEncountered = metaTypesEncountered;

            NbCommentsEncountered = nbCommentsEncountered;
            ActionPerformedOnComments = actionPerformedOnComments;
        }

    }
}
