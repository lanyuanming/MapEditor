using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using static MapData;

public class MapManager : MonoBehaviour
{
    string Cutstr = null;

    string NeedCutstr = null;


    public int CurrentEventNum=0;
    //MapUI

    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private GameObject _lineprefab;
    [SerializeField]
    private Transform _parent;
    [SerializeField]
    private Transform _parent1;
    //[SerializeField]
    //private GameObject _idprefab;
    //[SerializeField]
    //private GameObject _idlineprefab;
    //[SerializeField]
    //  private Transform _idparent;
    //[SerializeField]
    //private Transform _idlineparent;

    //UI相关
    [SerializeField]
    private GameObject EventSetChange;
    [SerializeField]
    private GameObject EventSetUI;
    [SerializeField]
    private GameObject IDNumPrefeb;
    //[SerializeField]
    //private GameObject EventSetChangeUI;

    [SerializeField]
    private GameObject MapChipMoveUI;

    [SerializeField]
    private GameObject MapChipMovePrefeb;
    [SerializeField]
    private Transform MapChipMoveArea;
    [SerializeField]
    private GameObject MapChipMoveAreaUI;


    //ID Messages
    //[SerializeField]
    //private Text _IDtext = null;

    //[SerializeField]
    //private GameObject _IDprefab = null;

    //[SerializeField]
    //private Transform _IDparentContent = null;

    //private List<ChipCountView> _buttonLists = new List<ChipCountView>();

  //  private int _selectIndex = -1;

    private readonly int _buttonSize = 100;


    //TestInput

    //IDprefrefab
     [SerializeField] private GameObject _itemPrefab = null;


    [SerializeField] private Transform _textParent = null;
    [SerializeField] private InputField _inputField = null;
    [SerializeField] private Button _button = null;
    [SerializeField] private Button _getButton = null;
    [SerializeField] private Text _text = null;
    [SerializeField] private Text _text2 = null;

    private List<BoxDataView> _boxDataViews = new List<BoxDataView>();
    private int _index = 0;
    private string _selectText = "";





    //testTest
    [SerializeField]
    public Text IdText;

    public ButtonTest buttonTest;


    [SerializeField]
    private List<Button> _buttons = new List<Button>();
    [SerializeField]
    private SizeChangeView _sizeChangeView = null;

    [SerializeField]
    private EventIDSet _eventIDSet = null;


    [SerializeField]
    private RectTransform _mapAreaRectTransform = null;
   // [SerializeField]
    //private List<Button> _IDbuttons = new List<Button>();


    [SerializeField]
    private Button IdsetButton = null;
    [SerializeField]
    private Button IdsetButton1 = null;
    [SerializeField]
    private Button CloseIdMessageButton = null;
    [SerializeField]
    private Button CloseIdMessageButton1 = null;
   // [SerializeField]
   // private Button CloseIdMessageButton2 = null;
    [SerializeField]
    private Button MapChipMove = null;


    public MapData DungeonMapData { get; set; } = null;
    private List<GameObject> _mapDatas = new List<GameObject>();
    private List<GameObject> _mapOutlineDatas = new List<GameObject>();

    [SerializeField]
    private List<Button> _chipmovebuttons = new List<Button>();
    private List<GameObject> _mapChipMoveDatas = new List<GameObject>();
    //private List<GameObject> _mapIdDatas = new List<GameObject>();
    // private List<GameObject> _mapIdlineDatas = new List<GameObject>();

    //private List<SetEventIDnum> _chipCountViews = new List<SetEventIDnum>();
    //
    private int _selectButtonNum = 0;
    // private int _selectEventIDNum = 0;




    //[SerializeField]
    //private GameObject IDprefab = null;

    //[SerializeField]
    //private Transform IDparent = null;


    //private List<ChipCountView> _chipCountViews = new List<ChipCountView>();




    //
    //  マップ幅
    public int _mapWidth = 20;
    //  マップ高さ
    public int _mapHeight = 20;

    public string _eventId = null;

    private const float _mapChipDistance = 100;
    private const float _mapStartPosX = -1000 + 50;
    private const float _mapStartPosY = 1000 - 50;
    private bool _isResetMapData = true;

