using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : Interactable
{
    [Header("이동할 씬")] public Object scene;
    [Header("스폰 이름")] public string spawnName;
    [Header("이동 딜레이")] public int delay;
    private Teleportable player;
    private FadeInOut fade;

    private void Awake()
    {
        fade = GetComponent<FadeInOut>();
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<Teleportable>();
    }

    protected override void Interact()
    {
        if (player != null)
        {
            OnEnter(player);
        }
    }

    private void OnEnter(Teleportable player)
    {
        if (player._canTp == false)
        {
            return;
        }

        player._canTp = false;

        if (SceneManager.GetActiveScene().name == scene.name)
        {
            Teleport(player);
        }
        else
        {
            StartCoroutine(TeleportToNewScene(scene.name, player));
        }
    }

    private IEnumerator TeleportToNewScene(string sceneName, Teleportable player)
    {
        fade.fadeIn = true;
        yield return new WaitForSeconds(delay);
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation newSceneAsyncLoad = SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Additive);

        while (!newSceneAsyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(player.gameObject, SceneManager.GetSceneByName(sceneName));
        Teleport(player);

        SceneManager.UnloadSceneAsync(currentScene);
    }

    private void Teleport(Teleportable player)
    {
        SpawnPoint spawnPoint = FindSpawnPoint(spawnName);
        if (spawnPoint != null)
        {
            player.transform.position = spawnPoint.transform.position;
        }
        player._canTp = true;
    }

    private SpawnPoint FindSpawnPoint(string spawnName)
    {
        SpawnPoint[] spawnPoints = FindObjectsOfType<SpawnPoint>();
        foreach (SpawnPoint spawn in spawnPoints)
        {
            SpawnPoint spawnPoint = spawn.GetComponent<SpawnPoint>();
            if (spawnPoint.pointName == spawnName)
            {
                return spawnPoint;
            }
        }
        return null;
    }
}
