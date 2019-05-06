using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnSpheres;//The spheres we're spawning
    public Transform spawn; //Where the spheres should spawn
    public Transform end; //Where the spheres should disappear
    private int spawnIndex;
    private bool needSpawn;
    private float spawnTimer;

    void Start()
    {
        spawnSpheres[spawnIndex].SetActive(true);
        StartCoroutine(MoveSphere(spawnSpheres[spawnIndex].transform));
        spawnIndex++;
        needSpawn = true;
        StartCoroutine(SpawnSphere());
    }

    private IEnumerator SpawnSphere()
    {
        while (needSpawn)
        {
            while (spawnTimer <= 3.0f)
            {
                spawnTimer += Time.deltaTime;
                yield return null;
            }
            spawnSpheres[spawnIndex].transform.position = spawn.position;
            spawnSpheres[spawnIndex].SetActive(true);
            StartCoroutine(MoveSphere(spawnSpheres[spawnIndex].transform));
            spawnIndex++;
            if (spawnIndex >= spawnSpheres.Length)
                spawnIndex = 0;
            spawnTimer = 0;
            yield return null;
        }
    }

    private IEnumerator MoveSphere(Transform mySphere)
    {
        while (Vector3.Distance(mySphere.position, end.position) > .01f)
        {
            mySphere.position = Vector3.MoveTowards(mySphere.position, end.position, 2f * Time.deltaTime);
            if (Vector3.Distance(mySphere.position, end.position) < .01f)
            {
                mySphere.gameObject.SetActive(false);
            }
            yield return null;
        }
    }
}
