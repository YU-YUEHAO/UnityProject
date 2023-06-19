using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBird : birds
{
    public override void birdskill()
    {
        base.birdskill();
        render.sprite = sprites[0];
        Vector2 speed = rd.velocity;
        speed.x *= -1;
        rd.velocity = speed;
    }
}
