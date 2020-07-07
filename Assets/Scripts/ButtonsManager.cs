using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum OPTION
{
    Straight,
    Single,
}
public class ButtonsManager : MonoBehaviour
{

    public GameObject Button_STRAIGHT;
    public GameObject Button_CLEAR;

    public void Button_Click_STRAIGHT()
    {
        switch (InfoContainer.GAMESTATE)
        {
            case OPTION.Single:
                InfoContainer.GAMESTATE = OPTION.Straight;
                Button_STRAIGHT.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                break;
            case OPTION.Straight:
                InfoContainer.GAMESTATE = OPTION.Single;
                Button_STRAIGHT.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
        }
    }
    public void Buttonn_Click_CLEAR()
    {
        SceneManager.LoadScene("Main");
    }
}
