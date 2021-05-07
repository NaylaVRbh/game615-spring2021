using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject snowballPrefab;
    [SerializeField] private GameObject SpawnPoint;
    [SerializeField] private GameObject MainCamera;
    private GameObject CurrentSnowBall;
    private bool isTraveling = false;

    public void SpawnSnowball()
    {
        StartCoroutine("SpawnSnow");
    }
    

    void Update()
    {
        if(isTraveling)
        {
            CurrentSnowBall.transform.position -= new Vector3(0, 0, 30 * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnSnowball();
        }

    }

    IEnumerator SpawnSnow()
    {
        yield return new WaitForSeconds(0.2f);

        isTraveling = true;

        GameObject snowball = Instantiate(snowballPrefab, SpawnPoint.transform.position, transform.rotation);

        CurrentSnowBall = snowball;

        snowball.transform.LookAt(MainCamera.transform);
    }

}
