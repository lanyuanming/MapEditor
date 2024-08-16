using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]

public class CardMasterData :ScriptableObject
{
    [Serializable]

    public class CardMaster
    {

    //里面放需要读取的数据
    public int crd_id;
    public string crd_pct_id;
    public string crd_name;
    public int item_type;
    public int item_stars;
    public int item_target;
    public int crd_cost;
    public int chr_caption_tex;
    public int chr_edition;
    public int chr_price;


    public int crd_type;
    public int clc_stars;
    public int clc_target;


    public int level;
    public int chr_exp;
        
    }

    public List<CardMaster> card_masters = new List<CardMaster>();


}