    // Start is called before the first frame update
    void Start()
    {
        DungeonMapData = new MapData(); 
        _mapWidth = _sizeChangeView.MapWidth;
        _mapHeight = _sizeChangeView.MapHeight;

        _sizeChangeView.Init(new MapData.MapPos(_mapWidth, _mapHeight));



        DrawMap();
        DrawIdMessage();



        foreach (var button in _buttons.Select((btn, index) => new { btn, index }))
        {
            button.btn.onClick.AddListener(() => _selectButtonNum = button.index);
        }

        //foreach (var button in _IDbuttons.Select((btn, index) => new { btn, index }))
        //{
        //    button.btn.onClick.AddListener(() => _selectEventIDNum = button.index);
        //}

        _sizeChangeView.OkButton.onClick.AddListener(CleanAndChangeMapSize);

        //
        // _eventIDSet.SetButton.onClick.AddListener(ChangeIdNum);

        MapChipMove.onClick.AddListener(MapChipMoveUICheck);
        //MapChipMove.onClick.AddListener(DrawMapChipMove);

        
      //  IdsetButton.onClick.AddListener(RedrawIdMessage);
         IdsetButton1.onClick.AddListener(ShowIdMessage);
        CloseIdMessageButton.onClick.AddListener(CloseIdMessage);
        CloseIdMessageButton1.onClick.AddListener(CloseIdMessage);
        //CloseIdMessageButton2.onClick.AddListener(CloseIdMessage);


    }

    public void DrawMap()
    {
        DungeonMapData.MapSize.x = _mapWidth;
        DungeonMapData.MapSize.y = _mapHeight;
        foreach (var y in Enumerable.Range(0, _mapHeight))
        {
            foreach (var x in Enumerable.Range(0, _mapWidth))
            {
                var obj = Instantiate(_prefab, _parent);
                var obj1 = Instantiate(_lineprefab, _parent1);
                obj.SetActive(true);
                obj1.SetActive(true);
                var position = new Vector3(_mapStartPosX + x * _mapChipDistance, _mapStartPosY - y * _mapChipDistance, 0);
                obj.GetComponent<RectTransform>().localPosition = position;
                obj1.GetComponent<RectTransform>().localPosition = position;

                Debug.Log("MapUI potion is " + position);

                var index = y * _mapWidth + x;
                DungeonMapData.Map[index].MapPosition = new MapData.MapPos(x, y);

                var mapChipPars = obj.GetComponent<MapChipParts>();
               
                
                mapChipPars.SetIndex(index);
                mapChipPars.OnClickButton(_isResetMapData ? 0 : DungeonMapData.Map[index].selectButtonNum);
                obj.GetComponent<Button>()
                   .onClick.AddListener(() =>
                                        {
                                            mapChipPars.OnClickButton(_selectButtonNum);
                                            DungeonMapData.Map[index].selectButtonNum = _selectButtonNum;
                                        });

                _mapDatas.Add(obj);
                _mapOutlineDatas.Add(obj1);
            }
        }

        if (!_isResetMapData) _isResetMapData = true;
    }
    public void CleanAndChangeMapSize()
    {
        CleanupWork();
        ChangeMapSize();
    }
    private void ChangeMapSize()
    {
        // CleanupWork();
        _mapWidth = _sizeChangeView.MapWidth;
        _mapHeight = _sizeChangeView.MapHeight;
        _sizeChangeView.Init(new MapData.MapPos(_mapWidth, _mapHeight));
        
        
        //wen ti dian ??

        _mapAreaRectTransform.sizeDelta = new Vector2(_mapWidth * 100, _mapHeight * 100);
       
        
        
        DrawMap();
        DrawIdMessage();
    }

    public void ChangeIdNum()
    {
        CleanupIDMessage();


        _mapWidth = _sizeChangeView.MapWidth;
        _mapHeight = _sizeChangeView.MapHeight;
        _sizeChangeView.Init(new MapData.MapPos(_mapWidth, _mapHeight));

       //  _mapAreaRectTransform.sizeDelta = new Vector2(_mapWidth * 100, _mapHeight * 100);
        //DrawMap();
        //is Save IDNum but can choose Number Index


        // _chipCountViews[index] = MapData.MapPos(x, y);
        //mapChip.MapEventID = _eventId;



        DrawIdMessage();
    }

    public void RedrawMap()
    {
        CleanupWork();
        _sizeChangeView.Init(DungeonMapData.MapSize);
        _isResetMapData = false;
        ChangeMapSize();
    }

    public void RedrawEventMessage()
    {
        CleanupWork();
        _sizeChangeView.Init(DungeonMapData.MapSize);
        _isResetMapData = false;
        ChangeIdNum();

    }

