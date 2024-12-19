using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timePerTurn = 30f; // Thời gian mỗi lượt
    public float remainingTime; // Thời gian còn lại trong lượt hiện tại
    private bool isWhiteTurn = true; // Biến để xác định lượt của người chơi (true = trắng, false = đen)

    // Hàm khởi tạo
    void Start()
    {
        StartTurn(); // Bắt đầu với lượt trắng
    }

    // Cập nhật đồng hồ mỗi frame
    void Update()
    {
        // Kiểm tra nếu thời gian còn lại lớn hơn 0
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime; // Giảm thời gian theo mỗi frame
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;
            timerText.color = Color.red; // Khi hết thời gian, đổi màu chữ thành đỏ
            // Lượt kết thúc khi hết thời gian, nhưng việc chuyển lượt sẽ được thực hiện trong Game
        }

        // Cập nhật hiển thị đồng hồ
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    // Hàm bắt đầu một lượt mới
    public void StartTurn()
    {
        remainingTime = timePerTurn; // Đặt lại thời gian cho lượt mới (30 giây)
        timerText.color = Color.white; // Đặt lại màu chữ về trắng
    }

    // Hàm reset thời gian khi chuyển lượt
    public void ResetTime()
    {
        StartTurn(); // Gọi lại StartTurn để reset thời gian
    }
}