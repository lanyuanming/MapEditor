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
    /// �ܥ�����ڻ�
    /// </summary>
    /// <param name="index">�ܥ���Υ���ǥå���</param>
    /// <param name="getIndexAction">�ܥ����Ѻ�����Ȥ��˺��ӳ������`��Хå�</param>
    public void SetIndex(int index, Action<int> getIndexAction)
    {
        _getIndexAction = getIndexAction;
        Index = index;
    }

    /// <summary>
    /// �ܥ����Ѻ�����餳�������Ф��
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