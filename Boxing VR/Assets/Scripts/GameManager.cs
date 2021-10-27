using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public int startHealth = 100;
  private int currentHealth;

  private bool down = false;

  // Start is called before the first frame update
  void Start()
  {
    currentHealth = startHealth;
  }

  public void Damage(int damage)
  {
    currentHealth -= damage;
    if (currentHealth == 0)
      SceneManager.LoadScene(0);
  }
}
