using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanuki : MonoBehaviour
{
    //Tanuki���N���b�N�����Ƃ���Leaf������Ώ�����

    //�^�C�~���O�FTanuki�N���b�N�������@  /OnClick

    public void OnClickThis()
    {
        //�����FLeaf�������Ă���
        bool hasItem = ItemBox.instance.CanUseItem(Item.ItemType.Leaf);
        if (hasItem)
        {
            //�����F�\��������
            gameObject.SetActive(false);
            //ItemBox����A�C�e��������
            ItemBox.instance.UseItem(Item.ItemType.Leaf);

        }
    }

}
