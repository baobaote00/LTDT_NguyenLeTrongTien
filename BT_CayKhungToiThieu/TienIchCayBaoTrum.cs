/*
 *Ten:Luu Thi Kieu Oanh
 * MSSV: 19211TT1688 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CayBaoTrum
{
    class TienIchCayBaoTrum
    {
        /// <summary>
        /// ghi file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="c"></param>
        public static void GhiFile(string fileName)
        {
            BinaryWriter bw;
            int soDinh = 5;
            string[] strs = new string[soDinh];
            strs[0] = "0,4,0,5,2";
            strs[1] = "4,0,6,3,0";
            strs[2] = "0,6,0,8,0";
            strs[3] = "5,3,8,0,6";
            strs[4] = "2,0,0,6,0";

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
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// doc file
        /// tao ma tran trong so
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static int[][] TaoMaTranTrongSoTuFile(string fileName)
        {
            try
            {
                using (BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open)))
                {
                    int[][] mtTrongSo;
                    int x;
                    string st;
                    int soDinh = br.ReadInt32();
                    mtTrongSo = new int[soDinh][];
                    Console.WriteLine("So dinh {0}", soDinh);
                    for (int i = 0; i < soDinh; i++)
                    {
                        mtTrongSo[i] = new int[soDinh];
                        st = br.ReadString();
                        if (st != " ")
                        {
                            string[] dong = st.Split(',');
                            for (int j = 0; j < soDinh; j++)
                            {
                                x = int.Parse(dong[j]);
                                mtTrongSo[i][j] = x;
                            }
                        }
                    }
                    return mtTrongSo;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
       
        /// <summary>
        /// in ma tran
        /// </summary>
        /// <param name="mt"></param>
        public static void InMaTran(int[][] mt)
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
        /// thuat toan primm
        /// </summary>
        /// <param name="mtTrongSo"></param>
        /// <param name="soCanhDoThi"></param>
        /// <param name="soDinh"></param>
        /// <param name="tongTS"></param>
        /// <returns></returns>
        public static Canh[] Primm(int[][] mtTrongSo, int soDinh, out int tongTS)
        {
            //khai bao bien
            Canh[] ketQua = new Canh[soDinh - 1];
            int min = int.MaxValue;
            int soCanh = 0;
            tongTS = 0;
            int temp = -1;
            //dinhDaXet cac dinh chua xet danh dau = 0
            int[] dinhDaXet = new int[soDinh];
            for (int j = 0; j < soDinh; j++)
            {
                dinhDaXet[j] = 0;
            }

            //tim min dong thu 0
            int i = 0;
            for (i = 0; i < soDinh; i++)
            {
                if (min > mtTrongSo[0][i] && mtTrongSo[0][i] != 0)
                {
                    min = mtTrongSo[0][i];
                    ketQua[0] = new Canh();
                    ketQua[0].Cuoi = i;
                    ketQua[0].TrongSo = min;

                }
            }
            tongTS = tongTS + min;
            ketQua[0].Dau = 0;
            dinhDaXet[0] = 1; //danh dau dinh dau 0 da xet
            dinhDaXet[ketQua[0].Cuoi] = 1; // danh dau dinh cuoi da xet
            soCanh++;

            do
            {
                min = int.MaxValue;
                for (i = 0; i < soDinh; i++)
                {
                    if (dinhDaXet[i] == 1)
                    {
                        for (int j = 0; j < soDinh; j++)
                        {
                            if (dinhDaXet[j] == 1)
                            {
                                continue;
                            }
                            else
                            {
                                if ((min > mtTrongSo[i][j] && mtTrongSo[i][j] != 0))
                                {
                                    min = mtTrongSo[i][j];
                                    ketQua[soCanh] = new Canh();
                                    ketQua[soCanh].Dau = i;
                                    ketQua[soCanh].Cuoi = j;
                                    ketQua[soCanh].TrongSo = min;
                                    temp = j;
                                }
                            }
                        }
                    }
                }
                tongTS += min;
                dinhDaXet[temp] = 1; // danh dau dinh cuoi da xet
                soCanh++;
            } while (soCanh < soDinh - 1);
            //ghiFileKetQua(tongTS, ketQua, "Prim_OUT.DAT");
            return ketQua;
        }


    }
}
