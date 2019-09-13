using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace jSlot{

	[System.Serializable]
	public struct Line{
		public Image line;
		public Image leftN;
		public Image rightN;

		public void show(bool s){
			line.enabled = s;
			leftN.enabled = !s;
			rightN.enabled = !s;
		}

	}

	public class Slot : MonoBehaviour {
		public GameObject gameObject;
		public Button btn;
		//public Button doubleBtn;
		//public Button LinesBtn;
		//public Button BetOneBtn;
		//public Button BetMaxBtn;
		//public Button autoSpinBtn;
		//public Image autoSpinActiveImage;
		public Image[] images;
		public Image[] imagesWin;
		public Sprite[] sprites;
		//public Text coinTextLabel;
		//public Text betTextLabel;
		//public Text tabloTextLabel;

		//public Line[] Lines;
		//public Image[] LinesButtonNumbers;

		public Image megaWin1;
		public Image megaWin2;
		public Image megaWin3;

		private bool isShow;
		private float timeRemaining = 0f;
		private int[] selectSprites;
		private int coins = 1000;
		private bool[] animatedSprite;
		private int activeLines = 9;

		private int defBet = 10;
		private int bet = 0;
		private int nowBet = 0;
		private int dBet = 2;
		private int winMoneyInSession = 0;

		private bool isAutospin;

		private int freeSpin = 10;

		// Use this for initialization
		void Start () {
			isShow = false;
			megaWin1.enabled = false;
			megaWin2.enabled = false;
			megaWin3.enabled = false;
			//autoSpinActiveImage.enabled = false;
			bet = defBet;
			isAutospin = false;
			//coinTextLabel.text = coins.ToString();
			//betTextLabel.text = bet.ToString();
			InvokeRepeating("LaunchProjectile", 2.0f, 0.2f);
			selectSprites = new int[images.Length];
			animatedSprite = new bool[images.Length];
			for (int i = 0; i < images.Length; i++){
				images[i].GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
				selectSprites[i] = 0;
				animatedSprite[i] = false;
				imagesWin[i].enabled = false;
			}
			LinesBtnOnClick();
			btn.onClick.AddListener(TaskOnClick);
			//LinesBtn.onClick.AddListener(LinesBtnOnClick);
			//doubleBtn.onClick.AddListener(DoubleBtnOnClick);
			//BetOneBtn.onClick.AddListener(BetOneBtnOnClick);
			//BetMaxBtn.onClick.AddListener(BetMaxBtnOnClick);
			//autoSpinBtn.onClick.AddListener(AutoSpinBtnOnClick);
		}

		void winHide(){
			CancelInvoke("winHide");
			megaWin1.enabled = false;
			megaWin2.enabled = false;
			megaWin3.enabled = false;
		}

		void stopAutoSpin(){
			CancelInvoke("AutospinWork");
			isAutospin = false;
			//autoSpinActiveImage.enabled = false;
		}

		void AutospinWork(){
			if (!isAutospin) return;
			//autoSpinActiveImage.enabled = true;
			updateBet(1);
	    	StartRoulet();
		}

		void AutoSpinBtnOnClick(){
			InvokeRepeating("AutospinWork", 5.0f, 5.0f);
			isAutospin = true;
			AutospinWork();
		}
		
		void BetOneBtnOnClick(){
			stopAutoSpin();
			nowBet++;
			if (nowBet > 10) nowBet = 0;
			updateBet(1);

		}

		void BetMaxBtnOnClick(){
			stopAutoSpin();
			nowBet = 10;
			updateBet(1);
		}

		void LaunchProjectile(){
	    	if (isShow){
	    		for (int i = 5; i < 15; i++){
					images[i].GetComponent<Image>().sprite = sprites[selectSprites[i - 5]];
					selectSprites[i] = selectSprites[i - 5];
				}

	    		for (int i = 0; i < 5; i++){
	    			int t = Random.Range(0, sprites.Length);
					images[i].GetComponent<Image>().sprite = sprites[t];
					selectSprites[i] = t;
				}
				
			}
	    }

	    void TaskOnClick(){
	    	stopAutoSpin();
	    	updateBet(1);
	    	StartRoulet();
	    }

	    void DoubleBtnOnClick(){
	    	stopAutoSpin();
	    	updateBet(2);
	    	StartRoulet();
	    }

	    void updateBet(int dbb){
	    	bet = dbb * (defBet + nowBet * dBet);
	    	//betTextLabel.text = bet.ToString();
	    }

	    void StartRoulet(){
	    	isShow = true;
	    	timeRemaining = 3f;
	    	megaWin1.enabled = false;
			megaWin2.enabled = false;
			megaWin3.enabled = false;
			if (freeSpin > 0){
				freeSpin--;
			}else{
				coins -= bet;
			}
	    	
	    	//coinTextLabel.text = coins.ToString();
	  //  	for (int i = 0; i < Lines.Length; i++){
			//	Lines[i].line.enabled = false;
			//}
			for (int i = 0; i < imagesWin.Length; i++){
				imagesWin[i].enabled = false;
			}
	    }

		// Update is called once per frame
		void Update () {
			if (timeRemaining > 0) {
				Debug.Log("Waitting..."+timeRemaining);
				timeRemaining -= Time.deltaTime;
				if ( timeRemaining <= 0 ) { isShow = false; chechWin();}
			} 
		}

		void chechWin(){

			//if (Random.Range(0, 100) > 80){
			//	gameObject.GetComponent<ads>().ShowAd();
			//}

			bool winNow = false;
			winMoneyInSession = 0;
			if (activeLines == 1){
				if (chechWinLine(5,6,7,8,9, 4)){ 
					winNow = true;
				}
			}else if(activeLines == 3){
				bool w1 = chechWinLine(5,6,7,8,9, 4);
				bool w2 = chechWinLine(0,1,2,3,4, 0);
				bool w3 = chechWinLine(10,11,12,13,14, 8);
				if (w1 || w2 || w3){ 
					winNow = true;
				}
			}else if(activeLines == 5){
				bool w1 = chechWinLine(5,6,7,8,9, 4);
				bool w2 = chechWinLine(0,1,2,3,4, 0);
				bool w3 = chechWinLine(10,11,12,13,14, 8);
				bool w4 = chechWinLine(0,6,12,8,4, 2);
				bool w5 = chechWinLine(10,6,2,8,14, 6);
				if (w1 || w2 || w3 || w4 || w5){ 
					winNow = true;
				}
			}else if(activeLines == 7){
				bool w1 = chechWinLine(5,6,7,8,9, 4);
				bool w2 = chechWinLine(0,1,2,3,4, 0);
				bool w3 = chechWinLine(10,11,12,13,14, 8);
				bool w4 = chechWinLine(0,6,12,8,4, 2);
				bool w5 = chechWinLine(10,6,2,8,14, 6);
				bool w6 = chechWinLine(10,11,7,13,14, 7);
				bool w7 = chechWinLine(0,1,7,3,4, 1);
				if (w1 || w2 || w3 || w4 || w5 || w6 || w7){ 
					winNow = true;
				}
			}else if(activeLines == 9){
				bool w1 = chechWinLine(5,6,7,8,9, 4);
				bool w2 = chechWinLine(0,1,2,3,4, 0);
				bool w3 = chechWinLine(10,11,12,13,14, 8);
				bool w4 = chechWinLine(0,6,12,8,4, 2);
				bool w5 = chechWinLine(10,6,2,8,14, 6);
				bool w6 = chechWinLine(10,11,7,13,14, 7);
				bool w7 = chechWinLine(0,1,7,3,4, 1);
				bool w8 = chechWinLine(5,1,2,3,9, 3);
				bool w9 = chechWinLine(5,11,12,13,9, 5);
				if (w1 || w2 || w3 || w4 || w5 || w6 || w7 || w8 || w9){ 
					winNow = true;
				}
			}
			
			//tabloTextLabel.text = "----";
			if (winNow) {
				megaWin1.enabled = true;
				megaWin2.enabled = true;
				megaWin3.enabled = true;
				coins += bet * 2 * (winMoneyInSession / 10);
				//coinTextLabel.text = coins.ToString();
				//tabloTextLabel.text = "+ " + (bet * 2 * (winMoneyInSession / 10)).ToString();
				InvokeRepeating("winHide", 2.0f, 2.0f);
			}else if (freeSpin > 0){
				//tabloTextLabel.text = "ФC: "+ freeSpin.ToString();
			}
		}

		bool chechWinLine(int a, int b, int c, int d, int e, int n){
			bool isWin = false;
			int[] winN = new int[0];
			if (C(a,b) && C(a,c) && C(a,d) && C(a,e)){
				winMoneyInSession += 20;
				freeSpin += 10;
				isWin = true;
				winN = new int[5] {a, b, c, d, e};
			}else if(C(a,b) && C(a,c) && C(a,d)){
				winMoneyInSession += 15;
				freeSpin += 5;
				isWin = true;
				winN = new int[4] {a, b, c, d};
			}else if(C(a,b) && C(a,c) && C(a,e)){
				winMoneyInSession += 15;
				freeSpin += 5;
				isWin = true;
				winN = new int[4] {a, b, c, e};
			}else if(C(a,b) && C(a,e) && C(a,d)){
				winMoneyInSession += 15;
				freeSpin += 5;
				isWin = true;
				winN = new int[4] {a, b, e, d};
			}else if(C(a,c) && C(a,d) && C(a,e)){
				winMoneyInSession += 15;
				freeSpin += 5;
				isWin = true;
				winN = new int[4] {a, c, d, e};
			}else if(C(b,c) && C(b,d) && C(b,e)){
				winMoneyInSession += 15;
				freeSpin += 5;
				isWin = true;
				winN = new int[4] {b, c, d, e};
			}else if(C(a,b) && C(a,c)){
				winMoneyInSession += 10;
				isWin = true;
				winN = new int[3] {a, b, c};
			}else if(C(a,b) && C(a,d)){
				winMoneyInSession += 10;
				isWin = true;
				winN = new int[3] {a, b, d};
			}else if(C(a,b) && C(a,e)){
				winMoneyInSession += 10;
				isWin = true;
				winN = new int[3] {a, b, e};
			}else if(C(a,c) && C(a,d)){
				winMoneyInSession += 10;
				isWin = true;
				winN = new int[3] {a, c, d};
			}else if(C(a,c) && C(a,e)){
				winMoneyInSession += 10;
				isWin = true;
				winN = new int[3] {a, c, e};
			}else if(C(a,d) && C(a,e)){
				winMoneyInSession += 10;
				isWin = true;
				winN = new int[3] {a, d, e};
			}else if(C(b,c) && C(b,d)){
				winMoneyInSession += 10;
				isWin = true;
				winN = new int[3] {b, c, d};
			}else if(C(b,c) && C(b,e)){
				winMoneyInSession += 10;
				isWin = true;
				winN = new int[3] {b, c, e};
			}else if(C(b,d) && C(b,e)){
				winMoneyInSession += 10;
				isWin = true;
				winN = new int[3] {b, d, e};
			}else if(C(c,d) && C(c,e)){
				winMoneyInSession += 10;
				isWin = true;
				winN = new int[3] {c, d, e};
			}

			if (isWin){
				for (int i = 0; i < winN.Length; i++){
					imagesWin[winN[i]].enabled = true;
				}
				//Lines[n].show(true);
			}

			return isWin;
		}

		bool C(int a, int b){
			return selectSprites[a] == selectSprites[b];
		}

		void LinesBtnOnClick(){
			stopAutoSpin();
			//for (int i = 0; i < Lines.Length; i++){
			//	Lines[i].show(false);
			//}
			//for (int i = 0; i < LinesButtonNumbers.Length; i++){
			//	LinesButtonNumbers[i].enabled = false;
			//}
			//if (activeLines == 1){
			//	activeLines = 3;
			//	Lines[4].show(true);
			//	Lines[0].show(true);
			//	Lines[8].show(true);
			//	LinesButtonNumbers[1].enabled = true;
			//}else if (activeLines == 3){
			//	activeLines = 5;
			//	Lines[4].show(true);
			//	Lines[0].show(true);
			//	Lines[8].show(true);
			//	Lines[2].show(true);
			//	Lines[6].show(true);
			//	LinesButtonNumbers[2].enabled = true;
			//}else if (activeLines == 5){
			//	activeLines = 7;
			//	Lines[4].show(true);
			//	Lines[0].show(true);
			//	Lines[8].show(true);
			//	Lines[2].show(true);
			//	Lines[6].show(true);
			//	Lines[1].show(true);
			//	Lines[7].show(true);
			//	LinesButtonNumbers[3].enabled = true;
			//}else if (activeLines == 7){
			//	activeLines = 9;
			//	Lines[4].show(true);
			//	Lines[0].show(true);
			//	Lines[8].show(true);
			//	Lines[2].show(true);
			//	Lines[6].show(true);
			//	Lines[1].show(true);
			//	Lines[7].show(true);
			//	Lines[3].show(true);
			//	Lines[5].show(true);
			//	LinesButtonNumbers[4].enabled = true;
			//}else if (activeLines == 9){
			//	activeLines = 1;
			//	Lines[4].show(true);
			//	LinesButtonNumbers[0].enabled = true;
			//}
		}

	}
}
