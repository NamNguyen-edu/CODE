using System;
using System.Text;

namespace GameTitleWithFrame
{
    class proj
    {
        static void Main(string[] args)
        {
            // Cho nó nhận tiếng việt có dấu
            Console.OutputEncoding = Encoding.UTF8;
            // Đảm bảo rằng con trỏ không hiển thị
            Console.CursorVisible = false;

            // Đặt kích thước cửa sổ Console (có thể điều chỉnh tùy nhu cầu)
            Console.SetWindowSize(125, 25);

            // Mảng chứa các dòng chữ của tên game "GOGREEN" với ký tự $ và khung = bao quanh
            string[] ShapeofGameName = new string[]
            {
                "=============================================================",
                "=                                                           =",
                "=  $$$$$   $$$$$$   $$$$$   $$$$$   $$$$$  $$$$$  $$$    $$ =",
                "= $$       $$   $$ $$       $$   $$ $$     $$     $$ $$  $$ =",
                "= $$  $$$  $$   $$ $$  $$$  $$$$$   $$$$   $$$$   $$  $$ $$ =",
                "= $$   $$  $$   $$ $$   $$  $$  $$  $$     $$     $$   $$$$ =",
                "=  $$$$$   $$$$$$   $$$$$   $$   $$ $$$$$  $$$$$  $$     $$ =",
                "=                                                           =",
                "============================================================="
            };

            // Đặt màu chữ thành màu xanh dương cho phần chữ và khung
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Gọi hàm hiển thị và căn giữa tên game "GOGREEN" với ký tự $ và khung bao quanh
            DisplayCenteredText(ShapeofGameName);

            // Giữ màn hình để người chơi có thể nhìn thấy tên game
            Console.ForegroundColor = ConsoleColor.Yellow;
            DisplayCenteredMessage("Nhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
            Console.Clear();

            // Reset lại màu về mặc định
            Console.ResetColor();
            InputPlayerInformation();
            Console.Clear();
            int roadOffset = Console.WindowWidth;  // Đường đi bắt đầu từ bên phải
            int objectX = Console.WindowWidth; // Vị trí vật thể
            int objectY = 8; // Vị trí Y của vật thể
                             //      int animalX = 5; // Vị trí X của con vật
                             //      int animalY = 10; // Vị trí Y của con vật

            // Vòng lặp chính của game
            while (true)
            {
                Console.Clear();  // Xóa màn hình mỗi lần vẽ lại

                // Vẽ phong cảnh
                DrawBackground();
                DrawRoad();

                // Di chuyển và vẽ vật thể
                objectX = MoveObject(objectX);
                DrawObject(objectX, objectY);

                // Vẽ con vật
                //  DrawAnimal(animalX, animalY);

                // Tạo hiệu ứng động mượt mà
                Thread.Sleep(250);
            }
        }

        // Hàm hiển thị các dòng chữ căn giữa
        static void DisplayCenteredText(string[] lines)
        {
            int windowWidth = Console.WindowWidth;  // Lấy chiều rộng của cửa sổ console
            int windowHeight = Console.WindowHeight; // Lấy chiều cao của cửa sổ console

            // Tính toán điểm bắt đầu của dòng đầu tiên để căn giữa theo chiều dọc
            int startRow = (windowHeight / 2) - (lines.Length / 2);

            for (int i = 0; i < lines.Length; i++)
            {
                // Tính toán vị trí x để căn giữa dòng hiện tại theo chiều ngang
                int padding = (windowWidth - lines[i].Length) / 2;

                // Di chuyển con trỏ đến vị trí để bắt đầu vẽ dòng
                Console.SetCursorPosition(padding, startRow + i);

                // Hiển thị dòng
                Console.WriteLine(lines[i]);
            }
        }
        static void DisplayCenteredMessage(string message)
        {
            int windowWidth = Console.WindowWidth;  // Lấy chiều rộng của cửa sổ console
            int windowHeight = Console.WindowHeight; // Lấy chiều cao của cửa sổ console

            // Tính toán vị trí x để căn giữa dòng thông báo
            int padding = (windowWidth - message.Length) / 2;

            // Di chuyển con trỏ đến vị trí cần thiết để căn giữa thông điệp
            Console.SetCursorPosition(padding, windowHeight / 2 + 6); // Vị trí dưới tên game

            // In thông điệp ra màn hình
            Console.WriteLine(message);
        }
        static void InputPlayerInformation()
        {
            // Đặt màu cho khung nhập
            Console.ForegroundColor = ConsoleColor.Red;

            // Mảng chứa các dòng khung nhập thông tin người chơi
            string[] inputFrame = new string[]
            {
                "==============================",
                "=     Nhập thông tin chơi     =",
                "==============================",
                "=  Tên:                       =",
                "=  MSSV:                      =",
                "=============================="
            };

            // Hiển thị khung nhập thông tin người chơi
            DisplayCenteredText(inputFrame);

            // Di chuyển con trỏ đến vị trí nhập Tên (dòng thứ 4 của khung)
            int windowWidth = Console.WindowWidth;
            int padding = (windowWidth - inputFrame[3].Length) / 2 + 8;
            // 8 là vị trí bắt đầu sau "Tên: "
            Console.SetCursorPosition(padding, Console.WindowHeight / 2);
            string playerName = Console.ReadLine();
            // Di chuyển con trỏ đến vị trí nhập MSSV (dòng thứ 5 của khung)
            padding = (windowWidth - inputFrame[4].Length) / 2 + 8;  // 8 là vị trí bắt đầu sau "MSSV: "
            Console.SetCursorPosition(padding, Console.WindowHeight / 2 + 1);
            string playerMSSV = Console.ReadLine();

            // Reset lại màu sau khi nhập
            Console.ResetColor();
        }
        static void DrawBackground()
        {
            // Vẽ mây và mặt trời
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("     \\   |   /    ");
            Console.WriteLine("  -      O      -  ");
            Console.WriteLine("     /   |   \\    ");
            Console.ResetColor();


        }

        static void DrawRoad()
        {
            Console.SetCursorPosition(0, 15);
            for (int i = 0; i < Console.WindowWidth - 5; i++)
            {
                Console.Write("█");
            }


        }

        static void DrawObject(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[*]");  // Vật thể là một ký tự đại diện
            Console.ResetColor();
        }

        static int MoveObject(int x)
        {
            return x - 2;  // Vật thể di chuyển sang trái
        }

        static void DrawAnimal(int x, int y)
        {
            string[] rabbit = new string[]
            {
            "  (\\(\\  ",
            "  (-.-)  ",
            " o_(\")(\")"
            };

            Console.SetCursorPosition(x, y);
            foreach (var line in rabbit)
            {
                Console.WriteLine(line);
            }

        }
    }
}
