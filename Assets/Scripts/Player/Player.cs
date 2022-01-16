using UnityEngine;

public class Player : MonoBehaviour
{
    public int CannonBallVelocity;
    public bool CanShoot;
    public float ReloadDuration;
    private float reloadTime;
    public float CannonBallDamage;
    public float CannonHealth;
    public int PenetrationAmount;


    private void Update()
    {
        reloadTime += Time.deltaTime;

        if (reloadTime >= ReloadDuration && !CanShoot)
        {
            CanShoot = true;
            reloadTime = 0f;
        }
    }
}
