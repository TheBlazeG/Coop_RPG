using Fusion;
using UnityEngine;

public abstract class ItemBase : NetworkBehaviour
{
    public virtual void UseItem() { Debug.Log("item used"); }
}
