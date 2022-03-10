using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerations : MonoBehaviour
{

    public float maxTime = 1;
    private float timer = 0;
    private float timer2 = 0;
    public GameObject pipe;
    public GameObject pipeCoin;

    public float height;
    public float heightCoin;
    public GameObject bonus;
    public float needSpawnBonus = 1;

    private float pip = 1;
    public GameObject[] BonusObject;
    private int random;
    void Start()
    {
        GameObject newpipe = Instantiate(pipe);
        newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        Destroy(newpipe, 15);
    }


    void Update()
    {

        SpawnPipeTest();
        Timer();

    }
    
    public void SpawnPipeTest()
    {

        if (timer > maxTime)
        {
            if (pip % 4 == 0)
            {
                GameObject newpipe = Instantiate(pipeCoin);
                newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
                Destroy(newpipe, 15);
                timer = 0;
                pip = 1;
            }
            else
            {
                GameObject newpipe = Instantiate(pipe);
                newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
                Destroy(newpipe, 15);
                timer = 0;
                pip++;
            }
        }

            if (timer2 > needSpawnBonus)
        {
            random = Random.Range(0, BonusObject.Length);
            GameObject newbonus = Instantiate(BonusObject[random]);
            newbonus.transform.position = transform.position + new Vector3(0, Random.Range(-heightCoin, heightCoin), 0);
            Destroy(newbonus, 15);
            timer2 = 0;
        }
    }


    public void Timer()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
    }
}

