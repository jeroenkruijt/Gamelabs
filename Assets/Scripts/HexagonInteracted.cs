using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class HexagonInteracted : MonoBehaviour
    {
        public GameObject[] players;
        GameObject culprit;
        public void DoInteraction()
        {
            Debug.Log("OwO I'm a hexagon");
            for (int i = 0; i < players.Length; i++)
            {
                PlayerSideInteraction target = players[i].GetComponent<PlayerSideInteraction>();
                GameObject checker = target.inRange;
                if (checker = gameObject)
                {
                    culprit = players[i];
                }
            }
            culprit.SendMessage("DamageBuff");
        }


    }
}