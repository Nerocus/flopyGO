using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusStar : MonoBehaviour
{
    public float cooldown;
   

    [HideInInspector] public bool isCooldown;

    private Image starImage;
    private Jump player;
   

    void Start()
    {
        starImage = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Jump>();
        isCooldown = true;
    }

    // Update is called once per frame
    void Update()
    {
        starImage.fillAmount -= 1 / cooldown * Time.deltaTime;
        if (starImage.fillAmount <= 0)
        {
            
            starImage.fillAmount = 1;
            isCooldown = false;
            gameObject.SetActive(false);
        }

    }

    public void ResetTimer()
    {
        starImage.fillAmount = 1;
    }
}
