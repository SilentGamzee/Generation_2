using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogs
{
    public class DialogController : Singleton<DialogController>
    {
        //EVENTS
        public Action onDialogsOpened;

        public Action onDialogsClosed;

        //PUBLIC VARIABLES
        public List<Dialog> Dialogs = new List<Dialog>();

        public Dialog currentDialog;

        public Dialog GetCurrentDialog()
        {
            return currentDialog;
        }

        public Dialog ShowDialog(string type)
        {
            Dialog dialog = null;
            for (int i = 0; i < Dialogs.Count; i++)
            {
                if (Dialogs[i].DialogType == type)
                    dialog = Dialogs[i];
            }

            if (dialog != null)
            {
                currentDialog = Instantiate(dialog, transform.position, transform.rotation, gameObject.transform);
                onDialogsOpened?.Invoke();
                return currentDialog;
            }
            else
            {
                Debug.LogError("DialogController:there is no dialog with this type");
                return null;
            }
        }
    }
}