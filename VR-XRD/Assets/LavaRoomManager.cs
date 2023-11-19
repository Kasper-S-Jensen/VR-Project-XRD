using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LavaRoomManager : MonoBehaviour
{
    private GameObject _crystal;
    private readonly List<GameObject> _crystalSpawnLocations = new();

    private void Start()
    {
        _crystalSpawnLocations.AddRange(GameObject.FindGameObjectsWithTag("CrystalSpawnLocation"));
        _crystal = GameObject.FindGameObjectWithTag("Crystal");
        SpawnCrystal();
    }

    private void SpawnCrystal()
    {
        Debug.Log("HEEEEEEEEEEEEEEEEREEEEEEEEEEEEEEEEEEE");
        var random = Random.Range(0, _crystalSpawnLocations.Count);
        _crystal.transform.position = _crystalSpawnLocations[random].transform.position;
    }
}