using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;

public class Bomb : NetworkBehaviour
{
    public float explosionRadius = 5f;
    public float explosionDelay = 2f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    public IEnumerator Explode()
    {
        yield return new WaitForSeconds(explosionDelay);

        CmdExplode(transform.position, explosionRadius);
    }

    [Command]
    void CmdExplode(Vector3 position, float radius)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hit in hits)
        {
            NetworkServer.Destroy(hit.gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(Explode());
    }
}
