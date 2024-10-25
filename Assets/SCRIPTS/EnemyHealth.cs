using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int MaxHealth=5;
    int CurrentHealth=0;
    [Tooltip("add max health when enemy die")]
    [SerializeField] int HealthIncreaser=1;
    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        CurrentHealth = MaxHealth;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessDamage();
    }

    void ProcessDamage()
    {
        CurrentHealth--;
        if (CurrentHealth <=0)
        {
            enemy.RewardGold();
            MaxHealth  +=HealthIncreaser;
            gameObject.SetActive(false);
        }
    }
}
