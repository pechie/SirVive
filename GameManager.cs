using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    private float respawnDelay = 1f;
    public Text livesLeft;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        livesLeft.text = "Lives Left: " + player.livesLeft;
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        livesLeft.text = "Lives Left: " + player.livesLeft;
        player.gameObject.SetActive(false);
        player.transform.position = player.respawnPoint;
        player.transform.localScale = new Vector2(0.5f, 0.5f);
        yield return new WaitForSeconds(respawnDelay);
        player.gameObject.SetActive(true);
    }

    public void EndGame()
    {

        Debug.Log("Game Over");
    }
}
