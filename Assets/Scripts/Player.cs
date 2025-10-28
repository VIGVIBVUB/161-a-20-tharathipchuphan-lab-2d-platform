using UnityEngine;

public class Player : Characher, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }

    [field: SerializeField] public Transform ShootPoint { get; set; }

     public float ReloadTime { get; set; }

     public float WaitTime { get; set; }

    public void Shoot()
    {
        if (Input.GetButtonDown("Frie1") && WaitTime >= ReloadTime)
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
                banana.InitWeapon(20, this);
            WaitTime = 0.0f;
          
        }
    }
    void Start()
    {
        base.Initialized(100);
        ReloadTime = 1.0f;
        WaitTime = 0.0f;
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log($"{this.name} Hit with {enemy.name}!");
            OnHitWith(enemy);
        }
    }

    
    void Update()
    {
        Debug.Log(Time.deltaTime);
        Shoot();
    }
    void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }


}
