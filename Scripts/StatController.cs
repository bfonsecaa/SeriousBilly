using UnityEngine;
using System.Collections;

public class StatController : MonoBehaviour {

    public GameObject levelUpGUI;
    public static Vector3 sizeVector;
    private float scaleIncrease;

    public BulletController bullet;
    public GameObject eventSystem;

    void Start()
    {
        sizeVector = new Vector3(0.18f, 0.18f, 0.18f);

        scaleIncrease = 0.05f;
    }

    public void moveSpeed()
    {
        PlayerController.speed = PlayerController.speed + 2f;

        PlayerExperienceManager.levelUpPoints--;

        if (PlayerExperienceManager.levelUpPoints == 0)
        {
            levelUpGUI.SetActive(false);
        }
        
    }

    public void bulletSize()
    {
        sizeVector = new Vector3(bullet.transform.localScale.x + scaleIncrease, bullet.transform.localScale.y + scaleIncrease, bullet.transform.localScale.z + scaleIncrease);
        scaleIncrease = scaleIncrease + 0.05f;

        BulletController.damage = BulletController.damage + 5;

        PlayerExperienceManager.levelUpPoints--;

        if (PlayerExperienceManager.levelUpPoints == 0)
        {
            levelUpGUI.SetActive(false);
        }
    }

    public void bulletSpeed()
    {
        BulletController.speed = BulletController.speed + 1f;
        
        PlayerExperienceManager.levelUpPoints--;

        if (PlayerExperienceManager.levelUpPoints == 0)
        {
            levelUpGUI.SetActive(false);
        }
    }

    public void addHealth()
    {
        PlayerHealthManager.currentHealth = PlayerHealthManager.currentHealth + 50;

        PlayerExperienceManager.levelUpPoints--;

        if (PlayerExperienceManager.levelUpPoints == 0)
        {
            levelUpGUI.SetActive(false);
        }
    }

    public void reloadTime()
    {
        if (GunController.reloadTime >= 0.5f)
            GunController.reloadTime = GunController.reloadTime - 0.1f;
        else if (GunController.reloadTime < 0.5f && GunController.reloadTime >= 0.1f)
            GunController.reloadTime = GunController.reloadTime - 0.05f;

        PlayerExperienceManager.levelUpPoints--;

        if (PlayerExperienceManager.levelUpPoints == 0)
        {
            levelUpGUI.SetActive(false);
        }
    }
}
