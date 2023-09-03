using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanuki : MonoBehaviour
{
    //TanukiをクリックしたときにLeafがあれば消える

    //タイミング：Tanukiクリックした時　  /OnClick

    public void OnClickThis()
    {
        //条件：Leafを持っている
        bool hasItem = ItemBox.instance.CanUseItem(Item.ItemType.Leaf);
        if (hasItem)
        {
            //処理：表示を消す
            gameObject.SetActive(false);
            //ItemBoxからアイテムを消す
            ItemBox.instance.UseItem(Item.ItemType.Leaf);

        }
    }

}
