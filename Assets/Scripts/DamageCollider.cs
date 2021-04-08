using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<LifeDisplay>().LoseLives(collision.GetComponent<Attacker>().GetLifeDamage());
        Destroy(collision.gameObject);
    }
}
