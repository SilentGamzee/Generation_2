using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AppsFlyerTrackerCallbacks : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(Application.identifier);
		printCallback("AppsFlyerTrackerCallbacks on Start");
        var id = AppsFlyer.getAppsFlyerId();
        AppsFlyer.setAppsFlyerKey("ASFASDHAD");
        #if UNITY_ANDROID
            /* Mandatory - set your Android package name */
            AppsFlyer.setAppID("com.testhotel.solidhotel");
           /* For getting the conversion data in Android, you need to add the "AppsFlyerTrackerCallbacks" listener.*/
            AppsFlyer.init("ASFASDHAD", "AppsFlyerTrackerCallbacks");
        #endif
    }

    // Update is called once per frame
    void Update () {
		
	}
	
	public void didReceiveConversionData(string conversionData) {
		printCallback ("AppsFlyerTrackerCallbacks:: got conversion data = " + conversionData);
	}
	
	public void didReceiveConversionDataWithError(string error) {
		printCallback ("AppsFlyerTrackerCallbacks:: got conversion data error = " + error);
	}
	
	public void didFinishValidateReceipt(string validateResult) {
		printCallback ("AppsFlyerTrackerCallbacks:: got didFinishValidateReceipt  = " + validateResult);
		
	}
	
	public void didFinishValidateReceiptWithError (string error) {
		printCallback ("AppsFlyerTrackerCallbacks:: got idFinishValidateReceiptWithError error = " + error);
		
	}
	
	public void onAppOpenAttribution(string validateResult) {
		printCallback ("AppsFlyerTrackerCallbacks:: got onAppOpenAttribution  = " + validateResult);
		
	}
	
	public void onAppOpenAttributionFailure (string error) {
		printCallback ("AppsFlyerTrackerCallbacks:: got onAppOpenAttributionFailure error = " + error);
		
	}
	
	public void onInAppBillingSuccess () {
		printCallback ("AppsFlyerTrackerCallbacks:: got onInAppBillingSuccess succcess");
		
	}
	public void onInAppBillingFailure (string error) {
		printCallback ("AppsFlyerTrackerCallbacks:: got onInAppBillingFailure error = " + error);
		
	}

	public void onInviteLinkGenerated (string link) {
		printCallback("AppsFlyerTrackerCallbacks:: generated userInviteLink "+link);
	}

	public void onOpenStoreLinkGenerated (string link) {
		printCallback("onOpenStoreLinkGenerated:: generated store link "+link);
		Application.OpenURL(link);
	}

	void printCallback(string str) {
		Debug.Log(str);
	}
}
