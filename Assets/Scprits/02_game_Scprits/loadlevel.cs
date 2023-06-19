using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadlevel : MonoBehaviour
{
    //从Resources目录加载对应选择的关卡
    private void Awake()
    {
        //print(PlayerPrefs.GetString("nowlevel"));
       Instantiate(Resources.Load(PlayerPrefs.GetString("nowlevel")));
    }
}
