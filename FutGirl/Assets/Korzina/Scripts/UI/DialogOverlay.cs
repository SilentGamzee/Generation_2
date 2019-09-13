using Dialogs;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogOverlay : MonoBehaviour, IPointerDownHandler
{
    //EVENTS
    public static Action OnClick;

    //PRIVATE VARIABLES
    [SerializeField]private Image _overlay;

    private Animator _animatorComponent;

    private void Awake()
    {
        //_overlay = GetComponent<Image>();
        _animatorComponent = GetComponent<Animator>();
    }

    private void Start()
    {
        DialogController.Instance.onDialogsOpened += OnDialogOpened;
        DialogController.Instance.onDialogsClosed += OnDialogClosed;
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        UpdateOverlay(false);
    }

    private void OnDialogOpened()
    {
        UpdateOverlay(true);
    }

    private void OnDialogClosed()
    {
        UpdateOverlay(false);
    }

    private void OnLevelFinishedLoading(Scene arg0, LoadSceneMode arg1)
    {
        UpdateOverlay(false);
    }

    private void UpdateOverlay(bool enable)
    {
        if (enable)
        {
            if (_overlay != null)
                _overlay.enabled = true;
            if(_animatorComponent != null)
            _animatorComponent.Play("Show", -1, 0f);
        }
        else
        {
            if(_overlay != null)
                _overlay.enabled = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }
}