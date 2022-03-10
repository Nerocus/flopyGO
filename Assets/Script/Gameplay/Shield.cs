using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shield : MonoBehaviour
{
    public float cooldown;
    public Collider2D headCollider;
    public Collider2D bodyCollider;

    [HideInInspector] public bool isCooldown;

    private Image shieldImage;
    private Jump player;
    void Start()
    {
        shieldImage = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Jump>();
        isCooldown = true;
    }

    // Update is called once per frame
    void Update()
    {
        shieldImage.fillAmount -= 1 / cooldown * Time.deltaTime;
        if (shieldImage.fillAmount <= 0)
        {
            shieldImage.fillAmount = 1;
            isCooldown = false;
            player.shield.SetActive(false);
            gameObject.SetActive(false);
            headCollider.enabled = true;
            bodyCollider.enabled = false;

        }

    }

    public void ResetTimer()
    {
        shieldImage.fillAmount = 1;
    }
}
