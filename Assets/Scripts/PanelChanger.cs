using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelChanger : MonoBehaviour
{
    //パネルを列挙型で定義
    enum Panel
    {
        Panel0,
        Panel1,
        Panel2,
        Panel3,
    }

    //現在のパネル
    Panel currentPanel = Panel.Panel0;

    //矢印の表示/非表示
    //*SetActive(true/false)
    //Panel0:Right
    //Panel1:Light
    //Panel2:Back
    //Panel3:Back
    //一度全て非表示

    public GameObject rightArrow;
    public GameObject leftArrow;
    public GameObject backArrow;

    private void Start()
    {
        HideArrows();
        rightArrow.SetActive(true);
    }

    void HideArrows()
    {
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
        backArrow.SetActive(false);

    }
    void ShowPanel(Panel panel)
    {
        
        //矢印を非表示にする        
        HideArrows();
        //currentPanelに引数を代入
        currentPanel = panel;

        switch (panel)
        {
            case Panel.Panel0:
                //Panel0へ移動：Pane;Pearentを(0, 0)
                transform.localPosition = new Vector2(0, 0);
                currentPanel = Panel.Panel0;
                //矢印を非表示にする
                //右矢印を表示
                rightArrow.SetActive(true);
                break;

            case Panel.Panel1:
                //Panel1へ移動：Pane;Pearentを(-1000, 0)
                transform.localPosition = new Vector2(-1000, 0);
                currentPanel = Panel.Panel1;
                //左矢印を表示
                leftArrow.SetActive(true);
                break;

            case Panel.Panel2:
                //Panel2へ移動：Pane;Pearentを(0, 1500)
                transform.localPosition = new Vector2(0, 1500);
                currentPanel = Panel.Panel2;
                //戻る矢印を表示
                backArrow.SetActive(true);
                break;

            case Panel.Panel3:
                //Panel3へ移動：Pane;Pearentを(-1000, 1500)
                transform.localPosition = new Vector2(-1000, 1500);
                currentPanel = Panel.Panel3;
                //戻る矢印を表示
                backArrow.SetActive(true);
                break;

        }

    }

    //ボタンを押したら移動してパネルを変更する

    //右ボタンを押したらPanel1へ移動
    public void OnRightArrow()
    {
        ShowPanel(Panel.Panel1);
    }

    //左ボタンを押したらPanel0へ移動
    public void OnLeftArrow()
    {
        ShowPanel(Panel.Panel0); 
    }
    //ロッカーを押したらPanel2に移動
    public void OnLocker0()
    {
        ShowPanel(Panel.Panel2);

    }

    //戻るボタン
    public void OnBackArrow()
    {
        //表示しているパネルがPanel2ならPanel0に移動
        switch (currentPanel)
        {
            case Panel.Panel2:
                ShowPanel(Panel.Panel0);
                break;
            case Panel.Panel3:
                ShowPanel(Panel.Panel1);
                break;

        }


    }

    //バケツをを押したらPanel3に移動
    public void OnBucket()
    {
        ShowPanel(Panel.Panel3);
    }

}