    private void CleanupWork()
    {
        _mapDatas.ForEach(map => map.GetComponent<Button>().onClick.RemoveAllListeners());
        _mapDatas.ForEach(Destroy);
        _mapOutlineDatas.ForEach(Destroy);
        _mapDatas.Clear();
        _mapOutlineDatas.Clear();
    }

    public void OnDestroy()
    {
        _buttons.ForEach(button => button.onClick.RemoveAllListeners());
        _mapDatas.ForEach(Destroy);
        _sizeChangeView.OkButton.onClick.RemoveListener(CleanAndChangeMapSize);
    }


    public void ShowIdMessage()
    {
        if (EventSetUI.activeSelf == false)
        {
            EventSetUI.SetActive(true);
        }
        else if (EventSetUI.activeSelf == true)
        {
            EventSetUI.SetActive(false);
        }
        //EventSetChange.SetActive(false);
        //if (EventSetChange.activeSelf == false)
        //{
        //    EventSetChange.SetActive(true);
        //}
        //else if (EventSetChange.activeSelf == true)
        //{
        //    EventSetChange.SetActive(false);
        //}


        if (IDNumPrefeb.activeSelf == false)
        {
            IDNumPrefeb.SetActive(true);
          //  DrawMapChipMove();
        }
        else if (IDNumPrefeb.activeSelf == true)
        {
            IDNumPrefeb.SetActive(false);
           // CleanupMoveDateWork();
        }

    }
    public void DrawIdMessage()// Show ID message
    {

        DungeonMapData.MapSize.x = _mapWidth;
        DungeonMapData.MapSize.y = _mapHeight;
       // _eventId = MapData.MapChip;

              //  Debug.Log("IDNumPrefeb.activeSelf:" + IDNumPrefeb.activeSelf);


        MakeButtons();




    }
    //public void outPutStr()
    //{
    //    ////        //    // is Cut String
    //    string NeedCutstr = needUseString;

    //    int start = 1, length = 3;

    //    string Cutedstr = NeedCutstr.Substring(start - 1, length);

    //    ////        //   // Console.WriteLine(NeedCutstr.Substring(start - 1, length));



    //    //targetText.text = needUseString;
    //    targetText.text = Cutedstr;




    //}

    //初始化IDevent界面

