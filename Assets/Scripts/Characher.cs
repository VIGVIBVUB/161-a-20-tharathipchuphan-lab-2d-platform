using UnityEngine;

public abstract class Characher : MonoBehaviour
{
    private int health;
    public int Health { get => health; set => health = (value < 0) ? 0 : value; }

    protected Animator anim;
    protected Rigidbody2D rb;

    public void Initialized(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} initial Healtk: {this.Health}");

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took damage {damage}. Cruuent Health: {Health}");

        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log($"{this.name} is ded and destroyd!");
            return true;
        }
        else return false;
    }
    
    void Start()
    {
        
    }

    
}
