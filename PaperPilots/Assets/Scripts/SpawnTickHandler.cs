using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Rand = System.Random;
namespace Assets.Scripts
{
    /// <summary>
    /// A class that handles the chance and time until an object spawns.
    /// </summary>
    public class SpawnTickHandler:MonoBehaviour
    {
        /// <summary>
        /// The minimum number of ticks or frames until the object checks if it can spawn.
        /// </summary>
        public int minTicksUntilSpawnChance;
        /// <summary>
        /// The maximum number of ticks or frames until the object checks if it can spawn.
        /// </summary>
        public int maxTicksUntilSpawnChance;
        /// <summary>
        /// The number of ticks until the object checks if it can spawn.
        /// </summary>
        public int ticksUntilSpawnChance=-1;

        /// <summary>
        /// The chance (typically out of 1000) the object has to spawn.
        /// </summary>
        public int spawnChance;

        /// <summary>
        /// The chance (typically out of 1000) the object has to spawn.
        /// </summary>
        public int SpawnChance
        {
            get
            {
                return this.spawnChance;
            }
            set
            {
                this.spawnChance = value;
            }
        }
        /// <summary>
        /// Start the script.
        /// </summary>
        public void Start()
        {
        }


        /// <summary>
        /// Checks if the object can try to spawn yet.
        /// </summary>
        /// <returns>A boolean representing if the object can spawn.</returns>
        public bool readyToTryToSpawn()
        {
            return this.ticksUntilSpawnChance == 0;
        }

        /// <summary>
        /// Ticks the number of frames until the object can spawn.
        /// </summary>
        public void tick()
        {
            if (this.ticksUntilSpawnChance <= 0) return;
            this.ticksUntilSpawnChance--;
        }

        /// <summary>
        /// Sets the number of ticks until the object can spawn.
        /// </summary>
        /// <param name="r">A System.Random that handles RNG for getting the number of ticks until spawn. The number is determined between it's two maxums.</param>
        public void setTicks(Rand r)
        {
            this.ticksUntilSpawnChance = r.Next(minTicksUntilSpawnChance, maxTicksUntilSpawnChance + 1);
        }

        /// <summary>
        /// Reset the object's number of ticks until it can spawn.
        /// </summary>
        /// <param name="r"></param>
        public void reset(Rand r)
        {
            setTicks(r);
        }

        /// <summary>
        /// "Spawn the object". Just resets the frame count to -1 so it can't loop if needed.
        /// </summary>
        public void spawn()
        {
            this.ticksUntilSpawnChance = -1;
        }
    }
}
