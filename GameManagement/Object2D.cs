﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Object2D : GameObject
{
    protected Vector2 origin, position;
    protected SpriteSheet spriteSheet;

    public Object2D(string assetname, int sheetIndex = 0, string id = "")
    {
        if (assetname != "")
            spriteSheet = new SpriteSheet(assetname, sheetIndex);
                
    }

    //drawing the object2D
    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (!visible || spriteSheet == null)
            return;
        spriteSheet.Draw(spriteBatch, Position, origin);      
    }

    //return position on the screen
    public Vector2 Position
    {
        get { return position; }
        set { position = value; }
    }

    //return spritesheet
    public SpriteSheet SpriteSheet
    {
        get { return SpriteSheet; }
    }

    //return spriteSheet width
    public int Width
    {
        get { return spriteSheet.Width; }
    }

    //return spriteSheet height
    public int Height
    {
        get { return spriteSheet.Height; }
    }

    //make a mirror of the spritesheet
    public bool Mirror
    {
        get { return spriteSheet.Mirror; }
        set { spriteSheet.Mirror = value; }
    }

    //the middle of the spritesheet
    public Vector2 Origin
    {
        get { return this.origin; }
        set { this.origin = value; }
    }
    
    //return the boundingbox for collision
    public  Rectangle BoundingBox
    {
        get
        {
            int left = (int)(Position.X - origin.X);
            int top = (int)(Position.Y - origin.Y);
            return new Rectangle(left, top, Width, Height);
        }
    }

    //collision of object2D with pixels
    public bool CollidesWith(Object2D obj2D)
    {
            if (!this.Visible || !obj2D.Visible || !BoundingBox.Intersects(obj2D.BoundingBox))
                return false;
            Rectangle b = Collision.Intersection(BoundingBox, obj2D.BoundingBox);
            for(int x = 0; x<b.Width; x++)
                for(int y = 0; y<b.Height; y++)
                {
                    int thisx = b.X - (int)(GlobalPosition.X - origin.X) + x;
                    int thisy = b.Y - (int)(GlobalPosition.Y - origin.Y) + y;
                    int objx = b.X - (int)(obj2D.GlobalPosition.X - obj2D.origin.X) + x;
                    int objy = b.Y - (int)(obj2D.GlobalPosition.Y - obj2D.origin.Y) + y;
                    if (SpriteSheet.GetPixelColor(thisx, thisy).A != 0 && obj2D.spriteSheet.GetPixelColor(objx, objy).A != 0)
                        return true;
                } 
            return false;  
           
    }
}
