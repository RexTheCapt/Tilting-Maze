using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts.VS_Scripts
{
    class Prefs
    {
        public int level
        {
            get { return PlayerPrefs.GetInt("Level"); }
            set { PlayerPrefs.SetInt("Level", value); }
        }

        public float GetPlayerLevel(string LevelName)
        {return PlayerPrefs.GetFloat(LevelName);}

        public void SetPlayerLevel(string LevelName, float value)
        { PlayerPrefs.SetFloat(LevelName, value);}
    }
}
