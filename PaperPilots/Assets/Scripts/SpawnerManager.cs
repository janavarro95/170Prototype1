using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using Rand = System.Random;

namespace Assets.Scripts
{
    /// <summary>
    /// Handles spawning different objects into the world.
    /// </summary>
    [System.Serializable]
    public class SpawnerManager:MonoBehaviour
    {
        /// <summary>
        /// System random number generation.
        /// </summary>
        public Rand random;
        
        /// <summary>
        /// A list of paths leading to the prefabs for the game objects.
        /// </summary>
        public List<string> pathsToObjects;

        /// <summary>
        /// The different objects that can spawn.
        /// </summary>
        public Dictionary<string,GameObject> spawnableObjects;


        public float X
        {
            get
            {
                return this.gameObject.transform.position.x;
            }
        }

        public float Y
        {
            get
            {
                return this.gameObject.transform.position.y;
            }
        }

        public float Z
        {
            get
            {
                return this.gameObject.transform.position.z;
            }
        }

        public Vector3 Position
        {
            get
            {
                return new Vector3(X, Y, Z);
            }
        }

        /// <summary>
        /// The upper limit for the random spawner to check against. I.E 1000.
        /// </summary>
        public int maxChanceSpawnLimit;

        /// <summary>
        /// Start the script.
        /// </summary>
        public void Start()
        {
            random = new Rand((int)X+(int)Y+(int)Z+GetHashCode());
            initializeSpawnChances();
            loadPrefabs();

            //spawnGameObject("Cube", new Vector3(0, 0, 20), new Vector3(0, 0, -20f));
        }

        /// <summary>
        /// Update the Spawn Manager.
        /// </summary>
        public void Update()
        {
            
        }

        /// <summary>
        /// Update the Spawn Manager on a fixed step and spawns objects.
        /// </summary>
        public void FixedUpdate()
        {

            foreach (var pair in this.spawnableObjects)
            {
                
                SpawnerObject spawn = getSpawnData(pair.Value);
                if (spawn.spawnHandler.readyToTryToSpawn())
                {
                    int spawnLimit = random.Next(0, maxChanceSpawnLimit+1); //Get a number from 0-maxSpawnChance. If the object's spawn chance is higher than the maxSpawnChance it will sucessfully spawn. Otherwise it's timer gets reset.
                    if (spawnLimit<spawn.spawnHandler.SpawnChance) //if the object's spawn chance is less than the cutoff, spawn it.
                    {
                        spawn.spawn(Position, new Vector3(0,0,-20f));
                        spawn.spawnHandler.reset(random);
                    }
                    else
                    {
                        spawn.spawnHandler.reset(random);
                    }
                }
                else
                {
                    spawn.spawnHandler.tick();
                }
            }
            //Debug.Log("Hello?");
        }

        /// <summary>
        /// Spawn a game object that has this name as a prefab.
        /// </summary>
        /// <param name="name">The name of the game object.</param>
        public void spawnGameObject(string name)
        {
            GameObject obj = this.spawnableObjects[name];
            Instantiate(obj);
        }

        /// <summary>
        /// Spawn a game object that has this name as a prefab.
        /// </summary>
        /// <param name="name">The name of the game object.</param>
        /// <param name="position">The position of the game object when spawned.</param>
        /// <param name="velocity">The velocity of the game object.</param>
        public void spawnGameObject(string name,Vector3 position, Vector3 velocity)
        {
            GameObject obj = this.spawnableObjects[name]; //Get a reference to the prefab I want to spawn.
            Instantiate(obj); //Instantiate it to the game world.
            getSpawnData(obj).spawn(position, velocity); //"Spawn" it by setting all of the variables I want to set to the object.
        }

        /// <summary>
        /// Spawn a game object while still respecting it's potential for chance.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="velocity"></param>
        public void spawnGameObjectWithChance(string name, Vector3 position, Vector3 velocity)
        {
                SpawnerObject spawn =getSpawnData(spawnableObjects[name]);
                if (spawn.spawnHandler.readyToTryToSpawn())
                {
                    int spawnLimit=random.Next(0, maxChanceSpawnLimit); //Get a number from 0-maxSpawnChance. If the object's spawn chance is higher than the maxSpawnChance it will sucessfully spawn. Otherwise it's timer gets reset.
                    if (spawn.spawnHandler.SpawnChance > spawnLimit)
                    {
                        spawn.spawn(position, velocity);
                    }
                }
            
        }

        /// <summary>
        /// Set up the spawn chances for all spawnable objects.
        /// </summary>
        private void initializeSpawnChances()
        {
            this.spawnableObjects = new Dictionary<string, GameObject>();
        }

        /// <summary>
        /// Load all of the prefabs from disk.
        /// </summary>
        private void loadPrefabs()
        {
            foreach(string path in this.pathsToObjects)
            {
                if (String.IsNullOrEmpty(path)) continue;
                GameObject obj = this.loadPrefab(path);
                this.spawnableObjects.Add(obj.name,obj);
            }
        }

        /// <summary>
        /// Load a prefab from disk.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public GameObject loadPrefab(string path)
        {
            string[] pathArray = path.Split(',');
            string actualPath = "";
            foreach(string pathPiece in pathArray)
            {
                actualPath = Path.Combine(actualPath, pathPiece);
            }
            UnityEngine.GameObject pPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(actualPath); //Load a prefab.

            GameObject pNewObject = pPrefab;
            var ok=Instantiate(pNewObject, new Vector3(-99999999, -99999999, -999999999),Quaternion.identity); //Get a fake clone in the world so that it can act as a reference for some various scripts for spawning.
            ok.name = pPrefab.name; //Get rid of the (Clone) part of a name.

            SpawnerObject obj = getSpawnData(ok);
            obj.obj = ok; //Set the spawn object to this.
            obj.spawnHandler.setTicks(random); //Set the number of ticks until spawn.

            return ok;
        }

        /// <summary>
        /// Get the SpawnObject script from a game object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public SpawnerObject getSpawnData(GameObject obj)
        {
            return obj.GetComponent<SpawnerObject>();
        }

        /// <summary>
        /// Get the spawn chance for a game object to appear and add it to the script.
        /// </summary>
        /// <param name="obj"></param>
        private void setSpawnChance(SpawnerObject obj,int value)
        {
            obj.spawnHandler.SpawnChance = value;
        }

        /// <summary>
        /// Adjust the chance for a game object to spawn.
        /// </summary>
        /// <param name="name">The name of a game object to adjust.</param>
        /// <param name="chance">The chance for it to spawn.</param>
        public void adjustSpawnChance(string name, int chance)
        {
            getSpawnData(this.spawnableObjects[name]).spawnHandler.SpawnChance=chance;
        }
    }
}
