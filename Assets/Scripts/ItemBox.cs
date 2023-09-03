using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    //必要な要素
    //Boxそれぞれの画像情報

    public GameObject[] boxs;

    //このクラスは他のどのファイルでも使いたい
    //static化する
    public static ItemBox instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (var itembox in boxs)
        {
            itembox.gameObject.SetActive(false);

        }

    }

    //アイテムがクリックされた時に、そのアイテム画像をItemBoxに表示する
    public void SetItem(Item.ItemType item)
    {
        int index = (int)item;

        boxs[index].SetActive(true);

        SaveManager.instance.SetItemData(item);

    }


    //アイテムが使えるか調べる
    public bool CanUseItem(Item.ItemType item)
    {
        int index = (int)item;
        //画像が表示されていれば使える

        if (boxs[index].activeSelf == true)
        {
            return true;
        }
        return false;
    }


    //アイテムを使う時に、そのアイテムの画像をItemBoxから非表示にする
    public void UseItem(Item.ItemType item)
    {
        int index = (int)item;

        boxs[index].SetActive(false);
    }

}
