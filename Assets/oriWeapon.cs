using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oriWeapon : MonoBehaviour
{
    private float attackRange = 5;
    [SerializeField] GameObject rangeIndicator;
    private Vector3 centerLoc;

    private void Update()
    {
        rangeIndicator.transform.position = transform.position + new Vector3(attackRange / 2, 0, 0);
        centerLoc = rangeIndicator.transform.position;
        Collider[] colliders = Physics.OverlapSphere(centerLoc, attackRange / 2);
        foreach (var collider in colliders)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (collider.gameObject.CompareTag("damageAble"))
                {
                    Destroy(collider.gameObject);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(centerLoc, attackRange / 2);
    }
}
