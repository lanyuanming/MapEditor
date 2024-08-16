using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDmessageParts : MonoBehaviour
{

    [SerializeField] private Text _text = null;

    private int _index = 0;

    public int Index => _index;

   // [SerializeField]
   // private List<Sprite> _sprites = new List<Sprite>();

  //  private Text _text = null;

    // Start is called before the first frame update
    void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void SetIndex(int index)
    {
        _index = index;
    }
    public void SetText(string text)
    {
        _text.text = text;
        //  _text.text = "CHANGEOK";

    }

    public string GetText()
    {
        return _text.text;
    }

//    public void OnClickButton(string EventIdMessage)
//    {




//        //if (null != _sprites && _sprites.ToString > EventIdMessage)
//        //    _text.text = _sprites[EventIdMessage];
//        // Debug.Log();
//    }
}
