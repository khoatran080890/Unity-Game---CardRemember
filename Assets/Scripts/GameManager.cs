using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public CanvasGroup Real_BackGround;
    public CanvasGroup Fake_BackGround;

    public Text Score;

    public GameObject Line_1;
    public GameObject Line_2;
    public GameObject Line_3;
    public GameObject Line_4;

    private void Start()
    {
        ActiveCanvasGroup(CANVANGROUP.REAL);

        InfoContainer.GAMESTATE = OPTION.Single;
        InfoContainer.point = 0;
    }
    private void Update()
    {
        Score.text = InfoContainer.point.ToString();
    }
    public void Button_Click_BackGround()
    {
        InfoContainer.point -= 5;
    }
    public void Button_Click_BacktoReal()
    {
        ActiveCanvasGroup(CANVANGROUP.REAL);
    }
    public void Button_Click_BacktoFake()
    {
        ActiveCanvasGroup(CANVANGROUP.FAKE);
    }
    public void ActiveCanvasGroup(CANVANGROUP background)
    {
        if(background == CANVANGROUP.REAL)
        {
            Real_BackGround.alpha = 1;
            Real_BackGround.interactable = true;
            Real_BackGround.blocksRaycasts = true;
            Fake_BackGround.alpha = 0;
            Fake_BackGround.interactable = false;
            Fake_BackGround.blocksRaycasts = false;
        }
        if(background == CANVANGROUP.FAKE)
        {
            Fake_BackGround.alpha = 1;
            Fake_BackGround.interactable = true;
            Fake_BackGround.blocksRaycasts = true;
            Real_BackGround.alpha = 0;
            Real_BackGround.interactable = false;
            Real_BackGround.blocksRaycasts = false;
        }
    }

    public void ChangeCardCombo(COMBOCARD combonumber)
    {
        switch (combonumber)
        {
            case COMBOCARD.COMBO_1:

                break;
        }
    }
}

public enum COMBOCARD
{
    COMBO_1,
    COMBO_2,
    COMBO_3,
    COMBO_4,
    COMBO_5,
}

public enum CANVANGROUP
{
    REAL,
    FAKE,
}
