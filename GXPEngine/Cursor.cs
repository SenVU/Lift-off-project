﻿using System;
using GXPEngine;

public class Cursor : Sprite
{
    AmmoTypeHandler barrelOne;
    AmmoTypeHandler barrelTwo;

    bool infiniteAmmo = false;

    int ammoIndex = 0;
    int grenadeKillCount;
    public Cursor() : base("assets/debug/square.png")
    {
        SetOrigin(width / 2, height / 2);
        barrelOne = AmmoTypeHandler.BUCKSHOT;
        barrelTwo = AmmoTypeHandler.BUCKSHOT;
        ammoIndex = 0;

        
    }


    void Update()
    {
        if(grenadeKillCount >= 5)
        {
            GrenadeHandler.addGrenade();
            grenadeKillCount = 0;
        }
    }

    public void fire()
    {
        if (barrelOne != null)
        {
            barrelOne.fire(x, y);
            if (!infiniteAmmo) barrelOne = null;
        }
        else if (barrelTwo != null)
        {
            barrelTwo.fire(x, y);
            if (!infiniteAmmo) barrelTwo = null;
        }
    }

    public void ReloadOne()
    {
        switch (ammoIndex)
        {
            case 0:
                barrelOne = AmmoTypeHandler.BUCKSHOT;
                Console.WriteLine("You reloaded Buckshot!");
                break;
            case 1:
                barrelOne = AmmoTypeHandler.SLUG;
                Console.WriteLine("You reloaded Slug!");
                break;
            case 2:
                barrelOne = AmmoTypeHandler.DRAGONS_BREATH;
                Console.WriteLine("You reloaded Dragons Breath!");
                break;
            default:
                break;
        }
    }

    public void ReloadTwo()
    {
        switch (ammoIndex)
        {
            case 0:
                barrelTwo = AmmoTypeHandler.BUCKSHOT;
                Console.WriteLine("You reloaded Buckshot!");
                break;
            case 1:
                barrelTwo = AmmoTypeHandler.SLUG;
                Console.WriteLine("You reloaded Slug!");
                break;
            case 2:
                barrelTwo = AmmoTypeHandler.DRAGONS_BREATH;
                Console.WriteLine("You reloaded Dragons Breath!");
                break;
            default:
                break;
        }
    }

    public void AmmoSwitch()
    {
        ammoIndex++;

        if (ammoIndex > 2)
        {
            ammoIndex = 0;
        }
        Console.WriteLine("You switched to bullet: " + ammoIndex);
    }

    public int getAmmoIndex() { return ammoIndex; }

    public void addkillCount(){ grenadeKillCount++; }

    public int GetKillCount(){ return grenadeKillCount; }

    public void ThrowGrenade(){ GrenadeHandler.throwGrenade(x,y); }
}