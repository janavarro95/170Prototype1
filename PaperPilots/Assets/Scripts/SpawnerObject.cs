
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rand = System.Random;

/// <summary>
/// A class that handles creating spawnable objects.
/// </summary>
public class SpawnerObject : MonoBehaviour {

    /// <summary>
    /// The game object to spawn.
    /// </summary>
    public GameObject obj;

    /// <summary>
    /// The velocity of the object.
    /// </summary>
    public Vector3 velocity;

    /// <summary>
    /// The spawn handler for the game object.
    /// </summary>
    public SpawnTickHandler spawnHandler
    {
        get
        {
            return this.gameObject.GetComponent<SpawnTickHandler>();
        }
    }

    /// <summary>
    /// The name of the game object.
    /// </summary>
    public string Name
    {
        get
        {
            return obj.gameObject.name;
        }
    }


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        this.transform.position += this.velocity*Time.deltaTime;
        if (this.transform.position.z <= Camera.main.transform.position.z+ -20&& this.transform.position.z!= -999999999)
        {
            DestroyObject(this.gameObject);
        }
	}

    /// <summary>
    /// Set how many frames until this object spawns again.
    /// </summary>
    /// <param name="r">A system random to get a number between the minimum and maxinum number of spawn frames.</param>
    public void setSpawnTick(Rand r)
    {
        this.spawnHandler.setTicks(r);
    }


    /// <summary>
    /// Spawns a clone of the game object.
    /// </summary>
    /// <param name="position">The position of the cloned object.</param>
    /// <param name="velocity">The velocity of the cloned object.</param>
    public void spawn(Vector3 position, Vector3 velocity)
    {
        GameObject clone=Instantiate(this.gameObject);
        clone.transform.position = position;
        clone.GetComponent<SpawnerObject>().velocity = velocity;
        clone.GetComponent<SpawnerObject>().spawnHandler.spawn();
    }
}
