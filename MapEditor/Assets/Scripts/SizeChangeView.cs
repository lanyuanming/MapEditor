using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SizeChangeView : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputFieldWidth = null;
    [SerializeField]
    private TMP_InputField _inputFieldHeight = null;
    [SerializeField]
    private Button _okButton = null;
    public Button OkButton  => _okButton;
    [SerializeField]
    private TextMeshProUGUI _sizeText = null;

    private const int _minMapSize = 1;
    private const int _maxMapSize = 20;

    public int MapWidth
    {
        get
        {
            if(int.TryParse(_inputFieldWidth.text, out int width))
            {
                width = Math.Clamp(width, _minMapSize, _maxMapSize);
                return width;
            }
            return _maxMapSize;
        }
    }

    public int MapHeight
    {
        get
        {
            if(int.TryParse(_inputFieldWidth.text, out int height))
            {
                height = Math.Clamp(height, _minMapSize, _maxMapSize);
                return height;
            }
            return _maxMapSize;
        }
    }

    public void Init(MapData.MapPos mapSize)
    {

        _inputFieldWidth.text  = mapSize.x.ToString();
        _inputFieldHeight.text = mapSize.y.ToString();
        _sizeText.text         = $"MapSIze({mapSize.x},{mapSize.y})";
    }

}
