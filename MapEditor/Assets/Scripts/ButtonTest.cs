using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    [SerializeField]
    public string needUseString;
    [SerializeField]
    public Button yesButton;
    [SerializeField]
    public Button ClearButton;

    [SerializeField]
    public Text targetText;

    public string Cutedstr = null;

    public void getstr(string str)
    {
        //ÊäÈëµÄÎÄ×Ö
        print(str);
        needUseString = str;


    }

    public void outPutStr()
    {
        ////        //    // is Cut String
       string NeedCutstr = needUseString;

         int start = 1, length = 3;

         Cutedstr = NeedCutstr.Substring(start - 1, length);

        ////        //   // Console.WriteLine(NeedCutstr.Substring(start - 1, length));



        //targetText.text = needUseString;
        targetText.text = Cutedstr;




    }

    public void clearButton()
    {
        targetText.text = null;
    }




}
