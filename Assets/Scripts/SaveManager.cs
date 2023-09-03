using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ゲームデータをセーブ/ロードするもの
public class SaveManager : MonoBehaviour
{
    // セーブの実装
    // ・セーブする形式を決める：true/falseの配列（アイテムを手に入れたかどうか）
    // ・セーブクラスを作成する：このセーブクラスを端末に保存したりする
    SaveData saveData;

    // static化：どこからでも取得できるようにする
    public static SaveManager instance;
    private void Awake()
    {
        instance = this;
        saveData = new SaveData();
        Load();
    }

    // ・セーブ関数を作る
    public void Save()
    {
        // SaveDataをJson化する：JsonUtility.ToJson
        // ・Json化：クラス（SaveData）を文字列(string)に変換する
        // PlayerPrefsを使って文字列を端末に保存する
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("SAVE_DATA", json);
        Debug.Log(json);
    }
    // ・ロード関数を作る
    public void Load()
    {
        if (PlayerPrefs.HasKey("SAVE_DATA") == true)
        {
            // PlayerPrefsを使って文字列(Json)を端末から取得する
            // 文字列をクラスに復元する：JsonUtility.FromJson
            string json = PlayerPrefs.GetString("SAVE_DATA");
            saveData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log(saveData.getItem[0]);
        }
    }

    // アイテムを取得したら、取得したことをセーブする
    public void SetItemData(Item.ItemType item)
    {
        int index = (int)item; // 列挙型を数字に変換
        saveData.getItem[index] = true;
        Save();
    }
    public bool GetItemData(Item.ItemType item)
    {
        int index = (int)item; // 列挙型を数字に変換
        return saveData.getItem[index];
    }
}

[System.Serializable]
class SaveData
{
    public bool[] getItem = new bool[2]; // アイテムを手に入れたかどうか
}
