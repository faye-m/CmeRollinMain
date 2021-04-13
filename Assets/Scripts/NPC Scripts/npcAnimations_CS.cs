using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcAnimations_CS : MonoBehaviour
{
    [SerializeField] private Animator npcAnim = null;
    [SerializeField] private int animVar = 0;
    // Start is called before the first frame update
    void Start()
    {
        npcAnim.SetBool("BG_Idle", true);
        
        switch (animVar) 
        {
            case 2:
                npcAnim.Play("Base Layer.NPC_Agitated_Anim");
                break;
            case 1:
                npcAnim.Play("Base Layer.NPC_Typing_Anim");
                break;
            default:
                npcAnim.Play("Base Layer.NPC_headinhand_Anim");
                break;
        }
    }
}
