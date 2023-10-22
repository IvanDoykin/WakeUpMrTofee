using System;
using UnityEngine;

public class TriggerReceiver : MonoBehaviour
{
    public Action<Collider2D> TriggerEnter;
    public Action<Collider2D> TriggerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEnter?.Invoke(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TriggerExit?.Invoke(collision);
    }
}
