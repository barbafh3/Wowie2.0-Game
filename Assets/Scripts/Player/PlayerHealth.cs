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

  public void AddHealth(float amount)
  {
    currentHealth.Value += amount;
    healthChangeEvent.Raise();
  }

  public void RemoveHealth(float amount)
  {
    currentHealth.Value -= amount;
    healthChangeEvent.Raise();
  }
}
