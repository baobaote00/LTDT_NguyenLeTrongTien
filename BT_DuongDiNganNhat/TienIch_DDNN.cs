/**
 * TEN: NGUYỄN LÊ TRỌNG TIỀN
 * MSSV: 19211TT4165
 * NGAY: 3/12/2020
 */
using System;
using System.IO;

namespace DuongDiNganNhat
{
    class TienIch_DDNN
    {
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
                    mtTrongSo = new int[soDinh][];// khởi tạo mt với số hàng = số dòng vừa đọc được trong file
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
        public static void GhiFile_MTTS(string fileName)
        {
            BinaryWriter bw;
            int soDinh = 6;

            //Nhap danh sach canh
            string[] strs = new string[soDinh];
            strs[0] = "0,5,8,-1,6,7";
            strs[1] = "5,0,1,6,-1,-1";
            strs[2] = "8,1,0,4,-1,7";
            strs[3] = "-1,6,4,0,2,3";
            strs[4] = "-1,-1,-1,2,0,5";
            strs[5] = "6,-1,7,3,5,0";
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
        /// <summary>
        /// thuat toan dijkstra
        /// tim duong di ngan nhat
        /// </summary>
        /// <param name="mtTrongSo"></param>
        /// <param name="dinhDau"></param>
        public static int[] Dijkstra(int[][] mtTrongSo, int dinhDau)
        {
            const int vocung = 100;
            int soDinh = mtTrongSo.GetLength(0);
            int dinhXet = -1;
            int temp = -1;

            int[] kc = new int[soDinh];
            int[] dinhDaXet = new int[soDinh];
            int[] dinhTruoc = new int[soDinh];
            //gan gia tri vocung cho canh khong co duong di
            for (int i = 0; i < soDinh; i++)
            {
                for (int j = 0; j < soDinh; j++)
                {
                    if (mtTrongSo[i][j] == -1 && i != j)
                    {
                        mtTrongSo[i][j] = vocung;
                    }
                }
            }
            for (int i = 0; i < dinhDaXet.Length; i++)
            {
                dinhDaXet[i] = 0;
                dinhTruoc[i] = dinhDau;
            }

            //khoang cach tu dinh dau den cac dinh con lai
            for (int i = 0; i < soDinh; i++)
            {
                kc[i] = mtTrongSo[dinhDau][i];
            }

            kc[dinhDau] = 0;
            dinhDaXet[dinhDau] = 1;

            //tim dinh co khoang cach den dinh dau la nho nhat
            int min = vocung;
            for (int i = 0; i < soDinh; i++)
            {
                if (dinhDaXet[i] != 1)
                {
                    if (min > mtTrongSo[dinhDau][i])
                    {
                        min = mtTrongSo[dinhDau][i];
                        dinhXet = i;
                    }
                }
            }
            kc[dinhXet] = min;
            dinhDaXet[dinhXet] = 1;
            dinhTruoc[dinhXet] = dinhDau;

            //Dieu kien de tiep tuc vong lap
            while (TinhTongDaXet(dinhDaXet) < soDinh)
            {
                min = vocung;
                for (int i = 0; i < soDinh; i++)
                {
                    if (dinhDaXet[i] != 1)
                    {
                        //Tinh khoang cach 
                        if (kc[i] > kc[dinhXet] + mtTrongSo[dinhXet][i])
                        {
                            kc[i] = kc[dinhXet] + mtTrongSo[dinhXet][i];
                            dinhTruoc[i] = dinhXet;
                        }
                        //tinh min 
                        if (min > kc[i])
                        {
                            min = kc[i];
                            temp = i;
                        }
                    }
                }
                dinhXet = temp;
                kc[dinhXet] = min;
                dinhDaXet[dinhXet] = 1;
            }

            //in duong di
            for (int i = 0; i < soDinh; i++)
            {
                if (i==dinhDau)
                {
                    continue;
                }
                else
                {
                    PrintLine(dinhTruoc, dinhDau, i);
                    Console.WriteLine();
                }
            }
            return kc;

        }
        /// <summary>
        /// truy vet duong di
        /// </summary>
        /// <param name="dinhTruoc"></param>
        /// <param name="dinhDau"></param>
        /// <param name="dinhCuoi"></param>
        public static void PrintLine(int[] dinhTruoc,int dinhDau,int dinhCuoi)
        {
            Console.Write(dinhCuoi);
            if (dinhCuoi== dinhDau)
            {
                return;
            }
            Console.Write("->");
            PrintLine(dinhTruoc, dinhDau, dinhTruoc[dinhCuoi]);
        }
        /// <summary>
        /// tinh tong dinh da xet
        /// </summary>
        /// <param name="dinhDaXet"></param>
        /// <returns></returns>
        public static int TinhTongDaXet(int[] dinhDaXet)
        {
            int tongDinhDaXet = 0;
            for (int i = 0; i < dinhDaXet.Length; i++)
            {
                if (dinhDaXet[i] == 1)
                {
                    tongDinhDaXet++;
                }
            }
            return tongDinhDaXet;
        }

    }
}
