using System;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockDestroyEffect;
    [SerializeField] int maxHits; 
    [SerializeField] Sprite[] sprites;
    [SerializeField] int hits = 0;

    // variable vom Typ LevelController
    LevelController level;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        if (tag == "Breakable")
        {
            // wenn hits >= maxHits => zerstöre den block
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        var gameStatus = FindObjectOfType<GameStatusController>();
        gameStatus.ScoreCalculator();
        ShowEffect();
        Destroy(gameObject);
        // wenn der letzte Block zerstört ist, soll das Level wechseln
        level.DestroyBlock();
    }

    private void ShowEffect()
    {
        Instantiate(blockDestroyEffect, transform.position, transform.rotation);
    }

    private void Start()
    {
        // FindObjectOfType ermittelt das Objekt vom Typ LevelController
        level = FindObjectOfType<LevelController>();
        level.CountBreakableBlocks();
    }
}
