using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyTrail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Ĭ��û����βЧ��
        myTrail.SetTime(0.0f, 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public WeaponTrail myTrail;

    private float t = 0.033f;
    private float tempT = 0;
    private float animationIncrement = 0.003f;

    public void heroAttack()
    {
        //������βʱ��
        myTrail.SetTime(2.0f, 0.0f, 1.0f);
        //��ʼ������β
        myTrail.StartTrail(0.5f, 0.4f);
    }

    public void heroIdle()
    {
        //�����β
        myTrail.ClearTrail();
    }
    void LateUpdate()
    {
        t = Mathf.Clamp(Time.deltaTime, 0, 0.066f);

        if (t > 0)
        {
            while (tempT < t)
            {
                tempT += animationIncrement;

                if (myTrail.time > 0)
                {
                    myTrail.Itterate(Time.time - t + tempT);
                }
                else
                {
                    myTrail.ClearTrail();
                }
            }

            tempT -= t;

            if (myTrail.time > 0)
            {
                myTrail.UpdateTrail(Time.time, t);
            }
        }
    }

}
