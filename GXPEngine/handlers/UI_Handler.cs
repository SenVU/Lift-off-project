﻿using System.Drawing;
using GXPEngine;
using TiledMapParser;
public class UI_Handler : GameObject
{
    Text textFont = new Text();
    EasyDraw textDrawer;
    EasyDraw playerHealthBarDrawer;
    Sprite grenadesImage;

    bool gameStarted = true;

    public float playerBaseHealth;
    public float playerCurrentHealth;

    private int healthBarHeight = 50;
    public int grenades = 0;
    public int playerScore;
    private int multiplier = 1;


    public UI_Handler()
    {
        this.playerBaseHealth = 100;
        this.playerCurrentHealth = this.playerBaseHealth;

        this.grenadesImage = new Sprite("assets/debug/checkers.png");
        grenadesImage.SetXY(1200, 700);
        AddChild(grenadesImage);

        // TODO: figure out width and height later
        textDrawer = new EasyDraw(1366, 768, false);
        textDrawer.alpha = 1.0f;
        AddChild(textDrawer);

        this.playerHealthBarDrawer = new EasyDraw((int)playerCurrentHealth * 5, healthBarHeight);
        AddChild(playerHealthBarDrawer);
    }

    public void Update()
    {
        if (gameStarted)
        {
            renderPlayerHealthBar();
            renderGrenades();
            PlayerScore();
        }
    }

    void renderPlayerHealthBar()
    {
        playerHealthBarDrawer.Clear(0, 0, 0, 0);
        playerHealthBarDrawer.Fill(Color.Red);
        playerHealthBarDrawer.Rect(0, 0, playerCurrentHealth * 5, healthBarHeight);
        playerHealthBarDrawer.SetXY(25, 50);
    }

    void renderGrenades()
    {
        textDrawer.Clear(0, 0, 0, 0);
        textDrawer.Text(" " + grenades + "/3", 1280, 735);
    }

    void PlayerScore()
    {
        textDrawer.Text("Score " + playerScore, 1220, 75);
    }

    public void addPoints(int points)
    {
        this.playerScore += points;
    }
}
