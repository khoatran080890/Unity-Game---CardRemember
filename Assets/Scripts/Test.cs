using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text txt;
    void Update()
    {
        txt.text = InfoContainer.GAMESTATE.ToString() + Environment.NewLine;
        txt.text += InfoContainer.StraightCheck_Line;
    }
}
