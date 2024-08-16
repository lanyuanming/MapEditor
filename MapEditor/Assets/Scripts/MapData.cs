using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class MapData
{
    private const int _mapMaxCount = 400;
    public readonly int MapWitdhMax = 20;


    [Serializable]


    public class MapPos
    {
        public int x;
        public int y;

        public MapPos()
        {
            x = 0;
            y = 0;
        }

        public MapPos (int x ,int y )
        {
            this.x = x;
            this.y = y;

        }
    }

    [Serializable]
    public class MapChip
    {
        public int selectButtonNum;
        public MapPos MapPosition;

        public int MapMove;
        public string MapEventID;
        public int _selectEventIDNum;

        public MapChip()
        {
            selectButtonNum = 0;
            MapPosition = new MapPos();
            _selectEventIDNum = 0;
            MapMove = 0;
            MapEventID = null;

        }
    }

        public MapPos MapSize = new MapPos(20, 20);
    public List<MapChip> Map = new List<MapChip>();

    public MapData()
    {
        foreach (var i in Enumerable.Range(0, _mapMaxCount))
        {
            Map.Add(new MapChip());
        }
    }
}



