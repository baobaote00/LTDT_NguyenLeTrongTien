/**
 * TEN: NGUYỄN LÊ TRỌNG TIỀN
 * MSSV: 19211TT4165
 * NGAY: 3/12/2020
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToMau
{
    class TienIchToMau
    {
        /// <summary>
        /// doc file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static int[][] DocFile(string fileName)
        {
            int[][] mt;

            int x = 0;//ghi lại dòng thứ mấy
            string str = "";//để ghi lại dữ liệu của một dòng trong file sang chuỗi 
            BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open));
            int soDinh = br.ReadInt32();//đọc số dòng
            mt = new int[soDinh][];//khởi tạo mt với số hàng = số dòng vừa đọc được trong file
            //doc file tao danh sach dinh ke bang 
            try
            {

                Console.WriteLine("So dinh: {0}", soDinh);
                //doc lan luot cac dong, tao ma tran ke
                for (int i = 0; i < soDinh; i++)
                {
                    mt[i] = new int[soDinh];

                    //Console.WriteLine("dinh dang xet {0}:  ", i);
                    str = br.ReadString();//
                    if (str != "")
                    {
                        string[] dong = str.Split(new Char[] { ',' });
                        for (int j = 0; j < soDinh; j++)
                        {
                            x = int.Parse(dong[j]);
                            mt[i][j] = x;
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Khong the doc file.");
            }
            br.Close();
            return mt;

        }
        /// <summary>
        /// in ma tran
        /// </summary>
        /// <param name="mt"></param>
        public static void inMaTran(int[][] mt)
        {
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int j = 0; j < mt.GetLength(0); j++)
                {
                    Console.Write(mt[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// ghi file 
        /// </summary>
        /// <param name="fileName"></param>
        public static void GhiFile(string fileName)
        {
            BinaryWriter bw;
            int soDinh = 6;

            //Nhap 
            string s0 = "0,1,1,1,0,1";
            string s1 = "1,0,1,0,0,0";
            string s2 = "1,1,0,1,1,0";
            string s3 = "1,0,1,0,0,1";
            string s4 = "0,0,1,0,0,1";
            string s5 = "1,0,0,1,1,0";

            //string s0 = "0,1,1,0,0,1";
            //string s1 = "1,0,1,1,1,1";
            //string s2 = "1,1,0,1,0,0";
            //string s3 = "0,1,1,0,1,0";
            //string s4 = "0,1,0,1,0,1";
            //string s5 = "1,1,0,0,1,0";

            try
            {
                bw = new BinaryWriter(new FileStream(fileName, FileMode.Create));
                bw.Write(soDinh);
                bw.Write(s0);
                bw.Write(s1);
                bw.Write(s2);
                bw.Write(s3);
                bw.Write(s4);
                bw.Write(s5);

                bw.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("khong ghi duoc file");
            }

        }
        /// <summary>
        /// tinh bac cua dinh
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        public static int[] TinhBacCuaDinh(int[][] mt)
        {
            int[] kq = new int[mt.GetLength(0)];
            int dem = 0;
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int j = 0; j < mt.GetLength(0); j++)
                {
                    if (mt[i][j] > 0)
                    {
                        dem++;
                    }
                }
                kq[i] = dem;
                dem = 0;
            }
            return kq;
        }
        /// <summary>
        /// in bac cua dinh
        /// </summary>
        /// <param name="arr"></param>
        public static void InBac(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Bac cua dinh " + i + ": " + arr[i]);
            }
        }
        /// <summary>
        /// tim dinh co bac lon nhat
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        public static int TimDinhBacMax(int[] soBac, List<List<int>> camTo, int[] kqToMau, int mau)
        {
            int max = int.MinValue;
            int dinh = -1;
            for (int i = 0; i < soBac.Length; i++)
            {
                if (kqToMau[i] == 0)
                {
                    if (!camTo[i].Contains(mau) && max < soBac[i])
                    {
                        max = soBac[i];
                        dinh = i;
                    }
                }
            }
            return dinh;
        }

        public static int[] ToMauHeuristic(int[][] mt)
        {
            int soDinh = mt.GetLength(0);
            int[] kqToMau = new int[soDinh];
            //int[] bangMau = { 1, 2, 3, 4 };
            List<List<int>> camTo = new List<List<int>>();
            //List<int> mauCam = new List<int>();
            int[] soBac = TinhBacCuaDinh(mt);
            //mauCam.Add(-1);
            int dinhMax = 0;
            int mau = 1;

            //
            for (int i = 0; i < soDinh; i++)
            {
                camTo.Add(new List<int>());
            }
           
            //
            while (CheckToMau(kqToMau))
            {
                Console.WriteLine("--------------------------------------------------------");
                dinhMax = TimDinhBacMax(soBac, camTo, kqToMau, mau);
                if (dinhMax != -1)
                {
                    Console.WriteLine("Dinh Lon Nhat: {0}", dinhMax);
                    Console.WriteLine("To mau {0} cho dinh {1}", mau, dinhMax);
                    kqToMau[dinhMax] = mau;
                    HaBac(soBac, mt, camTo, dinhMax, mau);
                }
                else
                {
                    break;
                }

                if (KiemTraDoiMau(camTo, kqToMau, mau)) mau++;

            }

            //foreach (var item in camTo)
            //{
            //    foreach (var item2 in item)
            //    {
            //        Console.WriteLine(item2);
            //    }
            //}

            return kqToMau;
        }

        public static bool CheckToMau(int[] kq)
        {
            bool check = true;
            foreach (var item in kq)
            {
                if (item == -1)
                {
                    check = false;
                    break;
                }
            }
            return check;
        }

        public static void HaBac(int[] soBac, int[][] mt, List<List<int>> camTo, int dinh, int mau)
        {
            Console.WriteLine(mt.GetLength(0));
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                Console.WriteLine(dinh);
                if (mt[dinh][i] > 0 && mt[dinh][i] < mt.GetLength(0) - 1)
                {
                    Console.WriteLine("Ha Bac Dinh {0}", i);
                    if (soBac[i] > 0)
                    {
                        soBac[i]--;
                    }
                    if (!camTo[i].Contains(mau))
                    {
                        Console.WriteLine("Cam To Dinh {0} - Mau {1}", i, mau);
                        camTo[i].Add(mau);
                    }
                }
            }
            soBac[dinh] = 0;
        }

        public static bool KiemTraDoiMau(List<List<int>> camTo, int[] kqToMau, int mau)
        {
            List<int> daTo = new List<int>();
            for (int i = 0; i < kqToMau.Length; i++)
            {
                if (kqToMau[i] == mau)
                {
                    daTo.Add(i);
                }
            }

            for (int i = 0; i < camTo.Count; i++)
            {
                if (!daTo.Contains(i) && !camTo[i].Contains(mau) && kqToMau[i] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void inBangMau(int[] kqBangMau)
        {
            Console.WriteLine("--------------------------Bang Mau------------------------");
            for (int i = 0; i < kqBangMau.Length; i++)
            {
                Console.WriteLine("Dinh {0} To Mau {1}", i, kqBangMau[i]);
            }
        }
    }
}
