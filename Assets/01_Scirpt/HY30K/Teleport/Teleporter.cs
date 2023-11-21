using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : Interactable
{
    [Header("�̵��� ��")] public Object scene;
    [Header("���� �̸�")] public string spawnName;
    [Header("�̵� ������")] public int delay;
    private Teleportable player;

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<Teleportable>();
        Debug.Log(other.gameObject.name);
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
        yield return new WaitForSeconds(delay);
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation newSceneAsyncLoad = SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Additive);

        while (!newSceneAsyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
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
        Debug.LogError(spawnPoints.Length);
        return null;
    }
}
