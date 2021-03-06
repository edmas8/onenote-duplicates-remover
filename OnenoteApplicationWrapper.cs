﻿using System;

namespace OneNoteDuplicatesRemover
{
    class OneNoteApplicationWrapper
    {
        private Microsoft.Office.Interop.OneNote.Application application = null;

        public bool InitializeOneNoteTypeLibrary()
        {
            try
            {
                application = new Microsoft.Office.Interop.OneNote.Application();
                return true;
            }
            catch (Exception exception)
            {
                etc.LoggerHelper.LogException(exception);
                return false;
            }
        }

        public bool TryGetHierarchyAsXML(out string fullHierarchyXmlStr)
        {
            fullHierarchyXmlStr = "";

            try
            {
                application.GetHierarchy(null, Microsoft.Office.Interop.OneNote.HierarchyScope.hsPages, out fullHierarchyXmlStr);
                return true;
            }
            catch (Exception exception)
            {
                etc.LoggerHelper.LogException(exception);
                return false;
            }
        }

        public bool TryGetPageContent(string pageId, out string pageContent)
        {
            pageContent = "";

            try
            {
                application.GetPageContent(pageId, out pageContent, Microsoft.Office.Interop.OneNote.PageInfo.piAll);
                return true;
            }
            catch (Exception exception)
            {
                etc.LoggerHelper.LogException(exception);
                return false;
            }
        }

        public bool TryNavigateTo(string lastSelectedPageId)
        {
            try
            {
                application.NavigateTo(lastSelectedPageId /* bstrHierarchyObjectID */, "", false);
                return true;
            }
            catch (Exception exception)
            {
                etc.LoggerHelper.LogException(exception);
                return false;
            }
        }

        public bool TryDeleteHierarchy(string pageId)
        {
            try
            {
                application.DeleteHierarchy(pageId);
                return true;
            }
            catch (Exception exception)
            {
                etc.LoggerHelper.LogException(exception);
                return false;
            }
        }
    }
}