    private void MakeButtons()
    {
        var startXOff = -_mapWidth * _buttonSize / 2+50;
        var startYOff = _mapHeight * _buttonSize / 2-50;


        //selectTextChange


        //  Cutstr = _inputField.text;

        //int textLength = Cutstr.Length;


        // Debug.Log("textLength:" + textLength);

        // //  Label1.Text = aaa.Length.ToString();  //结果5
        // if (textLength >= 3)
        // { 

        // int start = 1, length = 3;


        //     NeedCutstr = Cutstr.Substring(start - 1, length);


        //     _button.onClick.AddListener(() => _boxDataViews[_index].SetText(_selectText = NeedCutstr));

        //     Debug.Log("NeedCutstr:" + NeedCutstr);

        // }
        // else
        // {

        //      _button.onClick.AddListener(() => _boxDataViews[_index].SetText(_selectText = Cutstr));

        //     Debug.Log("Cutstr:" + Cutstr);
        // }

        //_inputField.text = "wewqw";
        
        
        //使显示框的文字等于输入框的文字
        _button.onClick.AddListener(() => _boxDataViews[_index].SetText(_selectText = _inputField.text.Substring(0, (_inputField.text.Length < 3) ? _inputField.text.Length:3)));
       //输入文字数据导入到json文件
        _button.onClick.AddListener(() => DungeonMapData.Map[_index].MapEventID = _inputField.text );

        _button.onClick.AddListener(() => Debug.Log("_inputField.text:"+ _inputField.text));
        _button.onClick.AddListener(() => Debug.Log("DungeonMapData.Map[_index].MapEventID" + DungeonMapData.Map[_index].MapEventID));


        //  _inputField.text = 输入的文字(需要保保存的文字)
        //_selectText = 选择位置的文字

        //暂时无关
        _getButton.onClick.AddListener(() => _text.text = _selectText);
        _getButton.onClick.AddListener(() => Debug.Log("_selectText:"+ _selectText));


        _getButton.onClick.AddListener(() => _text2.text = _boxDataViews[_index].GetText());
        _getButton.onClick.AddListener(() => Debug.Log("_boxDataViews[_index].GetText():" + _boxDataViews[_index].GetText()));


        foreach (var y in Enumerable.Range(0, _mapWidth))
        {
            foreach (var x in Enumerable.Range(0, _mapHeight))
            {
                // var gObj = Instantiate(_itemPrefab, _textParent);
                var gObj = Instantiate(_itemPrefab, _textParent);
                
                var position = new Vector3(_mapStartPosX + x * _mapChipDistance, _mapStartPosY - y * _mapChipDistance, 0);
                Debug.Log("IDUI potion is "+position);
                var rect = gObj.GetComponent<RectTransform>();
                rect.localPosition = position;



                CurrentEventNum++;
                Debug.Log(" CurrentEventNum+"+CurrentEventNum);
                var box = gObj.GetComponent<BoxDataView>();
                int index = y * _mapWidth + x;


                box.SetText(_isResetMapData ? string.Empty : DungeonMapData.Map[_index].MapEventID.ToString());
                box.SetIndex(index, SelectImage);


                DungeonMapData.Map[index].MapPosition = new MapData.MapPos(x, y);

               // var position = new Vector3(_mapStartPosX + x * _mapChipDistance, _mapStartPosY - y * _mapChipDistance, 0);
               // obj.GetComponent<RectTransform>().localPosition = position;
              
                //DungeonMapData.Map[index].selectButtonNum = 0;
                //DungeonMapData.Map[index]._selectEventIDNum = 0;
                //DungeonMapData.Map[index].MapMove = 0;

                //在这里初始化
                DungeonMapData.Map[index].MapEventID =null;


                //index 的值变成了-1,不行
                Debug.Log("DungeonMapData.Map[_index].MapEventID:" + DungeonMapData.Map[_index].MapEventID);
                //在;里面遍历了.不行
                DungeonMapData.Map[index].MapEventID = DungeonMapData.Map[_index].MapEventID;

                //DungeonMapData.Map[index].MapEventID = _inputField.text; 
                //DungeonMapData.Map[index].selectButtonNum = _selectButtonNum;
                //indexchange
                //
                //box.SetText(index.ToString());
                if (DungeonMapData.Map[_index].MapEventID != null)
                {

                    box.SetText(DungeonMapData.Map[_index].MapEventID.Substring(0, (DungeonMapData.Map[_index].MapEventID.Length < 3) ? DungeonMapData.Map[_index].MapEventID.Length : 3));
                    Debug.Log("DungeonMapData.Map[_index].MapEventID1:" + DungeonMapData.Map[_index].MapEventID);
                }
                else
                {

                    box.SetText(" ");
                    Debug.Log("DungeonMapData.Map[_index].MapEventID2:" + DungeonMapData.Map[_index].MapEventID);
                }
                //

                _boxDataViews.Add(box);
                box.transform.localPosition = new Vector3(startXOff + x * _buttonSize, startYOff - y * _buttonSize, 0);

                //存進去了.但是讀出來的時候應該怎麽樣吧對應方塊顯示對應的ID呢?

            }
        }



        /*


                foreach (var y in Enumerable.Range(0, _mapWidth))
                {
                    foreach (var x in Enumerable.Range(0, _mapWidth))
                    {


                        var gobj = Instantiate(_IDprefab, _IDparentContent);
                        gobj.transform.localPosition = new Vector3(startXOff + x * _buttonSize, startYOff - y * _buttonSize, 0);


                        var index = y * _mapWidth + x;


                        // _eventId = DungeonMapData.Map[index];

                        DungeonMapData.Map[index].MapPosition = new MapData.MapPos(x, y);
                        var mapChip = new MapData.MapChip();
                        DungeonMapData.Map[index].MapPosition = new MapData.MapPos(x, y);

                       //// mapChip.MapPosition = new MapData.MapPos(x, y);
                        mapChip.MapPosition = DungeonMapData.Map[index].MapPosition;

                        mapChip.selectButtonNum = 0;
                        mapChip._selectEventIDNum = 0;
                        mapChip.MapMove = 0;
                        mapChip.MapEventID = null;

                        IdText.text = mapChip.MapEventID;

                      //  _eventId = _eventIDSet.getID;



                      //  mapChip.MapEventID = _eventId;


                      //  _eventIDSet.getID = 

                        var customView = gobj.GetComponent<ChipCountView>();
                        customView.SetIndex(y * _mapWidth + x, GetSelectIndex);


                        Debug.Log(" index:"+index+" x:"+x+" y:"+y + "MapEventID:"+ mapChip.MapEventID);
                        //!!! bug aru!
                        //CutIDString();


                       // gobj.GetComponent<Button>()
                       //.onClick.AddListener(() =>
                       //{
                       //    _setButton.onClick.AddListener(SetID);
                       //    _eventIDSet.OnClickButton(_selectButtonNum);
                       //    DungeonMapData.Map[index].selectButtonNum = _selectButtonNum;
                       //});
                        _buttonLists.Add(customView);
                    }
                }
                */


    }


