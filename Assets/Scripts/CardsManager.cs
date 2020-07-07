using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour
{
    public bool Single_Check;
    public bool Straight_Check_1;

    public GameObject Button_STRAIGHT;


    private void Start()
    {
        Single_Check = false;
        Straight_Check_1 = false;

        InfoContainer.StraichtCheck_1 = false;
        InfoContainer.StraichtCheck_2 = false;
    }
    public void Button_Click_Card()
    {
        switch (InfoContainer.GAMESTATE)
        {
            case OPTION.Single:
                if (!Single_Check)
                {
                    gameObject.GetComponent<Image>().color = InfoContainer.colorFOLD;
                    Single_Check = true;
                }
                else
                {
                    gameObject.GetComponent<Image>().color = InfoContainer.colorUP;
                    Single_Check = false;
                }
                break;
            case OPTION.Straight:
                if (!Straight_Check_1 && !InfoContainer.StraichtCheck_1)
                {
                    Straight_Check_1 = true;
                    InfoContainer.StraichtCheck_1 = true;
                    gameObject.GetComponent<Image>().color = InfoContainer.colorFOLD;
                    Single_Check = true;
                    InfoContainer.StraightCheck_Line = transform.parent.name.Substring(transform.parent.name.Length - 1, 1) + "-" + transform.GetSiblingIndex();
                }
                else if (InfoContainer.StraichtCheck_1 && transform.parent.name.Substring(transform.parent.name.Length - 1, 1) == InfoContainer.StraightCheck_Line.Substring(0, 1))
                {
                    InfoContainer.StraightCheck_Line_Index = transform.parent.name.Substring(transform.parent.name.Length - 1, 1) + "-" + transform.GetSiblingIndex();

                    bool isFirstPickedCard = Straight_Check_1;
                    int line = int.Parse(InfoContainer.StraightCheck_Line.Substring(0, 1));
                    int firstNum = int.Parse(InfoContainer.StraightCheck_Line.Substring(2, InfoContainer.StraightCheck_Line.Length - 2));
                    int lastNum = int.Parse(InfoContainer.StraightCheck_Line_Index.Substring(2, InfoContainer.StraightCheck_Line_Index.Length - 2));

                    if (lastNum != firstNum)
                    {
                        GameObject lineObj = GameObject.Find("Line " + line);
                        for (int i = 0; i < lineObj.transform.childCount; i++)
                        {
                            int indexofchildcard = lineObj.transform.GetChild(i).GetSiblingIndex();
                            if (indexofchildcard >= firstNum && indexofchildcard <= lastNum)
                            {
                                lineObj.transform.GetChild(i).GetComponent<Image>().color = InfoContainer.colorFOLD;
                                lineObj.transform.GetChild(i).GetComponent<CardsManager>().Single_Check = true;
                                lineObj.transform.GetChild(i).GetComponent<CardsManager>().Straight_Check_1 = false;
                            }
                        }
                        InfoContainer.GAMESTATE = OPTION.Single;
                        InfoContainer.StraichtCheck_1 = false;
                        Button_STRAIGHT.GetComponent<Image>().color = InfoContainer.colorUP;
                    }
                    else if (lastNum == firstNum)
                    {
                        InfoContainer.GAMESTATE = OPTION.Single;
                        Straight_Check_1 = false;
                        InfoContainer.StraichtCheck_1 = false;
                        Button_STRAIGHT.GetComponent<Image>().color = InfoContainer.colorUP;

                        GameObject lineObj = GameObject.Find("Line " + line);
                        lineObj.transform.GetChild(lastNum).GetComponent<Image>().color = InfoContainer.colorUP;
                        lineObj.transform.GetChild(lastNum).GetComponent<CardsManager>().Straight_Check_1 = false;
                    }

                }
                else
                {

                }
                break;
        }
    }

    
}


