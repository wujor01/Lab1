using System;
using System.Text;

namespace ConsoleAppLab1
{
    class Program
    {
        private static int NumberCopied(int[] sourceArray, int lengthSourceArray, int startPointSourceArray, int endPointSourceArray, int[] destinationArray, int lengthDestinationArray, int positionStartDestinationArray)
        {
            //Kiểm tra tham số đầu vào (độ dài mảng nguồn)
            if (lengthSourceArray < sourceArray.Length) return 0;
            Array.Resize(ref sourceArray, lengthSourceArray);
            int[] arrayCopy = null;
            //Kiểm tra tham số đầu vào (điểm bắt đầu và kết thúc)
            if (startPointSourceArray < 0 || endPointSourceArray < 0 || endPointSourceArray <= startPointSourceArray || endPointSourceArray >= sourceArray.Length || startPointSourceArray > sourceArray.Length) return 0;
            else
            {
                //Tạo mảng mới chứa mảng được sao chép từ mảng đích
                int temp = 0;
                arrayCopy = new int[endPointSourceArray - startPointSourceArray];
                for (int i = startPointSourceArray; i < endPointSourceArray; i++)
                {
                    arrayCopy[temp] = sourceArray[i];
                    temp++;
                }
            }
            //Kiểm tra tham số đầu vào (độ dài mảng đích)
            if (lengthDestinationArray < destinationArray.Length) return 0;
            int totalIntAdded = lengthDestinationArray - destinationArray.Length;
            //Kiểm tra xem độ dài của mảng đích có đủ chứa thêm mảng Copy hay không nếu không thì cắt bớt mảng Copy đi
            if (totalIntAdded < arrayCopy.Length)
            {
                Array.Resize(ref arrayCopy, totalIntAdded);
                totalIntAdded = arrayCopy.Length;
            }
            Array.Resize(ref destinationArray, lengthDestinationArray);
            
            //Kiểm tra tham số đầu vào (vị trí bắt đầu thêm vào các dữ liệu trong mảng đích)
            if (positionStartDestinationArray > lengthDestinationArray) return 0;
            else
            {
                //Tạo mảng mới chứa dữ liệu từ vị trí đầu mảng đến vị trí chèn mảng mới
                var tempArray = destinationArray;
                Array.Resize(ref tempArray, positionStartDestinationArray);
                
                //Resize mảng tạm về đúng kích thước đầu
                Array.Resize(ref tempArray, destinationArray.Length);
                
                //Chuyển mảng copy vào mảng tạm ở vị trí đã được chỉ định
                Array.Copy(arrayCopy,0,tempArray,positionStartDestinationArray,totalIntAdded);
                //Chuyển các các số trong các mảng còn lại của mảng đích vào mảng tạm
                Array.Copy(destinationArray, positionStartDestinationArray, tempArray, positionStartDestinationArray + totalIntAdded, destinationArray.Length - (positionStartDestinationArray + totalIntAdded));
                
                return totalIntAdded;
            }
        }
        private static int[] RandomArray(int lengthRandomArray)
        {
            Random randNum = new Random();
            int[] arrInt = new int[lengthRandomArray];
            for (int i = 0; i < arrInt.Length; i++)
            {
                arrInt[i] = randNum.Next(1, 100);
            }
            return arrInt;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int temp = NumberCopied(RandomArray(10), 15, 2, 5, RandomArray(8), 10, 2);

            Console.Write("Số phần tử được chèn vào mảng là " + temp);
            Console.ReadLine();

            #region Nhập tay
            //string input = null;
            //Console.WriteLine("------Menu------");
            //Console.WriteLine("1.Mảng tự tạo ngẫu nhiên.");
            //Console.WriteLine("2.Mảng nhập tay.");
            //Console.Write("Vui lòng Chọn(1 hoặc 2): ", input);
            //input = Console.ReadLine();
            //int number;
            //bool isNumber = Int32.TryParse(input, out number);
            //if (!isNumber)
            //{
            //    Console.Write("Vui lòng Nhập lại chọn(1 hoặc 2): ", input);
            //    input = Console.ReadLine();
            //}
            //else
            //{
            //    if (number > 2)
            //    {
            //        Console.Write("Vui lòng Nhập lại chọn(1 hoặc 2): ", input);
            //        input = Console.ReadLine();
            //    }
            //    else if (number == 1)
            //    {
            //        Console.Write("Nhập chiều dài Mảng nguồn các số nguyên: ", input);
            //        input = Console.ReadLine();
            //        Console.Write("Điểm bắt đầu sao chép trong mảng nguồn: ", input);
            //        input = Console.ReadLine();
            //        Console.Write("Điểm kết thúc trong mảng nguồn: ", input);
            //        input = Console.ReadLine();
            //        Console.Write("Mảng đích các số nguyên(chiều dài tạo mảng random): ", input);
            //        input = Console.ReadLine();
            //        Console.Write("Chiều dài của mảng đích: ", input);
            //        input = Console.ReadLine();
            //        Console.Write("Vị trí bắt đầu thêm vào các dữ liệu trong mảng đích: ", input);
            //        input = Console.ReadLine();
            //        //Nhập tham số truyền vào nếu tham số chính xác thì sẽ return về số phần tử được chèn vào mảng đích
            //        int temp = NumberCopied(RandomArray(10), 15, 2, 5, RandomArray(8), 10, 2);

            //        Console.Write("Số phần tử được chèn vào mảng: " + temp);
            //        Console.ReadLine();
            //    }
            //    else if (number == 2)
            //    { 

            //    }
            //}
            #endregion
        }
    }
}
