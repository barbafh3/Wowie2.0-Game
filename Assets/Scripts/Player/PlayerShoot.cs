using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

  public GameObject shotPrefab;

  public Transform shotOrigin;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.F))
    {
      var shot = Instantiate(shotPrefab, shotOrigin.position, transform.rotation);
    }
  }
}
