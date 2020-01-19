using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  public float maxHealth, startingHealth;

  public FloatVariable currentHealth;

  public GameEvent healthChangeEvent;

  void Start()
  {
    currentHealth.Value = startingHealth;
  }

  void Update()
  {
    if (currentHealth.Value <= 0)
    {
      Debug.Log("Morreu");
    }
  }

  public void AddHealth(float amount)
  {
    if (currentHealth.Value + amount <= maxHealth)
    {
      currentHealth.Value += amount;
      healthChangeEvent.Raise();
    }
    else
    {
      currentHealth.Value = maxHealth;
    }
  }

  public void RemoveHealth(float amount)
  {
    if (currentHealth.Value - amount >= 0)
    {
      currentHealth.Value -= amount;
      GetComponent<PlayerMovement>().animator.SetTrigger("Hurt");
      healthChangeEvent.Raise();
    }
    else
    {
      currentHealth.Value = 0;
    }
  }
}
