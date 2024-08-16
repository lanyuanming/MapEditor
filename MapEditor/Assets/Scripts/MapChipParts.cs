using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapChipParts : MonoBehaviour
{
    private int _index = 0;

    public int Index => _index;

    [SerializeField]
    private List<Sprite> _sprites = new List<Sprite>();

    private Image _image = null;
    
    // Start is called before the first frame update
    void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void SetIndex(int index)
    {
        _index = index;
    }

    public void OnClickButton(int buttonNum)
    {
        if (null != _sprites && _sprites.Count > buttonNum)
            _image.sprite = _sprites[buttonNum];
       // Debug.Log();
    }
}
