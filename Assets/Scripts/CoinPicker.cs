using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class CoinPicker : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Tilemap coinPickup;
    [SerializeField] private Tilemap coinShadow;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null) Debug.LogError("AudioSource Not Found!");
    }

    private void Update()
    {
        var tileCoordinate = coinPickup.WorldToCell(player.position);
        var shadowTileCoordinate = coinShadow.WorldToCell(tileCoordinate - (Vector3.down / 2));
        
        if (coinPickup.GetTile(tileCoordinate))
        {
            _audioSource.Play();
            ScoreScript.Score += 1;
            coinPickup.SetTile(tileCoordinate, null);
            coinShadow.SetTile(shadowTileCoordinate, null);
        }
    }
}
