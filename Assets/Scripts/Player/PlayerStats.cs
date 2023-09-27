using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anim;
    [SerializeField] private Image healthFill;
    [SerializeField] float maxHealth;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Shield shield;
    private PlayerShooting playerShooting;

    private bool canPlayAnim = true;
    float health;
    void Start()
    {
        playerShooting = GetComponent<PlayerShooting>();
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
        EndGameManager.endGameManager.gameOver = false;
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        if (shield.protection) return;
        health -= damage;
        healthFill.fillAmount = health / maxHealth;
        if (canPlayAnim)
        {
            anim.SetTrigger("Damage");
            StartCoroutine(AntiSpamAnimation());
        }
        playerShooting.DecreaseUpgrade();
        if (health <= 0)
        {
            print("thua");
            EndGameManager.endGameManager.gameOver = true;
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private IEnumerator AntiSpamAnimation()
    {
        canPlayAnim = false;
        yield return new WaitForSeconds(0.15f);
        canPlayAnim = true;
    }
    public void AddHealth(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth) health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
    }
}