    private void SelectImage(int index)
    {
        if (-1 < _index)
            _boxDataViews[_index].SetColor(false);
        _boxDataViews[index].SetColor(true);
        _index = index;
    }


    //public void setButtonIn()
    //{

    //    DungeonMapData.Map[_selectIndex].MapEventID = buttonTest.needUseString;

    //    RedrawIdMessage();
    //}


    /// <summary>
    /// ボタンを押したらこれを呼び出す
    /// </summary>
    /// <param name="index">押したボタンのインデックス</param>
    //private void GetSelectIndex(int index)
    //{
    //    _index = index;

    //    IdText.text = buttonTest.Cutedstr;
       
    //    //??
    //    DungeonMapData.Map[_index].MapEventID = buttonTest.needUseString;







    //    // _IDtext.text = $"Select Index = {_selectIndex}";
    //    // index is NUM



    //    // CutIDString();

    //    //       // _eventId = DungeonMapData.Map[index];

    //    //        var mapChip = new MapData.MapChip();
    //    //        //DungeonMapData.Map[index].MapPosition = new MapData.MapPos(x, y);


    //    //        mapChip.MapPosition = new MapData.MapPos(x,y);
    //    //        mapChip.selectButtonNum = 0;
    //    //        mapChip._selectEventIDNum = 0;
    //    //        mapChip.MapMove = 0;


    //    //   if (IdsetButton.onClick.AddListener(RedrawIdMessage))

    //}

    //public void CutIDString()
    //{


    //    _eventId = _eventIDSet.getID;


    //    // is Cut String
    //    string NeedCutstr = _eventId;

    //    int start = 1, length = 3;

    //    string Cutedstr = NeedCutstr.Substring(start - 1, length);

    //    // Console.WriteLine(NeedCutstr.Substring(start - 1, length));

    //    _IDtext.text = Cutedstr;

    //}


    public void RedrawIdMessage()
    {
        if(CurrentEventNum>0)
        {
            return;
        }
        //不應該在這裏讀取json内的Event文件 应该在初始化的同时读取所有的Data数据并实装,button切换显示
        //CleanupWork();
       // CheckUIActive();

        CleanupIDMessage();

        DrawIdMessage();
        //_sizeChangeView.Init(DungeonMapData.MapSize);
        //_isResetMapData = false;
        //ChangeMapSize();
    }



    private void CleanupIDMessage()
    {

        //for (int a=0; a < IDNumPrefeb.transform.childCount; a++)
        //{
        //    Destroy(this.transform.GetChild(a).gameObject);
        //}

        //IDNumPrefeb(Destroy);
        // _chipCountViews.ForEach(map => map.GetComponent<Button>().onClick.RemoveAllListeners());
        //


        //_chipCountViews.ForEach(Destroy);

        _boxDataViews.ForEach(mapIdNum =>Destroy(mapIdNum.gameObject));
        _boxDataViews.ForEach(Destroy);
        Debug.Log("_chipCountViews is Destroyed");

        _boxDataViews.Clear();
        //_mapDatas.ForEach(map => map.GetComponent<Button>().onClick.RemoveAllListeners());
        //_mapDatas.ForEach(Destroy);
        //_mapOutlineDatas.ForEach(Destroy);
        //_mapDatas.Clear();
        //_mapOutlineDatas.Clear();
    }

