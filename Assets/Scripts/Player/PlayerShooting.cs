using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private Transform basicShootPoint;
    [SerializeField] private float shootingInterval;

    [Header("Upgrade Points")]
    [SerializeField] private Transform leftCanon;
    [SerializeField] private Transform rightCanon;
    [SerializeField] private Transform secondLeftCanon;
    [SerializeField] private Transform secondRightCanon;

    [Header("Upgrade Rotation Points")]
    [SerializeField] private Transform leftRotationCanon;
    [SerializeField] private Transform rightRotationCanon;

    private int upgradeLevel = 0;
    private float intervalReset;
    void Start()
    {
        intervalReset = shootingInterval;
    }

    // Update is called once per frame
    void Update()
    {
        shootingInterval -= Time.deltaTime;
        if (shootingInterval < 0)
        {
            Shoot();
            shootingInterval = intervalReset;
        }
    }
    public void IncreaseUpgrade(int increaseAmount)
    {
        upgradeLevel += increaseAmount;
        if (upgradeLevel > 4)
        {
            upgradeLevel = 4;
        }
    }
    public void DecreaseUpgrade()
    {
        upgradeLevel -= 1;
        if (upgradeLevel < 0) upgradeLevel = 0;
    }
  
    private void Shoot()
    {
        switch (upgradeLevel)
        {
            case 0:
                SpawnBasicShoot();
                break;
            case 1:
                SpawnLeftRightCanonBullet();
                break;
            case 2:
                SpawnBasicShoot();
                SpawnLeftRightCanonBullet();
                break;
            case 3:
                SpawnBasicShoot();
                SpawnLeftRightCanonBullet();
                SpawnSecondLeftRightCanonBullet();
                break;
            case 4:
                SpawnBasicShoot();
                SpawnLeftRightCanonBullet();
                SpawnSecondLeftRightCanonBullet();
                SpawnLeftRightRotationCanonBullet();
                break;
            default:
                break;

        }
    }
    void SpawnBasicShoot()
    {
        Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
    }
    void SpawnLeftRightCanonBullet()
    {
        Instantiate(laserBullet, rightCanon.position, Quaternion.identity);
        Instantiate(laserBullet, leftCanon.position, Quaternion.identity);
    }
    void SpawnSecondLeftRightCanonBullet()
    {
        Instantiate(laserBullet, secondRightCanon.position, Quaternion.identity);
        Instantiate(laserBullet, secondLeftCanon.position, Quaternion.identity);
    }
    void SpawnLeftRightRotationCanonBullet()
    {
        Instantiate(laserBullet, rightRotationCanon.position, Quaternion.identity);
        Instantiate(laserBullet, leftRotationCanon.position, Quaternion.identity);
    }
}
