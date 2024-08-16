using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipCountView : MonoBehaviour
{
    public int Index { get; private set; } = 0;

    private Action<int> _getIndexAction = null;

    /// <summary>
    /// 示正件場ぶ趙
    /// </summary>
    /// <param name="index">示正件及奶件犯永弁旦</param>
    /// <param name="getIndexAction">示正件毛挹仄凶午五卞網太堤允戊奈伙田永弁</param>
    public void SetIndex(int index, Action<int> getIndexAction)
    {
        _getIndexAction = getIndexAction;
        Index = index;
    }

    /// <summary>
    /// 示正件毛挹仄凶日仇仇互網壬木月
    /// </summary>
    public void OnClickButton()
    {
        if (null != _getIndexAction)
        {
            _getIndexAction.Invoke(Index);

            Debug.Log("Index:"+Index);
        }



    }
}