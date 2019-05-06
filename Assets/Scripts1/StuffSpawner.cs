using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour
{
    public FloatRange timeBetweenSpawns, scale, randomVelocity, angularVelocity;
    float currentSpawnDelay;
    private float _timeSinceLastSpawn;

    public float velocity; //Used to give our spawned objects an initial upwards velocity

    public RigibodyStuff[] rStuffPrefabs;

    public Material stuffMaterial;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate ()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        if (_timeSinceLastSpawn >= currentSpawnDelay)
        {
            _timeSinceLastSpawn -= currentSpawnDelay;
            currentSpawnDelay = timeBetweenSpawns.RandomInRange;
            SpawnStuff();
        }
		
	}

    private void SpawnStuff()
    {
        RigibodyStuff prefab = rStuffPrefabs[Random.Range(0, rStuffPrefabs.Length)];
        RigibodyStuff spawn = prefab.GetPooledInstance<RigibodyStuff>();
        spawn.transform.localPosition = transform.position;
        spawn.transform.localScale = Vector3.one * scale.RandomInRange;
        spawn.transform.localRotation = Random.rotation;
        spawn.GetComponent<MeshRenderer>().material = stuffMaterial;
        spawn.Body.velocity = transform.up * velocity + Random.onUnitSphere * randomVelocity.RandomInRange;
        spawn.Body.angularVelocity = Random.onUnitSphere * angularVelocity.RandomInRange;
    }
}
