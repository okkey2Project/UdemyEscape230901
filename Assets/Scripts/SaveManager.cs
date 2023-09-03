using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲームデータをセーブ/ロードするもの
public class SaveManager : MonoBehaviour
{
    //セーブの実装
    //・セーブする形式を決める：true/falseの配列（アイテムの所持状態）
    //・セーブクラスを作成する：このセーブクラスを端末に保存したりする
    SaveData saveData;

    //static化する
    public static SaveManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        saveData = new SaveData();

    }

    //・セーブ関数を作る
    public void Save()
    {

        //SaveDataをJson化する:JsonUtility.ToJsonを使う
        //・Json化：クラス（SaveData）を文字列（string）に変換する
        //PlayerPrefsを使って文字列を端末に保存する
        string json = JsonUtility.ToJson(saveData);
        //                      ↓キーコード
        PlayerPrefs.SetString("SAVE_DATA" , json );

        Debug.Log(json);


    }

    //・ロード関数を作る
    public void Load()
    {

        //PlayerPrefsを使って文字列を端末から取得する
        //文字列をクラスに復元する:JsonUtility.FromJson
        string json = PlayerPrefs.GetString("SAVE_DATA");
        saveData = JsonUtility.FromJson<SaveData>(json);

    }

    //アイテムを取得したら、取得したことをセーブする
    public void SetItemData(Item.ItemType item)
    {
        int index = (int) item;
        saveData.getItem[index] = true;
        Save();

    }


    //・セーブクラスを作成する

}

[System.Serializable]
class SaveData
{
    //アイテムを手に入れたかどうか
    public bool[] getItem = new bool[2];
}
