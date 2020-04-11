using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemPickUp : MonoBehaviour
{
    /* 
     * Summary
     * 
     * List of items needed to go find and pick of for the quest.
     * They are tracked using a tag.
     * When the player finds the item there is a prompt to pick it up.
     * After the player picks it up, a second passes and some particle affects appear and the item poofs
     * Then it is added to a list that tracks how many items have been collected. Only need 3 or 5 for quest.
     * 
     * End Summary
     */

    public List<GameObject> questItems;

    public void Update()
    {
        
    }






}
