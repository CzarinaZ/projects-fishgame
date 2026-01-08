using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flash : MonoBehaviour
{

    //Remember!!! add the material to the player so this code makes sense
  [SerializeField] private Material whiteFlashMat;
  [SerializeField] private float restoreDefaultMatTime = .2f;

  private Material defaultMat;
  private SpriteRenderer spriteRenderer;
  private EnemyHealth enemyHealth;

  private void Awake(){
    enemyHealth = GetComponent<EnemyHealth>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    defaultMat = spriteRenderer.material;
  }

  public IEnumerator FlashRoutine(){
    spriteRenderer.material = whiteFlashMat;
    yield return new WaitForSeconds(restoreDefaultMatTime);
    spriteRenderer.material = defaultMat;
    enemyHealth.DetectDeath();
  }
}
