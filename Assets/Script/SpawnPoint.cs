using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    void Awake()
    {
        Instantiate(Player, this.transform.position, this.transform.rotation);
    }

}
