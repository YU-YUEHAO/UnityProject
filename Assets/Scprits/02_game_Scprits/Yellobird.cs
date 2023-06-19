using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellobird : birds
{
    public override void birdskill()
    {
        base.birdskill();
        //System.Console.WriteLine(sprites.Length);
        render.sprite = sprites[0];
        rd.velocity *= 2;
    }
}
