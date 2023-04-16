using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics.Contracts;

namespace GameKeoBuaBao
{
    public partial class Form1 : Form
    {
        int rounds =3;//lượt chơi 
        int timerPerRound = 6;//thời gian chạy 
        bool gameOver = false;//check xem hết 1 ván game chưa 

        //tạo Random cho CPU chọn
        string[] CPUchoiceList = { "rock", "paper", "scrissors", "rock", "paper", "scrissors" };
        int randomNumber = 0;//chỉ số của mảng
        Random rnd = new Random();

        //lựa chọn của CPU và Player
        string CPUChoice;
        string PlayerChoice;

        //Điểm của Player và CPU
        int PlayerScore;
        int CPUScore;

        public Form1()
        {
            InitializeComponent();
            countDownTimer.Enabled= true;//thời gian bắt đầu chạy
            PlayerChoice = "none";//người chơi không chọn gì
            lblCountDown.Text = "5";

        }

        //Xử lý các lựa chọn của người chơi
        private void btnRock_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.rock;
            PlayerChoice= "rock";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.paper;
            PlayerChoice= "paper";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.scissors;
            PlayerChoice= "scrissors";
        }


        //làm mới lại game
        private void btnRestart_Click(object sender, EventArgs e)
        {
            //trả lại giá trị ban đầu
            PlayerScore= 0;
            CPUScore= 0;
            rounds = 3;

            lblScore.Text = "Player: " + PlayerScore + "  CPU: " + CPUScore;

            countDownTimer.Enabled = true;//bắt đầu lại bộ đếm thời gian

            //trả lại hình ảnh ban đầu 
            picPlayer.Image = Properties.Resources.qq;
            picCPU.Image = Properties.Resources.qq;

            gameOver = false;//đánh dấu chưa kết thúc game
        }



        private void countDownTimer_Tick(object sender, EventArgs e)
        {
            //Thời gian giảm dần
            timerPerRound -= 1;
            lblCountDown.Text=timerPerRound.ToString();

            //Lượt chơi
            lblRounds.Text = "Rounds: " + rounds;

            //Nếu thời gian chạy về 0
            if (timerPerRound < 1)
            {
                countDownTimer.Enabled = false;//dừng thời gian
                timerPerRound= 6;//Trả lại giá trị để bắt đầu lượt chơi tiếp theo

                //Xử lý lựa chọn cho CPU
                randomNumber= rnd.Next(0,CPUchoiceList.Length);
                CPUChoice = CPUchoiceList[randomNumber];

                switch(CPUChoice)
                {
                    case "rock":
                        picCPU.Image = Properties.Resources.rock;
                        break;
                    case "paper":
                        picCPU.Image = Properties.Resources.paper;
                        break;
                    case "scrissors":
                        picCPU.Image = Properties.Resources.scissors;
                        break;
                }

                //Xử lý từng lượt chơi đến khi kết thúc 1 ván
                if (rounds > 0)
                {
                    checkGame();
                }
                else
                {
                    if (PlayerScore > CPUScore)
                    {
                        MessageBox.Show("Player won the game !");
                    }
                    else
                    {
                        MessageBox.Show("CPU won the game !");
                    }
                    gameOver = true;//đãkết thúc 1 ván game
                }
            }           
        }


        //Xử lý thắng - thua trong Game
        private void checkGame()
        {
            if (PlayerChoice == "rock" && CPUChoice == "paper")
            {
                CPUScore++;//tăng điểm
                rounds--;//Giảm số lượng lượt chơi
                MessageBox.Show("CPU Win");
            }
            else if (PlayerChoice == "scrissors" && CPUChoice == "rock")
            {
                CPUScore++;
                rounds--;
                MessageBox.Show("CPU Win");
            }
            else if (PlayerChoice == "paper" && CPUChoice == "scrissors")
            {
                CPUScore++;
                rounds--;
                MessageBox.Show("CPU Win");
            }
            else if (PlayerChoice == "rock" && CPUChoice == "scrissors")
            {
                PlayerScore++;
                rounds--;
                MessageBox.Show("Player Win");
            }
            else if (PlayerChoice == "paper" && CPUChoice == "rock")
            {
                PlayerScore++;
                rounds--;
                MessageBox.Show("Player Win");
            }
            else if (PlayerChoice == "scrissors" && CPUChoice == "paper")
            {
                PlayerScore++;
                rounds--;
                MessageBox.Show("Player Win");
            }
            else if (PlayerChoice == "none") //người chơi không chọn gì
            {
                MessageBox.Show("Make a choice");

            }
            else { MessageBox.Show("Equals !!!"); }// Các trường hợp bằng nhau

            startNextRound();//Bắt đầu ván mới
        }

        //Xử lý ván chơi tiếp theo
        private void startNextRound()
        {
            if (gameOver==true)//nếu đã kết thúc game
            {
                return;
            }

            //Nếu chưa hết 1 ván chơi
            lblScore.Text = "Player: " + PlayerScore + "  CPU: " + CPUScore;//cập nhật điểm số của Player và CPU

            countDownTimer.Enabled = true;//resert lại bộ đếm thời gian

            //trả lại hình ảnh ban đầu
            picPlayer.Image = Properties.Resources.qq;
            picCPU.Image = Properties.Resources.qq;
        }

    }
}