    public void DrawMapChipMove()
    {

        foreach (var button in _chipmovebuttons.Select((btn, index) => new { btn, index }))
        {
            button.btn.onClick.AddListener(() => _selectButtonNum = button.index);
        }


        DungeonMapData.MapSize.x = _mapWidth;
        DungeonMapData.MapSize.y = _mapHeight;
        foreach (var y in Enumerable.Range(0, _mapHeight))
        {
            foreach (var x in Enumerable.Range(0, _mapWidth))
            {
                var obj = Instantiate(MapChipMovePrefeb, MapChipMoveArea);
               // var obj1 = Instantiate(_lineprefab, _parent1);
                obj.SetActive(true);
               // obj1.SetActive(true);
                var position = new Vector3(_mapStartPosX + x * _mapChipDistance, _mapStartPosY - y * _mapChipDistance, 0);
                obj.GetComponent<RectTransform>().localPosition = position;
               // obj1.GetComponent<RectTransform>().localPosition = position;

                var index = y * _mapWidth + x;
                DungeonMapData.Map[index].MapPosition = new MapData.MapPos(x, y);

                var mapChipPars = obj.GetComponent<MapChipParts>();


                mapChipPars.SetIndex(index);
                mapChipPars.OnClickButton(_isResetMapData ? 0 : DungeonMapData.Map[index].MapMove);
                obj.GetComponent<Button>()
                   .onClick.AddListener(() =>
                   {
                       mapChipPars.OnClickButton(_selectButtonNum);
                       DungeonMapData.Map[index].MapMove = _selectButtonNum;
                   });

                _mapChipMoveDatas.Add(obj);
                //_mapOutlineDatas.Add(obj1);
            }
        }

        if (!_isResetMapData) _isResetMapData = true;
    }


    private void CleanupMoveDateWork()
    {
        _mapChipMoveDatas.ForEach(map => map.GetComponent<Button>().onClick.RemoveAllListeners());
        _mapChipMoveDatas.ForEach(Destroy);

        _mapChipMoveDatas.Clear();
      
    }
    public void MapChipMoveUICheck()
    {
        if (MapChipMoveUI.activeSelf == false)
        {
            MapChipMoveUI.SetActive(true);
        }
        else if(MapChipMoveUI.activeSelf == true)
        {
            MapChipMoveUI.SetActive(false);
        }


        if (MapChipMoveAreaUI.activeSelf == false)
        {
            MapChipMoveAreaUI.SetActive(true);
            DrawMapChipMove();
        }
        else if (MapChipMoveAreaUI.activeSelf == true)
        {
            MapChipMoveAreaUI.SetActive(false);
            CleanupMoveDateWork();
        }

    }


    public void CheckUIActive()
    {
        if (IDNumPrefeb.activeSelf == false)
        //gameObject.activeSelf是判定当前物体的SetActive状态
        {

            IDNumPrefeb.SetActive(true);
            EventSetUI.SetActive(true);
        }
        else if (IDNumPrefeb.activeSelf == true)
        {
            EventSetChange.SetActive(false);
            EventSetUI.SetActive(false);

            IDNumPrefeb.SetActive(false);
        }


    }

    public void CloseIdMessage()// Close ID message
    {

        CheckUIActive();

        //IDNumPrefeb.SetActive(false);

        //if (EventSetUI.activeSelf == false)
        //{
        //    EventSetUI.SetActive(true);
        //}
        //else if (EventSetUI.activeSelf == true)
        //{
        //    EventSetUI.SetActive(false);
        //}

        // EventSetChange.SetActive(false);
        // EventSetUI.SetActive(false);
        //  CleanupIDMessage();
        //IDparent.Clear();
        //  _chipCountViews.ForEach(Destroy);
        //_mapIdDatas.Clear();
        // _mapIdlineDatas.Clear();
    }


}


/*
[SerializeField]
private Text _text = null;

[SerializeField]
private GameObject _prefab = null;

[SerializeField]
private Transform _parentContent = null;

private List<CustomView> _buttonLists = new List<CustomView>();

private int _selectIndex = -1;

private readonly int _maxX = 10;
private readonly int _maxY = 10;
private readonly int _buttonSize = 64;

// Start is called before the first frame update
void Start()
{
    MakeButtons();
}

/// <summary>
/// ボタン配置
/// </summary>
private void MakeButtons()
{
    var startXOff = -_maxX * _buttonSize / 2;
    var startYOff = _maxY * _buttonSize / 2;
    foreach (var y in Enumerable.Range(0, _maxX))
    {
        foreach (var x in Enumerable.Range(0, _maxY))
        {
            var gobj = Instantiate(_prefab, _parentContent);
            gobj.transform.localPosition = new Vector3(startXOff + x * _buttonSize, startYOff - y * _buttonSize, 0);
            var customView = gobj.GetComponent<CustomView>();
            customView.SetIndex(y * _maxX + x, GetSelectIndex);
            _buttonLists.Add(customView);
        }
    }
}

/// <summary>
/// ボタンを押したらこれを呼び出す
/// </summary>
/// <param name="index">押したボタンのインデックス</param>
private void GetSelectIndex(int index)
{
    _selectIndex = index;
    _text.text = $"Select Index = {_selectIndex}";
}
*/