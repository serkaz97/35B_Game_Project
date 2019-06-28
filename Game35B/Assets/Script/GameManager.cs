using System.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityHelpers;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : Singleton<GameManager>
{
    private GameObject _player;
    [SerializeField] private Vector3 _checkpointPosition;
    [SerializeField] private Vector3 _checkpointRotation;
    private float timer = 3f;

    private void SetPlayerTransform()
    {
        _player = GameObject.FindWithTag("Player");
        _player.GetComponent<FirstPersonController>().enabled = false;
        _player.GetComponent<CharacterController>().enabled = false;
        _player.transform.position = _checkpointPosition;
        _player.transform.rotation = Quaternion.Euler(_checkpointRotation);
        _player.GetComponent<FirstPersonController>().enabled = true;
        _player.GetComponent<CharacterController>().enabled = true;
    }

    private void Start()
    {
        SceneManager.sceneLoaded += (arg0, mode) => SetPlayerTransform();
        GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<LifeController>().LifeLevel = 100;
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetNewCheckpoint(Checkpoint checkpoint)
    {
        _checkpointPosition = checkpoint.transform.position;
        _checkpointRotation = checkpoint.transform.rotation.eulerAngles;
    }

    public GameObject GetPlayer()
    {
        _player = GameObject.FindWithTag("Player");
        return _player;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SceneManager.LoadScene(1);
            }
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            timer = 3f;
        }
    }
}
