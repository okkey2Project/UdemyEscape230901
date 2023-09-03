using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelChanger : MonoBehaviour
{
    //�p�l����񋓌^�Œ�`
    enum Panel
    {
        Panel0,
        Panel1,
        Panel2,
        Panel3,
    }

    //���݂̃p�l��
    Panel currentPanel = Panel.Panel0;

    //���̕\��/��\��
    //*SetActive(true/false)
    //Panel0:Right
    //Panel1:Light
    //Panel2:Back
    //Panel3:Back
    //��x�S�Ĕ�\��

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
        
        //�����\���ɂ���        
        HideArrows();
        //currentPanel�Ɉ�������
        currentPanel = panel;

        switch (panel)
        {
            case Panel.Panel0:
                //Panel0�ֈړ��FPane;Pearent��(0, 0)
                transform.localPosition = new Vector2(0, 0);
                currentPanel = Panel.Panel0;
                //�����\���ɂ���
                //�E����\��
                rightArrow.SetActive(true);
                break;

            case Panel.Panel1:
                //Panel1�ֈړ��FPane;Pearent��(-1000, 0)
                transform.localPosition = new Vector2(-1000, 0);
                currentPanel = Panel.Panel1;
                //������\��
                leftArrow.SetActive(true);
                break;

            case Panel.Panel2:
                //Panel2�ֈړ��FPane;Pearent��(0, 1500)
                transform.localPosition = new Vector2(0, 1500);
                currentPanel = Panel.Panel2;
                //�߂����\��
                backArrow.SetActive(true);
                break;

            case Panel.Panel3:
                //Panel3�ֈړ��FPane;Pearent��(-1000, 1500)
                transform.localPosition = new Vector2(-1000, 1500);
                currentPanel = Panel.Panel3;
                //�߂����\��
                backArrow.SetActive(true);
                break;

        }

    }

    //�{�^������������ړ����ăp�l����ύX����

    //�E�{�^������������Panel1�ֈړ�
    public void OnRightArrow()
    {
        ShowPanel(Panel.Panel1);
    }

    //���{�^������������Panel0�ֈړ�
    public void OnLeftArrow()
    {
        ShowPanel(Panel.Panel0); 
    }
    //���b�J�[����������Panel2�Ɉړ�
    public void OnLocker0()
    {
        ShowPanel(Panel.Panel2);

    }

    //�߂�{�^��
    public void OnBackArrow()
    {
        //�\�����Ă���p�l����Panel2�Ȃ�Panel0�Ɉړ�
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

    //�o�P�c������������Panel3�Ɉړ�
    public void OnBucket()
    {
        ShowPanel(Panel.Panel3);
    }

}
