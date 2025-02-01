using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthbarFill;

    private float drain = 0f;

    private void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {

            drain = 0.02f;

        }

        else
        {

            drain = 0.002f;

        }

        currentHealth -= drain;

        UpdateHealthBar();

        if (currentHealth <= 0)
        {

            Debug.Log("Ded lmao");
        }
    }


    void UpdateHealthBar()
    {
        healthbarFill.fillAmount = currentHealth / maxHealth;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

}
