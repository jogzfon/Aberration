using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField]private float health = 10000f;

    [SerializeField] private Slider healthSlider;

    [SerializeField] private Transform player;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
    private void Update()
    {
        transform.LookAt(player);
    }
    public void TakeDamage(float damage)
    {
        healthSlider.value -= damage;
        if(healthSlider.value <= 0)
        {
            Destroy(gameObject);
        }
    }

}
