using System;
using UnityEngine;

public class CustomView : MonoBehaviour
{
    public int Index { get; private set; } = 0;

    private Action<int> _getIndexAction = null;

    /// <summary>
    /// ボタン初期化
    /// </summary>
    /// <param name="index">ボタンのインデックス</param>
    /// <param name="getIndexAction">ボタンを押したときに呼び出すコールバック</param>
    public void SetIndex(int index, Action<int> getIndexAction)
    {
        _getIndexAction = getIndexAction;
        Index           = index;
    }

    /// <summary>
    /// ボタンを押したらここが呼ばれる
    /// </summary>
    public void OnClickButton()
    {
        if(null != _getIndexAction)
            _getIndexAction.Invoke(Index);
    }
}
