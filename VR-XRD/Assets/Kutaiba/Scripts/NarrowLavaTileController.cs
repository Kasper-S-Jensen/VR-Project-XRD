using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Kutaiba.Scripts
{
    public class NarrowLavaTileController: MonoBehaviour, ILavaManager
    {
        private GameObject _crystal;
        private GameObject _player;
        private readonly List<GameObject> _crystalSpawnLocations = new();
        private GameObject _playerSpawnLocations;

        private void Start()
        {
            _crystalSpawnLocations.AddRange(GameObject.FindGameObjectsWithTag("CrystalSpawnLocation"));
            _player = GameObject.FindGameObjectWithTag("Player");
            _crystal = GameObject.FindGameObjectWithTag("Crystal");
            _playerSpawnLocations = GameObject.FindGameObjectWithTag("PlayerSpawnLocation");
        }

        private void MoveCrystal()
        {
            var random = Random.Range(0, _crystalSpawnLocations.Count);
            _crystal.transform.position = _crystalSpawnLocations[random].transform.position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            SetCollisionParameters(collision);
        }

        public void SetCollisionParameters(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("PLAYER");
                _player.transform.position = _playerSpawnLocations.transform.position;
            }

            if (collision.gameObject.CompareTag("Crystal"))
            {
                Debug.Log("CRYSTAL");
                MoveCrystal();
            }
        }
    }
}