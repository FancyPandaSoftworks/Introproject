﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MainGame : GameEnvironment
{
    static void Main()
    {
        MainGame game = new MainGame();
        game.Run();
    }

    public MainGame()
    {
        Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
    }
}

