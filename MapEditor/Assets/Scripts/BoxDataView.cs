using UnityEngine;
using UnityEngine.UI;

public class BoxDataView : MonoBehaviour
{
    [SerializeField] private Text _text = null;

    private Button _button = null;

    public Sprite setImg;

    public Sprite noSetImg;




    private int                _index = 0;
    public  int                Index => _index;
    private bool               _isSelect = false;
    public  bool               IsSelect => _isSelect;
    private System.Action<int> _callback = null;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => _callback(_index));
    }

    public void SetIndex(int index, System.Action<int> callback)
    {
        _callback = callback;
        _index    = index;
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

    public void SetColor(bool isSelect)
    {
        _isSelect = isSelect;
        if(isSelect)
            GetComponent<Image>().sprite = setImg;
        else
            GetComponent<Image>().sprite = noSetImg;
    }
}
