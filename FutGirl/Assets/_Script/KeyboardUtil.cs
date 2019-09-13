using UnityEngine;
//using UnityEditor;

public class KeyboardUtil 
{
    public static int GetKeyboardSize()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            using (AndroidJavaClass UnityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject View = UnityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer").Call<AndroidJavaObject>("getView");

                using (AndroidJavaObject Rct = new AndroidJavaObject("android.graphics.Rect"))
                {
                    View.Call("getWindowVisibleDisplayFrame", Rct);
                    return Screen.height - Rct.Call<int>("height");
                }
            }
        }

        return 0;
    }
}