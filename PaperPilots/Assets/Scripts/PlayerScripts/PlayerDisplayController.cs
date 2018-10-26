using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerDisplayController:MonoBehaviour
    {

        public Dictionary<string, Color> colors;

        public int currentColorIndex;


        public PlayerHandler player;

        public void Start()
        {
            colors = new Dictionary<string, Color>();
            colors.Add("Black", new Color(0, 0, 0));
            colors.Add("White", new Color(255, 255, 255));
            colors.Add("Red", new Color(255, 0, 0));
            colors.Add("Green", new Color(0, 255, 0));
            colors.Add("Blue", new Color(0, 0, 255));

            this.currentColorIndex = 0;
        }

        public void Update()
        {
            
        }

        public void setColor()
        {
            this.player.gameObject.GetComponent<Renderer>().material.color = colors.ElementAt(currentColorIndex).Value;
        }

        public void incrementColor()
        {
            this.currentColorIndex++;
            if (this.currentColorIndex >= colors.Count) this.currentColorIndex = 0;
            setColor();
        }

        public void decrementColor()
        {
            this.currentColorIndex--;
            if (this.currentColorIndex < 0) this.currentColorIndex = colors.Count - 1;
            setColor();
        }



    }
}
