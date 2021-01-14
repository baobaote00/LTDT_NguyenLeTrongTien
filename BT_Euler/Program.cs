/**
 * TEN: NGUYỄN LÊ TRỌNG TIỀN
 * MSSV: 19211TT4165
 * NGAY: 10/12/2020
 */
using System;
using System.Collections.Generic;

namespace ChuTrinhEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "danhsachbat.dat";
            List<LinkedList<int>> danhsachke = new List<LinkedList<int>>();
            List<int> CTE = new List<int>();
            //ghi danh sach ke vao file
            TienIch_Euler.GhiFile(fileName);
            danhsachke = TienIch_Euler.DocFile(fileName);
            //in thông tin danh sach ke
            TienIch_Euler.InThongTin(danhsachke);
            //in bac cua dinh
            Console.WriteLine();
            TienIch_Euler.BacCuaDinh(danhsachke);
            Console.WriteLine();
            //Xet tinh lien thong
            if (!TienIch_Euler.KiemTraTinhLienThong(danhsachke))
            {
                Console.WriteLine("Do thi khong co tinh lien thong");
            }
            else
            {
                Console.WriteLine("Do thi co tinh lien thong");
            }
            Console.WriteLine();

            //Duong euler
            Console.WriteLine("Quy trinh xoa canh trong do thi:");
            CTE = TienIch_Euler.ChuTrinhEuler(danhsachke, 0);
            Console.WriteLine("Duong di cua chu trinh Euler: ");
            for (int i = CTE.Count-1 ; i >= 0; i--)
            {
                Console.Write(CTE[i] + "\t");
            }
            Console.WriteLine();


        }
    }
}