using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //�����A�C�e���̎���
    //�K�v�ȃA�C�e����񋓌^
    public enum ItemType
    {
        Leaf,
        Key,
        sample
            
    }

    public ItemType item;

    //�N���b�N���ꂽ���\���ɂ��ăA�C�e��BOX�֒ǉ�����
    //�^�C�~���O�F�N���b�N���ꂽ
    //�����F
    //      -��\��
    //      -�A�C�e��BOX�֒ǉ�



    public void OnClickThis()
    {
        gameObject.SetActive(false);

        //ItemBox�֒ǉ�
        ItemBox.instance.SetItem(item);

    }


}
