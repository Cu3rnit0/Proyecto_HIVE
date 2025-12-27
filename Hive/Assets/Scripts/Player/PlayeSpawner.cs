using UnityEngine;

public class PlayeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;

    private bool spawned = false;

    public void SpawnLocalPlayer()
    {
        Debug.Log("SpawnLocalPlayer ejecutado");

        GameObject player = Instantiate(
            playerPrefab,
            Vector3.up * 2,
            Quaternion.identity
        );

        player.name = "LocalPlayer";

        Debug.Log("Player creado con cámara");
    }
}

