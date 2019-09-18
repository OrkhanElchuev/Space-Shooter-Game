using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float healthPoints = 100.0f;
    [SerializeField] float shotCounter;
    [SerializeField] float minPeriodBetweenShots = 0.2f;
    [SerializeField] float maxPeriodBetweenShots = 3.0f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Giving shotCounter random value in the range between min and max 
        shotCounter = Random.Range(minPeriodBetweenShots, maxPeriodBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    // Enemy shooting after random amount of time passed(between min and max)
    public void CountDownAndShoot()
    {
        // Shot counter minus time that one frame takes 
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0.0f)
        {
            Shoot();
            // Reset shot Counter to new value
            shotCounter = Random.Range(minPeriodBetweenShots, maxPeriodBetweenShots);
        }
    }

    // Method for handling enemy shooting
    private void Shoot()
    {
        // Quaternion corresponds to "no rotatition" for instantiated object
        GameObject enemyLaser = Instantiate(projectile,
            transform.position, Quaternion.identity) as GameObject;
        // -projectileSpeed to change reverse direction of shooting(shoot downwards)
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    // On collision of laser with Enemy deal the damage
    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage damage = other.gameObject.GetComponent<Damage>();
        ProcessHit(damage);
    }

    // Decrement health 
    private void ProcessHit(Damage damage)
    {
        healthPoints -= damage.GetDamage();
        damage.Hit();
        // Destroy object when health <= 0
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
