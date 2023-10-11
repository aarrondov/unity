using UnityEngine;

public class LadderDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("collid");
        if (other.CompareTag("Player"))
        {
            // El collider del jugador ha tocado el collider de la escalera
            print("Player encontrado");
        }
    }
}