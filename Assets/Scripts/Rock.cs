using System;
using UnityEngine;

public class Rock : Weapon
{
    public Rigidbody2D rb;
    public Vector2 force;

    public override void Move()
    {
        rb.AddForce(force);
    }

    public override void OnHitWith(Characher obj)
    {
        if (obj is Player)
            obj.TakeDamage(this.damage);
    }

    internal void InitWeapon(int v, Crocodile crocodile)
    {
        throw new NotImplementedException();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
