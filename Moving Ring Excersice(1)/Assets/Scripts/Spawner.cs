using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Cube;

    private bool isSpawnRunning = false;

    private GameObject ins;

    [SerializeField] private float CubeSpeed;
    

    private void Start()
    {
        isSpawnRunning = false;
    }

    private void Update()
    {
        if(isSpawnRunning)
        {
            RunSpawn(ins);
            //StartCoroutine("DestroySpawn");
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject currentSpawn = SpawnCube();
            isSpawnRunning = true;
        }
        
    }

    private GameObject SpawnCube()
    {
        ins = Instantiate(Cube, transform.position, Quaternion.identity);

        return ins;
    }

    private void RunSpawn(GameObject CurrentSpawn)
    {
        CurrentSpawn.transform.position += new Vector3(CubeSpeed * Time.deltaTime, 0, 0);
    }

    //IEnumerator DestroySpawn()
    //{
    //    yield return new WaitForSeconds(1);
    //    Destroy(ins);
    //}
}
