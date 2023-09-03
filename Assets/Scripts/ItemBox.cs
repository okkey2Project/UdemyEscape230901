using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    //�K�v�ȗv�f
    //Box���ꂼ��̉摜���

    public GameObject[] boxs;

    //���̃N���X�͑��̂ǂ̃t�@�C���ł��g������
    //static������
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

    //�A�C�e�����N���b�N���ꂽ���ɁA���̃A�C�e���摜��ItemBox�ɕ\������
    public void SetItem(Item.ItemType item)
    {
        int index = (int)item;

        boxs[index].SetActive(true);

        SaveManager.instance.SetItemData(item);

    }


    //�A�C�e�����g���邩���ׂ�
    public bool CanUseItem(Item.ItemType item)
    {
        int index = (int)item;
        //�摜���\������Ă���Ύg����

        if (boxs[index].activeSelf == true)
        {
            return true;
        }
        return false;
    }


    //�A�C�e�����g�����ɁA���̃A�C�e���̉摜��ItemBox�����\���ɂ���
    public void UseItem(Item.ItemType item)
    {
        int index = (int)item;

        boxs[index].SetActive(false);
    }

}
