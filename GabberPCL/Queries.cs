﻿using System.Collections.Generic;
using System.Linq;
using GabberPCL.Models;

namespace GabberPCL
{
    public static class Queries
    {
        public static List<Participant> AllParticipants() => Session.Connection.Table<Participant>().ToList();
        public static List<Participant> SelectedParticipants() => AllParticipants().FindAll((p) => p.Selected);
        // TODO: topicID should be an int once Topic model is introduced
        public static void CreateAnnotation(string sessionID, int start, string topicID)
        {
            Session.Connection.Insert(new Annotation {
                SessionID = sessionID,
                Start = start,
                Topic = topicID,
                End = 0
            });
        }

        public static List<Annotation> AnnotationsForLastSession()
        {
            var AnnotationTable = Session.Connection.Table<Annotation>();
            var LastAnnotationInserted = AnnotationTable.Last().SessionID;
            return AnnotationTable.Where((a) => a.SessionID == LastAnnotationInserted).ToList();
        }

        public static void UpdateAnnotation(Annotation annotation) => Session.Connection.Update(annotation);
    }
}