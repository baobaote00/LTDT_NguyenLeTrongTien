/**
 * TEN: NGUYỄN LÊ TRỌNG TIỀN
 * MSSV: 19211TT4165
 * NGAY: 10/12/2020
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace ChuTrinhEuler
{
    class TienIch_Euler
    {
        //ghi file
        public static void GhiFile(string fileName)
        {
            BinaryWriter bw;
            int soDinh = 6;

            //Nhap danh sach dinh ke
            string[] strs = new string[soDinh];
            strs[0] = "1,2,3,4";
            strs[1] = "0,2,3,5";
            strs[2] = "0,1,3,5";
            strs[3] = "0,1,2,4";
            strs[4] = "0,3";
            strs[5] = "1,2";

            try
            {
                bw = new BinaryWriter(new FileStream(fileName, FileMode.Create));
                bw.Write(soDinh);
                foreach (var k in strs)
                {
                    bw.Write(k);
                }
                bw.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("khong ghi duoc file");
            }


        }
        //doc file
        public static List<LinkedList<int>> DocFile(string fileName)
        {
            List<LinkedList<int>> danhsachke = new List<LinkedList<int>>();
            int x = 0;
            string s0 = "";
            BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open));

            try
            {
                int soDinh = br.ReadInt32();
                Console.WriteLine("So dinh: {0}", soDinh);

                for (int i = 0; i < soDinh; i++)
                {
                    LinkedList<int> t = new LinkedList<int>();
                    s0 = br.ReadString();

                    if (s0 != "")
                    {
                        string[] danhsachdinhke = s0.Split(',');
                        for (int j = 0; j < danhsachdinhke.Length; j++)
                        {
                            x = int.Parse(danhsachdinhke[j]);

                            t.AddLast(x);
                        }
                    }
                    danhsachke.Add(t);
                }
                br.Close();
                return danhsachke;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        //in danh sach ke
        public static void InThongTin(List<LinkedList<int>> danhsachke)
        {
            int i = 0;
            foreach (var item in danhsachke)
            {
                Console.Write("Dinh {0} ke voi dinh: ", i);
                foreach (var item1 in item)
                {
                    Console.Write(item1 + " ");
                }
                Console.WriteLine();
                i++;
            }
        }

        //Kiem tra tinh lien thong
        public static bool KiemTraTinhLienThong(List<LinkedList<int>> danhsachke)
        {
            bool ketQua = true;
            int[] dinhDaXet = new int[danhsachke.Count];
            Queue<int> q = new Queue<int>();
            int dinhXet = -1;

            dinhDaXet[0] = 1; //gán nhãn phần tử dã xét thành 1
            q.Enqueue(0);

            while (q.Count > 0) //tại đây count = 1
            {
                dinhXet = q.Dequeue();
                if (danhsachke[dinhXet].Count != 0)
                {
                    foreach (var item in danhsachke[dinhXet])
                    {
                        if (dinhDaXet[item] == 0)
                        {
                            dinhDaXet[item] = 1;
                            q.Enqueue(item);
                        }
                    }
                }
            }
            //kiểm tra tính liên thông
            foreach (var item in dinhDaXet)
            {
                if (item == 0)
                {
                    ketQua = false;
                    break;
                }
            }
            return ketQua;

        }
        //Tinh bac cua dinh
        public static void BacCuaDinh(List<LinkedList<int>> danhsachke)
        {
            int i = 0;
            foreach (var item in danhsachke)
            {
                i++;
            }
        }

        //Viet chu trinh euler
        public static List<int> ChuTrinhEuler(List<LinkedList<int>> dske, int start)
        {
            Stack<int> st = new Stack<int>();
            List<int> kq = new List<int>();
            LinkedListNode<int> node = new LinkedListNode<int>(-1);
            int x = -1;
            int y = -1;

            st.Push(start);
            while (st.Count != 0)
            {
                x = st.Peek();
                if (dske[x].Count != 0)
                {
                    node = dske[x].First;
                    y = node.Value;

                    st.Push(y);
                    Console.Write("" + x + y + "\t");
                    dske[x].Remove(y);
                    dske[y].Remove(x);
                }
                else
                {
                    x = st.Pop();
                    kq.Add(x);
                }
            }
            Console.WriteLine();
            return kq;
        }
    }
}
