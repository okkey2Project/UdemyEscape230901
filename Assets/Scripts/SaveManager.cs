using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Q�[���f�[�^���Z�[�u/���[�h�������
public class SaveManager : MonoBehaviour
{
    //�Z�[�u�̎���
    //�E�Z�[�u����`�������߂�Ftrue/false�̔z��i�A�C�e���̏�����ԁj
    //�E�Z�[�u�N���X���쐬����F���̃Z�[�u�N���X��[���ɕۑ������肷��
    SaveData saveData;

    //static������
    public static SaveManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        saveData = new SaveData();

    }

    //�E�Z�[�u�֐������
    public void Save()
    {

        //SaveData��Json������:JsonUtility.ToJson���g��
        //�EJson���F�N���X�iSaveData�j�𕶎���istring�j�ɕϊ�����
        //PlayerPrefs���g���ĕ������[���ɕۑ�����
        string json = JsonUtility.ToJson(saveData);
        //                      ���L�[�R�[�h
        PlayerPrefs.SetString("SAVE_DATA" , json );

        Debug.Log(json);


    }

    //�E���[�h�֐������
    public void Load()
    {

        //PlayerPrefs���g���ĕ������[������擾����
        //��������N���X�ɕ�������:JsonUtility.FromJson
        string json = PlayerPrefs.GetString("SAVE_DATA");
        saveData = JsonUtility.FromJson<SaveData>(json);

    }

    //�A�C�e�����擾������A�擾�������Ƃ��Z�[�u����
    public void SetItemData(Item.ItemType item)
    {
        int index = (int) item;
        saveData.getItem[index] = true;
        Save();

    }


    //�E�Z�[�u�N���X���쐬����

}

[System.Serializable]
class SaveData
{
    //�A�C�e������ɓ��ꂽ���ǂ���
    public bool[] getItem = new bool[2];
}
