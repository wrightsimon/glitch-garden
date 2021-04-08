using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    //Config parameters
    [Range(0f,5f)] float currentSpeed = 1f;
    [SerializeField] int lifeDamage = 1;

    //State params
    GameObject currentTarget;
    float difficultyMod;

    //Awake is called before Start
    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();   
    }

    //OnDestroy is called when the gameObject is destroyed
    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }


    void Start()
    {
        difficultyMod = PlayerPrefsController.GetDifficulty();

        // If there is no difficulty modifier (if you are testing through the unity editor), set a default.
        if (difficultyMod <= 0)
        {
            difficultyMod = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) {   return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            damage = damage * difficultyMod;
            health.DealDamage(damage);
        }
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public int GetLifeDamage()
    {
        return lifeDamage;
    }
}
