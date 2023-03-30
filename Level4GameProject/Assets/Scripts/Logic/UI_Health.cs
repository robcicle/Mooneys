using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour
{
	[SerializeField]
	private Sprite FourWheel;
	[SerializeField]
	private Sprite ThreeWheel;
	[SerializeField]
	private Sprite TwoWheel;
	[SerializeField]
	private Sprite OneWheel;
	[SerializeField]
	private Sprite NoWheel;

	[SerializeField]
	private Image playerHealthUI;
	
    public void UpdateHealthUI(int playerHealth)
	{
		if (playerHealth >= 4)
		{
			playerHealthUI.sprite = FourWheel;
		}
		else if (playerHealth == 3)
		{
			playerHealthUI.sprite = ThreeWheel;
		}
        else if (playerHealth == 2)
        {
            playerHealthUI.sprite = TwoWheel;
        }
        else if (playerHealth == 1)
        {
            playerHealthUI.sprite = OneWheel;
        }
        else if (playerHealth <= 0)
        {
            playerHealthUI.sprite = NoWheel;
        }
    }
}
