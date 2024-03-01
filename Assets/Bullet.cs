using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private float damage = 15f;
    [SerializeField] private GameObject bulletImpact;
    [SerializeField] private GameObject bloodImpact;
    void Update()
    {
        // Move the GameObject forward based on the speed
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Optionally, destroy the GameObject after a certain time
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<BossHealth>().TakeDamage(damage);
            Instantiate(bloodImpact, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        Instantiate(bulletImpact, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject,0.2f);
    }
}
