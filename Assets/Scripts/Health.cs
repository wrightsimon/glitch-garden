using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Config parameters
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float deathDuration = 1f;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }

        Vector2 deathVFXLocation = new Vector2(transform.position.x - 0.5f, transform.position.y - 0.2f);
        GameObject deathVFXObject = Instantiate(deathVFX, deathVFXLocation, transform.rotation);
        Destroy(deathVFXObject, deathDuration);
    }
}
