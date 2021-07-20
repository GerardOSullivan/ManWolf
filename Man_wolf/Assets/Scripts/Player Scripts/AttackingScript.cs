using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingScript : MonoBehaviour
{
    public int baseDamage = 10;
    public float hitRange = 2.5f;
    public Camera firstPersonCamera;
    public KeyCode mouseAttackButton = KeyCode.Mouse0;
    private Tree tree;

    // Update is called once per frame
    void Update()
    {
        Ray ray = firstPersonCamera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
        RaycastHit hitInfo;

        if(Input.GetKeyDown(mouseAttackButton))
        {
            if(Physics.Raycast(ray, out hitInfo, hitRange))
            {
                if(hitInfo.collider.tag == "tree")
                {
                    tree = hitInfo.collider.GetComponentInParent<Tree>();
                    DamageTree();
                    Debug.Log("Tree hit. health = " + tree.health);
                }
            }
        }
    }

    void DamageTree()
    {
        tree.health -= baseDamage;
    }
}
