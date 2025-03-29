using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Live : MonoBehaviour
{
    public int totalLives = 3;  // จำนวนชีวิตเริ่มต้น
    public int currentLives;
    public TMP_Text livesText;  // ลิงก์กับ Text UI
    public string gameOver; 

    private void Start()
    {
        // กำหนดค่าชีวิตเริ่มต้น
        currentLives = totalLives;
        UpdateLivesUI();

        
    }

    private void UpdateLivesUI()
    {
        // อัปเดตข้อความใน UI
        livesText.text = "Lives: " + currentLives;

    }

    void OnCollisionEnter(Collision collision) // ตรวจจับการชน
    {
        // ตรวจสอบว่าชนกับวัตถุที่มี tag "player" หรือไม่
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(); // เรียกฟังก์ชันลดเลือด
        }
    }

    public void TakeDamage()  // ลดเลือด UI
    {
        currentLives--;  // ลดจำนวนชีวิตลง
        UpdateLivesUI();  // อัปเดต UI
        if (currentLives <= 0)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(gameOver);

        }
    }

    

}
