using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayProjectiles : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject bulletPrefab;
    private List<GameObject> bullets = new List<GameObject>();
    private Game game;

    private void Awake()
    {
        game = gameManager.GetComponent<Game>();
    }

    void Update()
    {
        removeBullets();
        addBullets();
        moveBullets();
        bulletsCollide();
    }

    private void removeBullets()
    {
        for (int i = 0; i < game.getProjectileRemovalSize(); i++)
        {
            Destroy(bullets[game.getProjectileRemovalIndex(i)]);
            bullets.RemoveAt(game.getProjectileRemovalIndex(i));
        }
        game.resetProjectileRemovalIndex();
    }

    private void addBullets()
    {
        int numberOfNewProjectiles = game.getProjectilesSize() - bullets.Count;
        int numberOfCurrentProjectiles = bullets.Count;
        for (int i = numberOfCurrentProjectiles; i < numberOfNewProjectiles + numberOfCurrentProjectiles; i++)
        {
            GameObject newBullet = Instantiate(bulletPrefab, game.getProjectile(i).getCoordinate(), Quaternion.identity);
            newBullet.transform.rotation = game.getProjectile(i).getRotation();
            newBullet.name = "Projectile";
            newBullet.tag = game.getProjectile(i).color;
            bullets.Add(newBullet);
        }
    }

    private void moveBullets()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].transform.position = game.getProjectile(i).getCoordinate();
            bullets[i].transform.rotation = game.getProjectile(i).getRotation();
        }
    }

    private void bulletsCollide()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i].GetComponent<ProjectileCollision>().tankHit != null)
            {
                for (int j = 0; j < game.getTanksSize(); j++)
                {
                    if (bullets[i].GetComponent<ProjectileCollision>().tankHit.name.Equals(game.getTank(j).color + " Tank"))
                    {
                        game.getTank(j).damage(game.getProjectile(i).damageOutput);
                    }
                }
                game.getProjectile(i).explode();
            }
        }
    }
}
