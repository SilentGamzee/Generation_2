using UnityEngine;

namespace Dialogs
{
    public class Dialog : MonoBehaviour
    {
        public string DialogType;
        public bool WithoutClickOverlay = false;
        private bool isShowing;
        private Animator anim;

        protected virtual void Start()
        {
            if (anim == null)
                anim = GetComponent<Animator>();
            GetComponent<Canvas>().worldCamera = Camera.main;
            anim.SetBool("isShow", true);
            Debug.Log("Show dialog: " + DialogType);
            if(!WithoutClickOverlay)
                DialogOverlay.OnClick += BackgroundClick;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Close();
            }
        }

        public void DestroyDialog()
        {
            DialogController.Instance.onDialogsClosed?.Invoke();
            DialogOverlay.OnClick -= BackgroundClick;
            Destroy(gameObject);
        }

        public virtual void Close()
        {
            if (anim != null)
                anim.SetBool("isShow", false);
            else
                DestroyDialog();

            DialogController.Instance.onDialogsClosed?.Invoke();
            DialogOverlay.OnClick -= BackgroundClick;
        }

        private void BackgroundClick()
        {
            Close();
        }
    }
}