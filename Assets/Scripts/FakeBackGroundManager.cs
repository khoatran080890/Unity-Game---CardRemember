using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBackGroundManager : MonoBehaviour
{
    public GameObject[] fishpools;
    public GameObject parrentPool;
    public float timetoupdate;



    private void Start()
    {
        timetoupdate = 0.2f;
        InfoContainer.numberoffish = 0;


    }

    private void Update()
    {
        timetoupdate -= Time.deltaTime;
        if (timetoupdate < 0)
        {
            if (InfoContainer.numberoffish < 20)
            {
                SpawnFish();
            }
            timetoupdate = 0.2f;
        }
    }

    public void SpawnFish()
    {
        int random = Random.Range(0, fishpools.Length);
        GameObject randomfish = Instantiate(fishpools[random], parrentPool.transform);
        int randomWidth = Random.Range(-700, 700);
        int randomHeight = Random.Range(-350, 350);
        randomfish.transform.localPosition = new Vector2(randomWidth, randomHeight);

        InfoContainer.numberoffish += 1;
    }
}
