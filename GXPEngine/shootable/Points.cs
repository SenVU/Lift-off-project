﻿using GXPEngine;

public class Points : EasyDraw
{
    int points;

    float textTimer = 1;
    public Points(float startX, float startY, int width, int height, int points) : base(width, height, false)
    {
       this.points = points;
        x = startX;
        y = startY;
    }
    public void Update()
    {
        float DeltaTimeS = Time.deltaTime / 1000f;

        textTimer -= DeltaTimeS;
        alpha = Mathf.Max(0f, alpha - DeltaTimeS);

        this.TextAlign(CenterMode.Center, CenterMode.Center);
        //this.TextFont();
        this.Text(" " + points, width / 2, height / 2);

        //move the text up
        y--; // TODO make this Deltatime based

        // destroy text once timer is up
        if (textTimer <= 0)
        {
            this.LateDestroy();
        }
    }
}
