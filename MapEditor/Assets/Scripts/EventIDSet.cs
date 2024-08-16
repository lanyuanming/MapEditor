using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
public class EventIDSet : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputEventId;
   
    
   
    
    
    [SerializeField]
    private Button _setButton = null;
    public Button SetButton => _setButton;

    [SerializeField]
    private Button _endsetButton = null;
    public Button EndsetButton => _endsetButton;
    //[SerializeField]
    //private TextMeshProUGUI _IdText = null;

    //private const int _minEventId = 1;
    //private const int _maxEventId = 100;


    public GameObject checkText;
  //  public GameObject inputtext;

    private string _eventIDString = null;

    public string getID = null;


    void Start()
    {
        // text.GetComponent<Text>().text = "Text";

        Debug.Log("checkText is " + checkText);

      //  transform.GetComponent<InputField>().onValueChange.AddListener(Change);
      //  transform.GetComponent<InputField>().onEndEdit.AddListener(End);    




        Debug.Log("checkText is " + checkText);

        Debug.Log("before_inputEventId");
       // _inputEventId.GetComponent<InputField>().text = "InputText";

        Debug.Log("_inputEventId");


        //_eventIDString = inputtext.GetComponent<InputField>().text;

        // getID = _eventIDString;

        _setButton.onClick.AddListener(SetID);

        _endsetButton.onClick.AddListener(SetClear);


       // _eventIDString = inputtext.GetComponent<InputField>().text;

       // getID = _eventIDString;
    }

    void Change(string str)
    {
        Debug.Log("正在输入：" + str);
    }

    void End(string str)
    {
        Debug.Log("输入结果为" + str);
    }



    public void SetID()
    {


        //_eventIDString = _inputEventId.GetComponent<InputField>().text;
        Debug.Log("IDSeter");
         getID = _eventIDString;
    }


    public void SetClear()
    {
        _eventIDString = null;
    }



    //public int EventId
    //{
    //    get
    //    {
    //        if (int.TryParse(_inputEventId.text, out int eventid))
    //        {
    //            eventid = Math.Clamp(eventid, _minEventId, _maxEventId);
    //            return eventid;
    //        }
    //        return _maxEventId;
    //        //cross back max
    //    }
    //}


    //public void Init(MapData.MapChip mapEventID)
    //{
    //    _inputEventId.text = mapEventID.MapEventID.ToString();


    //    _inputEventId.text = $"({mapEventID})";
    //}
}
