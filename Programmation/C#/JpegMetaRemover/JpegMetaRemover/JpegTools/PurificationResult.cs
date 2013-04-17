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

        public ActionType ActionPerformedOnMetadatas { get; private set; }

        public JpegMetaTypes MetaTypesEncountered { get; private set; }

        public int NbCommentsEncountered { get; private set; }

        public ActionType ActionPerformedOnComments { get; private set; }


        public PurificationResult(int nbMetadatasEncountered, ActionType actionPerformedOnMetadatas, JpegMetaTypes metaTypesEncountered, int nbCommentsEncountered, ActionType actionPerformedOnComments)
        {
            NbMetadatasEncountered = nbMetadatasEncountered;
            ActionPerformedOnMetadatas = actionPerformedOnMetadatas;
            MetaTypesEncountered = metaTypesEncountered;

            NbCommentsEncountered = nbCommentsEncountered;
            ActionPerformedOnComments = actionPerformedOnComments;
        }

    }
}
