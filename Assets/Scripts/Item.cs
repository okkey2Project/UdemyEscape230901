using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //複数アイテムの実装
    //必要なアイテムを列挙型
    public enum ItemType
    {
        Leaf,
        Key,
        sample
            
    }

    public ItemType item;

    //クリックされたら非表示にしてアイテムBOXへ追加する
    //タイミング：クリックされた
    //処理：
    //      -非表示
    //      -アイテムBOXへ追加



    public void OnClickThis()
    {
        gameObject.SetActive(false);

        //ItemBoxへ追加
        ItemBox.instance.SetItem(item);

    }


}
