using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test1
{
    public class InitScript : MonoBehaviour
    {
        //PUBLIC EDITOR
        public GameObject randomCol;
        
        public List<Sprite> spriteList;

        //PUBLIC STATIC
        public static InitScript _instance;

        void Start()
        {

            _instance = this;

            MoveCoordinator.Init();
        }


       

        public static void UpdateImages()
        {

            var r_col = _instance.randomCol.transform;
            
            
            UpdateImage(r_col.GetChild(0).gameObject);
        }

        public static void UpdateImage(GameObject item)
        {
            var spriteList = _instance.spriteList;

            var r = Random.Range(0, spriteList.Count);
            item.GetComponent<Image>().sprite = spriteList[r];
            //item.GetComponent<ItemInfo>().num = r;
            item.gameObject.SetActive(true);
        }

        public static void UpdateImage(GameObject item, int num)
        {
            var spriteList = _instance.spriteList;

        
            item.GetComponent<Image>().sprite = spriteList[num];
            //item.GetComponent<ItemInfo>().num = r;
            item.gameObject.SetActive(true);
        }
    }
}
