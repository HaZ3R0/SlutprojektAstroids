using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SlutprojektAstroids
{
    public interface IEnemy
    {
        void Movement();
        void Init();
    }
}