using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadlevel : MonoBehaviour
{
    //��ResourcesĿ¼���ض�Ӧѡ��Ĺؿ�
    private void Awake()
    {
        //print(PlayerPrefs.GetString("nowlevel"));
       Instantiate(Resources.Load(PlayerPrefs.GetString("nowlevel")));
    }
}
