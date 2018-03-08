using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutter : MonoBehaviour {

    public Material capMaterial;

    void OnCollisionEnter(Collision coll)
    {
        GameObject victis = coll.gameObject;
        GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victis, transform.position, transform.right, capMaterial);

        if (!pieces[1].GetComponent<Rigidbody>())
        {
            pieces[1].AddComponent<Rigidbody>();
        }

        Destroy(pieces[1], 1);

        if (victis.tag == "ResetUI")
        {
            spawn.Instance.ResetGame();
            Rigidbody rigidbody = pieces[0].GetComponent<Rigidbody>();
            rigidbody.useGravity = true;
            Destroy(pieces[0], 1f);
        }
        else if (victis.tag == "Respawn")
            spawn.Instance.addscore(-100);
        else
            spawn.Instance.addscore(20);
    }
}
