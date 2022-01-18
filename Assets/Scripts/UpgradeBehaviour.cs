using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBehaviour : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public Player Player;
    private int bulletType;

    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        Player = GameObject.FindObjectOfType<Player>();
        bulletType = Random.Range(0, 3);
        switch (bulletType) {
            //Damage Upgrade
            case 0:
                Sprite.color = Color.red;
                break;

                //Reload Upgrade
            case 1:
                Sprite.color = Color.green;
                break;

                //Penetration Upgrade
            case 2:
                Sprite.color = Color.yellow;
                break;
        }
    }

    public void Upgrade()
    {
        switch (bulletType)
        {
                //Damage Upgrade
            case 0:
                Player.CannonBallDamage++;
                break;

                //Reload Upgrade
            case 1:
                if(Player.ReloadDuration > .1f)
                    Player.ReloadDuration -= .2f;
                else
                    Player.CannonBallDamage++;
                break;

                //Penetration Upgrade
            case 2:
                Player.PenetrationAmount++;
                break;
        }
        GameObject[] a = GameObject.FindGameObjectsWithTag("Upgrade");
        foreach (GameObject gobject in a)
        {
            Destroy(gobject);
        }
    }
}
