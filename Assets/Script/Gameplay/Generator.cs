using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public float maxTime = 1;
    
    private float timer = 0;
    private float timerBonus = 0;
    private float timerHard = 0;

    public GameObject pipe;
    public GameObject pipeCoin;
    public GameObject hardMode;  
    public GameObject easyMode;  

    public float height;
    public float heightBonus;

    public float needSpawnBonus = 1;
    public float hardSpawn = 5;

    private float pip = 1; 
    public GameObject[] BonusObject;
    private int random;

    public Jump velocity; 

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
        GameObject go = GameObject.Find("Bird");
        Jump velocity = go.GetComponent<Jump>();
        float courrentSpeed = velocity.velocity;

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

        if (timerBonus > needSpawnBonus)
        {
            random = Random.Range(0, BonusObject.Length);
            GameObject newbonus = Instantiate(BonusObject[random]);
            newbonus.transform.position = transform.position + new Vector3(0, Random.Range(-heightBonus, heightBonus), 0);
            Destroy(newbonus, 15);
            timerBonus = 0;
        }

        if (timerHard > hardSpawn)
        {  if (velocity.velocity > 0)
            {
                GameObject newHard = Instantiate(hardMode);
                newHard.transform.position = transform.position + new Vector3(0, 0, 0);
                Destroy(newHard, 15);
                timerHard = 0;
                StartCoroutine(SpawnPipe());
            }
            if(velocity.velocity < 0)
            {
                GameObject newEasy = Instantiate(easyMode);
                newEasy.transform.position = transform.position + new Vector3(0, 0, 0);
                Destroy(newEasy, 15);
                timerHard = 0;
                StartCoroutine(SpawnPipe());
            }

        }
    }
    private IEnumerator SpawnPipe()
    {
        maxTime = 3;
        yield return new WaitForSeconds(3);
        maxTime = maxTime /2;
    }
    

    public void Timer()
    {
        timer += Time.deltaTime;
        timerBonus += Time.deltaTime;
        timerHard += Time.deltaTime;
    }
}
