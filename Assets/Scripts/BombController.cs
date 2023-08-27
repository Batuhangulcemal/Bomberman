using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public KeyCode inputKey = KeyCode.Space;
    public GameObject bombPrefab;
    public float bombFuseTime = 3f;
    public int bombAmount = 1;

    private int _bombsRemaining = 0;

    private void OnEnable()
    {
        _bombsRemaining = bombAmount;
    }

    private void Update()
    {
        if (_bombsRemaining > 0 && Input.GetKeyDown(inputKey))
        {
            StartCoroutine(PlaceBomb());

        }
    }
    private IEnumerator PlaceBomb()
    {

        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        var bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        _bombsRemaining--;
       
        yield return new WaitForSeconds(bombFuseTime);
       
        Destroy(bomb);
        _bombsRemaining++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            other.isTrigger = false;
        }
    }
}
