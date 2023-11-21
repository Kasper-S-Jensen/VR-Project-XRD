using System;
using System.Collections;
using System.Collections.Generic;
using Kutaiba.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class WideLavaTilesController : MonoBehaviour, ILavaManager
{
    private GameObject _crystal;
    private GameObject _blank;
    private GameObject _player;
    private readonly List<GameObject> _crystalSpawnLocations = new();
    private GameObject _playerSpawnLocations;
    private GameObject _blankSpawnLocations;

    private void Start()
    {
        _crystalSpawnLocations.AddRange(GameObject.FindGameObjectsWithTag("CrystalSpawnLocation"));
        _crystal = GameObject.FindGameObjectWithTag("Crystal");
        _player = GameObject.FindGameObjectWithTag("Player");
        _blank = GameObject.FindGameObjectWithTag("Blank");
        _blankSpawnLocations = GameObject.FindGameObjectWithTag("BlanksSpawnLocaion");
        _playerSpawnLocations = GameObject.FindGameObjectWithTag("PlayerSpawnLocation");
    }

    private void OnCollisionEnter(Collision collision)
    {
        SetCollisionParameters(collision);
    }

    private void MoveCrystal()
    {
        var random = Random.Range(0, _crystalSpawnLocations.Count);
        _crystal.transform.position = _crystalSpawnLocations[random].transform.position;
    }

    public void SetCollisionParameters(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player.transform.position = _playerSpawnLocations.transform.position;
        }
        else if (collision.gameObject.CompareTag("Blank"))
        {
            _blank.transform.position = _blankSpawnLocations.transform.position;
        }
        else if (collision.gameObject.CompareTag("Crystal"))
        {
            MoveCrystal();
        }
    }
}