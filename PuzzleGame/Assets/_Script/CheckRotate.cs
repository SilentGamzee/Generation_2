using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckRotate : MonoBehaviour {
	public bool needPortrait;
	public int bgWidth, bgHeight;
	public Canvas currentCanvas;

    public Button rB;
    public Text tT;

	// static DeviceOrientation orientation;
	// private canvasWidth, canvasHeight;
	// Use this for initialization
	void Start () {
		//DeviceChange.OnOrientationChange += MyOrientationChangeCode;
        //rB.onClick.AddListener(rBClick);
		// gameObject.GetComponent<RectTransform> ().rotation = Quaternion.EulerAngles(0f, 0f, 1.5707f);
	}
	
    void rBClick(){
        //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x,
        //            currentCanvas.GetComponent<RectTransform>().rect.height * 1.0f / bgHeight * 1.0f, 1);
        //transform.Rotate(0, 0, 90);
    }

	// Update is called once per frame
	void Update () {
        RectTransform rt = (RectTransform)gameObject.transform;
        //tT.text = rt.rect.width.ToString() + ":" + rt.rect.height.ToString();
    }

    void MyOrientationChangeCode(DeviceOrientation orientation){
        // gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x,  
        // 	currentCanvas.GetComponent<RectTransform> ().rect.height * 1.0f / bgHeight * 1.0f ,1);
        // gameObject.GetComponent<RectTransform> ().rotation.z = 90;
        // transform.Rotate(0, 0, 90);


        if (needPortrait){

		}else{

			if (orientation == DeviceOrientation.LandscapeLeft || orientation == DeviceOrientation.LandscapeRight){
				gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x,
					currentCanvas.GetComponent<RectTransform> ().rect.height * 1.0f / bgHeight * 1.0f , 1);
                //transform.Rotate(0, 0, 0);

                //tT.text = "1: " + Screen.width + ":" + Screen.height;

            }
            else{
				//   gameObject.GetComponent<RectTransform> ().rotation = Quaternion.EulerAngles(0f, 0f, 1.5707f);
				gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x,
					currentCanvas.GetComponent<RectTransform> ().rect.height * 1.0f / bgHeight * 1.0f , 1);
                //transform.Rotate(0, 0, 90);
                //tT.text = "1: " + Screen.width + ":" + Screen.height;
            }

		}

	}
}
