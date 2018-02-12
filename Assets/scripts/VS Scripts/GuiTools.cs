using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts.VS_Scripts
{
    class GuiTools
    {
        public int intPercent(int number, int percentOff, int percentMod = 100)
        {
            float floatWidth = number, floatPercent = percentOff;
            float f = floatWidth * (floatPercent / percentMod);
            return (int)f;
        }

        public int screenWidth(int percent = 100, int modifier = 100)
        {
            int w = Screen.width;
            float p = (float)percent / (float)modifier;
            w = (int)(w * p);
            return w;
        }

        public int screenHeight(int percent = 100, int modifier = 100)
        {
            int w = Screen.height;
            float p = (float)percent / (float)modifier;
            w = (int)(w * p);
            return w;
        }
    }
}
