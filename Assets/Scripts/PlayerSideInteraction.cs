using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PlayerSideInteraction : MonoBehaviour
    {
        [SerializeField]
        public GameObject inRange = null;
        [Header("Stats:")]
        [SerializeField]
        int health = 5;
        [SerializeField]
        int armor = 0;
        [SerializeField]
        int damage = 1;
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Interactable"))
            {
                Debug.Log("notices your player UwU");
                inRange = other.gameObject;
            }
        }
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Interactable") && other.gameObject == inRange)
            {
                Debug.Log("Don't leave me :(");
                inRange = null;
            }
        }

        void Update()
        {
            if(Input.GetButtonDown("Interact") && inRange)
            {
                inRange.SendMessage("DoInteraction");
            }

            if (Input.GetButtonDown("Attack"))
            {
                Debug.Log("bonk go to horny jail");
            }

            if (health <= 0)
            {
                Destroy (this.gameObject);
            }
        }

        public void goFuckYourself()
        {
            health = health-(3-armor);
        }

        public void HealthBuff()
        {
            int preBuffHP = health;
            health++;
        }

        public IEnumerator ArmorBuff()
        {
            int preBuffArmor = armor;
            armor++;
            yield return new WaitForSeconds(5);
            if (armor > preBuffArmor)
            {
                armor--;
            }
        }

        public IEnumerator SpeedBuff()
        {
            PlayerController target = gameObject.GetComponent<PlayerController>();
            target.walkSpeed = 10f;
            yield return new WaitForSeconds(5);
            target.walkSpeed = 4f;
        }

        public IEnumerator DamageBuff()
        {
            int preBuffDamage = damage;
            damage++; 
            yield return new WaitForSeconds(5);
            if (damage > preBuffDamage)
            {
                damage--;
            }
        }

    }
}
